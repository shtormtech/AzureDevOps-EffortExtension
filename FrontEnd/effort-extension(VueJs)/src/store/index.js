import Vue from 'vue'
import Vuex from 'vuex'
import axios from './../requests'
import addTimesheet from './modules/addTimesheet'

Vue.use(Vuex)
export default new Vuex.Store({
  state: {
    workItems: {},
    activities: {},
    userUniqueName: 'Iloer@mail.ru',
    workItemId: 0,
    totalCount: 0,
    userId: 0,
    projectName: '',
    isShowAddTimeModal: false
  },
  mutations: {
    FETCH_WORK_ITEMS: (state, workItems) => {
      state.workItems = workItems
      state.totalCount = workItems.reduce(function (sum, current) {
        return sum + current.duration
      }, 0)
    },
    FETCH_ACTIVITIES: (state, activities) => {
      state.activities = activities
    },
    SHOW_ADD_TIME_MODAL: (state, show) => {
      state.isShowAddTimeModal = show
    },
    SET_ROUTE_PARAMS: (state, routeParams) => {
      state.workItemId = routeParams.workItemId
      state.userId = routeParams.userId
      state.projectName = routeParams.projectName
    }
  },
  actions: {
    fetchWorkItems ({ commit, state }) {
      axios
        .get(`/TimeExtension/${state.workItemId}/WorkItems?${state.projectName ? `Project=${state.projectName}` : ''}`)
        .then(Response => {
          commit('FETCH_WORK_ITEMS', Response.data)
        })
        .catch(error => {
          console.log(error)
        })
    },
    fetchcTeams ({ commit }, selfId) {

    },
    fetchActivities ({ commit, state }, selfId) {
      axios
        .get(`/TimeExtension/${state.workItemId}/Activities`)
        .then(Response => {
          commit('FETCH_ACTIVITIES', Response.data)
        })
        .catch(error => {
          console.log(error)
        })
    },
    showAddTimeModal ({ commit }, show) {
      commit('SHOW_ADD_TIME_MODAL', show)
    },
    sendTimesheet ({ commit, state }, respData) {
      const body = {
        date: respData.date,
        activityTypeId: respData.activityType,
        userUniqueName: state.userId,
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
    },
    setRouteParams ({ commit }, routeParams) {
      commit('SET_ROUTE_PARAMS', routeParams)
    }
  },
  getters: {
    workItemTitle: state => workItemId => {
      const workItem = state.workItems.find(f => f.id === Number(workItemId))
      return workItem ? workItem.title : ''
    }
  },
  modules: {
    addTimesheet
  }
})
