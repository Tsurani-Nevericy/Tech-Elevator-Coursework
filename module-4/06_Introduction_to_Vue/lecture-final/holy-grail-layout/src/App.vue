<template>
  <div id="app">
    <the-header/>
      <left-sidebar/>
        <main-content/>
      <right-sidebar/>
    <the-footer/>
  </div>
</template>

<script>
import TheHeader from '@/components/TheHeader'
import LeftSidebar from '@/components/LeftSidebar'
import MainContent from '@/components/MainContent'
import RightSidebar from '@/components/RightSidebar'
import TheFooter from '@/components/TheFooter'

export default {
  name: "app",
  components: {
    TheHeader,
    LeftSidebar,
    MainContent,
    RightSidebar,
    TheFooter
  }
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