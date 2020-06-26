<template lang="pug">
  .header-wrap
    .counters
      Counter(
        title = "Total"
        count = "543:49"
        color = "#d8ecf9"
      )
      Counter(
        title = "Pace"
        count = "9.3"
        color = "#eeeeee"
      )
    .add-time(
      @click="showAddTimeModal(true)"
    )
      .add-time-item.title Add Time
      .add-time-item.plus +
</template>
<script>
import { mapActions } from 'vuex'
import Counter from './Counter'
export default {
  name: 'Header',
  components: { Counter },
  methods: {
    ...mapActions(['showAddTimeModal'])
  }
}
</script>
<style lang="scss" scoped>
.header-wrap{
  display: flex;
}
.counters{
  display: flex;
}
.add-time{
  width: 75px;
  height: 75px;
  margin: 2px;
  font-size: 13px;
  color: #007bd0;
  font-weight: 600;
  background: lightgray;
  border: 1px solid transparent;
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: center;
  cursor: pointer;

  &:hover{
    font-size: 14px;
    border: 1px solid gray;
  }
}
.add-time-item{
  text-align: center;
}
.plus{
  font-size: 35px;
}
</style>
