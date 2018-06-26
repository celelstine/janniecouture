<template>
    <div class="container">
        <h4 class="WelcomeNote"> Product Catalog</h4>
        <hr class="mt-0"/>
        <div
             class="d-flex row"
         >
            <div
                 class="p-0 flex-fill col-md-3 col-sm-12 mr-md-2 mt-2 card"
                 v-for="productCategory in productCategories"
                 v-bind:key="productCategory.productCategoryID">
                <div class="card-body1">
                    <img  v-bind:src="productCategory.imageUrl" alt="Name" class="card-img"/>
                </div>
                <div class="card-footer py-0 pl-0">
                    <h4 class="product-name pt-0">
                        {{ productCategory.name}}
                     </h4>
                    <router-link
                                 :to="{ name: 'productCategoryDetail',params: { name:  productCategory.name}}"
                                 class="explore-product float-right">
                        <i class="fas fa-eye">Explore</i>
                    </router-link>
                </div>
            </div>
        </div>

        <h4 v-if="message" class="text-warning">  {{  message }}</h4>
    </div>
</template>
<script>
import Product from './Product.vue'
import { mapState } from 'vuex';
export default {
    name: 'ProductCategory',
    components : {
        Product,
    },
    computed: {
        ...mapState('productCategory', {
            productCategories: state => state.productCategories,
            hasMoreproductCategories: state => state.hasMoreproductCategories,
            message: state => state.message,
        }),
    },
    watch: {
        productCategories(val) {
             if(this.hasMoreproductCategories) {
                const catCount = this.productCategories.length;
                this.$store.dispatch('productCategory/get', catCount);
            }
        }
    },
    created() {
        this.$store.dispatch('productCategory/get', 0);
    }
}
</script>
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
    productFooter > a{
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


</style>
<style scoped>
    .card-body1
    {
        height: 400px !important;
    }
    .card-body1 > img {
        width: 100% !important;
        height: 100% !important;
    }
</style>
