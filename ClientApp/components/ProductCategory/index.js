import Product from '../Product/index.vue.html';
import { EventBus } from  '../../event-bus.js'; //'../event-bus.js';
import { mapState } from 'vuex';

import AdminProductCategory from '../AdminProductCategory/index.vue.html';
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
    name: 'ProductCategory',
    components : {
        Product,
        AdminProductCategory,
        AsyncImage
    },
    computed: {
        ...mapState('productCategory', {
            productCategories: state => state.productCategories,
            hasMoreproductCategories: state => state.hasMoreproductCategories,
            message: state => state.message,
            hasMessage: state => (state.messageRecipient == 'ProductCategory'),
        }),
        ...mapState('auth', {
            roles: state => state.roles
        }),
    },
    data() {
        return {
            isAdmin: false,
            messageStyle: 'text-center text-warning',
        }
    },
    watch: {
        productCategories(val) {
             if(this.hasMoreproductCategories) {
                const catCount = this.productCategories.length;
                this.$store.dispatch('productCategory/getaddProductCategories', catCount);
            }
        },
        roles(val) {
            this.isAdmin = (val.indexOf('Admin')  !== -1);
        }
    },
    created() {
        if (!this.productCategories.length) {
            // this.$store.dispatch('productCategory/getaddProductCategories', 0);
        }
    },
    methods: {
        gotoCatDetailPage(categoryname) {
            this.$router.push({ path: `/productCategory/${categoryname}` });
        },
        editProdCat(productCategory, index) {
            EventBus.$emit('editProdCat', { productCategory, index } );
        },
        newProdCat() {
            EventBus.$emit('newProdCat', {});
        },
        deleteProdCat(productCategory, index) {
            var r = confirm(`Please Confirm that you want to Delete Product Category: ${productCategory.name}`);
            if (r == true) {
                this.$store.dispatch(
                    'productCategory/deleteProductCategory',
                    { productCategoryID: productCategory.productCategoryID, index}
                );


            }
        },
        closeNotification() {
            this.messageStyle = this.messageStyle.toString().replace('text-warning', 'hide');
        }
    }
}
