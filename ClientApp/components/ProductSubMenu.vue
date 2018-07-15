<template>
    <ul 
        class="list-inline d-flex px-lg-3 px-m6-1 px-xl-3"
        v-if="productCategories.length"
        >
        <li
            class="list-inline-item flex-fill"
            v-for="productCategory in productCategories"
            v-bind:key="productCategory.productCategoryID"
            >
            <router-link
                         :to="{ name: 'productCategoryDetail',params: { name:  productCategory.name}}"
                         class="social-icon text-xs-center">
                    {{ productCategory.name}}
            </router-link>
        </li>
    </ul>
</template>
<script>
import { mapState } from 'vuex';
export default {
    name: 'ProductSubMenu',
    computed: {
        ...mapState('productCategory', {
            productCategories: state => state.productCategories,
        }),
    },
    created() {
        if (!this.productCategories.length) {
            this.$store.dispatch('productCategory/get', 0);
        }
    }
}
</script>
<style scoped>

    a {
        color: white !important;
    }
</style>