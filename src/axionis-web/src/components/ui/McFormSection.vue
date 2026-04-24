<script setup lang="ts">
defineProps<{
  title?: string
  description?: string
  /** Layout: single column (default) or 2-col grid on wider screens. */
  columns?: 1 | 2
}>()
</script>

<template>
  <section class="ax-form-section">
    <header v-if="title || description" class="ax-form-section__head">
      <h3 v-if="title" class="ax-form-section__title">{{ title }}</h3>
      <p v-if="description" class="ax-form-section__desc">{{ description }}</p>
    </header>
    <div class="ax-form-section__grid" :class="`ax-form-section__grid--${columns ?? 1}`">
      <slot />
    </div>
  </section>
</template>

<style scoped>
.ax-form-section {
  display: flex;
  flex-direction: column;
  gap: 0.8rem;
  padding: 1.2rem 1.3rem;
  background: var(--ax-app-surface, #fff);
  border: 1px solid var(--ax-app-border-faint, #e2e8f0);
  border-radius: 14px;
}
.ax-form-section__head {
  display: flex;
  flex-direction: column;
  gap: 0.15rem;
}
.ax-form-section__title {
  margin: 0;
  font-size: 1rem;
  font-weight: 700;
  color: var(--ax-app-text, #0f172a);
  font-family: 'Barlow Condensed', 'Arial Narrow', sans-serif;
  letter-spacing: 0.05em;
  text-transform: uppercase;
}
.ax-form-section__desc {
  margin: 0;
  color: var(--ax-app-text-muted, #475569);
  font-size: 0.88rem;
}
.ax-form-section__grid {
  display: grid;
  gap: 0.75rem;
}
.ax-form-section__grid--1 { grid-template-columns: 1fr; }
.ax-form-section__grid--2 { grid-template-columns: repeat(2, minmax(0, 1fr)); }

@media (max-width: 640px) {
  .ax-form-section { padding: 1rem; }
  .ax-form-section__grid--2 { grid-template-columns: 1fr; }
}
</style>
