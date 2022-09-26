<template>
  <section
    class="p-4 justify-content-md-start justify-content-center"
    @click="SetActive()"
  >
    <div class="col-10 col-md-3 keep-title-card">
      <img
        class="keep-img img-fluid rounded shadow selectable"
        :src="keep.img"
        alt=""
      />
      <div class="col-12 col-md-12 justify-content-center d-flex title-card">
        <h3
          class="
            col-10 col-md-10
            text-white text-start
            p-2
            item-name
            text-center
          "
        >
          {{ keep.name }}
        </h3>
      </div>
    </div>
  </section>
  <!-- <KeepModal /> -->
</template>
<script>
import { keepsService } from '../services/KeepsService';

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
          Modal.getOrCreateInstance(document.getElementById("keepModal")).toggle();
          await keepsService.getById(props.keep.id)
        } catch (error) {
          logger.error(error);
        }
      }
    };
  },
  //   components: { KeepModal }
};
</script>
<style>
.keep-img {
  height: 20em;
  width: 100%;
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
}
</style>