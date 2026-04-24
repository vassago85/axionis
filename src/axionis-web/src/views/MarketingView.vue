<script setup lang="ts">
const features = [
  {
    title: 'Point of Sale',
    desc: 'Fast, barcode-driven terminal. Cart, discounts, customer lookup, and instant invoicing — designed for speed on a tablet or desktop.',
    icon: '⌘'
  },
  {
    title: 'Stock Control',
    desc: 'Full inventory management with supplier tracking, stock receipts, imports, label printing, and real-time quantity tracking.',
    icon: '☰'
  },
  {
    title: 'Consignment Management',
    desc: 'Receive, check, and reconcile consignment and owned stock against supplier documents with line-level detail.',
    icon: '↔'
  },
  {
    title: 'Quotes & Invoices',
    desc: 'Create professional quotes and invoices, email them with PDF attachments, and track conversions — all from one system.',
    icon: '✎'
  },
  {
    title: 'Reports & Analytics',
    desc: 'Revenue, margins, sales by rep, stock value, vendor performance, and more — filterable by date, supplier, or user.',
    icon: '▦'
  },
  {
    title: 'Tablet & PWA Ready',
    desc: 'Installable as a Progressive Web App on any device. Designed for tablets, phones, and desktops with touch-first UX.',
    icon: '◧'
  }
]
</script>

<template>
  <div class="mk">
    <!-- Hero -->
    <section class="mk-hero">
      <div class="mk-hero__inner">
        <img src="/brand/axionis-logo.svg" alt="Axionis POS" class="mk-hero__logo" />
        <p class="mk-hero__tagline">Built for mobility. Designed for real-world operations.</p>
        <p class="mk-hero__sub">
          A mobile-first POS, stock and consignment platform for businesses that need
          control wherever they operate.
        </p>
        <div class="mk-hero__cta">
          <a href="mailto:hello@charsleydigital.com?subject=Axionis%20POS%20Demo%20Request" class="mk-btn mk-btn--primary">Request Demo</a>
          <a href="#features" class="mk-btn mk-btn--outline">View Features</a>
        </div>
      </div>
    </section>

    <!-- Features -->
    <section id="features" class="mk-features">
      <h2 class="mk-section__title">Everything you need to operate</h2>
      <div class="mk-features__grid">
        <div v-for="f in features" :key="f.title" class="mk-card">
          <span class="mk-card__icon">{{ f.icon }}</span>
          <h3 class="mk-card__title">{{ f.title }}</h3>
          <p class="mk-card__desc">{{ f.desc }}</p>
        </div>
      </div>
    </section>

    <!-- Deployment -->
    <section class="mk-deploy">
      <h2 class="mk-section__title">Deploy anywhere</h2>
      <p class="mk-deploy__text">
        Axionis POS runs as a lightweight Docker stack — API, database, and web interface
        in one package. Deploy on your own server, a VPS, or on-prem hardware. Each client
        gets a fully isolated instance with their own database, branding, and domain.
      </p>
      <div class="mk-deploy__grid">
        <div class="mk-deploy__item">
          <strong>Isolated per client</strong>
          <span>Separate DB, separate container, separate domain</span>
        </div>
        <div class="mk-deploy__item">
          <strong>Docker Compose</strong>
          <span>One command to build and deploy</span>
        </div>
        <div class="mk-deploy__item">
          <strong>Custom branding</strong>
          <span>Logo, colors, business name, email sender</span>
        </div>
      </div>
    </section>

    <!-- CTA -->
    <section class="mk-cta">
      <h2 class="mk-cta__title">Ready to get started?</h2>
      <p class="mk-cta__text">
        Get a live demo of Axionis POS configured for your business.
      </p>
      <a href="mailto:hello@charsleydigital.com?subject=Axionis%20POS%20Demo%20Request" class="mk-btn mk-btn--primary mk-btn--lg">
        Request Demo
      </a>
    </section>

    <!-- Footer -->
    <footer class="mk-footer">
      <span>Axionis POS</span>
      <span class="mk-footer__sep">·</span>
      <span>Built by <strong>Charsley Digital</strong></span>
    </footer>
  </div>
</template>

<style scoped>
.mk {
  --mk-bg: #0f172a;
  --mk-surface: #1e293b;
  --mk-accent: #06b6d4;
  --mk-accent-light: #22d3ee;
  --mk-text: #f1f5f9;
  --mk-muted: #94a3b8;

  min-height: 100vh;
  background: var(--mk-bg);
  color: var(--mk-text);
  font-family: 'Source Sans 3', 'Inter', 'Segoe UI', sans-serif;
}

/* ── Hero ── */

.mk-hero {
  display: flex;
  align-items: center;
  justify-content: center;
  min-height: 80vh;
  padding: 4rem 2rem;
  text-align: center;
  background: linear-gradient(170deg, #0f172a 0%, #0c1220 40%, #0e2a3d 100%);
}

.mk-hero__inner {
  max-width: 680px;
}

.mk-hero__logo {
  height: 48px;
  margin-bottom: 1.5rem;
  color: #f1f5f9;
}

.mk-hero__tagline {
  font-size: 1.125rem;
  font-weight: 600;
  color: var(--mk-accent);
  letter-spacing: 0.02em;
  margin-bottom: 1rem;
}

.mk-hero__sub {
  font-size: 1.25rem;
  line-height: 1.6;
  color: var(--mk-muted);
  margin-bottom: 2.5rem;
}

.mk-hero__cta {
  display: flex;
  gap: 1rem;
  justify-content: center;
  flex-wrap: wrap;
}

/* ── Buttons ── */

.mk-btn {
  display: inline-flex;
  align-items: center;
  justify-content: center;
  padding: 0.75rem 2rem;
  border-radius: 8px;
  font-size: 1rem;
  font-weight: 600;
  text-decoration: none;
  transition: all 0.2s;
  cursor: pointer;
  border: none;
}

.mk-btn--primary {
  background: var(--mk-accent);
  color: #0f172a;
}

.mk-btn--primary:hover {
  background: var(--mk-accent-light);
}

.mk-btn--outline {
  background: transparent;
  color: var(--mk-accent);
  border: 2px solid var(--mk-accent);
}

.mk-btn--outline:hover {
  background: rgba(6, 182, 212, 0.1);
}

.mk-btn--lg {
  padding: 1rem 3rem;
  font-size: 1.125rem;
}

/* ── Section titles ── */

.mk-section__title {
  text-align: center;
  font-size: 1.75rem;
  font-weight: 700;
  margin-bottom: 2.5rem;
  color: var(--mk-text);
}

/* ── Features ── */

.mk-features {
  padding: 5rem 2rem;
  max-width: 1100px;
  margin: 0 auto;
}

.mk-features__grid {
  display: grid;
  grid-template-columns: repeat(auto-fit, minmax(300px, 1fr));
  gap: 1.5rem;
}

.mk-card {
  background: var(--mk-surface);
  border: 1px solid #334155;
  border-radius: 14px;
  padding: 2rem;
  transition: border-color 0.2s;
}

.mk-card:hover {
  border-color: var(--mk-accent);
}

.mk-card__icon {
  display: inline-flex;
  align-items: center;
  justify-content: center;
  width: 44px;
  height: 44px;
  border-radius: 10px;
  background: rgba(6, 182, 212, 0.12);
  color: var(--mk-accent);
  font-size: 1.25rem;
  margin-bottom: 1rem;
}

.mk-card__title {
  font-size: 1.125rem;
  font-weight: 700;
  margin-bottom: 0.5rem;
}

.mk-card__desc {
  font-size: 0.95rem;
  line-height: 1.55;
  color: var(--mk-muted);
}

/* ── Deploy ── */

.mk-deploy {
  padding: 5rem 2rem;
  max-width: 900px;
  margin: 0 auto;
}

.mk-deploy__text {
  text-align: center;
  font-size: 1.1rem;
  line-height: 1.65;
  color: var(--mk-muted);
  margin-bottom: 3rem;
}

.mk-deploy__grid {
  display: grid;
  grid-template-columns: repeat(auto-fit, minmax(240px, 1fr));
  gap: 1.5rem;
}

.mk-deploy__item {
  background: var(--mk-surface);
  border: 1px solid #334155;
  border-radius: 12px;
  padding: 1.5rem;
  display: flex;
  flex-direction: column;
  gap: 0.4rem;
}

.mk-deploy__item strong {
  color: var(--mk-text);
  font-weight: 700;
}

.mk-deploy__item span {
  color: var(--mk-muted);
  font-size: 0.9rem;
}

/* ── CTA ── */

.mk-cta {
  text-align: center;
  padding: 5rem 2rem;
  background: linear-gradient(180deg, transparent 0%, rgba(6, 182, 212, 0.05) 100%);
}

.mk-cta__title {
  font-size: 1.75rem;
  font-weight: 700;
  margin-bottom: 1rem;
}

.mk-cta__text {
  font-size: 1.1rem;
  color: var(--mk-muted);
  margin-bottom: 2rem;
}

/* ── Footer ── */

.mk-footer {
  text-align: center;
  padding: 2rem;
  font-size: 0.85rem;
  color: var(--mk-muted);
  border-top: 1px solid #1e293b;
}

.mk-footer strong {
  color: var(--mk-accent);
  font-weight: 600;
}

.mk-footer__sep {
  margin: 0 0.5rem;
}
</style>
