<template>
  <div class="container-fluid">
    <!-- SECTION img, name, stats -->
    <div class="row">
      <div
        class="col-12 d-flex justify-content-evenly align-items-center p-3 mt-5"
      >
        <div>
          <img class="col-4 rounded pro-img" :src="profile?.picture" alt="" />
        </div>
        <div class="col-8 justify-content-start">
          <h1>{{ profile?.name }}</h1>
        </div>
      </div>
    </div>

    <!-- SECTION user's vaults -->
    <div class="row">
      <div class="col-12 d-flex justify-content-between p-3 mt-5">
        <h4 class="offset-1">
          Vaults
          <span
            class="add"
            data-bs-toggle="modal"
            data-bs-target="#vault-form"
            v-if="yourProfile"
          >
            ⊕
          </span>
        </h4>
      </div>
    </div>
    <div class="row">
      <div class="masonry mt-3 p-5">
        <div class="shadow" v-for="v in vaults" :key="v.id">
          <VaultCard :vault="v" />
        </div>
      </div>
    </div>

    <!-- SECTION user's keeps -->
    <div class="row">
      <div class="col-12 d-flex justify-content-between p-3 mt-5">
        <h4 class="offset-1">
          Keeps
          <span
            class="add"
            data-bs-toggle="modal"
            data-bs-target="#keep-form"
            v-if="yourProfile"
          >
            ⊕
          </span>
        </h4>
      </div>
    </div>
    <div class="row">
      <div class="masonry mb-5 offset-1" v-for="k in keeps" :key="k.id">
        <KeepCard :keep="k" />
      </div>
    </div>
  </div>
  <KeepForm />
  <VaultForm />
</template>

<script>

import { computed, onMounted } from 'vue'
import { AppState } from '../AppState'
import { logger } from '../utils/Logger'
import { profilesService } from '../services/ProfilesService'
import { useRoute } from 'vue-router';
import { keepsService } from '../services/KeepsService'
import { vaultsService } from '../services/VaultsService'


export default {


  setup() {
    const route = useRoute();

    async function getActiveProfile() {
      try {
        await profilesService.getProfile(route.params.id);

      } catch (error) {
        logger.log(error);
      }
    }

    async function getVaultsByProfile() {
      try {
        logger.log('Testing Vaults', route.params.id)
        await vaultsService.getVaultsByProfile(route.params.id)
        logger.log('[Active]', AppState.activeVault)
      } catch (error) {
        logger.log(error)
      }
    }
    async function getProfileKeeps() {
      try {
        logger.log('Testing Keeps', route.params.id)
        await keepsService.getProfileKeeps(route.params.id);
        // console.log('[Profile Keeps]', 'we got keeps')
      }
      catch (error) {
        logger.log(error)
      }
    }
    onMounted(() => {
      getActiveProfile();
      getProfileKeeps();
      getVaultsByProfile();
    });
    return {
      account: computed(() => AppState.account),
      profile: computed(() => AppState.activeProfile),
      keeps: computed(() => AppState.keeps),
      vaults: computed(() => AppState.vaults),
      yourProfile: computed(() => AppState.activeKeep?.creatorId == AppState.account?.id),
    };
  },

}
</script>

<style scoped lang="scss">
.pro-img {
  width: 100px;
}
.add {
  color: #0096fa;
  cursor: pointer;
}
.masonry {
  columns: 300px;
  column-gap: 1em;

  div {
    display: block;
    margin-bottom: 1em;
  }
}
</style>
