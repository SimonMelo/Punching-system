import './assets/main.css'
import { createApp } from 'vue'
import App from './App.vue'
import router from './router/configRouter'
import Antd from 'ant-design-vue'


const app = createApp(App)

app.use(router)
app.use(Antd)
app.mount('#app')