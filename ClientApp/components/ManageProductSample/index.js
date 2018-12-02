import { mapGetters, mapActions, mapState } from 'vuex';
import { EventBus } from '../../event-bus.js';

export default {
  name: 'ManageProductSample',
  mounted() {
    if (!this.productTags.length) {
      this.$store.dispatch('fetchProductTag');
    }
    EventBus.$on('editProductSample', ({ProductDetail, index}) => {
      this.modalTitle = `Update Product Sample: ${ProductDetail.name}`;
      this.tags = ProductDetail.tags;
      this.PriceRange = ProductDetail.priceRange;
      this.PriceCurrent = ProductDetail.priceCurrent;
      this.marketNames =  ProductDetail.marketNames;
      this.image_url = ProductDetail.imageUrl;
      this.ProductDetailID = ProductDetail.ProductDetailID;
      this.name = ProductDetail.name;
      this.validInputs = ['tags','name', 'image'];
      this.ProductID = ProductDetail.ProductID;
      this.prodIndex = index;
      this.buttonText = 'Update';
    });

    EventBus.$on('newProductSample', ({ProductID}) => {
      this.modalTitle = 'Create a Product Sample';
      this.ProductID = ProductID;
      this.tags = [];
      this.PriceRange = null;
      this.PriceCurrent = null;
      this.marketNames =  null;
      this.image_url = null;
      this.name = null;
      this.validInputs= [];
      this.ProductDetailID = null;
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
          
          formData.append('ProductDetailID', this.ProductDetailID);
          formData.append('MarketNames', this.marketNames.toString().split(','));

          if (this.image) {
            formData.append('image', this.image, this.image.name);
          }

          this.$store.dispatch('productCategory/addProduct', { formData });
        } else if (this.ProductDetailID) {
          formData.append('Name', this.name);
          formData.append('Tags', this.tags);
          formData.append('PriceRange', this.PriceRange);
          formData.append('PriceCurrent', this.PriceCurrent);
          
          formData.append('ProductDetailID', this.ProductDetailID);
          formData.append('MarketNames', this.marketNames.toString().split(','));

          if (this.image) {
            formData.append('image', this.image, this.image.name);
          }

          this.$store.dispatch('productCategory/editProduct', { 
                prodCatIndex: this.prodCatIndex, 
                ProductDetailID: this.ProductDetailID,
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
        ProductDetail: null,
        imageStyle: 'form-control',
        tagsStyle: 'form-control',
        nameStyle: 'form-control',
        messageStyle: 'text-center text-warning',
        buttonText: 'Register',
        image_url: null,
        ProductID: null,
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
