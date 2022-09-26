import { AppState } from "../AppState"
import { logger } from "../utils/Logger"
import { api } from "./AxiosService"

class KeepsService {
    async getKeeps() {
        const res = await api.get('api/keeps')
        // logger.log(res.data, 'getting keeps')
        AppState.keeps = res.data
        // logger.log('appstate', AppState.keeps)
    }

    async getById(id) {
        const res = await api.get(`api/keeps/${id}`)
        // logger.log('[Get By Id]', res.data)
        AppState.activeKeep = res.data
        // logger.log('[Active]', AppState.activeKeep)
    }

    async create(keep) {
        const res = await api.post('api/keeps', keep)
        logger.log('Created Keep', res.data)
        AppState.keeps.push(res.data)
    }
}

export const keepsService = new KeepsService()