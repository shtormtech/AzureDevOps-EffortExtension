import VueRouter from 'vue-router'
import EffortExtension from './components/EffortExtension'
import Logo from './components/Logo.vue'

const router = new VueRouter({
  mode: 'history',
  routes: [
    {
      path: '/effort/:workItemId',
      name: 'workItems',
      component: EffortExtension
    },
    {
      path: '/',
      name: 'Logo',
      component: Logo
    }
  ]
})
export default router
