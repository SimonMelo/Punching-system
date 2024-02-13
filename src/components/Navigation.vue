<template>
    <a-layout-sider :trigger="null" collapsible v-model:collapsed="collapsed" theme="light">
      <a-menu theme="light" :default-selected-keys="['1']" mode="inline">
        <a-menu-item key="1">
          <router-link to="/home">
            <a-icon type="user" />
            <span>Home</span>
          </router-link>
        </a-menu-item>
        <!-- Adicione mais itens de menu conforme necessário -->
      </a-menu>
    </a-layout-sider>
  </template>
  
  <script setup>
  import { ref } from 'vue';
  
  const collapsed = ref(false);
  </script>