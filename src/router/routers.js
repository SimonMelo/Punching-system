import Login from '@/views/Login/Login.vue'
import Home from '@/views/Home/Home.vue'

const routes = [
  {
    path: '/',
    name: 'login',
    component: Login
  },
  {
    path: '/home',
    name: 'home',
    component: Home
  }
]

export default routes