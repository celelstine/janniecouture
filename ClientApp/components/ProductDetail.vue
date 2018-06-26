<template>
    <div>
        <h4 class="WelcomeNote">
            {{ productName }} Outfit
            <span
                  class="badge badge-pill badge-dark"
                  v-for="tag in productTags">
                {{ tag }}
            </span>

            <i
               class="fas fa-cart-plus mr-1"
               v-on:click="addToCart(prodcutID)"
               title="Add to Cart"
               ></i>
        </h4>
        <hr />
        <div class="row">
            <div class="col-4">
                <div v-if="product" class="productImageDiv">
                    <ProductImage :imageUrl="product.imageUrl"></ProductImage>
                </div>

                <h6 class="WelcomeNote mt-2"> Enter your measurement</h6>
                <table class="table">
                    <thead>
                        <th>
                            Body Part
                        </th>
                        <th>
                            measurement
                        </th>
                    </thead>
                    <tbody>
                        <tr class="my-0" v-for="n in 8">
                            <th class="my-0  py-1"> Waist</th>
                            <td class="my-0 py-1"><input type="number" /></td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <button class="btn-small">
                                    Submit
                                </button>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
            <div class="col-8">
                <div class="row mt-0">
                    <div class="p-0 card flex-fill mb-2 col-sm-6  col-md-3 mr-md-2"
                         v-for="n in 4">
                        <div class="card-header px-md-1 py-md-1">Cool Dress</div>
                        <div class="card-body">
                            <img
                                 v-if="product" 
                                 v-bind:src="product.imageUrl" alt="Name" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!--
        <h5 v-if="hasMessage" class="text-warning"> {{message}}</h5>
        <div class="row">
            <div class="p-0 flex-fill col-md-3 col-sm-12 mr-md-2 mt-2 card"
                 v-for="product in products"
                 v-bind:key="product.productID">
                <div class="card-header">{{ product.name}}</div>
                <div class="card-body">
                    <img v-bind:src="product.imageUrl" alt="Name" />
                </div>
                <div class="card-footer row mx-0 pl-0">
                    <router-link :to="{ name: 'product',params: { name:  product.name}}"
                                 class="productFooter col-3 mr-auto ml-1">
                        <i class="fas fa-bars"></i>
                    </router-link>
                    <span class="col-5 mr-auto productFooter price">
                        &#8358;{{Number(product.priceCurrent).toLocaleString('en')}} &nbsp;
                        ({{product.priceRange}})
                    </span>
                    <i class="fas fa-cart-plus col-3 mr-0"
                       title="Add to Cart"
                       v-on:click="addToCart(prodcutID)"></i>
                </div>
            </div>
            </div>
            -->
    </div>
</template>
<script>
import { mapState } from 'vuex';
import ProductImage from './ProductImage.vue';
export default {
    name: 'ProductDetail',
    components: {
        ProductImage
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
            hasMessage: state => state.messageForProduct,
            hasMoreproductDetails: state => state.hasMoreproductDetails,
        }),
    },
    data() {
        return {
            productName: '',
            productTags: []
        }
    },
    watch: {
        product(val) {
            if(val) {
                this.productTags = val.tags[0].split(",");

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
}
</script>
<style>
    .badge {
        font-size: 5%;
    }
    @media (min-width: 760px) {

        .col-md-3 {
            max-width: 23.8966% !important;
        }
    }
    table {
        font-size: 10px
    }
    #product-main-page {
        display: block;
    }

</style>