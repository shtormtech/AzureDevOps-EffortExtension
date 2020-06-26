import Vue from 'vue'
import Vuex from 'vuex'

Vue.use(Vuex)

export default new Vuex.Store({
  state: {
    workItems: {},
    totalCount: 0,
    showAddTimeModal: false
  },
  mutations: {
    FETCH_WORK_ITEMS: (state, workItems) => {
      state.workItems = workItems
      state.totalCount = workItems.reduce(function (sum, current) {
        return sum + current.duration
      }, 0)
    },
    SHOW_ADD_TIME_MODAL: (state, show) => {
      state.showAddTimeModal = show
    }
  },
  actions: {
    fetchWorkItems ({ commit }, selfId) {
      const workItems = [
        {
          id: 0,
          wiType: 'userStory',
          title: 'История',
          duration: 10
        },
        {
          id: 1,
          wiType: 'Bug',
          title: 'Ошибка',
          duration: 15
        },
        {
          id: 2,
          wiType: 'Epic',
          title: 'Эпик',
          duration: 62
        },
        {
          id: 3,
          wiType: 'Task',
          title: 'Задача',
          duration: 42
        }
      ]
      commit('FETCH_WORK_ITEMS', workItems)
    },
    fetchcTeams ({ commit }, selfId) {

    },
    fetchActivities ({ commit }, selfId) {

    },
    showAddTimeModal ({ commit }, show) {
      commit('SHOW_ADD_TIME_MODAL', show)
    },
    sendTimesheet () {
      
    }
  },
  modules: {
  }
})
