import { mapGetters, mapActions, mapState } from 'vuex';
import ProductCategory from '../ProductCategory/index.vue.html';
import { EventBus } from '../../event-bus.js';

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
      hasMessage: state => (state.messageRecipient == 'AdminProdCat'),
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
          this.$store.dispatch('productCategory/addProductCategory', { formData });
        } else if (this.productCatID) {
          formData.append('Name', this.name);
          formData.append('Tags', this.tags);
          formData.append('MarketNames', this.marketNames.toString().split(','));
          
          if (this.image) {
            formData.append('image', this.image, this.image.name);
          }
          this.$store.dispatch('productCategory/editProductCategory', { 
            prodCatIndex: this.prodCatIndex, 
            productCatID: this.productCatID,
            formData
          });
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
      message(val) {
        if (val.toString().includes('successfully')) {
            this.messageStyle = this.messageStyle.toString().replace('text-warning', 'text-success');
        }
        else {
            this.messageStyle += ' text-warning';
        }
      }
    }
  }
