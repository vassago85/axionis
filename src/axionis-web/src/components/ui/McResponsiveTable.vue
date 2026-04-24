<script setup lang="ts">
import { computed } from 'vue'

interface Column {
  key: string
  label: string
  align?: 'left' | 'right' | 'center'
  /** Hide on phones (<= 640px) to keep table legible. */
  hiddenOnMobile?: boolean
  /** Width hint, e.g. "120px" or "20%". */
  width?: string
  /** Column shown as the card title on mobile. */
  primary?: boolean
}

const props = defineProps<{
  columns: Column[]
  rows: Array<Record<string, unknown>>
  rowKey: string
  emptyText?: string
  /** When true, stack rows as cards on narrow screens. */
  mobileStack?: boolean
}>()

const primaryKey = computed(() =>
  props.columns.find(c => c.primary)?.key ?? props.columns[0]?.key ?? props.rowKey)
</script>

<template>
  <div class="ax-rt" :class="{ 'ax-rt--stack': mobileStack !== false }">
    <table class="ax-rt__table" role="table">
      <thead>
        <tr>
          <th
            v-for="c in columns"
            :key="c.key"
            :class="[
              c.align === 'right' ? 'text-right' : '',
              c.align === 'center' ? 'text-center' : '',
              c.hiddenOnMobile ? 'ax-rt__hide-sm' : ''
            ]"
            :style="c.width ? { width: c.width } : undefined"
          >{{ c.label }}</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="row in rows" :key="String(row[rowKey])">
          <td
            v-for="c in columns"
            :key="c.key"
            :class="[
              c.align === 'right' ? 'text-right' : '',
              c.align === 'center' ? 'text-center' : '',
              c.hiddenOnMobile ? 'ax-rt__hide-sm' : ''
            ]"
            :data-label="c.label"
            :data-primary="c.key === primaryKey ? 'true' : undefined"
          >
            <slot :name="`cell-${c.key}`" v-bind="{ row, column: c, value: row[c.key] }">
              {{ row[c.key] ?? '—' }}
            </slot>
          </td>
        </tr>
        <tr v-if="rows.length === 0">
          <td :colspan="columns.length" class="ax-rt__empty">{{ emptyText ?? 'No data' }}</td>
        </tr>
      </tbody>
    </table>
  </div>
</template>

<style scoped>
.ax-rt {
  width: 100%;
  overflow-x: auto;
  border: 1px solid var(--ax-app-border-faint, #e2e8f0);
  border-radius: 12px;
  background: var(--ax-app-surface, #fff);
}
.ax-rt__table {
  width: 100%;
  border-collapse: collapse;
  font-size: 0.9rem;
}
.ax-rt__table thead th {
  background: var(--ax-app-table-head-bg, #f1f5f9);
  text-align: left;
  font-size: 0.72rem;
  letter-spacing: 0.08em;
  text-transform: uppercase;
  color: var(--ax-app-text-muted, #475569);
  padding: 0.65rem 0.85rem;
  border-bottom: 1px solid var(--ax-app-border-faint, #e2e8f0);
}
.ax-rt__table tbody td {
  padding: 0.75rem 0.85rem;
  border-bottom: 1px solid var(--ax-app-border-faint, #e2e8f0);
  vertical-align: middle;
}
.ax-rt__table tbody tr:last-child td {
  border-bottom: 0;
}
.ax-rt__table tbody tr:nth-child(even) td {
  background: var(--ax-app-table-row-alt, #f8fafc);
}
.text-right { text-align: right; }
.text-center { text-align: center; }

.ax-rt__empty {
  text-align: center;
  padding: 1.25rem;
  color: var(--ax-app-text-muted, #475569);
}

@media (max-width: 640px) {
  .ax-rt--stack {
    border: 0;
    background: transparent;
  }
  .ax-rt--stack .ax-rt__table,
  .ax-rt--stack .ax-rt__table tbody,
  .ax-rt--stack .ax-rt__table tr,
  .ax-rt--stack .ax-rt__table td {
    display: block;
    width: 100%;
  }
  .ax-rt--stack .ax-rt__table thead { display: none; }
  .ax-rt--stack .ax-rt__hide-sm { display: none; }
  .ax-rt--stack .ax-rt__table tr {
    background: var(--ax-app-surface, #fff);
    border: 1px solid var(--ax-app-border-faint, #e2e8f0);
    border-radius: 12px;
    padding: 0.75rem;
    margin-bottom: 0.6rem;
  }
  .ax-rt--stack .ax-rt__table td {
    border: 0;
    padding: 0.35rem 0;
    display: flex;
    justify-content: space-between;
    gap: 1rem;
    text-align: right;
  }
  .ax-rt--stack .ax-rt__table td::before {
    content: attr(data-label);
    font-size: 0.7rem;
    letter-spacing: 0.08em;
    text-transform: uppercase;
    color: var(--ax-app-text-muted, #475569);
    font-weight: 600;
    text-align: left;
    flex: 0 0 auto;
  }
  .ax-rt--stack .ax-rt__table td[data-primary='true'] {
    flex-direction: column;
    align-items: flex-start;
    text-align: left;
    font-weight: 700;
    border-bottom: 1px solid var(--ax-app-border-faint, #e2e8f0);
    padding-bottom: 0.5rem;
    margin-bottom: 0.25rem;
  }
  .ax-rt--stack .ax-rt__table td[data-primary='true']::before {
    display: none;
  }
  .ax-rt--stack .ax-rt__table tbody tr:nth-child(even) td {
    background: transparent;
  }
}
</style>
