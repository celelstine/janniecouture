import  { mapState } from 'vuex';

export default {
  name: 'ConfirmAccount',
  mounted() {
    // check if user is already logged in
    if(this.userName){
        this.$route.push({ path: '/' });
    } else {
      const userId = this.$route.query.userId || null;

      let userCode = this.$route.query.code || null;
      if ( userId && userCode) {
        const pageUrl = window.location.href;
        const indexOFCode = pageUrl.indexOf('code=');
        // we add 5 to shift the cursor to the begin of the value of the 'code' querystring value
        userCode = pageUrl.substring(indexOFCode+5);
        this.$store.dispatch('auth/confirmAccount', { userId, userCode });
      } else {
        this.$route.push({ path: '/' });
      }
    }
  },
  computed: {
    ...mapState('auth', {
      userName: state => state.userName,
      message: state => state.message,
      hasMessage: state => (state.messageRecipient == 'ConfirmPassword'),
    }),
  },
}
