<script setup lang="ts">
defineProps<{
  title: string
  description?: string
}>()
</script>

<template>
  <header class="ax-page-header">
    <div class="ax-page-header__text">
      <h1 class="ax-page-header__title">{{ title }}</h1>
      <p v-if="description || $slots.default" class="ax-page-header__desc">
        <slot>{{ description }}</slot>
      </p>
    </div>
    <div v-if="$slots.actions" class="ax-page-header__actions">
      <slot name="actions" />
    </div>
  </header>
</template>

<style scoped>
.ax-page-header {
  display: flex;
  flex-wrap: wrap;
  align-items: flex-start;
  justify-content: space-between;
  gap: 1rem 1.5rem;
  margin-bottom: 2rem;
  padding-bottom: 1.25rem;
  border-bottom: 2px solid var(--ax-app-border-faint, #e2e8f0);
}
.ax-page-header__title {
  margin: 0 0 0.35rem;
  font-family: 'Barlow Condensed', 'Arial Narrow', sans-serif;
  font-size: clamp(1.75rem, 3.2vw, 2.2rem);
  font-weight: 700;
  letter-spacing: 0.045em;
  text-transform: uppercase;
  color: var(--ax-app-heading, #020617);
  line-height: 1.08;
}
.ax-page-header__desc {
  margin: 0;
  max-width: 58ch;
  font-size: 0.9375rem;
  color: var(--ax-app-text-muted, #475569);
  line-height: 1.55;
  font-weight: 500;
}
.ax-page-header__actions {
  display: flex;
  flex-wrap: wrap;
  gap: 0.6rem;
  align-items: center;
}
</style>
