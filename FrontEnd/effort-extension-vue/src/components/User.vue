<template lang="pug">
.user-wrapper
  .avatar
    img.avatar-img(
      :src="user.imageUrl"
    )
  .body
    .user-name {{ user.displayName }}
    .duration {{ duration }}
    .activities(
      :style="{width: `${MaxDuration}%`}"
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
    maxDuration: Number
  },
  computed: {
    duration () {
      let duration = 0
      this.user.activities.forEach(obj => {
        duration += obj.duration
      })
      return duration
    },
    MaxDuration () {
      return this.maxDuration / this.duration * 100
    }
  },
  methods: {
    getDuration (item) {
      return this.MaxDuration / item.duration * 100
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
.activities {
  position: absolute;
  bottom: 0px;
  left: 0px;
  height: 12%;
  flex: none;
  display: flex;
  border: 1px solid gray;
}
.duration {
  display: flex;
  align-items: center;
  font-weight: 700;
  justify-self: end;
}
</style>
