<template>
  <router-link
    :to="{
      name: 'Vault',
      params: { id: vault.id },
    }"
  >
    <div class="p-3 vault-title-card rounded">
      <img
        class="vault-img img-fluid rounded selectable"
        :src="vault.img"
        alt=""
      />
      <!-- <div class="title-card justify-content-center d-flex p-3">
        <h3 class="text-white text-start p-2 vault-name text-center">
          {{ vault.name }}
        </h3>
        <img
          :src="vault?.creator.picture"
          class="creator-img rounded-circle"
          alt=""
        />
      </div> -->
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

.vault-name {
  position: absolute;
  bottom: 0;
  font-size: 1.25em;
  text-shadow: 1px 1px 1px #000000;
}
.creator-img {
  width: 50px;
}
</style>