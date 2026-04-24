<script setup lang="ts">
import { watch, onMounted, onUnmounted } from 'vue'
import { X } from 'lucide-vue-next'

const props = defineProps<{
  modelValue: boolean
  title?: string
  closeOnBackdrop?: boolean
}>()

const emit = defineEmits<{
  'update:modelValue': [v: boolean]
}>()

function close() {
  emit('update:modelValue', false)
}

function onBackdrop() {
  if (props.closeOnBackdrop !== false) close()
}

watch(
  () => props.modelValue,
  (open) => {
    document.body.style.overflow = open ? 'hidden' : ''
  }
)

function onKey(e: KeyboardEvent) {
  if (e.key === 'Escape' && props.modelValue) close()
}

onMounted(() => {
  window.addEventListener('keydown', onKey)
})

onUnmounted(() => {
  document.body.style.overflow = ''
  window.removeEventListener('keydown', onKey)
})
</script>

<template>
  <Teleport to="body">
    <Transition name="ax-modal">
      <div v-if="modelValue" class="ax-modal-root" role="dialog" aria-modal="true" :aria-labelledby="title ? 'ax-modal-title' : undefined">
        <div class="ax-modal-backdrop" @click="onBackdrop" />
        <div class="ax-modal-panel">
          <header v-if="title || $slots.title" class="ax-modal-header">
            <slot name="title">
              <h2 id="ax-modal-title" class="ax-modal-title">{{ title }}</h2>
            </slot>
            <button type="button" class="ax-modal-x" aria-label="Close" @click="close"><X :size="18" /></button>
          </header>
          <div class="ax-modal-body">
            <slot />
          </div>
          <footer v-if="$slots.footer" class="ax-modal-footer">
            <slot name="footer" />
          </footer>
        </div>
      </div>
    </Transition>
  </Teleport>
</template>

<style scoped>
.ax-modal-root {
  position: fixed;
  inset: 0;
  z-index: 10040;
  display: flex;
  align-items: center;
  justify-content: center;
  padding: 1rem;
}
.ax-modal-backdrop {
  position: absolute;
  inset: 0;
  background: rgba(10, 10, 11, 0.5);
  backdrop-filter: blur(4px);
}
.ax-modal-panel {
  position: relative;
  width: 100%;
  max-width: 480px;
  max-height: min(90dvh, 720px);
  overflow: auto;
  background: var(--ax-app-surface, #fff);
  color: var(--ax-app-text, #0f172a);
  border-radius: 16px;
  box-shadow: 0 24px 64px rgba(0, 0, 0, 0.25), 0 8px 24px rgba(0, 0, 0, 0.1);
  border: 1px solid var(--ax-app-border-soft, #cbd5e1);
}
.ax-modal-header {
  display: flex;
  align-items: flex-start;
  justify-content: space-between;
  gap: 1rem;
  padding: 1.25rem 1.5rem;
  border-bottom: 1px solid var(--ax-app-border-faint, #e2e8f0);
  background: var(--ax-app-surface-2, #f8fafc);
  border-radius: 16px 16px 0 0;
}
.ax-modal-title {
  margin: 0;
  font-family: 'Barlow Condensed', 'Arial Narrow', sans-serif;
  font-size: 1.35rem;
  font-weight: 700;
  letter-spacing: 0.04em;
  text-transform: uppercase;
  color: var(--ax-app-heading, #020617);
}
.ax-modal-x {
  display: inline-flex;
  align-items: center;
  justify-content: center;
  flex-shrink: 0;
  width: 2.5rem;
  height: 2.5rem;
  border: 1.5px solid var(--ax-app-border-faint, #e2e8f0);
  background: var(--ax-app-surface, #fff);
  border-radius: 10px;
  font-size: 1.35rem;
  line-height: 1;
  cursor: pointer;
  color: var(--ax-app-text-secondary, #1e293b);
  transition: background 0.15s ease, border-color 0.15s ease;
}
.ax-modal-x:hover {
  background: var(--ax-app-surface-muted, #e2e8f0);
  border-color: var(--ax-app-border-subtle, #94a3b8);
}
.ax-modal-body {
  padding: 1.5rem;
}
.ax-modal-footer {
  padding: 1.15rem 1.5rem;
  border-top: 1px solid var(--ax-app-border-faint, #e2e8f0);
  display: flex;
  flex-wrap: wrap;
  gap: 0.6rem;
  justify-content: flex-end;
  background: var(--ax-app-surface-2, #f8fafc);
  border-radius: 0 0 16px 16px;
}
.ax-modal-enter-active,
.ax-modal-leave-active {
  transition: opacity 0.2s ease;
}
.ax-modal-enter-active .ax-modal-panel,
.ax-modal-leave-active .ax-modal-panel {
  transition: transform 0.2s ease;
}
.ax-modal-enter-from,
.ax-modal-leave-to {
  opacity: 0;
}
.ax-modal-enter-from .ax-modal-panel,
.ax-modal-leave-to .ax-modal-panel {
  transform: scale(0.96) translateY(8px);
}
</style>
