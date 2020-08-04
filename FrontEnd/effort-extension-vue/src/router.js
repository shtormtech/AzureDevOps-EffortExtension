import VueRouter from 'vue-router'
import EffortExtension from './components/EffortExtension'

const router = new VueRouter({
  mode: 'history',
  routes: [
    {
      path: '/effort/:workItemId',
      name: 'workItems',
      component: EffortExtension
    }
  ]
})

export default router
