<template>
  <div id="app">
    <header>Header</header>
    <aside class="sidebar-left">Left Sidebar</aside>
    <article>Article</article>
    <aside class="sidebar-right">Right Sidebar</aside>
    <footer>Footer</footer>
  </div>
</template>

<script>
export default {
  name: "app",
  components: {}
};
</script>

<style>
body {
  margin: 0px;
  padding: 0px;
}
#app {
  display: grid;
  grid-template-columns: 150px auto 150px;
  grid-template-rows: 60px 1fr 100px;
  grid-gap: 1em;
  height: 100vh;
}

header,
aside,
article,
footer {
  background: #eaeaea;
  padding: 1em;
  color: #949494;
}

header,
footer {
  grid-column: 1 / 4;
}
</style>