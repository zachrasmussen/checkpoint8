import { AppState } from "../AppState"
import { logger } from "../utils/Logger"
import Pop from "../utils/Pop"
import { api } from "./AxiosService"

class ProfilesService {
    async getProfile(id) {
        try {
            const res = await api.get(`api/profiles/${id}`)
            AppState.activeProfile = res.data
        } catch (error) {
            console.error(error)
            Pop.toast(error.message)
        }
    }

    async getProfileKeeps(id) {
        try {
            const res = await api.get(`api/profiles/${id}/keeps`)
            if (AppState.account.id === id) {
                AppState.userKeeps = res.data
            }
            AppState.profileKeeps = res.data
        }
        catch (error) {
            logger.log(error);
            Pop.toast(error.message, "couldn't find your keeps")
        }
    }
}
export const profilesService = new ProfilesService()