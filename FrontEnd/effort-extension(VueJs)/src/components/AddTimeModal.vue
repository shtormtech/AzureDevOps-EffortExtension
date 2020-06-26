<template lang="pug">
  transition(name="modal")
    .modal-mask
      .modal-wrapper
        .modal-container
          .modal-header
            h3 question.title
          .modal-body question.message
          .modal-footer
            button(
              @click.submit.prevent="changeQuestion(button)"
              ) button.title
</template>
<script>
import { mapState } from 'vuex'
export default {
  name: 'AddTimeModal',
  props: {
    data: Object
  },
  computed: {
    ...mapState({
    })
  },
  methods: {

  }
}
</script>
<style scoped>
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
