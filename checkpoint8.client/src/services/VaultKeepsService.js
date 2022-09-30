import { AppState } from "../AppState"
import { logger } from "../utils/Logger"
import { api } from "./AxiosService"


class VaultKeepsService {
    async getVaultKeep(id) {

        const res = await api.get(`api/vaults/${id}/keeps`)
        logger.log('Got VaultKeeps', res.data)
        AppState.vaultKeeps = res.data
    }

    async deleteVaultKeep(id) {
        const res = await api.delete('api/vaultKeeps/' + id)
        logger.log('vault deleted', res.data)
        AppState.vaultKeeps = AppState.vaultKeeps.filter(vk => vk.id != id)
    }
}

export const vaultKeepsService = new VaultKeepsService()