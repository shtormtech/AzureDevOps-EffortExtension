<template lang="pug">
  #app
    .wrapper
      .header
        Header
      .body
        .work-items
          WorkItems
        .team-activities
          .team
            Team
          .activities
            Activities
</template>

<script>
import Header from './components/Header'
import Activities from './components/Activities'
import Team from './components/Team'
import WorkItems from './components/WorkItems'

export default {
  name: 'App',
  components: { Header, Activities, Team, WorkItems }
}
</script>

<style lang="scss">
#app {
  font-family: "Segoe UI VSS (Regular)","Segoe UI","-apple-system",BlinkMacSystemFont,Roboto,"Helvetica Neue",Helvetica,Ubuntu,Arial,sans-serif,"Apple Color Emoji","Segoe UI Emoji","Segoe UI Symbol";
}
.body{
  display: grid;
  grid-template-columns: 1fr 1fr;
  column-gap: 10px;
  height: 100%;
  padding-top: 20px;
}
</style>
