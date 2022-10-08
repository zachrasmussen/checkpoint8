<template>
  <div class="about text-center">
    <h1>Welcome {{ account.name }}</h1>
    <img class="rounded" :src="account.picture" alt="" />
    <p>{{ account.email }}</p>
  </div>
  <div class="row">
    <div class="col-12 d-flex justify-content-between p-3 mt-5">
      <h4 class="offset-1">
        Create Your First Keep!
        <span class="add" data-bs-toggle="modal" data-bs-target="#keep-form">
          ⊕
        </span>
      </h4>
    </div>
  </div>
  <KeepForm />
</template>

<script>
import { computed } from 'vue'
import { AppState } from '../AppState'
export default {
  name: 'Account',
  setup() {
    return {
      account: computed(() => AppState.account)
    }
  }
}
</script>

<style scoped>
img {
  max-width: 100px;
}
.add {
  color: #0096fa;
  cursor: pointer;
}
</style>
