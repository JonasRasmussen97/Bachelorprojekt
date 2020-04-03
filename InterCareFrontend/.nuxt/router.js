import Vue from 'vue'
import Router from 'vue-router'
import { interopDefault } from './utils'
import scrollBehavior from './router.scrollBehavior.js'

const _449bf11c = () => interopDefault(import('..\\pages\\admin.vue' /* webpackChunkName: "pages_admin" */))
const _6a34a4ce = () => interopDefault(import('..\\pages\\client.vue' /* webpackChunkName: "pages_client" */))
const _289c758c = () => interopDefault(import('..\\pages\\manager.vue' /* webpackChunkName: "pages_manager" */))
const _15a45ec3 = () => interopDefault(import('..\\pages\\oadmin.vue' /* webpackChunkName: "pages_oadmin" */))
const _132c9d1f = () => interopDefault(import('..\\pages\\index.vue' /* webpackChunkName: "pages_index" */))

// TODO: remove in Nuxt 3
const emptyFn = () => {}
const originalPush = Router.prototype.push
Router.prototype.push = function push (location, onComplete = emptyFn, onAbort) {
  return originalPush.call(this, location, onComplete, onAbort)
}

Vue.use(Router)

export const routerOptions = {
  mode: 'history',
  base: decodeURI('/'),
  linkActiveClass: 'nuxt-link-active',
  linkExactActiveClass: 'nuxt-link-exact-active',
  scrollBehavior,

  routes: [{
    path: "/admin",
    component: _449bf11c,
    name: "admin"
  }, {
    path: "/client",
    component: _6a34a4ce,
    name: "client"
  }, {
    path: "/manager",
    component: _289c758c,
    name: "manager"
  }, {
    path: "/oadmin",
    component: _15a45ec3,
    name: "oadmin"
  }, {
    path: "/",
    component: _132c9d1f,
    name: "index"
  }],

  fallback: false
}

export function createRouter () {
  return new Router(routerOptions)
}
