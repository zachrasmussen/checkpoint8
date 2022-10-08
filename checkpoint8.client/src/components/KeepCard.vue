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
    <div class="keep-title-card m-2">
      <h3
        class="
          text-white text-start
          justify-content-between
          d-flex
          align-items-center
          p-3
          item-names
          w-100
          text-start
        "
      >
        {{ keep.name }}
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
.item-names {
  position: absolute;
  bottom: 0;
  font-size: 1.25em;
  text-shadow: 1px 1px 1px #000000;
}
.creator-img {
  width: 50px;
}
</style>