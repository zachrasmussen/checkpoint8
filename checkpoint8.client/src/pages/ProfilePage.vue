<template>
  <div class="container-fluid">
    <!-- SECTION img, name, stats -->
    <div class="row">
      <div
        class="col-12 d-flex justify-content-evenly align-items-center p-3 mt-5"
      >
        <div>
          <img class="col-4 rounded pro-img" :src="account.picture" alt="" />
        </div>
        <div class="col-8 justify-content-start">
          <h1>{{ account.name }}</h1>
          <h5>Vaults:</h5>
          <h5>Keeps</h5>
        </div>
      </div>
    </div>
    <!--  -->
    <!-- SECTION user's vaults -->
    <div class="row">
      <div class="col-12 d-flex justify-content-between p-3 mt-5">
        <h4 class="offset-1">
          Vaults
          <span class="add">⊕</span>
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
          <span class="add" data-bs-toggle="modal" data-bs-target="#keep-form"
            >⊕</span
          >
          <KeepForm />
        </h4>
      </div>
    </div>

    <!--  -->
  </div>
</template>

<script>

import { computed } from 'vue'
import { AppState } from '../AppState'
export default {
  name: 'Profile',
  props: {
    keep: {
      type: Object,
      required: true
    }
  },

  setup() {
    return {
      account: computed(() => AppState.account)
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
