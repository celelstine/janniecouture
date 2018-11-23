import { mapState } from 'vuex';
export default {
  name: 'Navbar',
  computed: {
    ...mapState('auth', {
        userName: state => state.userName
    }),
  },
}
