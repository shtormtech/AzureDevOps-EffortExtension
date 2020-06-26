import axios from 'axios'

const baseUrl = process.env.BACK_URL
axios.defaults.baseURL = baseUrl

export default axios
