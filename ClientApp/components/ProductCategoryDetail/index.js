import Product from '../Product/index.vue.html'
import AdminProduct from '../AdminProduct/index.vue.html';
import { mapState } from 'vuex';
import { EventBus } from '../../event-bus.js';

import DressImagePlaceholder from '../DressImagePlaceholder/index.vue.html';
import NoImageFound from '../NoImageFound/index.vue.html';

const AsyncImage = () => ({
  // The component to load (should be a Promise)
  component: import('../AsyncImage/index.vue.html'),
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
  name: 'ProductCategoryDetail',
  components : {
    AdminProduct,
    AsyncImage
  },
  mounted() {
    const name = this.$route.params.name;
    if (name) {
        this.categoryName = name;
        this.$store.dispatch('productCategory/getProductsByproductCategoryName', { name, lastIndex:0 });
        this.$store.dispatch('productCategory/getproductCategoryByName', { name });
    }
  },
  computed: {
    ...mapState('productCategory', {
      products: state => state.products,
      message: state => state.message,
      hasMessage: state => (state.messageRecipient == 'Products'),
      hasMoreproducts: state => state.hasMoreproducts,
      productCategory: state => state.productCategory,
    }),
    ...mapState('auth', {
      roles: state => state.roles
    }),
  },
  data() {
    return {
      categoryName: '',
      isAdmin: true,
      messageStyle: 'text-center text-warning',
    }
  },
  watch: {
    products(val) {
      if(this.hasMoreproducts) {
        const lastIndex = this.products.length;
        this.$store.dispatch('productCategory/getProductsByproductCategoryName', { name: this.categoryName, lastIndex});
      }
    },
    roles(val) {
      this.isAdmin = (val.indexOf('Admin')  !== -1);
    }
  },
  directives: {
    arrayString: {
      bind: function (el, binding, vnode) {
        el.innerHTML = binding.value.join(" | ");
      }
    }
  },
  methods: {
    gotoProductPage(name) {
      this.$router.push({ path: `/product/${name}` });
    },
    editProduct(product, index) {
      EventBus.$emit('editProduct', { product, index } );
    },
    newProduct() {
      if (this.productCategory) {
        EventBus.$emit('newProduct', { 
          'productCategoryID': parseInt(this.productCategory.productCategoryID)
        });
      } else {
        this.message = 'I could not find this product category, please pick one from the index page'
      }
    },
    deleteProduct(product, index) {
      var r = confirm(`Please Confirm that you want to Delete Product: ${product.name}`);
      if (r == true) {
        this.$store.dispatch(
          'productCategory/deleteProduct',
          { productID: product.productID, index}
        );
      }
    },
  }
}
