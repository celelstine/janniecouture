import { mapState } from 'vuex'; 

import NoImageFound from '../NoImageFound/index.vue.html';
import ProductSamples from '../ProductSamples/index.vue.html';
import ManageProductSample from '../ManageProductSample/index.vue.html';
import DressImagePlaceholder from '../DressImagePlaceholder/index.vue.html';


const AsyncComponent = () => ({
  // The component to load (should be a Promise)
  component: import('../ProductImage/index.vue.html'),
  // A component to use while the async component is loading
  loading: DressImagePlaceholder,
  // A component to use if the load fails
  error: NoImageFound,
  // Delay before showing the loading component. Default: 200ms.
  delay: 0,
  // The error component will be displayed if a timeout is
  // provided and exceeded. Default: Infinity.)
  timeout: 5000
});

export default {
  name: 'ProductDetail',
  components: {
    'ProductImage1': AsyncComponent,
    'ProductSamples': ProductSamples,
    'ManageProductSample': ManageProductSample,
    'DressImagePlaceholder': DressImagePlaceholder,
  },
  mounted() {
    const name = this.$route.params.name;
    if (name) {
      this.productName = name;
      this.$store.dispatch('product/getProductByName', name);
    }
  },
  computed: {
    ...mapState('product', {
      product: state => state.product,
      productDetails: state => state.productDetails,
      message: state => state.message,
      hasMessage: state => (state.messageRecipient == 'Product'),
      hasMoreproductDetails: state => state.hasMoreproductDetails,
    }),
  },
  data() {
    return {
      productName: '',
      productTags: [],
      currentImg: null
    }
  },
  watch: {
    product(val) {
      if(val) {
        this.productTags = val.tags[0].split(",");
        this.currentImg = val.imageUrl;
        // this.$store.dispatch('product/getProductDetailssByProductName', { name: this.productName, lastIndex: 0});
      }
    },
    productDetails(val) {
      if(this.hasMoreproductDetails) {
        const lastIndex = this.products.length;
        this.$store.dispatch('product/getProductDetailssByProductName', { name: this.productName, lastIndex});
      }
    }
  },
  methods: {
    setCurrentImg(imgURl) {
      if(imgURl) {
        this.currentImg = imgURl;
      }
    }
  }
}
