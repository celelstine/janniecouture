<template>
    <!-- Modal -->
    <div class="modal fade" id="newProdCat" role="dialog">
        <div class="modal-dialog">

            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">

                    <h4 class="modal-title">Register new Product Category</h4>
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                </div>
                <div class="modal-body">

                    <h4 v-if="hasMessage" v-bind:class="messageStyle">  {{  message }}</h4>
                    <div class="form-group">
                        <label for="name">Name:</label>
                        <input type="text"
                               v-bind:class="nameStyle"
                               id="name"
                               autocomplete="name"
                               v-model="name">
                        <div class="invalid-feedback">
                            Please provide a valid email.
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="marketNames">MarketNames (Seperate name with a comma ',' )</label>
                        <input type="text"
                               id="marketNames"
                               class="form-control"
                               autocomplete="marketNames"
                               v-model="marketNames">
                       
                    </div>
                    <div class="form-group">
                        <label for="image">Upload an Image</label>
                        <input type="file"
                               v-bind:class="imageStyle"
                               id="image"
                               accept="image/*"
                               v-on:change="filesChange"
                               autocomplete="image">
                        <img v-if="image_url"
                             v-bind:src="image_url"
                             style="width: 100%; height: 220px" />
                        <div class="invalid-feedback">
                            Please provide an Image.
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="tags">Select Tags for this Product Category</label>
                        <select class="w3-input w3-margin-bottom"
                                multiple
                                v-bind:class="tagsStyle"
                                id="tags"
                                autocomplete="tags"
                                v-model="tags">
                            <option v-for="productTag in productTags"
                                    v-bind:key="productTag.productTagID"
                                    v-bind:value="productTag.name">
                                {{ productTag.name }}
                            </option>
                        </select>
                        <div class="invalid-feedback">
                            Please provide tags for this product Category.
                        </div>
                    </div>
                    <div class="form-group">
                        <button type="button"
                                class="btn btn-primary form-control"
                                v-bind:disabled="inValidForm"
                                v-on:click="handleSubmit">
                            {{ buttonText }}
                        </button>
                    </div>
                </div>

                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                </div>
            </div>

        </div>
    </div>
</template>

<script>
import { mapGetters, mapActions, mapState } from 'vuex';
import ProductCategory from './ProductCategory.vue';
import { EventBus } from '../event-bus.js';

export default {
    name: 'AdminProductCategory',
     components : {
        ProductCategory,
    },
    mounted() {
        this.$store.dispatch('fetchProductTag');
          EventBus.$on('editProdCat', ({productCategory, index}) => {
            this.tags = productCategory.tags;
            this.marketNames =  productCategory.marketNames;
            this.image_url = productCategory.imageUrl;
            this.name = productCategory.name;
            this.validInputs = ['tags','name', 'image'];
            this.productCatID = productCategory.productCategoryID;
            this.prodCatIndex = index;
            this.buttonText = 'Update';

        });

        EventBus.$on('newProdCat', state => {
            this.tags = [];
            this.marketNames =  null;
            this.image_url = null;
            this.name = null;
            this.validInputs= [];
            this.productCatID = null;
            this.buttonText = 'Register';
       });

      },
    computed: {
        ...mapState('productCategory', {
          message: state => state.message,
          hasMessage: state => state.messageForAdminProdCat,
        }),
        ...mapState({
          productTags: state => state.productTags,
        }),
    },
    methods: {
        handleSubmit(event) {
            event.preventDefault();
              const formData = new FormData();
                if (this.buttonText === 'Register') {
                  formData.append('Name', this.name);
                  formData.append('Tags', this.tags);
                  formData.append('MarketNames', this.marketNames.toString().split(','));
                  formData.append('image', this.image, this.image.name);
                  this.$store.dispatch('productCategory/add', { formData });
                } else if (this.productCatID) {
                  formData.append('Name', this.name);
                  formData.append('Tags', this.tags);
                  formData.append('MarketNames', this.marketNames.toString().split(','));
                  if (this.image) {
                    formData.append('image', this.image, this.image.name);
                  }
                   this.$store.dispatch('productCategory/edit', { prodCatIndex: this.prodCatIndex, productCatID: this.productCatID, formData });

                }
        },
        filesChange(event) {
            this.image  = event.target.files[0];
            this.image_url = URL.createObjectURL(this.image);
        },
        checkForm(field, operation) {
            let validInputs = this.validInputs;
            const fieldIndex = validInputs.indexOf(field);
            const fieldCSSClass = `${field}Style`;

            if (operation === 'add') {
                this[fieldCSSClass] = this[fieldCSSClass].toString().replace('is-invalid', '');
                if (fieldIndex === -1) {
                  validInputs.push(field);
                }
            } else if (operation === 'remove') {
                if (fieldIndex !== -1) {
                    this[fieldCSSClass] += ' is-invalid';
                  validInputs = validInputs
                    .filter((item, index) => index !== fieldIndex);
                }
              }

              this.validInputs = validInputs;

              // disable the submit button when every field are not valid
              if (validInputs.length === 3) {
                this.inValidForm = false;
              } else {
                this.inValidForm = true;
              }
        },
    },
    data() {
        return {
            image: null,
            tags: [],
            name: null,
            inValidForm: true,
            marketNames: '',
            validInputs: [],
            imageStyle: 'form-control',
            tagsStyle: 'form-control',
            nameStyle: 'form-control',
            messageStyle: 'text-center text-warning',
            buttonText: 'Register',
            image_url: null,
            productCatID: null,
            prodCatIndex: null
        };
      },
      watch: {
        image(val) {
          if (!val) {
            this.checkForm('image', 'remove');
          } else {
            this.checkForm('image', 'add');
          }
        },
        tags(val) {
          if (!val) {
            this.checkForm('tags', 'remove');
          } else {
            this.checkForm('tags', 'add');
          }
        },
        name(val) {
          if (!val) {
                this.checkForm('name', 'remove');
              } else {
                this.checkForm('name', 'add');
              }
            },
        },
        message(val) {
            if (val.toString().includes('successfully')) {
                this.messageStyle = this.messageStyle.toString().replace('text-warning', 'text-success');
            }
            else {
                this.messageStyle += ' text-warning';
            }
       },

    }
</script>
<style>
    label {
        float: left;
    }

</style>
<style scoped>
    img {
        height: 100% !important;
    }
</style>