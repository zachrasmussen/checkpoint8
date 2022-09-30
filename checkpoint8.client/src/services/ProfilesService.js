import { AppState } from "../AppState"
import { logger } from "../utils/Logger"
import Pop from "../utils/Pop"
import { api } from "./AxiosService"

class ProfilesService {
    async getProfile(id) {
        const res = await api.get(`api/profiles/${id}`)
        AppState.activeProfile = res.data
    }

    // async getProfileKeeps(id) {
    //     try {
    //         const res = await api.get(`api/profiles/${id}/keeps`)
    //         if (AppState.profile.id === id) {

    //         }
    //         AppState.profileKeeps = res.data
    //         console.log("[GET PROFILE KEEPS]", res.data)
    //     }
    //     catch (error) {
    //         logger.log(error);
    //         Pop.toast(error.message, "couldn't find your keeps")
    //     }
    // }
}
export const profilesService = new ProfilesService()