<script setup lang="ts">
defineProps<{
  /** Max container width. Defaults to "lg". */
  width?: 'sm' | 'md' | 'lg' | 'xl' | 'full'
  /** Removes outer padding when you need an edge-to-edge page. */
  flush?: boolean
}>()
</script>

<template>
  <div
    class="ax-page"
    :class="[
      `ax-page--${width ?? 'lg'}`,
      { 'ax-page--flush': flush }
    ]"
  >
    <slot />
  </div>
</template>

<style scoped>
.ax-page {
  width: 100%;
  margin-inline: auto;
  padding: var(--ax-app-pad-page-y, 1.5rem) var(--ax-app-pad-page-x, 2rem);
  display: flex;
  flex-direction: column;
  gap: 1.25rem;
}
.ax-page--flush {
  padding: 0;
}
.ax-page--sm { max-width: var(--ax-container-sm); }
.ax-page--md { max-width: var(--ax-container-md); }
.ax-page--lg { max-width: var(--ax-container-lg); }
.ax-page--xl { max-width: var(--ax-container-xl); }
.ax-page--full { max-width: none; }

@media (max-width: 720px) {
  .ax-page {
    padding: 1rem;
    gap: 1rem;
  }
}
</style>
