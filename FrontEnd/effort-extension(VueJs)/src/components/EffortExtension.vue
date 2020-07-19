<template lang="pug">
.wrapper
  .header
    Header
  .body
    AddTimeModal(
      v-if="isShowAddTimeModal"
      @close="showAddTimeModal(false)"
    )
    .work-items
      WorkItems
    .team-activities
      .team
        Team
      .activities
        Activities
</template>
<script>
import { mapState, mapActions } from 'vuex'
import Header from './Header'
import Activities from './Activities'
import Team from './Team'
import WorkItems from './WorkItems'
import AddTimeModal from './AddTimeModal'
export default {
  name: 'EffortExtension',
  components: { Header, Activities, Team, WorkItems, AddTimeModal },
  computed: {
    ...mapState({
      isShowAddTimeModal: state => state.isShowAddTimeModal
    })
  },
  methods: {
    ...mapActions([
      'showAddTimeModal',
      'setRouteParams'
    ])
  },
  beforeMount () {
    this.setRouteParams({ workItemId: Number(this.$route.params.workItemId), userId: this.$route.query.userId })
  }
}
</script>
<style scoped>
.body {
  display: grid;
  grid-template-columns: 1fr 1fr;
  column-gap: 10px;
  height: 100%;
  padding-top: 20px;
}
</style>
