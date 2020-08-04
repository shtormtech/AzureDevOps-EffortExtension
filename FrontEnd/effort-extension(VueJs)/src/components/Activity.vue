<template lang="pug">
.activity-wrapper
  .progress-bar(
    :style="{width: `${getDuration()}%`}"
  )
  .activities
    .activity-color(
      :style="{background: activity.activityType.color}"
    )
    .activity.activity-title {{`${activity.activityType.name}`}}

    .activity.activity-duration {{activity.duration}}
</template>
<script>
import { mapState } from 'vuex'
export default {
  name: 'Activity',
  props: {
    activity: Object
  },
  computed: {
    ...mapState({
      totalCount: state => state.totalCount
    })
  },
  methods: {
    getDuration () {
      return this.totalCount / 100 * this.activity.duration
    }
  }

}
</script>
<style lang="scss" scoped>
.activity-wrapper{
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
.activities{
  display: grid;
  grid-template-columns: 5px 1fr 50px;
  column-gap: 10px;
}
.activity{
  display: flex;
  align-items: center;
  font-weight: 500;
}
.activity-duration{
  font-weight: 700;
  text-align: right;
  height: 30px;
  justify-self: end;
}
</style>
