
<template>
    <div>
        <img v-bind:src="imageUrl"
             alt="Dress Image"
             v-bind:data-zoom-image="imageUrl"
             v-on:mousemove="zoomIn"
             v-on:mouseout="zoomOut"
             id="product-main-page" />
        <div id="overlay" v-bind:style="style"  v-on:mousemove="zoomIn" v-on:mouseout="zoomOut">
        </div>

    </div>
</template>
<script>
    import * as ts from '../../wwwroot/lib/jquery.elevatezoom.js';
    export default {
    name: "ProductImage",
    props: {
        imageUrl: '',
    },
    computed: {
      style () {
        return `
            background-image: url(${this.imageUrl});
            display: ${this.overlayDisplay};
            backgroundPosition: ${this.backgroundPosition};
            left: ${this.overlayPositionX};
            height: ${this.overlayHeight}
        `;
      }
    },
    mounted: function() {
        // $('#product-main-page').elevateZoom();
    },
    watch: {
        imageUrl(val) {
            // $('#product-main-page').elevateZoom();
            console.log('---->', val);
        }
    },
    data() {
        return {
           backgroundPosition: "",
           overlayDisplay: "inline-block",
           overLayImage: '',
           overlayPositionX: '',
           overlayHeight: ''
        }
    },
    methods: {
        zoomIn (event) {
            this.overlayDisplay = "inline-block";
            var img = event.target;
            var posX = event.offsetX ? (event.offsetX) : event.pageX - img.offsetLeft;
            var posY = event.offsetY ? (event.offsetY) : event.pageY - img.offsetTop;
            this.backgroundPosition = -posX + "px " + -posY + "px";

            // add 10px to space the imagnified image from the image
            this.overlayPositionX = ( img.width + 15) + "px";

            this.overlayHeight = img.height + "px";
      },
      zoomOut (event) {
        this.overlayDisplay = "none"
      }
    }
  }
</script>
<style scoped>
    #overlay {
      border: 1px solid black;
      width: 100%;
      display: inline-block;
      background-repeat: no-repeat;
      position: absolute;
      z-index: 30000;
      top: 0;
      left: 308px;
    }
</style>