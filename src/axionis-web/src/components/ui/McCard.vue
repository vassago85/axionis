<script setup lang="ts">
withDefaults(
  defineProps<{
    padded?: boolean
    title?: string
  }>(),
  { padded: true }
)
</script>

<template>
  <section class="ax-card" :class="{ 'ax-card--tight': padded === false }">
    <header v-if="title || $slots.header" class="ax-card__head">
      <slot name="header">
        <h2 class="ax-card__title">{{ title }}</h2>
      </slot>
    </header>
    <div class="ax-card__body">
      <slot />
    </div>
  </section>
</template>

<style scoped>
.ax-card {
  background: var(--ax-app-surface, #ffffff);
  border: 1px solid var(--ax-app-border-soft, #cbd5e1);
  border-radius: var(--ax-app-radius-card, 18px);
  box-shadow: var(--ax-app-shadow-sm, 0 2px 8px rgba(0, 0, 0, 0.08));
  margin-bottom: 1.5rem;
  max-width: 100%;
  min-width: 0;
}
.ax-card--tight .ax-card__body {
  padding: 0;
  overflow: hidden;
}
.ax-card--tight .ax-card__body > :last-child {
  border-radius: 0 0 var(--ax-app-radius-card, 18px) var(--ax-app-radius-card, 18px);
}
.ax-card__head {
  padding: 1.1rem 24px;
  border-bottom: 1px solid var(--ax-app-border-faint, #e2e8f0);
  background: var(--ax-app-surface-2, #f8fafc);
  border-radius: var(--ax-app-radius-card, 18px) var(--ax-app-radius-card, 18px) 0 0;
}
.ax-card__title {
  margin: 0;
  font-family: 'Barlow Condensed', 'Arial Narrow', sans-serif;
  font-size: 0.9375rem;
  font-weight: 700;
  letter-spacing: 0.06em;
  text-transform: uppercase;
  color: var(--ax-app-heading, #020617);
}
.ax-card__body {
  padding: 24px;
  min-width: 0;
  overflow: hidden;
}
@media (max-width: 480px) {
  .ax-card__head {
    padding: 0.9rem 16px;
  }
  .ax-card__body {
    padding: 16px;
  }
}
.ax-card--tight .ax-card__head + .ax-card__body {
  padding: 0;
}
</style>
