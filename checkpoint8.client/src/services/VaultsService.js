import { AppState } from "../AppState"
import { logger } from "../utils/Logger"
import { api } from "./AxiosService"

class VaultsService {
    async getVaults() {
        const res = await api.get('api/vaults')
        // logger.log(res.data, 'getting vault')
        AppState.vaults = res.data
        // logger.log('appstate', AppState.vault)
    }

    async getById(id) {
        const res = await api.get(`api/vaults/${id}`)
        // logger.log('[Get By Id]', res.data)
        AppState.activeVault = res.data
        // logger.log('[Active]', AppState.activeVault)
    }

    async getVaultsByProfile(id) {
        const res = await api.get(`api/profiles/${id}/vaults`)
        logger.log('[Get By Id]', res.data)
        AppState.vaults = res.data
        logger.log('[Active]', AppState.vaults)
    }

    async deleteVault(id) {
        const res = await api.delete('api/vaults/' + id)
        logger.log('vault deleted', res.data)
        AppState.vaults = AppState.vaults.filter(k => k.id != id)
    }

    async createVault(vault) {
        const res = await api.post('api/vaults', vault)
        logger.log('Created Vault', res.data)
        AppState.vaults.push(res.data)
    }
}

export const vaultsService = new VaultsService()