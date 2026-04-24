<script setup lang="ts">
defineProps<{
  title?: string
  description?: string
}>()
</script>

<template>
  <section class="ax-page-section">
    <header v-if="title || description || $slots.actions || $slots.header" class="ax-page-section__head">
      <div class="ax-page-section__text">
        <h2 v-if="title" class="ax-page-section__title">{{ title }}</h2>
        <p v-if="description" class="ax-page-section__desc">{{ description }}</p>
        <slot name="header" />
      </div>
      <div v-if="$slots.actions" class="ax-page-section__actions">
        <slot name="actions" />
      </div>
    </header>
    <div class="ax-page-section__body">
      <slot />
    </div>
  </section>
</template>

<style scoped>
.ax-page-section {
  display: flex;
  flex-direction: column;
  gap: 0.9rem;
}
.ax-page-section__head {
  display: flex;
  justify-content: space-between;
  align-items: flex-end;
  gap: 1rem;
  flex-wrap: wrap;
}
.ax-page-section__text {
  display: flex;
  flex-direction: column;
  gap: 0.25rem;
  min-width: 0;
  flex: 1 1 auto;
}
.ax-page-section__title {
  margin: 0;
  font-size: 1.1rem;
  font-weight: 700;
  font-family: 'Barlow Condensed', 'Arial Narrow', sans-serif;
  letter-spacing: 0.04em;
  text-transform: uppercase;
  color: var(--ax-app-heading, #020617);
}
.ax-page-section__desc {
  margin: 0;
  color: var(--ax-app-text-muted, #475569);
  font-size: 0.9rem;
}
.ax-page-section__actions {
  display: flex;
  gap: 0.5rem;
  flex-wrap: wrap;
}
.ax-page-section__body {
  display: flex;
  flex-direction: column;
  gap: 0.75rem;
}
</style>
