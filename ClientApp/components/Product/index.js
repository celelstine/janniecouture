export default {
  name: 'Product',
  props: {
    name: {
      type: String,
      required: true
    },
    imgUrl: {
      type: String,
      required: true
    },
    productUrl: {
      type: String,
      required: true
    },
    price:{
      type: String,
      required: true
    },
    currency:{
      type: String,
      required: true
    },
    productID: {
      type: [ String, Number],
      required: true
    },
  },
  methods: {
    addToCart(productID){
        console.log('productID', productID);
    },
  },
}
