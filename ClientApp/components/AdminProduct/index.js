import { mapGetters, mapActions, mapState } from 'vuex';
import { EventBus } from '../../event-bus.js';

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
