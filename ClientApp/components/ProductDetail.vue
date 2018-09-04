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
               v-on:click="addToCart(productID)"
               title="Add to Cart"
               ></i>
        </h4>
        <hr />
        <div class="row">
            <div class="col-md-4 col-sm-12">
                <div v-if="currentImg" class="productImageDiv">
                    <ProductImage1 :imageUrl="currentImg"></ProductImage1>
                </div>
            </div>
            <div class="col-md-8 col-sm-12">
                <div class="container mt-3">
                    <ul class="nav nav-tabs">
                        <li class="nav-item">
                            <a class="nav-link active" data-toggle="tab" href="#Samples">Samples</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" data-toggle="tab" href="#measurement">Measurement</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" data-toggle="tab" href="#primary">Primary</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" data-toggle="tab" href="#demography">Demography</a>
                        </li>
                    </ul>

                    <!-- Tab panes -->
                    <div class="tab-content">
                        <div id="Samples" class="container tab-pane active">
                            <div class="row mt-1">
                                <div class="p-0 card flex-fill mb-2 col-sm-6  col-md-3 mr-md-1"
                                     v-for="n in 12">
                                    <div class="card-header px-md-1 py-md-1">Cool Dress</div>
                                    <div class="card-body">
                                        <img
                                             v-if="product"
                                             v-bind:src="product.imageUrl"
                                             v-on:click="setCurrentImg('images/fashion.jpg')"
                                             alt="Name" />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div id="measurement" class="container tab-pane fade">
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
                        <div id="primary" class="container tab-pane fade row pt-1">
                            <br />
                            <div class="row">
                                <div class="form-group col-md-6">
                                    <label for="usr">Name:</label>
                                    <input type="text" class="form-control" id="usr">
                                </div>
                                <div class="form-group col-md-6">
                                    <label for="image">Image:</label>
                                    <input type="file" id="image" accept="image/*" class="form-control-file border" name="file">
                                </div>
                                <div class="form-group col-md-6">
                                    <label for="priceRange">Price Range:</label>
                                    <input type="text" class="form-control" id="priceRange">
                                </div>
                                <div class="form-group col-md-6">
                                    <label for="tags">Select Tags:</label>
                                    <select class="form-control" id="tags">
                                        <option>1</option>
                                        <option>2</option>
                                        <option>3</option>
                                        <option>4</option>
                                    </select>
                                </div>
                                <div class="form-group col-md-6">
                                    <label for="prodcat">Select Category:</label>
                                    <select class="form-control" id="prodcat">
                                        <option>1</option>
                                        <option>2</option>
                                        <option>3</option>
                                        <option>4</option>
                                    </select>
                                </div>
                                <div class="form-group col-md-6">
                                    <label for="measureCat">Select Measurement Category:</label>
                                    <select class="form-control" id="measureCat">
                                        <option>1</option>
                                        <option>2</option>
                                        <option>3</option>
                                        <option>4</option>
                                    </select>
                                </div>
                                <div class="form-group col-md-12">
                                    <label for="aka">Market Names:</label>
                                    <input type="text" class="form-control" id="aka">
                                </div>
                                <div class="form-group col-md-12">
                                    <button type="button" class="btn float-right">Basic</button>
                                </div>
                            </div>
                        </div>
                        <div id="demography" class="container tab-pane">
                            <br />
                            <span class="badge badge-pill badge-dark demoValue mr-1"
                                  v-for="n in 4">
                                female
                            </span>
                            <hr />
                            <div class="row">
                                <div class="form-group col-md-6">
                                    <label for="demoUnits">Unit:</label>
                                    <select class="form-control" id="demoUnits">
                                        <option>1</option>
                                        <option>2</option>
                                        <option>3</option>
                                        <option>4</option>
                                    </select>
                                </div>
                                <div class="form-group col-md-6">
                                    <label for="demoValue">Value:</label>
                                    <input type="text" class="form-control" id="demoValue">
                                </div>
                            </div>
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
                       v-on:click="addToCart(productID)"></i>
                </div>
            </div>
            </div>
            -->
    </div>
</template>
<script>
import { mapState } from 'vuex'; NoImageFound
import DressImagePlaceholder from './DressImagePlaceholder.vue';
import NoImageFound from './NoImageFound.vue';

const AsyncComponent = () => ({
  // The component to load (should be a Promise)
  component: import('./ProductImage.vue'),
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
            hasMessage: state => state.messageForProduct,
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
    .tab-content {
        font-size: 12px;
    }
    .demoValue {
          font-size: 14px;
    }
    img {
        cursor: pointer;
    }
</style>