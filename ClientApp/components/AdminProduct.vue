
<template>
    <!-- Modal -->
    <div class="modal fade" id="newProduct" role="dialog">
        <div class="modal-dialog">

            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">

                    <h4 class="modal-title"> {{ modalTitle }}</h4>
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
                        <label for="PriceCurrent">PriceCurrent</label>
                        <input type="text"
                            id="PriceCurrent"
                            class="form-control"
                            autocomplete="PriceCurrent"
                            v-model="PriceCurrent">
                    </div>
                    <div class="form-group">
                        <label for="PriceRange">PriceRange</label>
                        <input type="text"
                            id="PriceRange"
                            class="form-control"
                            autocomplete="PriceRange"
                            v-model="PriceRange">
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
                        <label for="tags">Select Tags for this Product</label>
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
                            Please provide tags for this product.
                        </div>
                    </div>

                    <div class="form-group">
                        <h4 v-if="hasMessage" v-bind:class="messageStyle">  {{  message }}</h4>
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
import { EventBus } from '../event-bus.js';

export default {
    name: 'AdminProduct',
    mounted() {
        if (!this.productTags.length) {
            this.$store.dispatch('fetchProductTag');
        }
        EventBus.$on('editProduct', ({product, index}) => {
            this.modalTitle = `Update Product: ${product.name}`;
            this.tags = product.tags;
            this.PriceRange = product.priceRange;
            this.PriceCurrent = product.priceCurrent;
            this.marketNames =  product.marketNames;
            this.image_url = product.imageUrl;
            this.productCategoryID = product.productCategoryID;
            this.name = product.name;
            this.validInputs = ['tags','name', 'image'];
            this.productID = product.productID;
            this.prodIndex = index;
            this.buttonText = 'Update';

        });

        EventBus.$on('newProduct', ({productCategoryID}) => {
            this.modalTitle = 'Create a Product';
            this.productCategoryID = productCategoryID;
            this.tags = [];
            this.PriceRange = null;
            this.PriceCurrent = null;
            this.marketNames =  null;
            this.image_url = null;
            this.name = null;
            this.validInputs= [];
            this.productID = null;
            this.buttonText = 'Register';
       });

      },
    computed: {
        ...mapState('productCategory', {
          message: state => state.message,
          hasMessage: state => (state.messageRecipient == 'AdminProducts'),
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
                formData.append('PriceRange', this.PriceRange);
                formData.append('PriceCurrent', this.PriceCurrent);
                
                formData.append('productCategoryID', this.productCategoryID);
                formData.append('MarketNames', this.marketNames.toString().split(','));

                if (this.image) {
                    formData.append('image', this.image, this.image.name);
                }

                this.$store.dispatch('productCategory/addProduct', { formData });
            } else if (this.productID) {
                formData.append('Name', this.name);
                formData.append('Tags', this.tags);
                formData.append('PriceRange', this.PriceRange);
                formData.append('PriceCurrent', this.PriceCurrent);
                
                formData.append('productCategoryID', this.productCategoryID);
                formData.append('MarketNames', this.marketNames.toString().split(','));

                if (this.image) {
                    formData.append('image', this.image, this.image.name);
                }

                this.$store.dispatch('productCategory/editProduct', { 
                       prodCatIndex: this.prodCatIndex, 
                       productID: this.productID,
                        formData
                });
            }
        },
        filesChange(event) {
            this.image  = event.target.files[0];
            this.image_url = URL.createObjectURL(this.image);
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
            productCategoryID: null,
            imageStyle: 'form-control',
            tagsStyle: 'form-control',
            nameStyle: 'form-control',
            messageStyle: 'text-center text-warning',
            buttonText: 'Register',
            image_url: null,
            productID: null,
            productIndex: null,
            PriceRange: null,
            PriceCurrent: null,
            modalTitle: 'Create a Product'
        };
      },
      watch: {
        name(val) {
            this.inValidForm = (!val);
        },
        message(val) {
            if (val && val.toString().includes('successfully')) {
                this.messageStyle = this.messageStyle.toString().replace('text-warning', 'text-success');
            }
            else {
                this.messageStyle += ' text-warning';
            }
        },

    }
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
