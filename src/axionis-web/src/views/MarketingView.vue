<script setup lang="ts">
import { ref, onMounted } from 'vue'

const visible = ref(new Set<string>())

onMounted(() => {
  const observer = new IntersectionObserver(
    (entries) => {
      entries.forEach((e) => {
        if (e.isIntersecting) {
          visible.value.add(e.target.id)
          observer.unobserve(e.target)
        }
      })
    },
    { threshold: 0.15 }
  )
  document.querySelectorAll('[data-animate]').forEach((el) => observer.observe(el))
})

function isVisible(id: string) {
  return visible.value.has(id)
}

const features = [
  {
    title: 'Point of Sale',
    desc: 'Barcode-driven cart with real-time pricing, discounts, customer lookup, and instant invoicing. Designed for speed on any device.',
    icon: 'pos'
  },
  {
    title: 'Stock Control',
    desc: 'Full inventory lifecycle — supplier tracking, stock receipts, bulk imports, label printing, and live quantity monitoring.',
    icon: 'stock'
  },
  {
    title: 'Consignment',
    desc: 'Receive, reconcile, and return consignment stock against supplier documents with line-level detail and PDF parsing.',
    icon: 'consignment'
  },
  {
    title: 'Quotes & Invoices',
    desc: 'Create professional quotes, convert to invoices, email PDF attachments, and track everything from one place.',
    icon: 'quotes'
  },
  {
    title: 'Reports & Analytics',
    desc: 'Revenue, margins, vendor performance, daily sales, payment breakdowns — filterable by date, supplier, or user.',
    icon: 'reports'
  },
  {
    title: 'PWA & Mobile-First',
    desc: 'Install on any device as a Progressive Web App. Touch-optimized for tablets and phones with offline-ready design.',
    icon: 'pwa'
  }
]

const stats = [
  { value: '< 2s', label: 'Average checkout' },
  { value: '100%', label: 'Cloud or on-prem' },
  { value: '0', label: 'Monthly fees' },
  { value: '∞', label: 'Users & devices' }
]
</script>

<template>
  <div class="mk">
    <!-- ─── Nav ─── -->
    <nav class="mk-nav">
      <div class="mk-nav__inner">
        <img src="/brand/axionis-icon.png" alt="Axionis" class="mk-nav__icon" />
        <span class="mk-nav__wordmark">AXIONIS</span>
        <div class="mk-nav__spacer" />
        <a href="#features" class="mk-nav__link">Features</a>
        <a href="#preview" class="mk-nav__link">Preview</a>
        <a href="#deploy" class="mk-nav__link mk-nav__link--hide-mobile">Deploy</a>
        <router-link to="/login" class="mk-nav__cta">Sign In</router-link>
      </div>
    </nav>

    <!-- ─── Hero ─── -->
    <section class="mk-hero">
      <div class="mk-hero__bg-grid" />
      <div class="mk-hero__glow" />
      <div class="mk-hero__glow mk-hero__glow--2" />
      <div class="mk-hero__content">
        <img src="/brand/axionis-dark-bg.png" alt="Axionis POS" class="mk-hero__logo" />
        <h1 class="mk-hero__headline">
          The POS system built for
          <span class="mk-hero__accent">real-world operations</span>
        </h1>
        <p class="mk-hero__sub">
          Mobile-first point of sale, stock management, consignment tracking, and business intelligence —
          deployable anywhere, owned by you.
        </p>
        <div class="mk-hero__actions">
          <a
            href="mailto:hello@charsleydigital.com?subject=Axionis%20POS%20Demo%20Request"
            class="mk-btn mk-btn--glow"
          >
            Request a Demo
          </a>
          <a href="#features" class="mk-btn mk-btn--ghost">Explore Features</a>
        </div>
      </div>

      <!-- Floating stats -->
      <div class="mk-hero__stats">
        <div v-for="s in stats" :key="s.label" class="mk-stat">
          <span class="mk-stat__value">{{ s.value }}</span>
          <span class="mk-stat__label">{{ s.label }}</span>
        </div>
      </div>
    </section>

    <!-- ─── App Preview ─── -->
    <section id="preview" class="mk-preview" data-animate>
      <h2 class="mk-section-title">
        See it in action
        <span class="mk-section-title__line" />
      </h2>
      <p class="mk-section-sub">A complete business operations platform, not just a cash register.</p>

      <div class="mk-browser" :class="{ 'mk-visible': isVisible('preview') }">
        <div class="mk-browser__bar">
          <span class="mk-browser__dot" />
          <span class="mk-browser__dot mk-browser__dot--yellow" />
          <span class="mk-browser__dot mk-browser__dot--green" />
          <span class="mk-browser__url">axionis.co.za/#/pos</span>
        </div>
        <div class="mk-browser__body">
          <!-- Sidebar mockup -->
          <div class="mk-mock-sidebar">
            <div class="mk-mock-sidebar__brand">
              <img src="/brand/axionis-icon.png" alt="" class="mk-mock-sidebar__logo" />
              <span>AXIONIS</span>
            </div>
            <div class="mk-mock-sidebar__label">SELL</div>
            <div class="mk-mock-sidebar__item mk-mock-sidebar__item--active">⌘ Point of Sale</div>
            <div class="mk-mock-sidebar__item">✎ Quotes</div>
            <div class="mk-mock-sidebar__item">⊙ Price Lookup</div>
            <div class="mk-mock-sidebar__label">INVENTORY</div>
            <div class="mk-mock-sidebar__item">☰ Stock List</div>
            <div class="mk-mock-sidebar__item">⊞ Print Labels</div>
            <div class="mk-mock-sidebar__item">↔ Stock Batches</div>
            <div class="mk-mock-sidebar__label">OFFICE</div>
            <div class="mk-mock-sidebar__item">▦ Reports</div>
            <div class="mk-mock-sidebar__item">⚙ Settings</div>
          </div>
          <!-- POS mockup -->
          <div class="mk-mock-main">
            <div class="mk-mock-topbar">
              <span class="mk-mock-topbar__title">Point of Sale</span>
              <span class="mk-mock-topbar__badge">Manager Mode</span>
            </div>
            <div class="mk-mock-search">
              <span class="mk-mock-search__icon">⌕</span>
              <span class="mk-mock-search__text">Scan barcode, or type SKU / name…</span>
            </div>
            <div class="mk-mock-cart">
              <div class="mk-mock-cart__header">
                <span>Item</span><span>Qty</span><span>Price</span><span>Total</span>
              </div>
              <div class="mk-mock-cart__row">
                <span>Shimano Deore XT M8100</span><span>2</span><span>R 1,450.00</span><span>R 2,900.00</span>
              </div>
              <div class="mk-mock-cart__row">
                <span>Maxxis Minion DHF 27.5</span><span>1</span><span>R 890.00</span><span>R 890.00</span>
              </div>
              <div class="mk-mock-cart__row">
                <span>Fox 36 Float GRIP2 Fork</span><span>1</span><span>R 18,500.00</span><span>R 18,500.00</span>
              </div>
              <div class="mk-mock-cart__row mk-mock-cart__row--highlight">
                <span>RockShox Reverb AXS Dropper</span><span>1</span><span>R 12,200.00</span><span>R 12,200.00</span>
              </div>
            </div>
            <div class="mk-mock-totals">
              <div class="mk-mock-totals__line">
                <span>Subtotal</span><span>R 34,490.00</span>
              </div>
              <div class="mk-mock-totals__line mk-mock-totals__line--vat">
                <span>VAT (15%)</span><span>R 5,173.50</span>
              </div>
              <div class="mk-mock-totals__line mk-mock-totals__line--total">
                <span>Total Due</span><span>R 39,663.50</span>
              </div>
              <div class="mk-mock-totals__btn">Complete Sale</div>
            </div>
          </div>
        </div>
      </div>
    </section>

    <!-- ─── Features ─── -->
    <section id="features" class="mk-features" data-animate>
      <h2 class="mk-section-title">
        Everything you need to operate
        <span class="mk-section-title__line" />
      </h2>
      <p class="mk-section-sub">
        From the shop floor to the back office, Axionis covers the full cycle.
      </p>
      <div class="mk-features__grid">
        <div
          v-for="(f, i) in features"
          :key="f.title"
          class="mk-fcard"
          :class="{ 'mk-visible': isVisible('features') }"
          :style="{ transitionDelay: `${i * 0.08}s` }"
        >
          <div class="mk-fcard__icon" :data-icon="f.icon">
            <svg v-if="f.icon === 'pos'" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="1.5"><rect x="2" y="3" width="20" height="14" rx="2"/><path d="M8 21h8M12 17v4"/><path d="M7 8h2m2 0h2m2 0h2M7 11h10"/></svg>
            <svg v-if="f.icon === 'stock'" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="1.5"><path d="M20 7l-8-4-8 4m16 0l-8 4m8-4v10l-8 4M4 7l8 4M4 7v10l8 4m0-10v10"/></svg>
            <svg v-if="f.icon === 'consignment'" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="1.5"><path d="M16 3h5v5M4 20L21 3M21 16v5h-5M20 21L8 9"/></svg>
            <svg v-if="f.icon === 'quotes'" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="1.5"><path d="M14 2H6a2 2 0 0 0-2 2v16a2 2 0 0 0 2 2h12a2 2 0 0 0 2-2V8z"/><path d="M14 2v6h6M8 13h8M8 17h8M8 9h2"/></svg>
            <svg v-if="f.icon === 'reports'" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="1.5"><path d="M18 20V10M12 20V4M6 20v-6"/></svg>
            <svg v-if="f.icon === 'pwa'" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="1.5"><rect x="5" y="2" width="14" height="20" rx="3"/><path d="M12 18h.01"/></svg>
          </div>
          <h3 class="mk-fcard__title">{{ f.title }}</h3>
          <p class="mk-fcard__desc">{{ f.desc }}</p>
        </div>
      </div>
    </section>

    <!-- ─── Secondary Screens ─── -->
    <section class="mk-screens" id="screens" data-animate>
      <h2 class="mk-section-title">
        Built for every department
        <span class="mk-section-title__line" />
      </h2>

      <div class="mk-screens__grid" :class="{ 'mk-visible': isVisible('screens') }">
        <!-- Stock screen -->
        <div class="mk-screen-card">
          <div class="mk-screen-card__label">Stock Management</div>
          <div class="mk-screen-card__mock">
            <div class="mk-mini-header">
              <span>Stock List</span>
              <div class="mk-mini-actions">
                <span class="mk-mini-btn">+ Add</span>
                <span class="mk-mini-btn mk-mini-btn--sec">Export</span>
              </div>
            </div>
            <div class="mk-mini-table">
              <div class="mk-mini-table__head"><span>SKU</span><span>Product</span><span>Qty</span><span>Cost</span><span>Sell</span></div>
              <div class="mk-mini-table__row"><span>SHM-XT-01</span><span>Shimano XT Derailleur</span><span class="mk-qty-ok">24</span><span>R 980</span><span>R 1,450</span></div>
              <div class="mk-mini-table__row"><span>MAX-DHF-27</span><span>Maxxis DHF 27.5</span><span class="mk-qty-ok">18</span><span>R 620</span><span>R 890</span></div>
              <div class="mk-mini-table__row"><span>FOX-36-FRK</span><span>Fox 36 Float Fork</span><span class="mk-qty-low">3</span><span>R 14,200</span><span>R 18,500</span></div>
              <div class="mk-mini-table__row"><span>RSX-RVB-AX</span><span>RockShox Reverb AXS</span><span class="mk-qty-out">0</span><span>R 9,400</span><span>R 12,200</span></div>
            </div>
          </div>
        </div>

        <!-- Reports screen -->
        <div class="mk-screen-card">
          <div class="mk-screen-card__label">Reports & Analytics</div>
          <div class="mk-screen-card__mock">
            <div class="mk-mini-header">
              <span>Sales Report</span>
              <div class="mk-mini-actions">
                <span class="mk-mini-chip mk-mini-chip--active">7 Days</span>
                <span class="mk-mini-chip">30 Days</span>
                <span class="mk-mini-chip">Month</span>
              </div>
            </div>
            <div class="mk-kpi-row">
              <div class="mk-kpi"><span class="mk-kpi__val">R 487,320</span><span class="mk-kpi__label">Revenue</span></div>
              <div class="mk-kpi"><span class="mk-kpi__val">R 143,890</span><span class="mk-kpi__label">Gross Profit</span></div>
              <div class="mk-kpi"><span class="mk-kpi__val">29.5%</span><span class="mk-kpi__label">Margin</span></div>
              <div class="mk-kpi"><span class="mk-kpi__val">184</span><span class="mk-kpi__label">Invoices</span></div>
            </div>
            <div class="mk-chart-bars">
              <div class="mk-chart-bar" style="--h: 65%"><span>Mon</span></div>
              <div class="mk-chart-bar" style="--h: 82%"><span>Tue</span></div>
              <div class="mk-chart-bar" style="--h: 45%"><span>Wed</span></div>
              <div class="mk-chart-bar" style="--h: 90%"><span>Thu</span></div>
              <div class="mk-chart-bar" style="--h: 72%"><span>Fri</span></div>
              <div class="mk-chart-bar" style="--h: 95%"><span>Sat</span></div>
              <div class="mk-chart-bar" style="--h: 30%"><span>Sun</span></div>
            </div>
          </div>
        </div>

        <!-- Quotes screen -->
        <div class="mk-screen-card">
          <div class="mk-screen-card__label">Quotes & Invoicing</div>
          <div class="mk-screen-card__mock">
            <div class="mk-mini-header">
              <span>Quotes</span>
              <div class="mk-mini-actions"><span class="mk-mini-btn">+ New Quote</span></div>
            </div>
            <div class="mk-mini-table">
              <div class="mk-mini-table__head"><span>#</span><span>Customer</span><span>Total</span><span>Status</span></div>
              <div class="mk-mini-table__row"><span>Q-041</span><span>Red Bull Racing</span><span>R 84,200</span><span class="mk-badge mk-badge--sent">Sent</span></div>
              <div class="mk-mini-table__row"><span>Q-040</span><span>Trail Riders ZA</span><span>R 23,450</span><span class="mk-badge mk-badge--draft">Draft</span></div>
              <div class="mk-mini-table__row"><span>Q-039</span><span>Pedal Power CC</span><span>R 156,800</span><span class="mk-badge mk-badge--accepted">Accepted</span></div>
              <div class="mk-mini-table__row"><span>Q-038</span><span>Western Province MTB</span><span>R 41,600</span><span class="mk-badge mk-badge--invoiced">Invoiced</span></div>
            </div>
          </div>
        </div>
      </div>
    </section>

    <!-- ─── Deploy ─── -->
    <section id="deploy" class="mk-deploy" data-animate>
      <h2 class="mk-section-title">
        Your system. Your server. Your data.
        <span class="mk-section-title__line" />
      </h2>
      <p class="mk-section-sub">
        No subscriptions, no vendor lock-in. Axionis deploys as a Docker stack you own and control.
      </p>
      <div class="mk-deploy__grid" :class="{ 'mk-visible': isVisible('deploy') }">
        <div class="mk-deploy-card">
          <div class="mk-deploy-card__num">01</div>
          <h3 class="mk-deploy-card__title">Clone & Configure</h3>
          <p class="mk-deploy-card__desc">Pull the repository, set your environment variables, and configure your branding.</p>
        </div>
        <div class="mk-deploy-card">
          <div class="mk-deploy-card__num">02</div>
          <h3 class="mk-deploy-card__title">Deploy</h3>
          <p class="mk-deploy-card__desc">One <code>docker compose up</code> command builds and launches API, database, and web interface.</p>
        </div>
        <div class="mk-deploy-card">
          <div class="mk-deploy-card__num">03</div>
          <h3 class="mk-deploy-card__title">Operate</h3>
          <p class="mk-deploy-card__desc">Your team logs in from any device. Fully isolated instance with your own database and domain.</p>
        </div>
      </div>
    </section>

    <!-- ─── CTA ─── -->
    <section class="mk-cta">
      <div class="mk-cta__glow" />
      <h2 class="mk-cta__title">Ready to take control?</h2>
      <p class="mk-cta__text">
        Get a live, personalised demo of Axionis POS configured for your business.
      </p>
      <a
        href="mailto:hello@charsleydigital.com?subject=Axionis%20POS%20Demo%20Request"
        class="mk-btn mk-btn--glow mk-btn--lg"
      >
        Request a Demo
      </a>
    </section>

    <!-- ─── Footer ─── -->
    <footer class="mk-footer">
      <div class="mk-footer__inner">
        <img src="/brand/axionis-icon.png" alt="" class="mk-footer__icon" />
        <span class="mk-footer__copy">Axionis POS — Built by <strong>Charsley Digital</strong></span>
      </div>
    </footer>
  </div>
</template>

<style scoped>
/* ══════════════════════════════════════
   AXIONIS MARKETING PAGE
   ══════════════════════════════════════ */

.mk {
  --mk-bg: #050a18;
  --mk-surface: #0d1525;
  --mk-surface-2: #131d33;
  --mk-border: #1a2744;
  --mk-accent: #06b6d4;
  --mk-accent-light: #22d3ee;
  --mk-accent-glow: rgba(6, 182, 212, 0.35);
  --mk-text: #e2e8f0;
  --mk-text-bright: #f8fafc;
  --mk-muted: #64748b;

  min-height: 100vh;
  background: var(--mk-bg);
  color: var(--mk-text);
  font-family: 'Source Sans 3', 'Inter', system-ui, sans-serif;
  overflow-x: hidden;
}

/* ── Animate on scroll ── */
.mk-visible { animation: mkFadeUp 0.7s ease both; }
@keyframes mkFadeUp {
  from { opacity: 0; transform: translateY(32px); }
  to   { opacity: 1; transform: translateY(0); }
}

/* ── Nav ── */
.mk-nav {
  position: fixed;
  top: 0;
  left: 0;
  right: 0;
  z-index: 100;
  background: rgba(5, 10, 24, 0.85);
  backdrop-filter: blur(16px);
  border-bottom: 1px solid var(--mk-border);
}

.mk-nav__inner {
  max-width: 1200px;
  margin: 0 auto;
  padding: 0 2rem;
  height: 64px;
  display: flex;
  align-items: center;
  gap: 0.75rem;
}

.mk-nav__icon {
  height: 28px;
  width: auto;
}

.mk-nav__wordmark {
  font-family: 'Barlow Condensed', sans-serif;
  font-weight: 700;
  font-size: 1.15rem;
  letter-spacing: 0.12em;
  color: var(--mk-text-bright);
}

.mk-nav__spacer { flex: 1; }

.mk-nav__link {
  color: var(--mk-muted);
  text-decoration: none;
  font-size: 0.875rem;
  font-weight: 600;
  letter-spacing: 0.04em;
  padding: 0.5rem 0.75rem;
  border-radius: 8px;
  transition: color 0.2s, background 0.2s;
}

.mk-nav__link:hover {
  color: var(--mk-text-bright);
  background: rgba(255, 255, 255, 0.04);
}

.mk-nav__cta {
  display: inline-flex;
  align-items: center;
  padding: 0.5rem 1.25rem;
  border-radius: 8px;
  background: var(--mk-accent);
  color: #050a18;
  font-weight: 700;
  font-size: 0.85rem;
  text-decoration: none;
  letter-spacing: 0.04em;
  transition: background 0.2s, box-shadow 0.2s;
}

.mk-nav__cta:hover {
  background: var(--mk-accent-light);
  box-shadow: 0 0 20px var(--mk-accent-glow);
}

/* ── Hero ── */
.mk-hero {
  position: relative;
  min-height: 100vh;
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: center;
  padding: 8rem 2rem 4rem;
  text-align: center;
  overflow: hidden;
}

.mk-hero__bg-grid {
  position: absolute;
  inset: 0;
  background-image:
    linear-gradient(rgba(6, 182, 212, 0.03) 1px, transparent 1px),
    linear-gradient(90deg, rgba(6, 182, 212, 0.03) 1px, transparent 1px);
  background-size: 60px 60px;
  mask-image: radial-gradient(ellipse 70% 60% at 50% 40%, black, transparent);
}

.mk-hero__glow {
  position: absolute;
  width: 700px;
  height: 700px;
  border-radius: 50%;
  background: radial-gradient(circle, rgba(6, 182, 212, 0.15), transparent 70%);
  top: -15%;
  left: 50%;
  transform: translateX(-50%);
  pointer-events: none;
  animation: mkPulse 6s ease-in-out infinite alternate;
}

.mk-hero__glow--2 {
  width: 500px;
  height: 500px;
  background: radial-gradient(circle, rgba(59, 130, 246, 0.1), transparent 70%);
  top: 20%;
  left: 30%;
  animation-delay: -3s;
  animation-duration: 8s;
}

@keyframes mkPulse {
  from { opacity: 0.6; transform: translateX(-50%) scale(1); }
  to   { opacity: 1; transform: translateX(-50%) scale(1.15); }
}

.mk-hero__content {
  position: relative;
  z-index: 1;
  max-width: 800px;
}

.mk-hero__logo {
  max-width: min(480px, 85vw);
  height: auto;
  margin-bottom: 2.5rem;
  filter: drop-shadow(0 0 40px rgba(6, 182, 212, 0.2));
}

.mk-hero__headline {
  font-family: 'Barlow Condensed', sans-serif;
  font-size: clamp(2rem, 5vw, 3.5rem);
  font-weight: 700;
  letter-spacing: 0.03em;
  text-transform: uppercase;
  line-height: 1.15;
  color: var(--mk-text-bright);
  margin: 0 0 1.5rem;
}

.mk-hero__accent {
  background: linear-gradient(135deg, var(--mk-accent), #3b82f6);
  -webkit-background-clip: text;
  -webkit-text-fill-color: transparent;
  background-clip: text;
}

.mk-hero__sub {
  font-size: 1.2rem;
  line-height: 1.7;
  color: var(--mk-muted);
  max-width: 620px;
  margin: 0 auto 2.5rem;
}

.mk-hero__actions {
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
  padding: 0.85rem 2.25rem;
  border-radius: 10px;
  font-size: 0.95rem;
  font-weight: 700;
  text-decoration: none;
  letter-spacing: 0.04em;
  transition: all 0.25s ease;
  border: none;
  cursor: pointer;
}

.mk-btn--glow {
  background: linear-gradient(135deg, var(--mk-accent), #0891b2);
  color: #050a18;
  box-shadow: 0 0 30px var(--mk-accent-glow), 0 4px 15px rgba(0,0,0,0.3);
}

.mk-btn--glow:hover {
  background: linear-gradient(135deg, var(--mk-accent-light), var(--mk-accent));
  box-shadow: 0 0 50px var(--mk-accent-glow), 0 8px 25px rgba(0,0,0,0.3);
  transform: translateY(-2px);
}

.mk-btn--ghost {
  background: transparent;
  color: var(--mk-accent);
  border: 1.5px solid rgba(6, 182, 212, 0.4);
}

.mk-btn--ghost:hover {
  background: rgba(6, 182, 212, 0.08);
  border-color: var(--mk-accent);
}

.mk-btn--lg {
  padding: 1.1rem 3rem;
  font-size: 1.05rem;
}

/* ── Hero Stats ── */
.mk-hero__stats {
  position: relative;
  z-index: 1;
  display: flex;
  gap: 1px;
  margin-top: 5rem;
  background: var(--mk-border);
  border-radius: 16px;
  overflow: hidden;
  border: 1px solid var(--mk-border);
}

.mk-stat {
  display: flex;
  flex-direction: column;
  align-items: center;
  padding: 1.5rem 2.5rem;
  background: var(--mk-surface);
}

.mk-stat__value {
  font-family: 'Barlow Condensed', sans-serif;
  font-size: 1.75rem;
  font-weight: 700;
  color: var(--mk-accent);
}

.mk-stat__label {
  font-size: 0.75rem;
  color: var(--mk-muted);
  text-transform: uppercase;
  letter-spacing: 0.1em;
  margin-top: 0.25rem;
}

/* ── Section Titles ── */
.mk-section-title {
  text-align: center;
  font-family: 'Barlow Condensed', sans-serif;
  font-size: 2rem;
  font-weight: 700;
  letter-spacing: 0.04em;
  text-transform: uppercase;
  color: var(--mk-text-bright);
  margin: 0 0 0.5rem;
  display: flex;
  flex-direction: column;
  align-items: center;
}

.mk-section-title__line {
  display: block;
  width: 60px;
  height: 3px;
  background: linear-gradient(90deg, var(--mk-accent), transparent);
  border-radius: 2px;
  margin-top: 0.75rem;
}

.mk-section-sub {
  text-align: center;
  font-size: 1.1rem;
  color: var(--mk-muted);
  max-width: 560px;
  margin: 0.5rem auto 3.5rem;
  line-height: 1.6;
}

/* ── Browser Mockup ── */
.mk-preview {
  padding: 6rem 2rem;
  max-width: 1200px;
  margin: 0 auto;
}

.mk-browser {
  border-radius: 16px;
  border: 1px solid var(--mk-border);
  overflow: hidden;
  box-shadow:
    0 40px 80px rgba(0, 0, 0, 0.5),
    0 0 80px rgba(6, 182, 212, 0.08);
  opacity: 0;
  transform: translateY(40px);
  transition: opacity 0.8s ease, transform 0.8s ease;
}

.mk-browser.mk-visible {
  opacity: 1;
  transform: translateY(0);
}

.mk-browser__bar {
  display: flex;
  align-items: center;
  gap: 8px;
  padding: 12px 16px;
  background: #0a0f1f;
  border-bottom: 1px solid var(--mk-border);
}

.mk-browser__dot {
  width: 12px;
  height: 12px;
  border-radius: 50%;
  background: #ef4444;
}

.mk-browser__dot--yellow { background: #eab308; }
.mk-browser__dot--green { background: #22c55e; }

.mk-browser__url {
  margin-left: 12px;
  padding: 4px 16px;
  border-radius: 6px;
  background: rgba(255, 255, 255, 0.04);
  font-size: 0.75rem;
  color: var(--mk-muted);
  font-family: 'SF Mono', 'Fira Code', monospace;
}

.mk-browser__body {
  display: flex;
  min-height: 420px;
  background: #f1f5f9;
}

/* ── Mock Sidebar ── */
.mk-mock-sidebar {
  width: 200px;
  background: linear-gradient(180deg, #0f172a, #020617);
  padding: 1rem 0;
  flex-shrink: 0;
  border-right: 1px solid #1e293b;
}

.mk-mock-sidebar__brand {
  display: flex;
  align-items: center;
  gap: 0.5rem;
  padding: 0.5rem 1rem 1rem;
  border-bottom: 1px solid #1e293b;
  margin-bottom: 0.75rem;
  font-family: 'Barlow Condensed', sans-serif;
  font-weight: 700;
  font-size: 0.85rem;
  letter-spacing: 0.1em;
  color: #f1f5f9;
}

.mk-mock-sidebar__logo {
  height: 22px;
  width: auto;
}

.mk-mock-sidebar__label {
  padding: 0.5rem 1rem 0.25rem;
  font-size: 0.55rem;
  font-weight: 700;
  letter-spacing: 0.14em;
  text-transform: uppercase;
  color: #475569;
}

.mk-mock-sidebar__item {
  padding: 0.4rem 1rem;
  font-size: 0.7rem;
  color: #94a3b8;
  font-family: 'Barlow Condensed', sans-serif;
  font-weight: 600;
  letter-spacing: 0.04em;
  text-transform: uppercase;
  border-radius: 6px;
  margin: 2px 0.5rem;
}

.mk-mock-sidebar__item--active {
  background: rgba(6, 182, 212, 0.14);
  color: #22d3ee;
  border: 1px solid rgba(6, 182, 212, 0.3);
}

/* ── Mock Main ── */
.mk-mock-main {
  flex: 1;
  padding: 1.25rem;
  display: flex;
  flex-direction: column;
  gap: 0.75rem;
  min-width: 0;
}

.mk-mock-topbar {
  display: flex;
  align-items: center;
  justify-content: space-between;
}

.mk-mock-topbar__title {
  font-family: 'Barlow Condensed', sans-serif;
  font-weight: 700;
  font-size: 1.1rem;
  text-transform: uppercase;
  letter-spacing: 0.05em;
  color: #0f172a;
}

.mk-mock-topbar__badge {
  font-size: 0.6rem;
  font-weight: 700;
  padding: 0.25rem 0.75rem;
  border-radius: 20px;
  background: rgba(6, 182, 212, 0.12);
  color: #0891b2;
  text-transform: uppercase;
  letter-spacing: 0.06em;
}

.mk-mock-search {
  display: flex;
  align-items: center;
  gap: 0.5rem;
  padding: 0.6rem 1rem;
  border-radius: 10px;
  background: #fff;
  border: 1.5px solid #94a3b8;
}

.mk-mock-search__icon {
  font-size: 1rem;
  color: #94a3b8;
}

.mk-mock-search__text {
  font-size: 0.75rem;
  color: #94a3b8;
}

.mk-mock-cart {
  background: #fff;
  border-radius: 14px;
  border: 1px solid #cbd5e1;
  overflow: hidden;
  flex: 1;
  box-shadow: 0 2px 8px rgba(0, 0, 0, 0.06);
}

.mk-mock-cart__header {
  display: grid;
  grid-template-columns: 2fr 0.5fr 1fr 1fr;
  padding: 0.5rem 1rem;
  font-size: 0.55rem;
  font-weight: 700;
  text-transform: uppercase;
  letter-spacing: 0.08em;
  color: #475569;
  background: #f1f5f9;
  border-bottom: 2px solid #cbd5e1;
}

.mk-mock-cart__row {
  display: grid;
  grid-template-columns: 2fr 0.5fr 1fr 1fr;
  padding: 0.55rem 1rem;
  font-size: 0.7rem;
  color: #1e293b;
  border-bottom: 1px solid #e2e8f0;
}

.mk-mock-cart__row--highlight {
  background: rgba(6, 182, 212, 0.04);
  animation: mkRowFlash 2s ease infinite alternate;
}

@keyframes mkRowFlash {
  from { background: rgba(6, 182, 212, 0.04); }
  to   { background: rgba(6, 182, 212, 0.1); }
}

.mk-mock-totals {
  background: #fff;
  border-radius: 14px;
  border: 1px solid #cbd5e1;
  padding: 0.75rem 1rem;
  box-shadow: 0 2px 8px rgba(0, 0, 0, 0.06);
}

.mk-mock-totals__line {
  display: flex;
  justify-content: space-between;
  padding: 0.25rem 0;
  font-size: 0.7rem;
  color: #475569;
}

.mk-mock-totals__line--vat {
  border-bottom: 1px solid #e2e8f0;
  padding-bottom: 0.4rem;
  margin-bottom: 0.3rem;
}

.mk-mock-totals__line--total {
  font-size: 0.9rem;
  font-weight: 700;
  color: #0f172a;
}

.mk-mock-totals__btn {
  margin-top: 0.5rem;
  padding: 0.5rem;
  text-align: center;
  border-radius: 8px;
  background: linear-gradient(180deg, #22d3ee, #06b6d4);
  color: #0f172a;
  font-weight: 700;
  font-size: 0.7rem;
  text-transform: uppercase;
  letter-spacing: 0.06em;
}

/* ── Features ── */
.mk-features {
  padding: 6rem 2rem;
  max-width: 1200px;
  margin: 0 auto;
}

.mk-features__grid {
  display: grid;
  grid-template-columns: repeat(3, 1fr);
  gap: 1.5rem;
}

@media (max-width: 900px) {
  .mk-features__grid { grid-template-columns: repeat(2, 1fr); }
}

@media (max-width: 600px) {
  .mk-features__grid { grid-template-columns: 1fr; }
}

.mk-fcard {
  padding: 2rem;
  background: var(--mk-surface);
  border: 1px solid var(--mk-border);
  border-radius: 16px;
  transition: border-color 0.3s, box-shadow 0.3s, opacity 0.6s, transform 0.6s;
  opacity: 0;
  transform: translateY(24px);
}

.mk-fcard.mk-visible {
  opacity: 1;
  transform: translateY(0);
}

.mk-fcard:hover {
  border-color: rgba(6, 182, 212, 0.4);
  box-shadow: 0 0 30px rgba(6, 182, 212, 0.06);
}

.mk-fcard__icon {
  display: inline-flex;
  align-items: center;
  justify-content: center;
  width: 48px;
  height: 48px;
  border-radius: 12px;
  background: rgba(6, 182, 212, 0.08);
  border: 1px solid rgba(6, 182, 212, 0.15);
  color: var(--mk-accent);
  margin-bottom: 1.25rem;
}

.mk-fcard__icon svg {
  width: 24px;
  height: 24px;
}

.mk-fcard__title {
  font-family: 'Barlow Condensed', sans-serif;
  font-size: 1.15rem;
  font-weight: 700;
  text-transform: uppercase;
  letter-spacing: 0.05em;
  color: var(--mk-text-bright);
  margin: 0 0 0.65rem;
}

.mk-fcard__desc {
  font-size: 0.92rem;
  line-height: 1.6;
  color: var(--mk-muted);
  margin: 0;
}

/* ── Secondary Screens ── */
.mk-screens {
  padding: 6rem 2rem;
  max-width: 1200px;
  margin: 0 auto;
}

.mk-screens__grid {
  display: grid;
  grid-template-columns: repeat(3, 1fr);
  gap: 1.5rem;
  opacity: 0;
  transform: translateY(30px);
  transition: opacity 0.7s ease, transform 0.7s ease;
}

.mk-screens__grid.mk-visible {
  opacity: 1;
  transform: translateY(0);
}

@media (max-width: 900px) {
  .mk-screens__grid { grid-template-columns: 1fr; }
}

.mk-screen-card {
  border-radius: 16px;
  border: 1px solid var(--mk-border);
  overflow: hidden;
  background: var(--mk-surface);
  transition: border-color 0.3s, box-shadow 0.3s;
}

.mk-screen-card:hover {
  border-color: rgba(6, 182, 212, 0.3);
  box-shadow: 0 0 40px rgba(6, 182, 212, 0.06);
}

.mk-screen-card__label {
  padding: 1rem 1.25rem;
  font-family: 'Barlow Condensed', sans-serif;
  font-weight: 700;
  text-transform: uppercase;
  letter-spacing: 0.06em;
  font-size: 0.85rem;
  color: var(--mk-accent);
  border-bottom: 1px solid var(--mk-border);
}

.mk-screen-card__mock {
  background: #f1f5f9;
  padding: 0.75rem;
  min-height: 280px;
}

.mk-mini-header {
  display: flex;
  align-items: center;
  justify-content: space-between;
  margin-bottom: 0.5rem;
  font-family: 'Barlow Condensed', sans-serif;
  font-weight: 700;
  font-size: 0.8rem;
  text-transform: uppercase;
  letter-spacing: 0.04em;
  color: #0f172a;
}

.mk-mini-actions {
  display: flex;
  gap: 0.35rem;
}

.mk-mini-btn {
  padding: 0.2rem 0.6rem;
  border-radius: 6px;
  background: linear-gradient(180deg, #22d3ee, #06b6d4);
  color: #0f172a;
  font-size: 0.55rem;
  font-weight: 700;
  text-transform: uppercase;
  letter-spacing: 0.04em;
}

.mk-mini-btn--sec {
  background: #fff;
  color: #1e293b;
  border: 1px solid #94a3b8;
}

.mk-mini-chip {
  padding: 0.2rem 0.5rem;
  border-radius: 6px;
  background: #fff;
  color: #475569;
  font-size: 0.55rem;
  font-weight: 600;
  border: 1px solid #cbd5e1;
}

.mk-mini-chip--active {
  background: rgba(6, 182, 212, 0.12);
  color: #0891b2;
  border-color: rgba(6, 182, 212, 0.3);
}

.mk-mini-table {
  background: #fff;
  border-radius: 10px;
  border: 1px solid #cbd5e1;
  overflow: hidden;
  font-size: 0.6rem;
}

.mk-mini-table__head {
  display: grid;
  grid-template-columns: 1fr 2fr 1fr 0.8fr;
  padding: 0.4rem 0.6rem;
  background: #f1f5f9;
  border-bottom: 1.5px solid #cbd5e1;
  font-weight: 700;
  color: #475569;
  text-transform: uppercase;
  letter-spacing: 0.06em;
  font-size: 0.5rem;
}

.mk-mini-table__row {
  display: grid;
  grid-template-columns: 1fr 2fr 1fr 0.8fr;
  padding: 0.4rem 0.6rem;
  color: #1e293b;
  border-bottom: 1px solid #e2e8f0;
}

.mk-mini-table__row:last-child {
  border-bottom: none;
}

.mk-qty-ok { color: #16a34a; font-weight: 700; }
.mk-qty-low { color: #d97706; font-weight: 700; }
.mk-qty-out { color: #dc2626; font-weight: 700; }

.mk-badge {
  padding: 0.15rem 0.4rem;
  border-radius: 4px;
  font-size: 0.5rem;
  font-weight: 700;
  text-transform: uppercase;
  letter-spacing: 0.04em;
}

.mk-badge--sent { background: #dbeafe; color: #1d4ed8; }
.mk-badge--draft { background: #f1f5f9; color: #475569; }
.mk-badge--accepted { background: #dcfce7; color: #15803d; }
.mk-badge--invoiced { background: #d1fae5; color: #047857; }

/* ── KPIs ── */
.mk-kpi-row {
  display: grid;
  grid-template-columns: repeat(4, 1fr);
  gap: 0.35rem;
  margin-bottom: 0.5rem;
}

.mk-kpi {
  background: #fff;
  border-radius: 8px;
  border: 1px solid #cbd5e1;
  padding: 0.4rem;
  text-align: center;
  display: flex;
  flex-direction: column;
}

.mk-kpi__val {
  font-family: 'Barlow Condensed', sans-serif;
  font-weight: 700;
  font-size: 0.7rem;
  color: #0f172a;
}

.mk-kpi__label {
  font-size: 0.45rem;
  color: #64748b;
  text-transform: uppercase;
  letter-spacing: 0.06em;
}

/* ── Chart Bars ── */
.mk-chart-bars {
  display: flex;
  gap: 0.35rem;
  align-items: flex-end;
  height: 90px;
  padding: 0.5rem;
  background: #fff;
  border-radius: 8px;
  border: 1px solid #cbd5e1;
}

.mk-chart-bar {
  flex: 1;
  height: var(--h);
  background: linear-gradient(180deg, #22d3ee, #0891b2);
  border-radius: 4px 4px 0 0;
  display: flex;
  align-items: flex-end;
  justify-content: center;
  position: relative;
}

.mk-chart-bar span {
  position: absolute;
  bottom: -14px;
  font-size: 0.45rem;
  color: #64748b;
  font-weight: 600;
}

/* ── Deploy ── */
.mk-deploy {
  padding: 6rem 2rem;
  max-width: 1000px;
  margin: 0 auto;
}

.mk-deploy__grid {
  display: grid;
  grid-template-columns: repeat(3, 1fr);
  gap: 1.5rem;
  opacity: 0;
  transform: translateY(24px);
  transition: opacity 0.7s ease, transform 0.7s ease;
}

.mk-deploy__grid.mk-visible {
  opacity: 1;
  transform: translateY(0);
}

@media (max-width: 700px) {
  .mk-deploy__grid { grid-template-columns: 1fr; }
}

.mk-deploy-card {
  padding: 2rem;
  background: var(--mk-surface);
  border: 1px solid var(--mk-border);
  border-radius: 16px;
  transition: border-color 0.3s;
}

.mk-deploy-card:hover {
  border-color: rgba(6, 182, 212, 0.3);
}

.mk-deploy-card__num {
  font-family: 'Barlow Condensed', sans-serif;
  font-size: 2rem;
  font-weight: 700;
  color: var(--mk-accent);
  opacity: 0.6;
  margin-bottom: 0.75rem;
}

.mk-deploy-card__title {
  font-family: 'Barlow Condensed', sans-serif;
  font-size: 1.15rem;
  font-weight: 700;
  text-transform: uppercase;
  letter-spacing: 0.05em;
  color: var(--mk-text-bright);
  margin: 0 0 0.65rem;
}

.mk-deploy-card__desc {
  font-size: 0.92rem;
  line-height: 1.6;
  color: var(--mk-muted);
  margin: 0;
}

.mk-deploy-card__desc code {
  padding: 0.15rem 0.45rem;
  border-radius: 4px;
  background: rgba(6, 182, 212, 0.08);
  color: var(--mk-accent);
  font-size: 0.85rem;
  font-family: 'SF Mono', 'Fira Code', monospace;
}

/* ── CTA ── */
.mk-cta {
  position: relative;
  text-align: center;
  padding: 7rem 2rem;
  overflow: hidden;
}

.mk-cta__glow {
  position: absolute;
  width: 600px;
  height: 400px;
  border-radius: 50%;
  background: radial-gradient(circle, rgba(6, 182, 212, 0.12), transparent 70%);
  top: 50%;
  left: 50%;
  transform: translate(-50%, -50%);
  pointer-events: none;
}

.mk-cta__title {
  position: relative;
  font-family: 'Barlow Condensed', sans-serif;
  font-size: 2.25rem;
  font-weight: 700;
  letter-spacing: 0.04em;
  text-transform: uppercase;
  color: var(--mk-text-bright);
  margin: 0 0 1rem;
}

.mk-cta__text {
  position: relative;
  font-size: 1.15rem;
  color: var(--mk-muted);
  margin: 0 0 2.5rem;
  line-height: 1.6;
}

/* ── Footer ── */
.mk-footer {
  border-top: 1px solid var(--mk-border);
  padding: 2rem;
}

.mk-footer__inner {
  max-width: 1200px;
  margin: 0 auto;
  display: flex;
  align-items: center;
  justify-content: center;
  gap: 0.75rem;
}

.mk-footer__icon {
  height: 20px;
  width: auto;
  opacity: 0.5;
}

.mk-footer__copy {
  font-size: 0.85rem;
  color: var(--mk-muted);
}

.mk-footer__copy strong {
  color: var(--mk-accent);
  font-weight: 600;
}

/* ── Responsive ── */
@media (max-width: 768px) {
  .mk-hero { padding: 7rem 1.25rem 3rem; }
  .mk-hero__stats { flex-direction: column; }
  .mk-stat { padding: 1rem 1.5rem; flex-direction: row; gap: 0.75rem; justify-content: center; }

  .mk-nav__link--hide-mobile { display: none; }
  .mk-nav__link { padding: 0.5rem 0.5rem; font-size: 0.8rem; }

  .mk-browser__body { flex-direction: column; }
  .mk-mock-sidebar { width: 100%; padding: 0.5rem; display: flex; gap: 0.5rem; overflow-x: auto; flex-wrap: wrap; }
  .mk-mock-sidebar__brand { padding: 0.25rem 0.5rem; margin-bottom: 0; border-bottom: none; }
  .mk-mock-sidebar__label { display: none; }
  .mk-mock-sidebar__item { white-space: nowrap; font-size: 0.6rem; padding: 0.3rem 0.6rem; }

  .mk-preview { padding: 4rem 1rem; }
  .mk-features { padding: 4rem 1rem; }
  .mk-screens { padding: 4rem 1rem; }
  .mk-deploy { padding: 4rem 1rem; }
}

@media (max-width: 500px) {
  .mk-kpi-row { grid-template-columns: repeat(2, 1fr); }
  .mk-mini-table__head,
  .mk-mini-table__row { grid-template-columns: 1fr 2fr 1fr; }
  .mk-mini-table__head span:last-child,
  .mk-mini-table__row span:last-child { display: none; }
}
</style>
