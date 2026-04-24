<script setup lang="ts">
defineProps<{
  modelValue: string
  value: string
  title: string
  description?: string
}>()

defineEmits<{
  'update:modelValue': [value: string]
}>()
</script>

<template>
  <label
    class="ax-radio-card"
    :class="{ 'ax-radio-card--selected': modelValue === value }"
    @click="$emit('update:modelValue', value)"
  >
    <input
      type="radio"
      class="ax-radio-card__input"
      :checked="modelValue === value"
      :value="value"
      @change="$emit('update:modelValue', value)"
    />
    <span class="ax-radio-card__body">
      <span class="ax-radio-card__title">{{ title }}</span>
      <span v-if="description" class="ax-radio-card__desc">{{ description }}</span>
    </span>
  </label>
</template>

<style scoped>
.ax-radio-card {
  display: flex;
  align-items: flex-start;
  gap: 0.75rem;
  padding: 1rem 1.15rem;
  border-radius: var(--ax-app-radius-control, 10px);
  border: 1.5px solid var(--ax-app-border-soft, #cbd5e1);
  background: var(--ax-app-surface, #fff);
  cursor: pointer;
  transition: border-color 0.15s ease, background 0.15s ease, box-shadow 0.15s ease;
}
.ax-radio-card:hover {
  border-color: var(--ax-app-border, #64748b);
}
.ax-radio-card--selected {
  border-color: var(--ax-accent, #06b6d4);
  background: rgba(6, 182, 212, 0.04);
  box-shadow: inset 3px 0 0 var(--ax-accent, #06b6d4);
}
.ax-radio-card--selected:hover {
  border-color: var(--ax-accent, #06b6d4);
}
.ax-radio-card__input {
  flex-shrink: 0;
  width: 1.2rem;
  height: 1.2rem;
  margin-top: 0.15rem;
  accent-color: var(--ax-accent, #06b6d4);
  cursor: pointer;
}
.ax-radio-card__body {
  display: flex;
  flex-direction: column;
  gap: 0.2rem;
}
.ax-radio-card__title {
  font-weight: 700;
  font-size: 0.9375rem;
  color: var(--ax-app-text, #0f172a);
  line-height: 1.3;
}
.ax-radio-card--selected .ax-radio-card__title {
  color: var(--ax-accent-dim, #0891b2);
}
.ax-radio-card__desc {
  font-size: 0.8125rem;
  color: var(--ax-app-text-muted, #475569);
  line-height: 1.45;
}
</style>
