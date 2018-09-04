<template>
    <div class="container">
        <h4 class="WelcomeNote"> Product Catalog</h4>
        <hr class="mt-0"/>
        <AdminProductCategory></AdminProductCategory>

        <h4 v-if="hasMessage && message" class="text-warning ">
            {{  message }} 
            <button type="button" onclick="">&times;</button>
        </h4>
        <!--<h4 v-bind:class="messageStyle" >
            mkekk
            <button type="button" v-on:click="closeNotification()">&times;</button>
        </h4>-->
        <div
             class="d-flex row mt-0"
         >
            <div
                 class="p-0 flex-fill col-md-2 col-sm-12 mr-md-2 mt-2 card productCategory"
                 title="Create Product Category"
                 v-on:click="newProdCat()"
                 v-if="isAdmin"
                 data-toggle="modal"
                 data-target="#newProdCat"
             >
                <div class="card-body1 newProductCat">
                    <h4>
                        <i class="fas fa-plus"></i> <br /> <br />
                        new Product Category
                    </h4>
                </div>
            </div>
            <div
                 class="p-0 flex-fill col-md-2 col-sm-12 mr-md-2 mt-2 card productCategory"
                 v-for="(productCategory, index) in productCategories"
                 v-bind:key="productCategory.productCategoryID"
                 >
                <div class="card-body1">
                    <AsyncImage
                                :imageUrl="productCategory.imageUrl"
                                :name="productCategory.name"
                                :link="'/productCategory/' + productCategory.name"
                                >

                    </AsyncImage>
                    <!--<img
                         
                         v-bind:src="productCategory.imageUrl"
                         alt="Name"
                         title="Explore"
                         class="card-img"
                         v-on:click="gotoCatDetailPage(productCategory.name)"/>-->
                </div>
                <div class="card-footer py-1 pl-1">
                    <h4 class="product-name pt-0">
                        <span class="cat_name">{{ productCategory.name}}</span>

                        <i
                           class="fas fa-edit"
                           v-if="isAdmin"
                           v-on:click="editProdCat(productCategory, index)"
                           data-toggle="modal"
                           data-target="#newProdCat">
                        </i>
                        &nbsp;
                        <i 
                           class="fas fa-trash"
                           v-if="isAdmin"
                           data-toggle="tooltip"
                           data-placement="top"
                           title="Risky!!!"
                           v-on:click="deleteProdCat(productCategory, index)">
                        </i>
                    </h4>

                    <hr />
                    <h6 class="aka">
                        AKA &rArr;
                        <span
                            v-for="MarketName in productCategory.marketNames"
                            v-bind:key="MarketName"
                            >
                            {{ MarketName }}
                        </span>
                    </h6>
                    <span
                          class="badge badge-pill badge-dark"
                          v-for="tag in productCategory.tags"
                          v-bind:key="tag"
                          >
                        {{ tag }}
                    </span>

                </div>
            </div>
        </div>

    </div>
</template>
<script>
import Product from './Product.vue';
import { EventBus } from '../event-bus.js';
import { mapState } from 'vuex';

import AdminProductCategory from './AdminProductCategory.vue';
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
            hasMessage: state => state.messageForProductCategory,
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
                this.$store.dispatch('productCategory/get', catCount);
            }
        },
        roles(val) {
            this.isAdmin = (val.indexOf('Admin')  !== -1);
        }
    },
    created() {
        if (!this.productCategories.length) {
            // this.$store.dispatch('productCategory/get', 0);
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
                console.log("You pressed OK!", productCategory);
                this.$store.dispatch(
                    'productCategory/deleteProdCat',
                    { productCategoryID: productCategory.productCategoryID, index}
                );


            }
        },
        closeNotification() {
            this.messageStyle = this.messageStyle.toString().replace('text-warning', 'hide');
        }
    }
}
</script>
<style scoped>
    img {
        height: 100%;
    }
</style>
<style>
    img {
        width: 100%;
    }
    .card-body {
        padding: 0;
    }
    .productFooter {
        font-size: 10px;
        padding: 0px;
    }
    .productFooter > a{
        text-decoration: none !important;
        cursor: pointer;
    }
    i.fas, button {
        cursor: pointer;
    }
    .card-footer > a {
        text-decoration: none !important;
        cursor: pointer;
    }

    .cat_name {
        width: 90%;
        overflow: hidden;
        text-overflow: ellipsis;
    }

    .btn-sm, .btn-group-sm > .btn {
        padding: 0.05rem 0.15rem;
        font-size: 8px;
        line-height: 1.5;
        border-radius: 0.2rem;
    }
    .card-header {
        text-transform: capitalize;
        color: #153466;
    }
    @media (max-width: 560px) {
        .card {
            margin-left: 3px;
            max-width: 98% !important;
        }
    }
    @media (min-width: 768px) {
        .col-md-3 {
            -ms-flex: 0 0 25%;
            flex: 0 0 25%;
            max-width: 24.29%;
        }

    }
    .newProductCat  {
        background: aliceblue;
        text-align: center;
        padding-top: 55%;
        min-height: 100%;
    }

    .product-name {
        width: 100%;
    }


</style>
<style scoped>
    .aka {
        font-size: 10px;
        margin-bottom: 0;
    }
    .card-body1
    {
        height: 300px !important;
    }
    .card-body1 > img {
        width: 100% !important;
    }
    .productCategory {
        cursor: pointer;
    }

    hr {
        margin: 0;
    }
</style>
