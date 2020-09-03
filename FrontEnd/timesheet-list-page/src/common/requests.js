import axios from 'axios';

const baseUrl = 'https://iloer.francecentral.cloudapp.azure.com:31053/api';

export const TimesheetClient = axios.create({
  baseURL: baseUrl,
  headers: {'Content-Type': 'application/json'},
});
