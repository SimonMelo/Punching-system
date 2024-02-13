<template>
  <a-layout>
    <Navigation />
    <a-layout-content style="margin: 24px 16px; padding: 24px; background: #fff; min-height: 280px;">
      <div class="about">
        <h1>Bem-vindo à nossa página inicial!</h1>
        <p>Aqui está o conteúdo principal da página inicial...</p>
      </div>
    </a-layout-content>
  </a-layout>
</template>

<script setup>
import Navigation from '../../components/Navigation.vue';
</script>