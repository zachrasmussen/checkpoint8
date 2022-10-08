<template>
  <div class="container-fluid">
    <div class="row">
      <div class="col-12 d-flex justify-content-between p-3 mt-5">
        <h4 class="offset-1">{{ vault?.name }}</h4>

        <button class="btn-color rounded" @click="deleteVault">
          Delete Vault
        </button>
      </div>
    </div>
    <div class="row">
      <div class="masonry">
        <div class="" v-for="vk in vaultKeeps" :key="vk.id">
          <KeepCard :keep="vk" />
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { computed, onMounted } from '@vue/runtime-core';
import { logger } from '../utils/Logger';
import { vaultsService } from '../services/VaultsService';
import { AppState } from '../AppState';
import { useRoute, useRouter } from 'vue-router';
import { vaultKeepsService } from '../services/VaultKeepsService';
export default {

  name: 'Home',
  setup() {
    const route = useRoute();
    const router = useRouter();
    //computed active vaults
    async function getVaultKeep() {
      try {

        logger.log('Testing Keeps', route.params.id)
        await vaultKeepsService.getVaultKeep(route.params.id);
        // console.log('[Profile Keeps]', 'we got keeps')
      }
      catch (error) {
        logger.log(error)
        router.push({ name: 'Home' })
      }
    }

    async function getVaultById() {
      try {
        await vaultsService.getById(route.params.id)
      } catch (error) {
        logger.log(error)
      }

    }

    onMounted(async () => {
      getVaultKeep()
      getVaultById()
    });
    return {
      // async getVaultKeep() {
      //   try {
      //     logger.log('Testing Keeps', route.params.id)
      //     await vaultKeepsService.getVaultKeep(route.params.id);
      //     // console.log('[Profile Keeps]', 'we got keeps')
      //   }
      //   catch (error) {
      //     logger.log(error)
      //   }
      // },
      router,
      async deleteVault() {
        try {
          await vaultsService.deleteVault(AppState.activeVault.id)
          Pop.toast('Vault Deleted', 'success')
        } catch (error) {
          logger.log(error);
        }
      },

      vault: computed(() => AppState.activeVault),
      account: computed(() => AppState.account),
      vaultKeeps: computed(() => AppState.vaultKeeps),

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
.btn-color {
  background-color: #0096fa;
  border: none;
  padding: 10px 20px;
  color: white;
}
</style>
