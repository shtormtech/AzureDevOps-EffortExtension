<template lang="pug">
  .work-item-wrapper
    .progress-bar(
      :style="{width: `${getDuration()}%`}"
    )
    .work-items
      .work-item-color(
        :style="{background: getColor()}"
      )
      .work-item.work-item-title {{`${workItem.title} (`}}
        a(
          href='#'
        ) {{` ${workItem.id} `}}
        span )
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
      switch (this.workItem.wiType.toLowerCase()) {
        case 'user story':
          return '#30a6e8'
        case 'bug':
          return 'red'
        case 'epic':
          return 'purple'
        case 'task':
          return 'green'
        case 'feature':
          return '#773b93'
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
  height: 30px;

  &:last-child{
    margin-bottom: 0px;
  }
}
.progress-bar{
  position: absolute;
  top: 0px;
  left: 5px;
  height: 100%;
  background: #2ab3ecee;
  opacity: 0.2;
}
.work-items{
  display: grid;
  grid-template-columns: 5px 1fr 50px 50px;
  column-gap: 10px;
  height: 100%;
}
.work-item{
  display: flex;
  align-items: center;
  font-weight: 500;
}
.work-item-duration{
  font-weight: 700;
  text-align: right;
  justify-self: end;
}
</style>
