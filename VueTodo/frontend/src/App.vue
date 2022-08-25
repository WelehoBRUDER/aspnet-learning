<script setup>
import { RouterView } from "vue-router";
</script>

<template>
  <main class="main">
    <header class="header"></header>
    <RouterView />
  </main>
</template>

<style lang="scss" scoped>
.main {
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: center;
  height: 100vh;
  width: 100vw;
  position: absolute;
  top: 0;
  left: 0;
}

.header {
  position: fixed;
  top: 0;
  left: 0;
  width: 100%;
  height: 10vh;
  background-color: #313131;
}
</style>
