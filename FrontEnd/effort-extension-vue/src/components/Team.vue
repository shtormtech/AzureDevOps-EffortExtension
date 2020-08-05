<template lang="pug">
  .team-wrapper
    .header
      span Team
    .users
      User(
        v-for="user in users"
        :user="user"
        :maxGlobalDuration="maxDuration"
        :key="user.id"
      )
</template>
<script>
import User from './User'
import { mapState, mapActions } from 'vuex'
export default {
  name: 'Team',
  components: {
    User
  },
  computed: {
    ...mapState({
      users: state => state.users
    }),
    maxDuration () {
      let maxDuration = 0
      this.users.forEach(user => {
        let duration = 0
        user.activities.forEach(item => {
          duration += item.duration
        })
        maxDuration = duration > maxDuration ? duration : maxDuration
      })
      return maxDuration
    }
  },
  methods: {
    ...mapActions(['fetchUsers'])
  },
  mounted () {
    this.fetchUsers()
  }
}
</script>
<style scoped>
.header {
  font-weight: 700;
}
.users {
  margin-top: 10px;
}
</style>
