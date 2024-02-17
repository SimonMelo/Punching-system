import axios from "axios"

export const loginSession = (userData) => {
    const url = 'http://localhost:5271/loginAuth/login'
    const headers = {
        "Content-Type": "application/json"
    }
  
    return axios.post(url, userData, { headers })
  }