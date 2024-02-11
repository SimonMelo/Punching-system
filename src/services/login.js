import axios from "axios"

export const loginSession = (userData) => {
    const url = 'https://run.mocky.io/v3/5436f2f8-e556-4174-a9dc-b0611d03f057'
    const headers = {
        "Content-Type": "application/json",
        "Authorization": "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwMCIsImlhdCI6MTY0NDIyOTg5MH0.8kprG3zwnobqHxV_Zf6UI_DuBLuE4FMCiYlS0q8CyGg"
    }
  
    return axios.post(url, userData, { headers })
  }