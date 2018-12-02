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
      this.$store.dispatch('productCategory/getaddProductCategories', 0);
    }
  }
}
