<template>
  <div class="p-3 keep-title-card">
    <img
      @click="setActive"
      class="keep-img img-fluid rounded shadow selectable"
      :src="keep.img"
      alt=""
      data-bs-toggle="modal"
      data-bs-target="#keep-details"
    />
    <div class="justify-content-center d-flex title-card">
      <h3 class="text-white text-start p-2 item-name text-center">
        {{ keep.name }}
      </h3>
    </div>
  </div>
  <KeepDetails />
</template>

<script>
import { Modal } from 'bootstrap';
import { logger } from '../utils/Logger';
import { keepsService } from '../services/KeepsService';
import KeepDetails from './KeepDetails.vue';

export default {
  props: {
    keep: {
      type: Object,
      required: true
    }
  },
  setup(props) {
    return {
      async setActive() {
        try {
          Modal.getOrCreateInstance(document.getElementById("keep-details")).toggle();
          await keepsService.getById(props.keep.id)
        } catch (error) {
          logger.error(error);
        }
      }
    };
  },
  components: { KeepDetails }
};
</script>
<style>
.keep-img {
  object-fit: cover;
  object-position: center;
}
.keep-title-card div {
  position: relative;
}

.item-name {
  position: absolute;
  bottom: 0;
  background: rgba(218, 217, 217, 0.4);
  border: 0.5px solid #a3a3a3;
  backdrop-filter: blur(10px);
  font-size: 1em;
}
</style>