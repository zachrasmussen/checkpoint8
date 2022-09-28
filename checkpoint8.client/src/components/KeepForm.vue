<template>
  <div class="row">
    <div class="col-12">
      <div
        class="modal fade"
        id="keep-form"
        tabindex="-1"
        role="dialog"
        aria-labelledby="exampleModalLabel"
        aria-hidden="true"
      >
        <div class="modal-dialog modal-dialog-centered modal-md">
          <div class="modal-content">
            <form class="row p-3" @submit.prevent="handleSubmit">
              <h3 class="mb-4">New Keep</h3>
              <div class="col-md-12 mb-3">
                <label for="keep-name" class="form-label">Keep Name</label>
                <input
                  v-model="editable.name"
                  type="text"
                  class="form-control"
                  name="keep-name"
                  placeholder="Name"
                  required
                />
              </div>
              <div class="col-md-12 mb-3">
                <label for="keep-img" class="form-label">Image</label>
                <input
                  v-model="editable.img"
                  type="text"
                  class="form-control"
                  name="keep-name"
                  placeholder="Add URL"
                  required
                />
              </div>
              <div class="col-md-12 mb-3">
                <label for="keep-description" class="form-label"
                  >Description</label
                >
                <textarea
                  v-model="editable.description"
                  type="textarea"
                  style="height: 100px"
                  class="form-control"
                  name="keep-name"
                  placeholder="Description"
                  required
                />
              </div>
              <div class="justify-content-end d-flex">
                <button
                  class="btn-color rounded"
                  data-bs-dismiss="modal"
                  @click="createKeep"
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
import { keepsService } from '../services/KeepsService'
import { logger } from '../utils/Logger'
import Pop from '../utils/Pop'
export default {
  props: { keepData: { type: Object, required: false, default: {} } },
  setup(props) {

    const editable = ref({})
    watchEffect(() => {
      logger.log('watch')
      editable.value = props.keepData
    })
    return {
      editable,
      async createKeep() {
        try {
          await keepsService.create(props.keep.id)
        } catch (error) {
          logger.error(error);
        }
      },
      async handleSubmit() {
        try {
          logger.log("form data", editable.value);
          if (!editable.value.id) {
            await keepsService.create(editable.value);
            Pop.toast("Keep Created");
          } else {
            await keepsService.update(editable.value)
            Pop.toast("Keep Updated")
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
