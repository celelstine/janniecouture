
<template>
    <img v-bind:src="imageUrl"
         alt="Name"
         v-bind:data-zoom-image="imageUrl"
         id="product-main-page" />
</template>
<script>
    import * as ts from '../../wwwroot/lib/jquery.elevatezoom.js';
    export default {
    name: "ProductImage",
    props: {
        imageUrl: '',
    },
    mounted: function() {
        $('#product-main-page').elevateZoom();
      },
  }
</script>
