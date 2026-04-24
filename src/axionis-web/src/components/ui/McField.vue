<script setup lang="ts">
defineProps<{
  label?: string
  hint?: string
  forId?: string
}>()
</script>

<template>
  <div class="ax-field">
    <label v-if="label" class="ax-field__label" :for="forId">{{ label }}</label>
    <div class="ax-field__control">
      <slot />
    </div>
    <p v-if="hint" class="ax-field__hint">{{ hint }}</p>
  </div>
</template>

<style scoped>
.ax-field {
  margin-bottom: 1rem;
}
.ax-field__label {
  display: block;
  font-size: 0.8rem;
  font-weight: 700;
  color: var(--ax-app-text-secondary, #1e293b);
  margin-bottom: 0.45rem;
  letter-spacing: 0.02em;
}
.ax-field__control :deep(input),
.ax-field__control :deep(select),
.ax-field__control :deep(textarea) {
  width: 100%;
  max-width: 100%;
  min-height: 46px;
  padding: 0.6rem 0.85rem;
  border-radius: var(--ax-app-radius-control, 10px);
  border: 1.5px solid var(--ax-app-border-subtle, #94a3b8);
  background: var(--ax-app-surface, #fff);
  color: var(--ax-app-text, #0f172a);
  font: inherit;
  font-size: 1rem;
  box-sizing: border-box;
  transition: border-color 0.15s ease, box-shadow 0.15s ease;
}
.ax-field__control :deep(textarea) {
  min-height: 88px;
  resize: vertical;
}
.ax-field__control :deep(input:hover),
.ax-field__control :deep(select:hover),
.ax-field__control :deep(textarea:hover) {
  border-color: var(--ax-app-border, #64748b);
}
.ax-field__control :deep(input:focus),
.ax-field__control :deep(select:focus),
.ax-field__control :deep(textarea:focus) {
  outline: none;
  border-color: var(--ax-accent, #06b6d4);
  box-shadow: inset 0 0 0 1px var(--ax-accent, #06b6d4);
}
.ax-field__hint {
  margin: 0.4rem 0 0;
  font-size: 0.8125rem;
  color: var(--ax-app-text-muted, #4a4842);
  line-height: 1.4;
}
</style>
