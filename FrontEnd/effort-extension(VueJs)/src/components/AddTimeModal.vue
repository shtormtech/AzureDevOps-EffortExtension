<template lang="pug">
  transition(name="modal")
    .modal-mask
      .modal-wrapper
        .modal-container
          .modal-header
            h3 Add timesheet
          .modal-body
            .user
              .user-title.left {{user.userName}}
            .tiket
              .tiket-title.left {{user.tiketTitle}}
            .date
              .date-title.left Date
              .date-value.right
                input(
                  type="date"
                  v-model="date"
                )
            .duration
              .duration-title.left Duration
              .duration-value.right
                input(
                  type="number"
                  v-model="duration"
                )
            .comment
              .comment-title.left Comment
              .comment-value.right
                textArea(
                  v-model="comment"
                )
          .modal-footer
            button.add-timesheet(
              @click.submit.prevent="sendTimesheet({duration, date, comment})"
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
      comment: '',
      user: {
        id: 1,
        tiketTitle: 'Тестовый тикет',
        userName: 'Test User'
      }
    }
  },
  computed: {
    ...mapState({

    })
  },
  methods: {
    ...mapActions(['sendTimesheet'])
  }
}
</script>
<style scoped>
.modal-footer{
  text-align: right;
}
.date, .duration, .comment {
  display: grid;
  grid-template-columns: 1fr 3fr;
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
.question_button_grey {
    background: #708188;
    border: none;
    padding: 9px 25px;
    margin: 10px 10px 10px 0;
    font-size: 15px;
    text-align: center;
    color: #fff;
    cursor: pointer;
}
.question_button {
    background: #00aae7;
    border: none;
    padding: 9px 25px;
    margin: 10px 10px 10px 0;
    font-size: 15px;
    text-align: center;
    color: #fff;
    cursor: pointer;
}
</style>
