<script setup lang="ts">
defineProps<{
  title: string
  hint?: string
}>()
</script>

<template>
  <div class="ax-empty">
    <p class="ax-empty__title">{{ title }}</p>
    <p v-if="hint" class="ax-empty__hint">{{ hint }}</p>
    <div v-if="$slots.default" class="ax-empty__actions">
      <slot />
    </div>
  </div>
</template>

<style scoped>
.ax-empty {
  text-align: center;
  padding: 3rem 2rem;
  color: var(--ax-app-text-muted, #475569);
}
.ax-empty__title {
  margin: 0 0 0.5rem;
  font-weight: 700;
  font-size: 1.1rem;
  color: var(--ax-app-text-secondary, #1e293b);
}
.ax-empty__hint {
  margin: 0 auto 1rem;
  max-width: 38ch;
  font-size: 0.9rem;
  line-height: 1.5;
  font-weight: 500;
}
.ax-empty__actions {
  display: flex;
  justify-content: center;
  flex-wrap: wrap;
  gap: 0.5rem;
}
</style>
