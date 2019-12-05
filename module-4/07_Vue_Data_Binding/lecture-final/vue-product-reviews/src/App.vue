<template>
  <div id="app">
    <product-review/>
  </div>
</template>

<script>
import ProductReview from '@/components/ProductReview';

export default {
  name: 'app',
  components: {
    ProductReview
  }
}
</script>

<style>
#app {
  margin-bottom: 50px;
}
</style>
