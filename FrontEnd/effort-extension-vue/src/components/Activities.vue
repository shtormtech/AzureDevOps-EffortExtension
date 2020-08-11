<template lang="pug">
  .activities-wrap
    Spinner.spiner(
        v-if="activities.length == 0"
      )
    .activities-body(
      v-if="true"
    )
      .activities-header
        .activities-header-item Activities
      .activities
        Activity(
          v-for="item in sortActivities"
          :key="item.id"
          :activity="item"
        )
</template>
<script>
import Activity from './Activity'
import Spinner from './Spinner'
import { mapActions, mapState } from 'vuex'
export default {
  name: 'Activities',
  components: { Activity, Spinner },
  computed: {
    ...mapState({
      activities: state => state.activities
    }),
    sortActivities () {
      if (this.activities.length > 0) {
        const activitiesCopy = JSON.parse(JSON.stringify(this.activities))
        activitiesCopy.sort((a, b) => {
          return b.duration - a.duration
        })
        return activitiesCopy
      } else {
        return this.activities
      }
    }
  },
  methods: {
    ...mapActions(['fetchActivities'])
  },
  mounted () {
    this.fetchActivities()
  }
}
</script>
<style scoped>
.activities-wrap {
  margin-top: 20px;
  min-height: 100px;
  position: relative;
}
.activities{
  margin-top: 5px;
  border: 0.25px solid transparent;
}
.spiner {
  position: absolute;
}
.activities-body{
  width: 100%;
}
.activities-header{
  display: grid;
  grid-template-columns: 5px 1fr 50px 50px;
  column-gap: 10px;
}
.activities-header-item{
  list-style-type: none;
  font-weight: 700;
  font-size: 14px;
}
</style>
