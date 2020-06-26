import Vue from 'vue'
import App from './App.vue'
import './registerServiceWorker'
import store from './store'

console.log(process.env)
console.log(process.env.BACK_URL)
Vue.config.productionTip = false

new Vue({
  store,
  render: h => h(App)
}).$mount('#app')
