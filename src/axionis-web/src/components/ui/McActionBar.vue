<script setup lang="ts">
defineProps<{
  hint?: string
}>()
</script>

<template>
  <div class="ax-action-bar">
    <div class="ax-action-bar__actions">
      <slot />
    </div>
    <p v-if="hint" class="ax-action-bar__hint">{{ hint }}</p>
  </div>
</template>

<style scoped>
.ax-action-bar {
  margin-top: 1.5rem;
  padding-top: 1.5rem;
  border-top: 2px solid var(--ax-app-border-faint, #e2e8f0);
}
.ax-action-bar__actions {
  display: flex;
  flex-wrap: wrap;
  gap: 0.75rem;
  align-items: center;
}
.ax-action-bar__hint {
  margin: 0.75rem 0 0;
  font-size: 0.8125rem;
  color: var(--ax-app-text-muted, #475569);
  line-height: 1.45;
}
</style>
