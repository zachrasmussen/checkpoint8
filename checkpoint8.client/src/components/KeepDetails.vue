<template>
  <!-- SECTION once the KeepCard is clicked, this is the modal that pops up. -->
  <div class="row">
    <div class="col-12">
      <div
        class="modal fade"
        id="keep-details"
        tabindex="-1"
        role="dialog"
        aria-labelledby="exampleModalLabel"
        aria-hidden="true"
      >
        <div class="modal-dialog modal-dialog-centered modal-xl">
          <div class="modal-content">
            <b>{{ keep?.name }}</b>
            <h1>is this working? is it</h1>
            <p>{{ keep?.description }}</p>
          </div>
        </div>
      </div>
    </div>
  </div>
  <!--  -->
</template>

<script>
import { computed } from '@vue/runtime-core';
import { AppState } from '../AppState';
export default {
  setup() {
    return {
      keep: computed(() => AppState.activeKeep)
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
</style>
