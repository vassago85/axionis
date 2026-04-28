/**
 * One-shot localStorage key migration.
 *
 * Reads the new key first; if absent and the old key has a value, copies the
 * value to the new key and deletes the old one. Idempotent on subsequent calls
 * because once the new key is set, the old key never exists again.
 *
 * Safe to call from module top-level — handles SSR / privacy mode by
 * swallowing any storage exceptions and returning null.
 *
 * Returns the value that should be considered "current" (new key if present,
 * otherwise the migrated value, otherwise null).
 */
export function migrateLocalStorageKey(newKey: string, oldKey: string): string | null {
  if (typeof window === 'undefined' || typeof localStorage === 'undefined') {
    return null
  }
  try {
    const fresh = localStorage.getItem(newKey)
    if (fresh !== null) return fresh

    const legacy = localStorage.getItem(oldKey)
    if (legacy !== null) {
      localStorage.setItem(newKey, legacy)
      localStorage.removeItem(oldKey)
      return legacy
    }
    return null
  } catch {
    // Quota / private mode / disabled storage — caller treats as "no value".
    return null
  }
}
