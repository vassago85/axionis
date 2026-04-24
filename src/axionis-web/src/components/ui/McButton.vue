<script setup lang="ts">
defineProps<{
  variant?: 'primary' | 'secondary' | 'danger' | 'ghost'
  type?: 'button' | 'submit'
  disabled?: boolean
  block?: boolean
  /** Tighter control for tables and dense toolbars */
  dense?: boolean
}>()
</script>

<template>
  <button
    :type="type ?? 'button'"
    class="ax-btn"
    :class="[
      `ax-btn--${variant ?? 'primary'}`,
      { 'ax-btn--block': block, 'ax-btn--dense': dense }
    ]"
    :disabled="disabled"
  >
    <slot />
  </button>
</template>

<style scoped>
.ax-btn {
  display: inline-flex;
  align-items: center;
  justify-content: center;
  gap: 0.4rem;
  min-height: 44px;
  padding: 0 1.25rem;
  border-radius: var(--ax-app-radius-control, 10px);
  font: inherit;
  font-weight: 700;
  font-size: 0.84rem;
  letter-spacing: 0.04em;
  text-transform: uppercase;
  cursor: pointer;
  border: 1.5px solid transparent;
  transition:
    filter 0.15s ease,
    background 0.15s ease,
    border-color 0.15s ease,
    box-shadow 0.15s ease,
    color 0.15s ease;
}
.ax-btn:disabled {
  cursor: not-allowed;
  pointer-events: none;
}
.ax-btn--primary:disabled {
  background: #99d5de;
  border-color: transparent;
  color: rgba(15, 23, 42, 0.5);
  box-shadow: none;
}
.ax-btn--secondary:disabled {
  background: var(--ax-app-surface-muted, #e2e8f0);
  border-color: var(--ax-app-border-faint, #e2e8f0);
  color: var(--ax-app-border, #64748b);
  box-shadow: none;
}
.ax-btn--danger:disabled {
  background: #c4a0a0;
  border-color: transparent;
  color: rgba(255, 255, 255, 0.6);
  box-shadow: none;
}
.ax-btn--ghost:disabled {
  color: var(--ax-app-border-subtle, #94a3b8);
}
.ax-btn--block {
  width: 100%;
  max-width: 100%;
}
.ax-btn--dense {
  min-height: 36px;
  padding: 0 0.8rem;
  font-size: 0.6875rem;
  letter-spacing: 0.055em;
  border-radius: 8px;
}
.ax-btn--primary {
  background: linear-gradient(180deg, #22d3ee 0%, #06b6d4 45%, #0e7490 100%);
  border-color: rgba(0,0,0,0.12);
  color: #0f172a;
  box-shadow: 0 1px 3px rgba(6, 182, 212, 0.3), inset 0 1px 0 rgba(255,255,255,0.2);
}
.ax-btn--primary:hover:not(:disabled) {
  filter: brightness(1.06);
  box-shadow: 0 2px 8px rgba(6, 182, 212, 0.35), inset 0 1px 0 rgba(255,255,255,0.2);
}
.ax-btn--secondary {
  background: var(--ax-app-surface, #fff);
  border-color: var(--ax-app-border-subtle, #94a3b8);
  color: var(--ax-app-text-secondary, #1e293b);
  box-shadow: 0 1px 2px rgba(0,0,0,0.05);
}
.ax-btn--secondary:hover:not(:disabled) {
  background: var(--ax-app-surface-muted, #e2e8f0);
  border-color: var(--ax-app-border, #64748b);
  box-shadow: 0 1px 3px rgba(0,0,0,0.08);
}
.ax-btn--danger {
  background: linear-gradient(180deg, #c0392b 0%, #9a1818 100%);
  border-color: rgba(0,0,0,0.15);
  color: #fff;
  box-shadow: 0 1px 3px rgba(154, 24, 24, 0.3);
}
.ax-btn--danger:hover:not(:disabled) {
  filter: brightness(1.08);
  box-shadow: 0 2px 8px rgba(154, 24, 24, 0.35);
}
.ax-btn--ghost {
  background: transparent;
  border-color: transparent;
  color: var(--ax-app-text-muted, #475569);
}
.ax-btn--ghost:hover:not(:disabled) {
  background: rgba(18, 18, 20, 0.06);
  color: var(--ax-app-text, #0f172a);
}
.ax-btn--ghost.ax-btn--dense {
  border-color: var(--ax-app-border-faint, #e2e8f0);
}
.ax-btn--ghost.ax-btn--dense:hover:not(:disabled) {
  border-color: var(--ax-app-border-soft, #cbd5e1);
}
</style>
