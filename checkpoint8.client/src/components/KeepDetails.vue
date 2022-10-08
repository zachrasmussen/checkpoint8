<template>
  <!-- SECTION once the KeepCard is clicked, this is the modal that pops up. -->

  <div class="row m-height">
    <div class="col-12">
      <div
        class="modal fade"
        id="keep-details"
        tabindex="-1"
        role="dialog"
        aria-labelledby="exampleModalLabel"
        aria-hidden="true"
      >
        <div class="m-height modal-dialog modal-dialog-centered modal-xl">
          <div class="modal-content">
            <div class="container-fluid">
              <div class="row">
                <div class="col-12 col-md-5 p-2 m-0">
                  <img
                    :src="keep?.img"
                    alt=""
                    class="img-fluid modal-img rounded"
                  />
                </div>
                <div class="col-10 col-md-7">
                  <div
                    class="
                      modal-header
                      justify-content-center
                      d-flex
                      align-items-center
                    "
                  >
                    <p class="pb-2 m-0 p-0">
                      <i class="mdi mdi-eye icon mx-2"
                        ><span>{{ keep?.views }}</span></i
                      >
                      <i class="mdi mdi-pin icon mx-2"
                        ><span class="ms-2">{{ keep?.kept }}</span></i
                      >
                    </p>
                  </div>

                  <div
                    class="
                      modal-body
                      justify-content-evenly
                      d-flex
                      m-2
                      mt-2
                      mb-3
                      pb-2
                    "
                  >
                    <div
                      class="
                        col-12 col-md-10
                        order-2 order-md-1
                        mx-2
                        body-height
                      "
                    >
                      <div class="steps text-dark p-2 rounded-top">
                        <h4 class="text-center mt-4">
                          <b>{{ keep?.name }}</b>
                        </h4>
                        <div class="justify-content-center d-flex mt-4">
                          <p>{{ keep?.description }}</p>
                        </div>
                      </div>
                    </div>
                  </div>
                  <div class="modal-footer justify-content-between d-flex">
                    <button
                      v-if="!vaultKeep"
                      class="btn-color rounded"
                      data-bs-toggle="dropdown"
                    >
                      ADD TO VAULT
                      <i
                        class="mdi mdi-arrow-down-drop-circle-outline ms-2"
                      ></i>
                      <ul class="dropdown-menu">
                        <option
                          class="selectable"
                          v-for="v in vaults"
                          :key="v.id"
                          @click="addToVault(v.id)"
                        >
                          {{ v.name }}
                        </option>
                      </ul>
                    </button>
                    <button
                      v-if="vaultKeep"
                      @click="deleteFromVault(vaultKeep.vaultKeepId)"
                      data-bs-dismiss="modal"
                      class="btn-color rounded"
                    >
                      Remove From Vault
                    </button>

                    <i
                      v-if="isCreator"
                      @click="deleteKeep"
                      class="mdi mdi-close-circle-outline d-icon"
                      data-bs-dismiss="modal"
                    ></i>

                    <div>
                      <router-link
                        v-if="keep"
                        :to="{
                          name: 'Profile',
                          params: { id: keep?.creator.id },
                        }"
                      >
                        <img
                          :src="keep?.creator.picture"
                          class="creator-img rounded-circle"
                          alt=""
                          data-bs-dismiss="modal"
                        />
                      </router-link>
                    </div>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { computed } from '@vue/runtime-core';
import { AppState } from '../AppState';
import { keepsService } from '../services/KeepsService';
import Pop from '../utils/Pop';
import { router } from '../router';
import { logger } from '../utils/Logger';
import { useRoute } from 'vue-router';
import { vaultsService } from '../services/VaultsService';
import { vaultKeepsService } from '../services/VaultKeepsService';

export default {
  setup() {
    const route = useRoute();
    return {

      keep: computed(() => AppState.activeKeep),
      vaultKeep: computed(() => AppState.vaultKeeps.find(vk => vk.id == AppState.activeKeep?.id)),
      creator: computed(() => AppState.activeProfile),
      isCreator: computed(() => AppState.activeKeep?.creatorId == AppState.account?.id),
      vaults: computed(() => AppState.myVaults),
      async addToKeep() {

      },
      async deleteKeep() {
        try {
          await keepsService.deleteKeep(AppState.activeKeep.id)
          Pop.toast('Keep Deleted', 'success')

        } catch (error) {

          logger.log(error);
        }
      },
      async addToVault(vaultId) {
        try {
          let keep = { keepId: AppState.activeKeep.id, vaultId }
          logger.log('[DID THIS WORK]', keep)
          await vaultKeepsService.creatVaultKeep(keep)
          // await vaultsService.myAccountVaults(keep)
          this.keep.kept++

          // await keepsService.getKeeps(keep)
          // logger.log('trying this relationship', keep)
        } catch (error) {
          logger.log(error);
        }
      },
      async deleteFromVault(vaultKeepId) {
        try {
          await vaultKeepsService.deleteVaultKeep(vaultKeepId)

        } catch (error) {
          logger.log(error)
        }
      }




    };
  },
};
</script>

<style scoped>
/* .modal-img {
  height: 650px;
  width: 600px;
  object-fit: cover;
} */
.icon {
  font-size: 1.25em;
  color: #0096fa;
}
.d-icon {
  font-size: 1.25em;
  color: red;
}
.body-height {
  height: 50vh;
}
.modal-img {
  height: 100%;
  object-fit: cover;
  object-position: center;
}
.btn-color {
  background-color: #0096fa;
  border: none;
  padding: 10px 20px;
  color: white;
}
.m-height {
  max-height: 20vh;
}
.creator-img {
  height: 50px;
}
</style>
