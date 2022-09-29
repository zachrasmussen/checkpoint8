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
          <h5>Vaults:</h5>
          <h5>Keeps:</h5>
        </div>
      </div>
    </div>
    <!--  -->
    <!-- SECTION user's vaults -->
    <div class="row">
      <div class="col-12 d-flex justify-content-between p-3 mt-5">
        <h4 class="offset-1">
          Vaults
          <span class="add" data-bs-toggle="modal" data-bs-target="#vault-form">
            ⊕
          </span>
        </h4>
      </div>
      <div></div>
    </div>
    <!--  -->
    <!-- SECTION user's keeps -->
    <div class="row">
      <div class="col-12 d-flex justify-content-between p-3 mt-5">
        <h4 class="offset-1">
          Keeps
          <span class="add" data-bs-toggle="modal" data-bs-target="#keep-form">
            ⊕
          </span>
        </h4>

        <!-- {{ profile?.keeps }} -->
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
export default {
  name: 'Profile',
  props: {
    keep: {
      type: Object,
      required: true
    }
  },

  setup() {
    const route = useRoute();
    async function getActiveProfile() {
      try {
        await profilesService.getProfile(route.params.id);

      } catch (error) {
        logger.log(error);
        router.push({ name: 'Home' })
      }
    }
    async function getProfileKeeps() {
      try {
        await profilesService.getProfileKeeps(route.params.id);
      }
      catch (error) {
        logger.log(error)
      }
    }
    onMounted(() => {
      getActiveProfile();
      // getProfileKeeps()
    });
    return {
      account: computed(() => AppState.account),
      profile: computed(() => AppState.activeProfile),
      keep: computed(() => AppState.profileKeeps)
    }
  }

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
</style>
