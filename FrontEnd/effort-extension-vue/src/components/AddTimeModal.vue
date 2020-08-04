<template lang="pug">
  transition(name="modal")
    .modal-mask
      .modal-wrapper(
        @click.once="showAddTimeModal(false)"
      )
        .modal-container(
          @click.stop=""
        )
          .modal-header
            span.tiket-title.left {{workItemId + ' '}}
            strong.tiket-title.left {{workItemTitle}}
          .modal-body
            .body-item.activities
              .activities-title.left Activities
              .activities-value.right
                select.input(
                  v-model="activityType"
                )
                  option(
                    v-for="item in activityTypes"
                    :value="item.id"
                    ) {{item.name}}
            .body-item.date
              .date-title.left Date
              .date-value.right
                input.date-input(
                  type="date"
                  v-model="date"
                )
            .body-item.duration
              .duration-title.left Duration
              .duration-value.right
                input.duration-input(
                  type="number"
                  v-model="duration"
                )
            .body-item.comment
              .comment-title.left Comment
              .comment-value.right
                textarea.input(
                  v-model="comment"
                )
          .modal-footer
            button.add-timesheet(
              @click.submit.prevent="sendTimesheet({duration: Number(duration), date, comment, activityType: inActivityType})"
              ) Add
</template>
<script>
import { mapState, mapActions } from 'vuex'
export default {
  name: 'AddTimeModal',
  data () {
    return {
      duration: 0,
      date: new Date(),
      inActivityType: 1,
      comment: ''
    }
  },
  computed: {
    ...mapState('addTimesheet', {
      activityTypes: state => state.activityTypes
    }),
    ...mapState({
      workItemId: state => state.workItemId
    }),
    workItemTitle () {
      return this.$store.getters.workItemTitle(this.workItemId)
    },
    activityType: {
      // геттер
      get: function () {
        return this.inActivityType
      },
      // сеттер:
      set: function (value) {
        this.inActivityType = value
      }
    }
  },
  methods: {
    ...mapActions('addTimesheet', ['fetchActivityTypes']),
    ...mapActions(['sendTimesheet', 'showAddTimeModal'])
  },
  beforeMount () {
    this.fetchActivityTypes()
  }
}
</script>
<style scoped>
.modal-footer{
  text-align: right;
}
.date, .duration, .comment, .activities {
  display: grid;
  grid-template-columns: 1fr 290px;
}
.body-item{
  padding-bottom: 10px;
}
.body-item:last-child{
  padding-bottom: 0px;
}
.right{
  width: 100%;
}
.input{
  width: 100%;
  height: 100%;
}
.date-input, .duration-input {
  width: 99%
}
input, textarea {
  padding: 0px;
}
.add-timesheet {
  background: #1e6eef;
  color: white;
  width: 90px;
  height: 30px;
}
/* modal */
.modal-mask {
  position: fixed;
  z-index: 9998;
  top: 0;
  left: 0;
  width: 100%;
  height: 100%;
  background-color: rgba(0, 0, 0, 0.5);
  display: table;
  transition: opacity 0.3s ease;
}
.body-item.tiket {
  display: inline;
}

.modal-wrapper {
  display: table-cell;
  vertical-align: middle;
}
.modal-container {
  width: 400px;
  margin: 0px auto;
  background-color: #fff;
  border-radius: 2px;
  box-shadow: 0 2px 8px rgba(0, 0, 0, 0.33);
  transition: all 0.3s ease;
}

.modal-header h3 {
  font-size: 14px;
    margin: 0;
    color: #555;
    display: inline-block;
}

.modal-body {
  padding: 12px 10px;
}

.modal-enter {
  opacity: 0;
}

.modal-leave-active {
  opacity: 0;
}

.modal-enter .modal-container,
.modal-leave-active .modal-container {
  -webkit-transform: scale(1.1);
  transform: scale(1.1);
}
.modal-footer {
    border-top: 1px solid #e5e5e5;
    padding: 8px 10px;
}
.modal-header {
    padding-top: 20px;
    padding: 10px 8px;
    background-color: #f6f7f9;
    border-bottom: 1px solid #e5e5e5;
}
</style>
