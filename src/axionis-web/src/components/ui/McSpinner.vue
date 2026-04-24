<template>
  <span class="ax-spinner" aria-hidden="true" />
</template>

<style scoped>
.ax-spinner {
  display: inline-block;
  width: 1.25rem;
  height: 1.25rem;
  border: 2px solid rgba(6, 182, 212, 0.25);
  border-top-color: #06b6d4;
  border-radius: 50%;
  animation: ax-spin 0.7s linear infinite;
  vertical-align: middle;
}
@keyframes ax-spin {
  to {
    transform: rotate(360deg);
  }
}
</style>
