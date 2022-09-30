<template>
  <router-link
    :to="{
      name: 'Vault',
      params: { id: vault.id },
    }"
  >
    <div class="p-3 vault-title-card">
      <img
        class="vault-img img-fluid rounded shadow selectable"
        :src="vault.img"
        alt=""
      />
      <div class="title-card">
        <h3 class="text-white text-start p-2 item-name text-center">
          {{ vault.name }}
        </h3>
        <!-- <img
        :src="vault?.creator.picture"
        class="creator-img rounded-circle"
        alt=""
      /> -->
      </div>
    </div>
    <VaultDetails />
  </router-link>
</template>

<script>
import { Modal } from 'bootstrap';
import { logger } from '../utils/Logger';
import { vaultsService } from '../services/VaultsService';
import VaultDetails from './VaultDetails.vue';

export default {
  props: {
    vault: {
      type: Object,
      required: true
    }
  },
  setup(props) {
    return {
      //add @click to set active when clicked
      async setActive() {
        try {
          await vaultsService.getById(props.vault.id)
        } catch (error) {
          logger.error(error);
        }
      }
    };
  },
  components: { VaultDetails }
};
</script>
<style>
.vault-img {
  object-fit: cover;
  object-position: center;
}
.vault-title-card div {
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
.creator-img {
  width: 50px;
}
</style>