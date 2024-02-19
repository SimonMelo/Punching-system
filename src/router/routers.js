import Login from '@/views/Login/Login.vue'
import Home from '@/views/Home/Home.vue'
import Dashboard from '@/views/Dashboard/Dashboard.vue'

const routes = [
  {
    path: '/login',
    name: 'login',
    component: Login
  },
  {
    path: '/home',
    name: 'home',
    component: Home
  },
  {
    path: '/dashboard',
    name: 'dashboard',
    component: Dashboard
  }
]

export default routes