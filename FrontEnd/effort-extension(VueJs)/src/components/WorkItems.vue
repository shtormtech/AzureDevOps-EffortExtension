<template lang="pug">
  .work-items-wrap
    .work-items-body(
      v-if="workItems"
    )
      .work-items-header
        .work-items-header-item Work Item
        .work-items-header-item Hours
        .work-items-header-item Pace
      .work-items
        WorkItem(
          v-for="item in workItems"
          :key="item.id"
          :workItem="item"
        )
</template>
<script>
import WorkItem from './WorkItem'
import { mapActions, mapState } from 'vuex'
export default {
  name: 'WorkItems',
  components: { WorkItem },
  computed: {
    ...mapState({
      workItems: state => state.workItems
    })
  },
  methods: {
    ...mapActions(['fetchWorkItems'])
  },
  mounted () {
    this.fetchWorkItems()
  }
}
</script>
<style scoped>
.work-items {
  margin-top: 5px;
}
.work-items-body {
  width: 100%;
}
.work-items-header {
  display: grid;
  grid-template-columns:1fr 50px 50px;
  column-gap: 10px;
}
.work-items-header-item {
  list-style-type: none;
  font-weight: 700;
  font-size: 14px;
}
</style>
