<script setup lang="ts">
defineProps<{
  modelValue: boolean
  label: string
  hint?: string
}>()

defineEmits<{
  'update:modelValue': [value: boolean]
}>()
</script>

<template>
  <label class="ax-check">
    <input
      type="checkbox"
      class="ax-check__input"
      :checked="modelValue"
      @change="$emit('update:modelValue', ($event.target as HTMLInputElement).checked)"
    />
    <span class="ax-check__body">
      <span class="ax-check__label">{{ label }}</span>
      <span v-if="hint" class="ax-check__hint">{{ hint }}</span>
    </span>
  </label>
</template>

<style scoped>
.ax-check {
  display: flex;
  align-items: flex-start;
  gap: 0.65rem;
  cursor: pointer;
  padding: 0.5rem 0;
}
.ax-check__input {
  flex-shrink: 0;
  width: 1.25rem;
  height: 1.25rem;
  margin-top: 0.1rem;
  accent-color: var(--ax-accent, #06b6d4);
  cursor: pointer;
}
.ax-check__body {
  display: flex;
  flex-direction: column;
  gap: 0.15rem;
}
.ax-check__label {
  font-weight: 600;
  font-size: 0.9375rem;
  color: var(--ax-app-text-secondary, #1e293b);
  line-height: 1.4;
}
.ax-check__hint {
  font-size: 0.8125rem;
  color: var(--ax-app-text-muted, #475569);
  line-height: 1.4;
}
</style>
