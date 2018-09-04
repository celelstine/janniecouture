<template>
    <div>
        <h4 class="WelcomeNote">
            {{ categoryName }} Shelve
        </h4>
        <h5  v-if="!products.length" class="text-warning"> We have no product on this Shelve</h5>
        <hr v-else/>
        <AdminProduct></AdminProduct>
        <h5 v-if="hasMessage" class="text-warning"> {{message}}</h5>
        <div class="row">
            <div class="p-0 flex-fill col-md-2 col-sm-12 mr-md-2 mt-2 card productCategory"
                 title="Create Product"
                 v-on:click="newProduct()"
                 v-if="isAdmin"
                 data-toggle="modal"
                 data-target="#newProduct">
                <div class="card-body1 newProductCat">
                    <h4>
                        <i class="fas fa-plus"></i> <br /> <br />
                        new Product
                    </h4>
                </div>
            </div>
            <div
                 class="p-0 flex-fill col-md-2 col-sm-12 mr-md-2 mt-2 card"
                 v-for="product in products"
                 v-bind:key="product.productID">
                    <div
                         class="card-body"
                         v-on:click="gotoProductPage(product.name )"
                         >
                        <AsyncImage :imageUrl="product.imageUrl"
                                    :name="product.name">
                        </AsyncImage>
                        <!--<img v-bind:src="product.imageUrl" alt="Name" />-->
                    </div>
                <div class="card-footer row mx-0 pl-0">
                    <h4 class="product-name pt-0">
                        <span class="cat_name">{{ product.name}}</span>
                        <i class="fas fa-edit"
                           v-if="isAdmin"
                           v-on:click="editProduct(product, index)"
                           data-toggle="modal"
                           data-target="#newProduct">
                        </i>
                        &nbsp;
                        <i class="fas fa-trash"
                           v-if="isAdmin"
                           data-placement="top"
                           data-toggle="popover"
                           title="Risky!!!"
                           data-content="This product would be delete and can only be retrived by the database admin"
                           v-on:click="deleteProduct(product, index)">
                        </i>
                    </h4>
                    <hr />
                    <span class="col-8 ml-1 mr-auto productFooter price">
                        &#8358;{{ Number(product.priceCurrent).toLocaleString('en') }} &nbsp;
                        ({{ product.priceRange }})
                    </span>
                    <i class="fas fa-cart-plus col-3 mr-0"
                       title="Add to Cart"
                       v-on:click="addToCart(prodcutID)">
                    </i>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
import Product from './Product.vue'
import AdminProduct from './AdminProduct.vue';
import { mapState } from 'vuex';
import { EventBus } from '../event-bus.js';

import DressImagePlaceholder from './DressImagePlaceholder.vue';
import NoImageFound from './NoImageFound.vue';

const AsyncImage = () => ({
  // The component to load (should be a Promise)
  component: import('./AsyncImage.vue'),
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
            this.$store.dispatch('productCategory/getProductsByCatName', { name, lastIndex:0 });
            this.$store.dispatch('productCategory/getCatByName', { name });
        }
    },
    computed: {
        ...mapState('productCategory', {
            products: state => state.products,
            message: state => state.message,
            hasMessage: state => state.messageForProducts,
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
                this.$store.dispatch('productCategory/getProductsByCatName', { name: this.categoryName, lastIndex});
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
                console.log("You pressed OK!", product);
                this.$store.dispatch(
                    'product/deleteProduct',
                    { productID: product.productID, index}
                );
            }
        },
    }
}
</script>

<style scoped>
    .card-body {
        cursor: pointer;
    }
</style>
