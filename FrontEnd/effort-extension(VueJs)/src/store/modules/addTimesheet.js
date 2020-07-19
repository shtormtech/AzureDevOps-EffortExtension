import axios from '../../requests'
export default {
  namespaced: true,
  state: {
    activityTypes: {},
    title: ''
  },
  mutations: {
    SET_ACTIVITY_TYPE: (state, activityTypes) => (state.activityTypes = activityTypes)
  },
  actions: {
    fetchActivityTypes ({ commit }) {
      axios
        .get('/ActivityTypes')
        .then(Response => {
          commit('SET_ACTIVITY_TYPE', Response.data)
        })
        .catch(error => {
          console.log(error)
        })
    },
    fetchTitleWorkItem ({ commit }) {
      console.log(this)
      // axios
      //   .get(`/api/workItems/${id}`)
      //   .then(Response => {
      //     commit('SET_ACTIVITY_TYPE', Response.data)
      //   })
      //   .catch(error => {
      //     console.log(error)
      //   })
    }
  },
  getters: {
  }
}
