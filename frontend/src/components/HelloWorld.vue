<script setup lang="ts">
import { ref } from 'vue'

import Mails from './Mails.vue'

defineProps<{ 
  msg: string 
}>();

const tab = ref('mails');

</script>

<template>
  <div>
    <q-tabs v-model="tab">
      <q-tab name="mails" icon="mail" label="Mails" />
      <q-tab name="alarms" icon="alarm" label="Alarms" />
      <q-tab name="movies" icon="movie" label="Movies" />
    </q-tabs>

    <q-separator />

    <q-tab-panels v-model="tab">
          <q-tab-panel name="mails">
            <Mails />
          </q-tab-panel>

          <q-tab-panel name="alarms">
            <div>Alarms</div>
          </q-tab-panel>

          <q-tab-panel name="movies">
            <div>Movies</div>
          </q-tab-panel>
        </q-tab-panels>
  </div>
</template>

<style lang="scss" scoped />
