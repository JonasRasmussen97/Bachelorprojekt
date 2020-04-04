export const state = () => ({
  JWT: ""
})

export const mutations = {
  changeJWT (state, payload) {
    state.JWT = payload;
  }
}

export const getters = {
  JWT: state => state.JWT
}