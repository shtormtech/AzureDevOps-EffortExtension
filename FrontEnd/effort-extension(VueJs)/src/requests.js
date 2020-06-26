
import axios from 'axios'

const baseUrl = "http://iloer.francecentral.cloudapp.azure.com:31051";
axios.defaults.baseURL = baseUrl;

export default axios;