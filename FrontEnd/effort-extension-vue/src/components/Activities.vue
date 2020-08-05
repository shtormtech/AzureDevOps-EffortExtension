<template lang="pug">
  .activities-wrap
    .activities-body(
      v-if="true"
    )
      .activities-header
        .activities-header-item Activities
      .activities
        Activity(
          v-for="item in activities"
          :key="item.id"
          :activity="item"
        )
</template>
<script>
import Activity from './Activity'
import { mapActions, mapState } from 'vuex'
export default {
  name: 'Activities',
  components: { Activity },
  computed: {
    ...mapState({
      activities: state => state.activities
    })
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
}
.activities{
  margin-top: 5px;
  border: 0.25px solid transparent;
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
