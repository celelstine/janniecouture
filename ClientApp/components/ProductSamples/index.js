import { EventBus } from '../../event-bus.js';
export default {
  name: "ProductSamples",
  props: {
      product: null,
  },
  computed: {
  },
  mounted: function() {
    console.log('came here');
  },
  watch: {},
  data() {
    return { 
      isAdmin: true,
    }
  },
  methods: {
    setCurrentImg(imgURl) {
      if(imgURl) {
          // this.currentImg = imgURl;
      }
    },
    newProductSample() {
      if (this.product) {
        EventBus.$emit('newProductSample', { 
            'productID': parseInt(this.product.productID)
          });
      } else {
        this.message = 'I could not find this product category, please pick one from the index page'
      }
    }
  }
}
