<template>
  <a-layout-sider :trigger="null" collapsible v-model:collapsed="collapsed" theme="light">
    <a-menu theme="light" :default-selected-keys="['1']" mode="inline">
      <a-menu-item key="1">
        <router-link to="/home">
          <a-icon type="user" />
          <span>Início</span>
        </router-link>
      </a-menu-item>
    </a-menu>
    <a-menu theme="light" :default-selected-keys="['2']" mode="inline">
      <a-menu-item key="2">
        <router-link to="/dashboard">
          <a-icon type="user" />
          <span>Dashboard</span>
        </router-link>
      </a-menu-item>
    </a-menu>
    <div class="row justify-content-center mt-4">
      <div class="col-sm-6">
        <a-button class="logout-button" :loading="loadingButton" @click="handleLogout" type="primary" block>Sair</a-button>
      </div>
    </div>
  </a-layout-sider>
  
</template>

<script setup>
import { logout } from '@/services/auth';
import { ref } from 'vue'

const loadingButton = ref(false)

const collapsed = ref(false)

const handleLogout = () => {
  loadingButton.value = true
  setTimeout(() => {
    logout()
    window.location.pathname = "/login"
    loadingButton.value = false
  }, 1000)
}
</script>

<style scoped>
.logout-button {
  font-size: 1rem; 
  background-color: rgb(11, 0, 107);
}
</style>
