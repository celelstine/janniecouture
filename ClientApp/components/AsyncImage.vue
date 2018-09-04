<template>
        <img v-bind:src="imageUrl"
             alt="Dress image"
             class="card-img"
             v-on:click="gotoDetailPage()" />
</template>
<script>

export default {
    name: 'AsyncImage',
    props: {
        imageUrl: '',
        name: '',
        link: ''
    },
    methods: {
        gotoDetailPage() {
            console.log('--->', this.link);
            if (this.link) {
                 this.$router.push({ path: this.link });
            }
        }
    },

}
</script>
<style>
     .simpleBorder {
        border: #cac7c7 1px solid;
    }
</style>