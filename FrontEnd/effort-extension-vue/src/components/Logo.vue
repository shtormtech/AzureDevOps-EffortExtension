<template lang="pug">
  .logo
    .logo-text Effort-extension
</template>
<script>
export default {
  name: 'Logo'
}
</script>
<style lang="scss" scoped>
.logo {
  text-shadow: 1px 1px 2px black, 0 0 1em red; /* Параметры тени */
  color: white; /* Белый цвет текста */
  font-size: 2em; /* Размер надписи */
}
.logo {
  height: 100vh;
  width: 100wh;
  display: flex;
  align-items: center;
  justify-content: center;
}
</style>
