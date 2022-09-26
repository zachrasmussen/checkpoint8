<template>
  <Modal id="keep-form">
    <div
      class="modal fade"
      id="keep-form"
      tabindex="-1"
      role="dialog"
      aria-labelledby="exampleModalLabel"
      aria-hidden="true"
    >
      <form class="row p-5" @submit.prevent="handleSubmit">
        <div class="col-md-4 mb-3">
          <label for="keep-name" class="form-label">Keep Name</label>
          <input
            v-model="editable.name"
            type="text"
            class="form-controll"
            name="keep-name"
            id="keep-name"
            placeholder="Keep Name"
            required
          />
        </div>
        <div class="col-md-4 mb-3">
          <label for="keep-img" class="form-label">Keep Image</label>
          <input
            v-model="editable.img"
            type="text"
            class="form-controll"
            name="keep-name"
            id="keep-name"
            placeholder="Keep Image"
            required
          />
        </div>
        <div class="col-md-4 mb-3">
          <label for="keep-description" class="form-label"
            >Keep Description</label
          >
          <input
            v-model="editable.description"
            type="text"
            class="form-controll"
            name="keep-name"
            id="keep-name"
            placeholder="Keep Description"
            required
          />
        </div>
      </form>
    </div>
  </Modal>
</template>


<script>
import { watchEffect } from '@vue/runtime-core'
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
</style>
