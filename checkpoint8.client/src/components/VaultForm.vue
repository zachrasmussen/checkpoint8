<template>
  <div class="row">
    <div class="col-12">
      <div
        class="modal fade"
        id="vault-form"
        tabindex="-1"
        role="dialog"
        aria-labelledby="exampleModalLabel"
        aria-hidden="true"
      >
        <div class="modal-dialog modal-dialog-centered modal-md">
          <div class="modal-content">
            <form class="row p-3" @submit.prevent="handleSubmit">
              <h3 class="mb-4">New Vault</h3>
              <div class="col-md-12 mb-3">
                <label for="vault-name" class="form-label">Title</label>
                <input
                  v-model="editable.name"
                  type="text"
                  class="form-control"
                  name="vault-title"
                  placeholder="Title"
                  required
                />
              </div>
              <div class="col-md-12 mb-3">
                <label for="vault-img" class="form-label">Image</label>
                <input
                  v-model="editable.img"
                  type="text"
                  class="form-control"
                  name="vault-img"
                  placeholder="Add URL"
                  required
                />
              </div>
              <div class="col-md-12 mb-3">
                <input
                  v-model="editable.description"
                  type="checkbox"
                  class="form-check-input"
                  name="vault-private"
                  required
                />
                <label for="vault-description" class="form-check-label ms-3">
                  Private?
                  <div>
                    <small>Private Vaults can only be seen by you</small>
                  </div>
                </label>
              </div>
              <div class="justify-content-end d-flex">
                <button
                  class="btn-color rounded"
                  data-bs-dismiss="modal"
                  @click="createVault"
                >
                  Create
                </button>
              </div>
            </form>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>


<script>
import { watchEffect, ref } from '@vue/runtime-core'
import { vaultsService } from '../services/VaultsService'
import { logger } from '../utils/Logger'
import Pop from '../utils/Pop'
export default {
  props: { vaultData: { type: Object, required: false, default: {} } },
  setup(props) {

    const editable = ref({})
    watchEffect(() => {
      logger.log('watch')
      editable.value = props.vaultData
    })
    return {
      editable,
      async createVault() {
        try {
          await vaultsService.createVault(props.vault.id)
        } catch (error) {
          logger.error(error);
        }
      },
      async handleSubmit() {
        try {
          logger.log("form data", editable.value);
          if (!editable.value.id) {
            await vaultsService.create(editable.value);
            Pop.toast("Vault Created");
          } else {
            await vaultsService.update(editable.value)
            Pop.toast("Vault Updated")
          }
        } catch (error) {

        }
      }
    }
  }
}
</script>


<style lang="scss" scoped>
.btn-color {
  background-color: #0096fa;
  border: none;
  padding: 10px 20px;
  color: white;
}
</style>
