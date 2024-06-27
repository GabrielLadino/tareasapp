import axios from 'axios'

const SERVER_URL = `${ import.meta.env.VITE_BASE_PATH }`

axios.defaults.baseURL =SERVER_URL 

const http = axios.create({
  baseURL: SERVER_URL,
  timeout: 10000
})

export default http