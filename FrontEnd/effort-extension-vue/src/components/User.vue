<template lang="pug">
.user-wrapper
  .avatar
    img.avatar-img(
      :src="user.imageUrl"
    )
  .body
    .user-name {{ user.displayName }}
    .duration {{ duration }}
    .activities-wrapeer(
      :style="{width: `${maxDuration}%`}"
    )
    .activities(
      :style="{width: `100%`}"
    )
      .activity-item(
        v-for="item in user.activities"
        :style="{width: `${getDuration(item)}%`, background: item.activityType.color}"
      )
</template>
<script>
export default {
  name: 'User',
  props: {
    user: Object,
    maxGlobalDuration: Number
  },
  computed: {
    duration () {
      let duration = 0
      this.user.activities.forEach(obj => {
        duration += obj.duration
      })
      return duration
    },
    maxDuration () {
      return this.duration * 100 / this.maxGlobalDuration
    }
  },
  methods: {
    getDuration (item) {
      return item.duration * 100 / this.maxGlobalDuration
    }
  }
}
</script>
<style lang="scss" scoped>
.user-wrapper {
  display: flex;
  height: 30px;
  width: 100%;
}
.avatar {
  height: 30px;
}

.body {
  position: relative;
  flex: 1;
  display: grid;
  grid-template-columns: 1fr 50px;
  column-gap: 10px;
  margin-left: 10px;
}

.avatar-img {
  object-fit: cover;
  height: 100%;
}
.user-name {
  font-weight: 500;
}
// .body {
//   position: relative;
//   display: flex;
//   justify-content: space-between;
// }
.activities-wrapeer {
  position: absolute;
  bottom: 0px;
  left: 0px;
  height: 5px;
  border: 0.25px solid gray;
}
.activities {
  position: absolute;
  bottom: 0px;
  left: 0px;
  height: 5px;
  display: flex;
  border: 0.25px solid transparent;
}
.duration {
  display: flex;
  align-items: center;
  font-weight: 700;
  justify-self: end;
}
</style>
