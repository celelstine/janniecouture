
import axios from 'axios'

export const fetchAgeRange = ({ commit, state }) => {
    commit("PROCESSING_REQUEST");
    axios.get(`${state.domainUrl}/api/AgeRange`).then(response => {
        commit("FECTH_AGERANGE", response.data);
    }).catch(err => {
        commit("ERROR", err.response.data);
    });
}
