import NProgress from 'nprogress';
import 'nprogress/nprogress.css';
import  { mapState } from 'vuex';
import Navbar from '../Navbar/index.vue.html';
import ProductSubMenu from '../ProductSubMenu/index.vue.html';
import Footer from '../Footer/index.vue.html';
import Signup from '../Signup/index.vue.html';
import Login from '../Login/index.vue.html';

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
