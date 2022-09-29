<template>
  <div class="container-fluid">
    <div class="row">
      <div>
        <div class="" v-for="v in vaults" :key="v.id">
          <VaultCard :keep="v" />
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { computed, onMounted } from '@vue/runtime-core';
import { logger } from '../utils/Logger';
import { keepsService } from '../services/KeepsService';
import { AppState } from '../AppState';
export default {
  name: 'Home',
  setup() {
    async function getKeeps() {
      try {
        await keepsService.getKeeps();
      } catch (error) {
        logger.log(error);
      }
    }
    onMounted(() => {
      getKeeps();
    });
    return {
      keeps: computed(() => AppState.keeps)
    }
  }
}
</script>

<style scoped lang="scss">
</style>
