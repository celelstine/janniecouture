<template>
    <div>
        <h4 class="WelcomeNote">
            {{ categoryName }} Shelve
        </h4>
        <h5  v-if="!products.length" class="text-warning"> We have no product on this Shelve</h5>
        <hr v-else/>
        <h5 v-if="hasMessage" class="text-warning"> {{message}}</h5>
        <div class="row">
            <div
                 class="p-0 flex-fill col-md-3 col-sm-12 mr-md-2 mt-2 card"
                 v-for="product in products"
                 v-bind:key="product.productID">
                    <div class="card-header">{{ product.name }}</div>
                    <div class="card-body">
                        <img v-bind:src="product.imageUrl" alt="Name" />
                    </div>
                <div class="card-footer row mx-0 pl-0">
                    <router-link 
                                 :to="{ name: 'product',params: { name:  product.name}}"
                                 class="productFooter col-3 mr-auto ml-1">
                        <i class="fas fa-eye"></i>
                    </router-link>
                        <span class="col-5 mr-auto productFooter price">
                            &#8358;{{ Number(product.priceCurrent).toLocaleString('en') }} &nbsp;
                            ({{ product.priceRange }})
                        </span>
                    <i
                       class="fas fa-cart-plus col-3 mr-0"
                       title="Add to Cart"
                       v-on:click="addToCart(prodcutID)"></i>
                    </div>
            </div>
        </div>
    </div>
</template>
<script>
import Product from './Product.vue'
import { mapState } from 'vuex';
export default {
    name: 'ProductCategoryDetail',
    mounted() {
        const name = this.$route.params.name;
        if (name) {
            this.categoryName = name;
            this.$store.dispatch('productCategory/getProductsByCatName', { name, lastIndex:0 });
        }
    },
    computed: {
        ...mapState('productCategory', {
            products: state => state.products,
            message: state => state.message,
            hasMessage: state => state.messageForProducts,
            hasMoreproducts: state => state.hasMoreproducts,
        }),
    },
    data() {
        return {
            categoryName: '',
        }
    },
    watch: {
        products(val) {
             if(this.hasMoreproducts) {
                const lastIndex = this.products.length;
                this.$store.dispatch('productCategory/getProductsByCatName', { name: this.categoryName, lastIndex});
            }
        }
    },
    directives: {
      arrayString: {
        bind: function (el, binding, vnode) {
          el.innerHTML = binding.value.join(" | ");
        }
      }
    },
}
</script>