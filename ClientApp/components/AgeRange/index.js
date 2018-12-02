import { mapGetters, mapActions } from 'vuex';

export default {
    computed: mapGetters(['ageRanges']),
    created () {
      return this.$store.dispatch('fetchAgeRange')
    }
}
