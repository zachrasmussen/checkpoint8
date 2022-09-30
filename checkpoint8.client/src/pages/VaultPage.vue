<template>
  <div class="container-fluid">
    <div class="row">
      <div class="col-12 d-flex justify-content-between p-3 mt-5">
        <h4 class="offset-1">{{ vault.name }}</h4>
        <button
          class=""
          v-if="vault?.creator.id == account.id"
          @click="deleteVault(vault.id)"
        >
          Delete Vault
        </button>
      </div>
    </div>
    <div class="row">
      <div class="" v-for="k in keeps" :key="k.id" :keep="k"></div>
      <VaultCard />
    </div>
  </div>
</template>

<script>
import { computed, onMounted } from '@vue/runtime-core';
import { logger } from '../utils/Logger';
import { vaultsService } from '../services/VaultsService';
import { AppState } from '../AppState';
export default {
  name: 'Home',
  setup() {
    async function getVaults() {
      try {
        await vaultsService.getById();
      } catch (error) {
        logger.log(error);
      }
    }
    onMounted(() => {
      getVaults();
    });
    return {
      vaults: computed(() => AppState.vaults)
    }
  }
}
</script>

<style scoped lang="scss">
.masonry {
  columns: 300px;
  column-gap: 1em;

  div {
    display: block;
    margin-bottom: 1em;
  }
}
</style>
