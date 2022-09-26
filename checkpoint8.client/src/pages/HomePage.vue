<template>
  <section class="row">
    <div class="col-12" v-for="k in keeps" :key="k.id">
      <KeepCard :keep="k" />
    </div>
  </section>
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
// .masonry {
//   columns: 200px;
//   column-gap: 1em;

//   div {
//     display: block;
//     margin-bottom: 1em;
//   }
// }
</style>
