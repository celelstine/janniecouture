<template>
    <div>
        <ProductCategory />
        <TrendingProduct />
    </div>
</template>
<script>
import ProductCategory from './ProductCategory.vue';
import TrendingProduct from './TrendingProduct.vue'

export default {
    name: 'Home',
    components : {
        ProductCategory,
        TrendingProduct,
    },
}
</script>