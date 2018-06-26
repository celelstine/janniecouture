<template>
    <div>
        <div class="jumbotron jumbotron-fluid">
            <div class="container">
                <h4 class="WelcomeNote">
                    Any woman can be transformed by a beautiful dress and high heels.
                </h4>
                <h6 class="WelcomeNote">
                    We deliver Ready-made and Customized Facinating dresses at your time
                </h6>
                <h6 class="jannieExperience" v-if="userName">
                    For Loggin user {{ userName }}
                </h6>
                <h6 class="jannieExperience"  v-else>
                    So enjoy the <span class="WelcomeNote"> Jannie Experience</span>
                    <i class="fas fa-hand-point-right">
                    </i>
                    <button type="button" class="btn btn-primary py-0" data-toggle="modal" data-target="#signupModal">
                        Get Started
                    </button>
                    <button type="button" class="btn btn-primary py-0" data-toggle="modal" data-target="#loginModal">
                        Login
                    </button>
                </h6>
            </div>
        </div>
        <ProductCategory />
        <TrendingProduct />
    </div>
</template>
<script>
import { mapState } from 'vuex';
import ProductCategory from './ProductCategory.vue';
import TrendingProduct from './TrendingProduct.vue'

export default {
    name: 'Home',
    components : {
        ProductCategory,
        TrendingProduct,
    },
    computed: {
        ...mapState('auth', {
            userName: state => state.userName
        }),
    },
}
</script>
<style>
    .loginbtn {
        
    }
</style>