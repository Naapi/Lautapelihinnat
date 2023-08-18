<template>
  <h1>Hellooo</h1>
  <Header />
  <SearchBar />
</template>

<script script lang="ts">
import { defineComponent } from 'vue';
import Header from './components/MainView/Header.vue'
import SearchBar from './components/MainView/SearchBar.vue';

export default defineComponent({
  name: 'App',
  components: {
    Header,
    SearchBar,

  }
});
</script>