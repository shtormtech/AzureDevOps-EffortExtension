import axios from 'axios'

const baseUrl = process.env.VUE_APP_BACK_URL
axios.defaults.baseURL = baseUrl

export default axios
