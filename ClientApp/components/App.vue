<template>
    <div  id="app">
        <Navbar />
        <div class="d-none d-md-block ProductSubMenu">
            <ProductSubMenu />
        </div>
        <div class="jumbotron jumbotron-fluid">
            <div class="container">
                <h4 class="WelcomeNote">
                    Any woman can be transformed by a beautiful dress and high heels.
                </h4>
                <h6 class="WelcomeNote">
                    We deliver Ready-made and Customized Facinating dresses at your time
                </h6>
                <h6 class="jannieExperience">
                    So enjoy the <span class="WelcomeNote"> Jannie Experience</span> 
                    <a href="#">
                        <i class="fas fa-hand-point-right">
                            Get Started
                        </i>
                    </a>
                </h6>
            </div>
        </div>
        <p v-if="message" class="bg-danger text-white px-lg-2 px-md-1 px-xs-1"> {{ message }}</p>
        <div class="container body-content">
            <router-view />
        </div>

        <hr />
        <Footer />
    </div>
</template>

<script>
import NProgress from 'nprogress';
import 'nprogress/nprogress.css';
import  { mapState } from 'vuex';
import Navbar from './Navbar.vue';
import ProductSubMenu from './ProductSubMenu.vue';
import Footer from './Footer.vue';

export default {
    name: 'App',
    components : {
        Navbar,
        ProductSubMenu,
        Footer
    },
    computed: {
        ...mapState({
            isLoading: state => state.isLoading,
            message: state => state.message,
        }),
    },

    watch: {
        isLoading(val) {
              if (val) {
               NProgress.start();
              } else {
                NProgress.done();;
              }
        },
    },
}
</script>
<style>
    body {
        padding-top: 0px;
        font-family: 'Vollkorn', serif;
    }
    .row {
        width: 100%;
        margin: auto;
    }
    .container {
        padding: 0px;
    }
    .btn-outline-success {
        background: #153466 !important;
        color: white;
        border-color: #153466 !important;
    }
    .btn-outline-success:focus, .btn-outline-success:active{
        background-color:#153466 !important;
        color: white !important;
        border-color: #153466 !important;
    }

    .ProductSubMenu {
        background:  #153466 !important;
        color: white;
        width: 100%;
    }
    p {
        margin-bottom: 1px
    }
    ol, ul, dl {
        margin-top: 0;
        margin-bottom: 1px;
    }
    .WelcomeNote{
        color: #310bb7;
        text-align: center;
        font-weight: 700;
        text-transform: Uppercase;
    }
    .jannieExperience{
        text-align: center;
        color: #153466;
        font-weight: 700;
    }
    @media (min-width: 576px) {

        .jumbotron {
                padding: 2rem 2rem;
                margin-bottom: 5px;
        }
    }

    @media (min-width: 760px) {

        .col-md-2 {
            max-width: 15.2% !important;
        }
    }
    .price {
        font-family: 'Kameron', serif;
    }

</style>