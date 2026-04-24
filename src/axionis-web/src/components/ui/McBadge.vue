<script setup lang="ts">
defineProps<{
  variant?: 'neutral' | 'accent' | 'success' | 'warning' | 'danger'
}>()
</script>

<template>
  <span class="ax-badge" :class="`ax-badge--${variant ?? 'neutral'}`">
    <slot />
  </span>
</template>

<style scoped>
.ax-badge {
  display: inline-flex;
  align-items: center;
  padding: 0.25rem 0.6rem;
  border-radius: 8px;
  font-size: 0.6875rem;
  font-weight: 700;
  letter-spacing: 0.055em;
  text-transform: uppercase;
  border: 1px solid transparent;
  line-height: 1.2;
}
.ax-badge--neutral {
  background: var(--ax-app-surface-muted, #e2e8f0);
  border-color: var(--ax-app-border-soft, #cbd5e1);
  color: var(--ax-app-text-secondary, #1e293b);
}
.ax-badge--accent {
  background: rgba(6, 182, 212, 0.1);
  border-color: rgba(6, 182, 212, 0.25);
  color: #9a3c00;
}
.ax-badge--success {
  background: #ecfdf5;
  border-color: #a7f3d0;
  color: #065f46;
}
.ax-badge--warning {
  background: #fffbeb;
  border-color: #fde68a;
  color: #92400e;
}
.ax-badge--danger {
  background: #fef2f2;
  border-color: #fecaca;
  color: #991b1b;
}
</style>
