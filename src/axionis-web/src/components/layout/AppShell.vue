<script setup lang="ts">
import { ref, computed, watch } from 'vue'
import { useRoute, useRouter } from 'vue-router'
import { useAuthStore } from '@/stores/auth'
import { logoLight } from '@/branding'
import { useBranding } from '@/composables/useBranding'
import {
  Menu, ChevronLeft, ChevronRight,
  ShoppingCart, Search, Package, ClipboardList, Truck, PackagePlus,
  PackageCheck, Upload, BarChart3, DollarSign, Mail, Users, Building2,
  Settings as SettingsIcon,
  FileText,
  Printer,
  Store,
  LogOut
} from 'lucide-vue-next'

const auth = useAuthStore()
const route = useRoute()
const router = useRouter()
const sidebarOpen = ref(false)
const { businessName, logoUrl, features, terminology } = useBranding()
const brandLogo = computed(() => logoUrl.value ?? logoLight)

const isStandalone = ref(
  window.matchMedia('(display-mode: standalone)').matches ||
  (navigator as any).standalone === true
)

const canGoBack = computed(() => window.history.length > 1)

watch(
  () => route.fullPath,
  () => {
    sidebarOpen.value = false
  }
)

function goBack() {
  router.back()
}

function goForward() {
  router.forward()
}

function logout() {
  auth.clear()
  router.push('/login')
}
</script>

<template>
  <div class="ax-shell" :class="{ 'ax-shell--standalone': isStandalone }">
    <div
      class="ax-sidebar-overlay"
      :class="{ 'ax-sidebar-overlay--visible': sidebarOpen }"
      aria-hidden="true"
      @click="sidebarOpen = false"
    />
    <aside class="ax-sidebar" :class="{ 'ax-sidebar--open': sidebarOpen }">
      <div class="ax-sidebar__brand">
        <img class="ax-sidebar__logo" :src="brandLogo" :alt="businessName" />
        <p class="ax-sidebar__tag">Point of sale</p>
      </div>
      <nav class="ax-sidebar__nav" aria-label="Main">
        <div class="ax-nav-group">
          <p class="ax-nav-group__label">Sell</p>
          <RouterLink class="ax-nav-link" to="/pos" @click="sidebarOpen = false"><ShoppingCart :size="16" />POS</RouterLink>
          <RouterLink v-if="features.quotes" class="ax-nav-link" to="/quotes" @click="sidebarOpen = false"><FileText :size="16" />{{ terminology.quote }}s</RouterLink>
          <RouterLink class="ax-nav-link" to="/price-lookup" @click="sidebarOpen = false"><Search :size="16" />Price lookup</RouterLink>
        </div>
        <div class="ax-nav-group">
          <p class="ax-nav-group__label">Inventory</p>
          <RouterLink class="ax-nav-link" to="/stock" @click="sidebarOpen = false"><Package :size="16" />Stock list</RouterLink>
          <RouterLink class="ax-nav-link" to="/stock/labels" @click="sidebarOpen = false"><Printer :size="16" />Print labels</RouterLink>
          <RouterLink class="ax-nav-link" to="/stocktake" @click="sidebarOpen = false"><ClipboardList :size="16" />Stocktake</RouterLink>
          <RouterLink class="ax-nav-link" to="/consignment" @click="sidebarOpen = false"><Truck :size="16" />Stock batches</RouterLink>
          <RouterLink v-if="auth.hasRole('Admin', 'Owner', 'Dev')" class="ax-nav-link" to="/receiving" @click="sidebarOpen = false"><PackagePlus :size="16" />Receive stock</RouterLink>
        </div>
        <div v-if="auth.hasVendorScope" class="ax-nav-group">
          <p class="ax-nav-group__label">Vendor</p>
          <RouterLink class="ax-nav-link" to="/vendor-report" @click="sidebarOpen = false"><Store :size="16" />My vendor report</RouterLink>
        </div>
        <div v-if="auth.hasRole('Admin', 'Owner', 'Dev')" class="ax-nav-group">
          <p class="ax-nav-group__label">Office</p>
          <RouterLink class="ax-nav-link" to="/deliveries" @click="sidebarOpen = false"><PackageCheck :size="16" />Deliveries</RouterLink>
          <RouterLink class="ax-nav-link" to="/wholesalers" @click="sidebarOpen = false"><Building2 :size="16" />Wholesalers</RouterLink>
          <RouterLink class="ax-nav-link" to="/import" @click="sidebarOpen = false"><Upload :size="16" />Import</RouterLink>
          <RouterLink class="ax-nav-link" to="/reports" @click="sidebarOpen = false"><BarChart3 :size="16" />Reports</RouterLink>
          <RouterLink class="ax-nav-link" to="/settings" @click="sidebarOpen = false"><DollarSign :size="16" />Pricing</RouterLink>
          <RouterLink class="ax-nav-link" to="/settings/business" @click="sidebarOpen = false"><SettingsIcon :size="16" />Business</RouterLink>
          <RouterLink class="ax-nav-link" to="/setup" @click="sidebarOpen = false"><Mail :size="16" />Email setup</RouterLink>
          <RouterLink class="ax-nav-link" to="/admin/team" @click="sidebarOpen = false"><Users :size="16" />Team</RouterLink>
        </div>
      </nav>
      <div class="ax-sidebar__foot">
        <button type="button" class="ax-sidebar__logout" @click="logout"><LogOut :size="16" />Log out</button>
      </div>
    </aside>
    <div class="ax-main">
      <header class="ax-topbar">
        <button type="button" class="ax-topbar__menu" aria-label="Open menu" @click="sidebarOpen = true"><Menu :size="20" /></button>
        <button
          type="button"
          class="ax-topbar__nav-btn"
          :class="{ 'ax-topbar__nav-btn--disabled': !canGoBack }"
          :disabled="!canGoBack"
          aria-label="Go back"
          @click="goBack"
        ><ChevronLeft :size="20" /></button>
        <button
          type="button"
          class="ax-topbar__nav-btn"
          aria-label="Go forward"
          @click="goForward"
        ><ChevronRight :size="20" /></button>
        <span class="brand-wordmark" style="font-size: 0.95rem; color: #2a2a2d">{{ businessName }}</span>
      </header>
      <div class="ax-main__inner">
        <slot />
      </div>
    </div>
  </div>
</template>
