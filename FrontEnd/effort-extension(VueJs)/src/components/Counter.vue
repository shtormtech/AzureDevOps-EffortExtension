<template lang="pug">
  .counter(
    :style="{background: color}"
  )
    .counter-item.title {{title}}
    .counter-item.count {{count}}
</template>
<script>
export default {
  name: 'Counter',
  props: {
    title: String,
    count: Number,
    color: String
  }
}
</script>
<style lang="scss" scoped>
.counter{
  width: 150px;
  height: 70px;
  margin: auto 0px;
  margin-right: 5px;

  &:last-child{
    margin-right: 0px;
  }
}
.count{
  font-size: 25px;
}
.counter-item{
  font-weight: 500;
  padding-left: 10px;
}
</style>
