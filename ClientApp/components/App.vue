<template>
    <div  id="app" class="container-fluid">
        <Navbar />
        <div class="d-none d-md-block ProductSubMenu mb-1">
            <ProductSubMenu />
        </div>
        <Login />
        <Signup />
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
import Signup from './Signup.vue';
import Login from './Login.vue';

export default {
    name: 'App',
    components : {
        Navbar,
        ProductSubMenu,
        Footer,
        Login,
        Signup,
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
        color: #007bff;
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
            max-width: 15.7666% !important;
        }
    }
    .price {
        font-family: 'Kameron', serif;
    }

    button {
        color: white;
        background : #153466 !important;
    }
    .formHeader {
        color: #153466 !important;
        background: inherit
    }
    .card, .card-footer {
        border-width: 0px;
    }
    .card:hover {
        border-width: 2px;
    }
    .card-footer {
        padding-right: 0px;
        padding-left: 0x;
        background: inherit;
        border-top: 1px solid rgba(0, 0, 0, 0.125);
    }
    .product-name {
        font-size: 14px;
        display: inline-flex;
        padding-left: 2px;
        font-weight: bolder;
        FONT-STYLE: italic;
        text-transform: capitalize;
    }
    .explore-product{
        font-size: smaller;
         padding-right: 2px
    }
    a {
        color: #153466;
    }
    .card-img {
        border-radius: 0;
    }
    .fa-trash {
        color: #808080;
    }
    .hide {
        display: none;
    }
</style>