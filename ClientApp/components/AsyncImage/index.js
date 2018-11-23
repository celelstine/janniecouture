export default {
  name: 'AsyncImage',
  props: {
      imageUrl: '',
      name: '',
      link: ''
  },
  methods: {
    gotoDetailPage() {
      if (this.link) {
        this.$router.push({ path: this.link });
      }
    }
  },

}
