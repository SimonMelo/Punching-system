export const setAccessToken = (token) => {
    localStorage.setItem("accessToken", token)
}

export const getAccessToken = () => {
    return localStorage.getItem("accessToken")
}

export const isAuthenticated = () => {
    return localStorage.getItem("accessToken") !== null
}

export const logout = () => {
    localStorage.removeItem('accessToken')
}
