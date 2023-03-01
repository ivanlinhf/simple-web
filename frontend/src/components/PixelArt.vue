<script setup lang="ts">
import { ref } from 'vue'

const url = ref<string>();

function show() {
    url.value = "http://localhost:5000/img"
}
</script>

<template>
  <div>
    <q-btn label="Show" @click="show" />
    <q-img class="img" v-if="url !== undefined" :src="url" fit="none" />
  </div>
</template>

<style lang="scss" scoped>
.img {
  width: 64px;
  height: 64px;
  border-style: solid;
  border-color: black;
}
</style>
