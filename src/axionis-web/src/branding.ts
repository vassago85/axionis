// White-label build-time fallbacks. The runtime branding store
// (useBranding) loads the live values from BusinessSettings and overrides
// these. We deliberately ship NO bundled logo so a fresh deployment shows the
// configured business name as a text wordmark until an operator uploads
// their logo via Settings -> Business / Branding.

/** Fallback logo for dark surfaces (sidebar, login). null = render text. */
export const logoLight: string | null = null

/** Fallback logo for light surfaces (favicon, public docs). null = render text. */
export const logoDark: string | null = null
