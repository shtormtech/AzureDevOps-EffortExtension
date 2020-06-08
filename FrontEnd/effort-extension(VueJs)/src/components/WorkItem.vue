<template lang="pug">
  .work-item-wrapper
    .progress-bar(
      :style="{width: `${getDuration()}%`}"
    )
    .work-items
      .work-item-color(
        :style="{background: getColor()}"
      )
      .work-item.work-item-title {{workItem.title}}
      .work-item.work-item-duration {{workItem.duration}}
      .work-item.work-item-pace {{null}}
</template>
<script>
import { mapState } from 'vuex'
export default {
  name: 'WorkItem',
  props: {
    workItem: Object
  },
  computed: {
    ...mapState({
      totalCount: state => state.totalCount
    })
  },
  methods: {
    getColor () {
      switch (this.workItem.wiType) {
        case 'userStory':
          return '#30a6e8'
        case 'Bug':
          return 'red'
        case 'Epic':
          return 'purple'
        case 'Task':
          return 'green'
        default:
          return 'white'
      }
    },
    getDuration () {
      return this.totalCount / 100 * this.workItem.duration
    }
  }
}
</script>
<style lang="scss" scoped>
.work-item-wrapper{
  position: relative;
  margin-bottom: 5px;
  width: 100%;

  &:last-child{
    margin-bottom: 0px;
  }
}
.progress-bar{
  position: absolute;
  top: 0px;
  left: 0px;
  height: 100%;
  background: #2ab3ecee;
  opacity: 0.2;
}
.work-items{
  display: grid;
  grid-template-columns: 5px 1fr 50px 50px;
  column-gap: 10px;
}
.work-item{
  display: flex;
  align-items: center;
  font-weight: 500;
}
.work-item-duration{
  font-weight: 700;
  text-align: right;
  height: 25px;
}
</style>
