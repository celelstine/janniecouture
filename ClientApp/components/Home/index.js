import { mapState } from 'vuex';
import ProductCategory from '../ProductCategory/index.vue.html';
import TrendingProduct from '../TrendingProduct/index.vue.html';

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
