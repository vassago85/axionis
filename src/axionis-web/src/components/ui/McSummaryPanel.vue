<script setup lang="ts">
defineProps<{
  title?: string
  /** When true, the panel sticks to the top on wide screens (useful for cart totals). */
  sticky?: boolean
}>()
</script>

<template>
  <aside class="ax-summary" :class="{ 'ax-summary--sticky': sticky }">
    <header v-if="title || $slots.header" class="ax-summary__head">
      <slot name="header">
        <h3 class="ax-summary__title">{{ title }}</h3>
      </slot>
    </header>
    <div class="ax-summary__body">
      <slot />
    </div>
    <footer v-if="$slots.footer" class="ax-summary__foot">
      <slot name="footer" />
    </footer>
  </aside>
</template>

<style scoped>
.ax-summary {
  background: var(--ax-app-surface, #fff);
  border: 1px solid var(--ax-app-border-faint, #e2e8f0);
  border-radius: var(--ax-app-radius-card, 18px);
  box-shadow: var(--ax-app-shadow-xs, 0 1px 2px rgba(0,0,0,0.06));
  display: flex;
  flex-direction: column;
  overflow: hidden;
}
.ax-summary--sticky {
  position: sticky;
  top: 1rem;
}
.ax-summary__head {
  padding: 1rem 1.25rem;
  border-bottom: 1px solid var(--ax-app-border-faint, #e2e8f0);
  background: var(--ax-app-surface-2, #f8fafc);
}
.ax-summary__title {
  margin: 0;
  font-size: 0.85rem;
  letter-spacing: 0.1em;
  text-transform: uppercase;
  font-family: 'Barlow Condensed', 'Arial Narrow', sans-serif;
  color: var(--ax-app-text-secondary, #1e293b);
}
.ax-summary__body {
  padding: 1rem 1.25rem;
  display: flex;
  flex-direction: column;
  gap: 0.5rem;
}
.ax-summary__foot {
  padding: 0.85rem 1.25rem;
  border-top: 1px solid var(--ax-app-border-faint, #e2e8f0);
  background: var(--ax-app-surface-2, #f8fafc);
  display: flex;
  flex-direction: column;
  gap: 0.5rem;
}
</style>
