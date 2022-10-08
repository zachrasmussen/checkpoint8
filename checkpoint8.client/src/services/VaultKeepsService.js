import { AppState } from "../AppState"
import { logger } from "../utils/Logger"
import { api } from "./AxiosService"


class VaultKeepsService {
    async getVaultKeep(id) {

        const res = await api.get(`api/vaults/${id}/keeps`)
        logger.log('Got VaultKeeps', res.data)
        AppState.vaultKeeps = res.data
    }

    async deleteVaultKeep(vaultKeepId) {
        const res = await api.delete(`api/vaultkeeps/${vaultKeepId}`)
        logger.log('vault deleted', res.data)
        AppState.vaultKeeps = AppState.vaultKeeps.filter(vk => vk.vaultKeepId != id)
    }

    async creatVaultKeep(keep) {
        const res = await api.post('api/vaultkeeps', keep)
        logger.log('vaultKeep created', res.data)

    }
}

export const vaultKeepsService = new VaultKeepsService()