<template>
  <div
    class="
      home
      flex-grow-1
      d-flex
      flex-column
      align-items-center
      justify-content-center
    "
  ></div>
</template>

<script>
import { onMounted } from '@vue/runtime-core';
import { logger } from '../utils/Logger';
import { keepsService } from '../services/KeepsService';
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
  }
}
</script>

<style scoped lang="scss">
</style>
