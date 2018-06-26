<template>
    <div class="container px-1 mt-2">
        <h4 class="WelcomeNote"> Trending Outfits</h4>
        <hr class="mt-0" />
        <div class="d-flex row">
            <div
                 class="p-0 card flex-fill my-2 col-6 col-sm-6  col-md-2 mr-md-2"
                 v-for="n in 12"
            >
                
                <Product
                         name="Flar Dress"
                         imgUrl="images/fashion.jpg" 
                         productUrl="#"
                         price="100000"
                         currency="$"
                         productID=1
                 />
            </div>
        </div>
    </div>
</template>

<script>
import Product from './Product.vue'

export default {
    name: 'TrendingProduct',
    components : {
        Product,
    },
}
</script>
<style>
    @media (max-width: 560px) {
        .card {
            margin-left: 3px;
            max-width: 49%
        }
    }
</style>