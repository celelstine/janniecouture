<template>
    <div class="jumbotron jumbotron-fluid mt-md-4 pt-1 text-center">
        <div class="container">
            <h4 v-if="hasMessage" class="text-center text-warning">  {{  message }}</h4>
            <h3>Welcome to Jannie Couture</h3>
            <h4>We are confirming your account.</h4>
            <img src="/images/loader.gif" v-if="!hasMessage"/>
        </div>
    </div>
</template>
<script>
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
            hasMessage: state => state.messageForConfirmPassword,

        }),
    },
}
</script>
<style scoped>
    .jumbotron {
         background: white !important;
    }
    img {
        max-width: 220px !important;
    }
</style>