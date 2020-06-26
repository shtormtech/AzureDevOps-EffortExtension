import Vue from 'vue'
import Vuex from 'vuex'
import axios from './../requests'
import addTimesheet from './modules/addTimesheet'

Vue.use(Vuex)

export default new Vuex.Store({
  state: {
    workItems: {},
    userUniqueName: 'Iloer@mail.ru',
    workItemId: 6,
    totalCount: 0,
    isShowAddTimeModal: false
  },
  mutations: {
    FETCH_WORK_ITEMS: (state, workItems) => {
      state.workItems = workItems
      state.totalCount = workItems.reduce(function (sum, current) {
        return sum + current.duration
      }, 0)
    },
    SHOW_ADD_TIME_MODAL: (state, show) => {
      state.isShowAddTimeModal = show
    }
  },
  actions: {
    fetchWorkItems ({ commit, state }) {
      // const workItems = [
      //   {
      //     id: 0,
      //     wiType: 'userStory',
      //     title: 'История',
      //     duration: 10
      //   },
      //   {
      //     id: 1,
      //     wiType: 'Bug',
      //     title: 'Ошибка',
      //     duration: 15
      //   },
      //   {
      //     id: 2,
      //     wiType: 'Epic',
      //     title: 'Эпик',
      //     duration: 62
      //   },
      //   {
      //     id: 3,
      //     wiType: 'Task',
      //     title: 'Задача',
      //     duration: 42
      //   }
      // ]
      // commit('FETCH_WORK_ITEMS', workItems)
      axios
        .get(`/TimeExtension/${state.workItemId}/WorkItems`)
        .then(Response => {
          commit('FETCH_WORK_ITEMS', Response.data)
        })
        .catch(error => {
          console.log(error)
        })
    },
    fetchcTeams ({ commit }, selfId) {

    },
    fetchActivities ({ commit }, selfId) {

    },
    showAddTimeModal ({ commit }, show) {
      commit('SHOW_ADD_TIME_MODAL', show)
    },
    sendTimesheet ({ commit, state }, respData) {
      const body = {
        date: respData.date,
        activityTypeId: respData.activityType,
        userUniqueName: state.userUniqueName,
        workItemId: state.workItemId,
        duration: respData.duration,
        comment: respData.comment
      }
      axios
        .post('/Timesheets', body)
        .then(Response => {
          commit('SHOW_ADD_TIME_MODAL', false)
        })
        .catch(error => {
          console.log(error)
        })
    }
  },
  modules: {
    addTimesheet
  }
})
