<template lang="pug">
  .team-wrapper
    Spinner.spiner(
        v-if="users.length == 0"
      )
    .header
      span Team
    .users
      User(
        v-for="user in sortUsers"
        :user="user"
        :maxGlobalDuration="maxDuration"
        :key="user.id"
      )
</template>
<script>
import User from './User'
import Spinner from './Spinner'
import { mapState, mapActions } from 'vuex'
export default {
  name: 'Team',
  components: {
    User,
    Spinner
  },
  computed: {
    ...mapState({
      users: state => state.users
    }),
    sortUsers () {
      if (this.users.length > 0) {
        const usersCopy = JSON.parse(JSON.stringify(this.users))
        usersCopy.sort((a, b) => {
          let durationA = 0
          let durationB = 0
          a.activities.forEach(obj => {
            durationA += obj.duration
          })
          b.activities.forEach(obj => {
            durationB += obj.duration
          })
          return durationB - durationA
        })
        return usersCopy
      } else {
        return this.users
      }
    },
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
.team-wrapper {
  position: relative;
  min-height: 100px;
}
.spiner {
  position: absolute;
}
.header {
  font-weight: 700;
}
.users {
  margin-top: 10px;
}
</style>
