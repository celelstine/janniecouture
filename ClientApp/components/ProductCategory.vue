<template>
    <div class="container">
        <h4 class="WelcomeNote"> Product Catalog</h4>
        <hr class="mt-0"/>
        <div class="d-flex row  my-2">
            <div class="p-0 card flex-fill col-md-3 col-sm-12 mr-md-2">
                <div class="card-header">Header</div>
                <div class="card-body">
                    <img src="images/fashion.jpg" alt="Name" />
                </div>
                <div class="card-footer">
                    <a class="col-4 mr-auto">View Detail</a>
                </div>
            </div>

            <div
                 class="p-0 card flex-fill my-auto col-2 mr-md-2 d-none d-md-block mb-2"
                 v-for="n in 4">
                <Product name="Flar Dress"
                         imgUrl="images/fashion.jpg"
                         productUrl="#"
                         price="100"
                         currency="$"
                         productID="1" />
            </div>
        </div>
    </div>
</template>
<script>
import Product from './Product.vue'

export default {
    name: 'ProductCategory',
    components : {
        Product,
    },
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
            text-align: center;
        }
        a.productFooter {
            text-decoration: underline !important;
            cursor: pointer;
        }
        i.fas, button {
            cursor: pointer;
        }
        .card-footer > a {
            text-decoration: underline !important;
                cursor: pointer;
        }
        .card-footer {
            padding-right: 2px;
            padding-left: px;
        }
        .btn-sm, .btn-group-sm > .btn {
            padding: 0.05rem 0.15rem;
            font-size: 8px;
            line-height: 1.5;
            border-radius: 0.2rem;
        }
</style>
