<template>
    <div class="container card text-center px-md-4 col-md-6">
        <div class="card-body py-2">
            <h4 class=formHeader> Register new Product Category</h4>
            <h4 v-if="message"  v-bind:class="messageStyle">  {{  message }}</h4>
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
                            v-bind:value="productTag.productTagID">
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
    </div>
</template>
<script>
import { mapGetters, mapActions, mapState } from 'vuex';

export default {
    name: 'AdminProductCategory',
    mounted() {
        this.$store.dispatch('fetchProductTag');
      },
    computed: {
        ...mapState('productCategory', {
          message: state => state.message,
        }),
        ...mapState({
          productTags: state => state.productTags,
        }),
    },
    methods: {
        handleSubmit(event) {
              event.preventDefault();
              const formData = new FormData();
              // add user input to form data
              formData.append('Name', this.name);
              formData.append('Tags', this.tags);
              formData.append('MarketNames', this.marketNames.toString().split(','));
            formData.append('image', this.image, this.image.name);
            this.$store.dispatch('productCategory/add', { formData });
        },
        filesChange(event) {
            this.image  = event.target.files[0];
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
            buttonText: 'Register'
        };s
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