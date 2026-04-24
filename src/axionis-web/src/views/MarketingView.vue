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
    { threshold: 0.12 }
  )
  document.querySelectorAll('[data-animate]').forEach((el) => observer.observe(el))
})

function isVisible(id: string) {
  return visible.value.has(id)
}

const features = [
  { title: 'Fast POS Terminal', desc: 'Barcode-driven cart with real-time pricing, discounts, customer lookup, and instant invoicing. Built for speed.', icon: 'pos' },
  { title: 'Barcode Scanning', desc: 'Scan with a hardware reader or the built-in camera scanner. Works on tablets, phones, and desktops.', icon: 'scan' },
  { title: 'Stock Control', desc: 'Full inventory lifecycle — supplier tracking, stock receipts, bulk imports, label printing, and live quantities.', icon: 'stock' },
  { title: 'Consignment', desc: 'Receive, reconcile, and return consignment stock against supplier documents with line-level detail.', icon: 'consignment' },
  { title: 'Quotes & Invoices', desc: 'Create quotes, convert to invoices, email branded PDFs, and keep customer details attached to every sale.', icon: 'quotes' },
  { title: 'Customer Records', desc: 'Store customer details, company info, VAT numbers, and link them to invoices and quotes automatically.', icon: 'customers' },
  { title: 'Promotions & Pricing', desc: 'Set pricing rules, markup methods, product specials, and promotional pricing across your catalogue.', icon: 'pricing' },
  { title: 'Reports & Exports', desc: 'Revenue, margins, vendor performance, daily sales, payment breakdowns — filterable and exportable.', icon: 'reports' },
  { title: 'Branded PDFs', desc: 'Invoices, quotes, consignment checklists, and labels — all generated with your business branding.', icon: 'pdf' },
  { title: 'Tablet & PWA Ready', desc: 'Install as a Progressive Web App on any device. Touch-first design for tablets, phones, and desktops.', icon: 'pwa' }
]

const audiences = [
  { title: 'Retail shops', desc: 'With active stock movement and supplier relationships' },
  { title: 'Consignment businesses', desc: 'That need to track supplier stock separately from owned stock' },
  { title: 'Event & mobile sellers', desc: 'Operating from tablets at markets, expos, and pop-ups' },
  { title: 'Warehouses & dispatch', desc: 'Managing receiving, stock counts, and outbound orders' },
  { title: 'Specialist operators', desc: 'Who need control and speed, not complexity and bloat' }
]

const packages = [
  {
    name: 'Starter',
    desc: 'For small operators getting started.',
    items: ['POS + stock control', 'Axionis subdomain', 'Basic invoices', 'Unlimited users', 'Email support']
  },
  {
    name: 'Business',
    desc: 'For growing businesses that need more.',
    featured: true,
    items: ['Everything in Starter', 'Quotes + consignment', 'Custom domain option', 'Reports + CSV exports', 'Branded PDF documents']
  },
  {
    name: 'Managed',
    desc: 'For businesses that want it all handled.',
    items: ['Everything in Business', 'Managed email sending', 'Branded sender setup', 'Backups + maintenance', 'Priority support']
  }
]
</script>

<template>
  <div class="mk">
    <!-- ═══ NAV ═══ -->
    <nav class="mk-nav">
      <div class="mk-nav__inner">
        <img src="/brand/axionis-icon.png" alt="Axionis" class="mk-nav__icon" />
        <span class="mk-nav__wordmark">AXIONIS</span>
        <div class="mk-nav__spacer" />
        <a href="#features" class="mk-nav__link">Features</a>
        <a href="#pricing" class="mk-nav__link">Pricing</a>
        <a href="#preview" class="mk-nav__link mk-hide-mobile">Preview</a>
        <router-link to="/login" class="mk-nav__cta">Sign In</router-link>
      </div>
    </nav>

    <!-- ═══ 1. HERO ═══ -->
    <section class="mk-hero">
      <div class="mk-hero__grid-bg" />
      <div class="mk-hero__glow" />
      <div class="mk-hero__glow mk-hero__glow--2" />

      <div class="mk-hero__content">
        <img src="/brand/axionis-dark-bg.png" alt="Axionis POS" class="mk-hero__logo" />
        <p class="mk-hero__tagline">Built for mobility. Designed for real-world operations.</p>
        <h1 class="mk-hero__headline">
          A mobile-first POS, stock and consignment system for businesses that
          <span class="mk-hero__accent">don't sit behind a desk.</span>
        </h1>
        <div class="mk-hero__actions">
          <a href="mailto:hello@charsleydigital.com?subject=Axionis%20POS%20Demo%20Request" class="mk-btn mk-btn--glow">Request Demo</a>
          <a href="#features" class="mk-btn mk-btn--ghost">View Features</a>
        </div>
      </div>

      <!-- Hero indicators -->
      <div class="mk-hero__indicators">
        <div class="mk-indicator">
          <svg viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2"><rect x="2" y="3" width="20" height="14" rx="2"/><path d="M8 21h8M12 17v4"/></svg>
          <span>Fast POS</span>
        </div>
        <div class="mk-indicator">
          <svg viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2"><path d="M20 7l-8-4-8 4m16 0l-8 4m8-4v10l-8 4M4 7l8 4M4 7v10l8 4m0-10v10"/></svg>
          <span>Stock Control</span>
        </div>
        <div class="mk-indicator">
          <svg viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2"><path d="M14 2H6a2 2 0 0 0-2 2v16a2 2 0 0 0 2 2h12a2 2 0 0 0 2-2V8z"/><path d="M14 2v6h6"/></svg>
          <span>Quotes & Invoices</span>
        </div>
        <div class="mk-indicator">
          <svg viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2"><rect x="5" y="2" width="14" height="20" rx="3"/><path d="M12 18h.01"/></svg>
          <span>Tablet Ready</span>
        </div>
      </div>
    </section>

    <!-- ═══ 2. WHO IT IS FOR ═══ -->
    <section id="audience" class="mk-section" data-animate>
      <h2 class="mk-section-title">Built for operators who move product<span class="mk-section-title__line" /></h2>
      <div class="mk-audience-grid" :class="{ 'mk-visible': isVisible('audience') }">
        <div v-for="(a, i) in audiences" :key="a.title" class="mk-audience-card" :style="{ transitionDelay: `${i * 0.06}s` }">
          <h3 class="mk-audience-card__title">{{ a.title }}</h3>
          <p class="mk-audience-card__desc">{{ a.desc }}</p>
        </div>
      </div>
    </section>

    <!-- ═══ 3. CORE FEATURES ═══ -->
    <section id="features" class="mk-section" data-animate>
      <h2 class="mk-section-title">Everything you need to operate<span class="mk-section-title__line" /></h2>
      <p class="mk-section-sub">From the shop floor to the back office — sales, stock, consignment, quotes, invoices, and reports.</p>
      <div class="mk-features-grid">
        <div v-for="(f, i) in features" :key="f.title" class="mk-fcard" :class="{ 'mk-visible': isVisible('features') }" :style="{ transitionDelay: `${i * 0.05}s` }">
          <div class="mk-fcard__icon">
            <svg v-if="f.icon === 'pos'" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="1.5"><rect x="2" y="3" width="20" height="14" rx="2"/><path d="M8 21h8M12 17v4"/><path d="M7 8h2m2 0h2m2 0h2M7 11h10"/></svg>
            <svg v-if="f.icon === 'scan'" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="1.5"><path d="M3 7V5a2 2 0 0 1 2-2h2M17 3h2a2 2 0 0 1 2 2v2M21 17v2a2 2 0 0 1-2 2h-2M7 21H5a2 2 0 0 1-2-2v-2"/><path d="M7 12h10M7 8h3m4 0h3M7 16h3"/></svg>
            <svg v-if="f.icon === 'stock'" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="1.5"><path d="M20 7l-8-4-8 4m16 0l-8 4m8-4v10l-8 4M4 7l8 4M4 7v10l8 4m0-10v10"/></svg>
            <svg v-if="f.icon === 'consignment'" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="1.5"><path d="M16 3h5v5M4 20L21 3M21 16v5h-5M20 21L8 9"/></svg>
            <svg v-if="f.icon === 'quotes'" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="1.5"><path d="M14 2H6a2 2 0 0 0-2 2v16a2 2 0 0 0 2 2h12a2 2 0 0 0 2-2V8z"/><path d="M14 2v6h6M8 13h8M8 17h8M8 9h2"/></svg>
            <svg v-if="f.icon === 'customers'" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="1.5"><path d="M17 21v-2a4 4 0 0 0-4-4H5a4 4 0 0 0-4 4v2"/><circle cx="9" cy="7" r="4"/><path d="M23 21v-2a4 4 0 0 0-3-3.87M16 3.13a4 4 0 0 1 0 7.75"/></svg>
            <svg v-if="f.icon === 'pricing'" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="1.5"><path d="M20.59 13.41l-7.17 7.17a2 2 0 0 1-2.83 0L2 12V2h10l8.59 8.59a2 2 0 0 1 0 2.82z"/><circle cx="7" cy="7" r="1"/></svg>
            <svg v-if="f.icon === 'reports'" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="1.5"><path d="M18 20V10M12 20V4M6 20v-6"/></svg>
            <svg v-if="f.icon === 'pdf'" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="1.5"><path d="M14 2H6a2 2 0 0 0-2 2v16a2 2 0 0 0 2 2h12a2 2 0 0 0 2-2V8z"/><path d="M14 2v6h6"/><path d="M9 15v-2h2a1 1 0 1 1 0 2H9z"/></svg>
            <svg v-if="f.icon === 'pwa'" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="1.5"><rect x="5" y="2" width="14" height="20" rx="3"/><path d="M12 18h.01"/></svg>
          </div>
          <h3 class="mk-fcard__title">{{ f.title }}</h3>
          <p class="mk-fcard__desc">{{ f.desc }}</p>
        </div>
      </div>
    </section>

    <!-- ═══ 4. APP PREVIEW ═══ -->
    <section id="preview" class="mk-section mk-section--wide" data-animate>
      <h2 class="mk-section-title">See it in action<span class="mk-section-title__line" /></h2>
      <p class="mk-section-sub">A complete business operations platform, not just a cash register.</p>
      <div class="mk-browser" :class="{ 'mk-visible': isVisible('preview') }">
        <div class="mk-browser__bar">
          <span class="mk-browser__dot" /><span class="mk-browser__dot mk-browser__dot--y" /><span class="mk-browser__dot mk-browser__dot--g" />
          <span class="mk-browser__url">axionis.co.za/#/pos</span>
        </div>
        <div class="mk-browser__body">
          <div class="mk-mock-sidebar">
            <div class="mk-mock-sidebar__brand"><img src="/brand/axionis-icon.png" alt="" class="mk-mock-sidebar__logo" /><span>AXIONIS</span></div>
            <div class="mk-mock-sidebar__label">SELL</div>
            <div class="mk-mock-sidebar__item mk-mock-sidebar__item--active">Point of Sale</div>
            <div class="mk-mock-sidebar__item">Quotes</div>
            <div class="mk-mock-sidebar__item">Price Lookup</div>
            <div class="mk-mock-sidebar__label">INVENTORY</div>
            <div class="mk-mock-sidebar__item">Stock List</div>
            <div class="mk-mock-sidebar__item">Stock Batches</div>
            <div class="mk-mock-sidebar__label">OFFICE</div>
            <div class="mk-mock-sidebar__item">Reports</div>
            <div class="mk-mock-sidebar__item">Settings</div>
          </div>
          <div class="mk-mock-main">
            <div class="mk-mock-topbar"><span class="mk-mock-topbar__title">Point of Sale</span><span class="mk-mock-badge">Manager Mode</span></div>
            <div class="mk-mock-search"><span>Scan barcode, or type SKU / name…</span></div>
            <div class="mk-mock-cart">
              <div class="mk-mock-cart__head"><span>Item</span><span>Qty</span><span>Price</span><span>Total</span></div>
              <div class="mk-mock-cart__row"><span>Shimano Deore XT M8100</span><span>2</span><span>R 1,450</span><span>R 2,900</span></div>
              <div class="mk-mock-cart__row"><span>Maxxis Minion DHF 27.5</span><span>1</span><span>R 890</span><span>R 890</span></div>
              <div class="mk-mock-cart__row"><span>Fox 36 Float GRIP2 Fork</span><span>1</span><span>R 18,500</span><span>R 18,500</span></div>
              <div class="mk-mock-cart__row mk-mock-cart__row--hl"><span>RockShox Reverb AXS</span><span>1</span><span>R 12,200</span><span>R 12,200</span></div>
            </div>
            <div class="mk-mock-footer">
              <div class="mk-mock-footer__line"><span>Subtotal</span><span>R 34,490.00</span></div>
              <div class="mk-mock-footer__line mk-mock-footer__line--vat"><span>VAT (15%)</span><span>R 5,173.50</span></div>
              <div class="mk-mock-footer__line mk-mock-footer__line--total"><span>Total Due</span><span>R 39,663.50</span></div>
              <div class="mk-mock-footer__btn">Complete Sale</div>
            </div>
          </div>
        </div>
      </div>
    </section>

    <!-- ═══ 5. MOBILE-FIRST ═══ -->
    <section id="mobile" class="mk-section" data-animate>
      <div class="mk-split" :class="{ 'mk-visible': isVisible('mobile') }">
        <div class="mk-split__text">
          <h2 class="mk-split__title">Your business doesn't sit still.<br />Your POS shouldn't either.</h2>
          <p class="mk-split__desc">Run sales, scan products, check stock and manage consignment from the counter, warehouse, event stand, or tablet.</p>
          <ul class="mk-check-list">
            <li>Tablet-ready touch interface</li>
            <li>Installable as a Progressive Web App</li>
            <li>Camera barcode scanning built in</li>
            <li>Works across desktop, tablet, and mobile</li>
          </ul>
        </div>
        <div class="mk-split__visual">
          <div class="mk-device">
            <div class="mk-device__screen">
              <div class="mk-device__bar">Axionis POS</div>
              <div class="mk-device__row">Scan barcode…</div>
              <div class="mk-device__item"><span>Shimano XT</span><span class="mk-device__qty">×2</span><span>R 2,900</span></div>
              <div class="mk-device__item"><span>Maxxis DHF</span><span class="mk-device__qty">×1</span><span>R 890</span></div>
              <div class="mk-device__total"><span>Total</span><span>R 3,790</span></div>
              <div class="mk-device__btn">Complete Sale</div>
            </div>
          </div>
        </div>
      </div>
    </section>

    <!-- ═══ 6. CONSIGNMENT ═══ -->
    <section id="consignment" class="mk-section" data-animate>
      <div class="mk-split mk-split--reverse" :class="{ 'mk-visible': isVisible('consignment') }">
        <div class="mk-split__text">
          <h2 class="mk-split__title">Built for consignment from day one.</h2>
          <p class="mk-split__desc">Track supplier stock, received batches, checked quantities, returns, owned stock and consignment stock — without losing control.</p>
          <ul class="mk-check-list">
            <li>Supplier-linked stock tracking</li>
            <li>Batch receiving with expected vs checked quantities</li>
            <li>Return packing lists and movement history</li>
            <li>Owned and consignment stock separated</li>
            <li>PDF import and reconciliation</li>
          </ul>
        </div>
        <div class="mk-split__visual">
          <div class="mk-mini-card">
            <div class="mk-mini-card__head">Consignment Batch — Draft</div>
            <div class="mk-mini-card__row"><span>SKU</span><span>Product</span><span>Expected</span><span>Received</span></div>
            <div class="mk-mini-card__row mk-mini-card__row--data"><span>SHM-01</span><span>Shimano XT</span><span>10</span><span class="mk-text-ok">10</span></div>
            <div class="mk-mini-card__row mk-mini-card__row--data"><span>FOX-36</span><span>Fox 36 Fork</span><span>5</span><span class="mk-text-warn">3</span></div>
            <div class="mk-mini-card__row mk-mini-card__row--data"><span>MAX-27</span><span>Maxxis DHF</span><span>20</span><span class="mk-text-ok">20</span></div>
            <div class="mk-mini-card__bar"><div class="mk-mini-card__bar-fill" style="width:85%"></div></div>
            <div class="mk-mini-card__foot">85% checked — 2 lines remaining</div>
          </div>
        </div>
      </div>
    </section>

    <!-- ═══ 7. QUOTES & INVOICES ═══ -->
    <section id="quotes" class="mk-section" data-animate>
      <div class="mk-split" :class="{ 'mk-visible': isVisible('quotes') }">
        <div class="mk-split__text">
          <h2 class="mk-split__title">From quote to invoice without the admin mess.</h2>
          <p class="mk-split__desc">Create quotes, convert accepted quotes to invoices, generate branded PDFs, and keep customer details attached to every sale.</p>
          <ul class="mk-check-list">
            <li>Create and email professional quotes</li>
            <li>One-click convert to invoice</li>
            <li>Branded PDF generation</li>
            <li>Customer and company records linked</li>
          </ul>
        </div>
        <div class="mk-split__visual">
          <div class="mk-mini-card">
            <div class="mk-mini-card__head">Quotes</div>
            <div class="mk-mini-card__row"><span>#</span><span>Customer</span><span>Total</span><span>Status</span></div>
            <div class="mk-mini-card__row mk-mini-card__row--data"><span>Q-041</span><span>Red Bull Racing</span><span>R 84,200</span><span class="mk-pill mk-pill--blue">Sent</span></div>
            <div class="mk-mini-card__row mk-mini-card__row--data"><span>Q-040</span><span>Trail Riders ZA</span><span>R 23,450</span><span class="mk-pill mk-pill--grey">Draft</span></div>
            <div class="mk-mini-card__row mk-mini-card__row--data"><span>Q-039</span><span>Pedal Power CC</span><span>R 156,800</span><span class="mk-pill mk-pill--green">Accepted</span></div>
          </div>
        </div>
      </div>
    </section>

    <!-- ═══ 8. DEPLOYMENT ═══ -->
    <section id="hosting" class="mk-section" data-animate>
      <h2 class="mk-section-title">Hosted your way<span class="mk-section-title__line" /></h2>
      <p class="mk-section-sub">Every client gets a fully isolated deployment — own database, own files, own branding, own domain.</p>
      <div class="mk-hosting-grid" :class="{ 'mk-visible': isVisible('hosting') }">
        <div class="mk-hosting-card">
          <div class="mk-hosting-card__domain">clientname.axionis.co.za</div>
          <p>Axionis subdomain — ready in minutes, no DNS setup needed.</p>
        </div>
        <div class="mk-hosting-card">
          <div class="mk-hosting-card__domain">pos.yourbusiness.co.za</div>
          <p>Custom domain — your own brand front and centre.</p>
        </div>
      </div>
      <div class="mk-hosting-features" :class="{ 'mk-visible': isVisible('hosting') }">
        <span>Isolated database</span><span>Own file storage</span><span>Custom branding</span><span>SSL included</span><span>Optional managed email</span>
      </div>
    </section>

    <!-- ═══ 9. PRICING ═══ -->
    <section id="pricing" class="mk-section" data-animate>
      <h2 class="mk-section-title">Simple, transparent packages<span class="mk-section-title__line" /></h2>
      <p class="mk-section-sub">No per-user fees. No transaction charges. No surprises.</p>
      <div class="mk-pricing-grid" :class="{ 'mk-visible': isVisible('pricing') }">
        <div v-for="(p, i) in packages" :key="p.name" class="mk-pkg" :class="{ 'mk-pkg--featured': p.featured }" :style="{ transitionDelay: `${i * 0.08}s` }">
          <div v-if="p.featured" class="mk-pkg__badge">Most popular</div>
          <h3 class="mk-pkg__name">{{ p.name }}</h3>
          <p class="mk-pkg__desc">{{ p.desc }}</p>
          <ul class="mk-pkg__list">
            <li v-for="item in p.items" :key="item">{{ item }}</li>
          </ul>
          <a href="mailto:hello@charsleydigital.com?subject=Axionis%20POS%20-%20Pricing%20Enquiry" class="mk-btn" :class="p.featured ? 'mk-btn--glow' : 'mk-btn--ghost'">
            Request Pricing
          </a>
        </div>
      </div>
    </section>

    <!-- ═══ 10. FINAL CTA ═══ -->
    <section class="mk-cta">
      <div class="mk-cta__glow" />
      <h2 class="mk-cta__title">Ready to see Axionis POS in action?</h2>
      <p class="mk-cta__text">Book a demo and see how Axionis POS handles sales, stock, consignment, and real-world operations.</p>
      <a href="mailto:hello@charsleydigital.com?subject=Axionis%20POS%20Demo%20Request" class="mk-btn mk-btn--glow mk-btn--lg">Request Demo</a>
    </section>

    <!-- ═══ FOOTER ═══ -->
    <footer class="mk-footer">
      <div class="mk-footer__inner">
        <div class="mk-footer__brand">
          <img src="/brand/axionis-icon.png" alt="" class="mk-footer__icon" />
          <div>
            <strong>Axionis POS</strong>
            <span>Built for mobility. Designed for real-world operations.</span>
          </div>
        </div>
        <div class="mk-footer__links">
          <a href="mailto:hello@charsleydigital.com">Contact</a>
          <span>Privacy</span>
          <span>Terms</span>
        </div>
        <div class="mk-footer__copy">Built by <strong>Charsley Digital</strong></div>
      </div>
    </footer>
  </div>
</template>

<style scoped>
.mk {
  --bg: #050a18;
  --surface: #0c1424;
  --surface-2: #111c32;
  --border: #1a2744;
  --accent: #06b6d4;
  --accent-lt: #22d3ee;
  --accent-glow: rgba(6,182,212,0.3);
  --text: #e2e8f0;
  --text-hi: #f8fafc;
  --muted: #64748b;
  min-height: 100vh;
  background: var(--bg);
  color: var(--text);
  font-family: 'Source Sans 3','Inter',system-ui,sans-serif;
  overflow-x: hidden;
}

.mk-visible { animation: fadeUp .7s ease both; }
@keyframes fadeUp { from{opacity:0;transform:translateY(28px)} to{opacity:1;transform:translateY(0)} }

/* ── NAV ── */
.mk-nav { position:fixed;top:0;left:0;right:0;z-index:100;background:rgba(5,10,24,.88);backdrop-filter:blur(16px);border-bottom:1px solid var(--border); }
.mk-nav__inner { max-width:1200px;margin:0 auto;padding:0 2rem;height:64px;display:flex;align-items:center;gap:.75rem; }
.mk-nav__icon { height:28px;width:auto; }
.mk-nav__wordmark { font-family:'Barlow Condensed',sans-serif;font-weight:700;font-size:1.15rem;letter-spacing:.12em;color:var(--text-hi); }
.mk-nav__spacer { flex:1; }
.mk-nav__link { color:var(--muted);text-decoration:none;font-size:.875rem;font-weight:600;letter-spacing:.04em;padding:.5rem .75rem;border-radius:8px;transition:color .2s,background .2s; }
.mk-nav__link:hover { color:var(--text-hi);background:rgba(255,255,255,.04); }
.mk-nav__cta { display:inline-flex;align-items:center;padding:.5rem 1.25rem;border-radius:8px;background:var(--accent);color:#050a18;font-weight:700;font-size:.85rem;text-decoration:none;letter-spacing:.04em;transition:background .2s,box-shadow .2s; }
.mk-nav__cta:hover { background:var(--accent-lt);box-shadow:0 0 20px var(--accent-glow); }
.mk-hide-mobile { }

/* ── BUTTONS ── */
.mk-btn { display:inline-flex;align-items:center;justify-content:center;padding:.85rem 2.25rem;border-radius:10px;font-size:.95rem;font-weight:700;text-decoration:none;letter-spacing:.04em;transition:all .25s;border:none;cursor:pointer; }
.mk-btn--glow { background:linear-gradient(135deg,var(--accent),#0891b2);color:#050a18;box-shadow:0 0 30px var(--accent-glow),0 4px 15px rgba(0,0,0,.3); }
.mk-btn--glow:hover { background:linear-gradient(135deg,var(--accent-lt),var(--accent));box-shadow:0 0 50px var(--accent-glow),0 8px 25px rgba(0,0,0,.3);transform:translateY(-2px); }
.mk-btn--ghost { background:transparent;color:var(--accent);border:1.5px solid rgba(6,182,212,.4); }
.mk-btn--ghost:hover { background:rgba(6,182,212,.08);border-color:var(--accent); }
.mk-btn--lg { padding:1.1rem 3rem;font-size:1.05rem; }

/* ── HERO ── */
.mk-hero { position:relative;min-height:100vh;display:flex;flex-direction:column;align-items:center;justify-content:center;padding:7rem 2rem 4rem;text-align:center;overflow:hidden; }
.mk-hero__grid-bg { position:absolute;inset:0;background-image:linear-gradient(rgba(6,182,212,.03) 1px,transparent 1px),linear-gradient(90deg,rgba(6,182,212,.03) 1px,transparent 1px);background-size:60px 60px;mask-image:radial-gradient(ellipse 70% 60% at 50% 40%,black,transparent); }
.mk-hero__glow { position:absolute;width:700px;height:700px;border-radius:50%;background:radial-gradient(circle,rgba(6,182,212,.15),transparent 70%);top:-15%;left:50%;transform:translateX(-50%);pointer-events:none;animation:pulse 6s ease-in-out infinite alternate; }
.mk-hero__glow--2 { width:500px;height:500px;background:radial-gradient(circle,rgba(59,130,246,.1),transparent 70%);top:20%;left:30%;animation-delay:-3s;animation-duration:8s; }
@keyframes pulse { from{opacity:.6;transform:translateX(-50%) scale(1)} to{opacity:1;transform:translateX(-50%) scale(1.15)} }
.mk-hero__content { position:relative;z-index:1;max-width:800px; }
.mk-hero__logo { max-width:min(440px,85vw);height:auto;margin-bottom:2rem;filter:drop-shadow(0 0 40px rgba(6,182,212,.2)); }
.mk-hero__tagline { font-size:1.05rem;font-weight:600;color:var(--accent);letter-spacing:.03em;margin:0 0 1rem; }
.mk-hero__headline { font-family:'Barlow Condensed',sans-serif;font-size:clamp(1.75rem,4.5vw,3rem);font-weight:700;letter-spacing:.03em;text-transform:uppercase;line-height:1.2;color:var(--text-hi);margin:0 0 2rem; }
.mk-hero__accent { background:linear-gradient(135deg,var(--accent),#3b82f6);-webkit-background-clip:text;-webkit-text-fill-color:transparent;background-clip:text; }
.mk-hero__actions { display:flex;gap:1rem;justify-content:center;flex-wrap:wrap; }

.mk-hero__indicators { position:relative;z-index:1;display:flex;gap:1px;margin-top:4rem;background:var(--border);border-radius:14px;overflow:hidden;border:1px solid var(--border); }
.mk-indicator { display:flex;flex-direction:column;align-items:center;gap:.35rem;padding:1.25rem 2rem;background:var(--surface);min-width:0; }
.mk-indicator svg { width:22px;height:22px;color:var(--accent); }
.mk-indicator span { font-size:.7rem;font-weight:600;color:var(--muted);text-transform:uppercase;letter-spacing:.08em;white-space:nowrap; }

/* ── SECTIONS ── */
.mk-section { padding:6rem 2rem;max-width:1100px;margin:0 auto; }
.mk-section--wide { max-width:1200px; }
.mk-section-title { text-align:center;font-family:'Barlow Condensed',sans-serif;font-size:2rem;font-weight:700;letter-spacing:.04em;text-transform:uppercase;color:var(--text-hi);margin:0 0 .5rem;display:flex;flex-direction:column;align-items:center; }
.mk-section-title__line { display:block;width:60px;height:3px;background:linear-gradient(90deg,var(--accent),transparent);border-radius:2px;margin-top:.75rem; }
.mk-section-sub { text-align:center;font-size:1.1rem;color:var(--muted);max-width:600px;margin:.5rem auto 3rem;line-height:1.6; }

/* ── AUDIENCE ── */
.mk-audience-grid { display:grid;grid-template-columns:repeat(auto-fit,minmax(200px,1fr));gap:1rem;opacity:0;transform:translateY(24px);transition:opacity .7s,transform .7s; }
.mk-audience-grid.mk-visible { opacity:1;transform:translateY(0); }
.mk-audience-card { padding:1.5rem;background:var(--surface);border:1px solid var(--border);border-radius:14px;transition:border-color .3s; }
.mk-audience-card:hover { border-color:rgba(6,182,212,.35); }
.mk-audience-card__title { font-family:'Barlow Condensed',sans-serif;font-size:1.05rem;font-weight:700;text-transform:uppercase;letter-spacing:.04em;color:var(--text-hi);margin:0 0 .4rem; }
.mk-audience-card__desc { font-size:.88rem;color:var(--muted);margin:0;line-height:1.5; }

/* ── FEATURES ── */
.mk-features-grid { display:grid;grid-template-columns:repeat(auto-fill,minmax(260px,1fr));gap:1.25rem; }
.mk-fcard { padding:1.75rem;background:var(--surface);border:1px solid var(--border);border-radius:14px;transition:border-color .3s,box-shadow .3s,opacity .6s,transform .6s;opacity:0;transform:translateY(20px); }
.mk-fcard.mk-visible { opacity:1;transform:translateY(0); }
.mk-fcard:hover { border-color:rgba(6,182,212,.35);box-shadow:0 0 24px rgba(6,182,212,.05); }
.mk-fcard__icon { display:inline-flex;align-items:center;justify-content:center;width:44px;height:44px;border-radius:10px;background:rgba(6,182,212,.08);border:1px solid rgba(6,182,212,.15);color:var(--accent);margin-bottom:1rem; }
.mk-fcard__icon svg { width:22px;height:22px; }
.mk-fcard__title { font-family:'Barlow Condensed',sans-serif;font-size:1.05rem;font-weight:700;text-transform:uppercase;letter-spacing:.04em;color:var(--text-hi);margin:0 0 .5rem; }
.mk-fcard__desc { font-size:.88rem;line-height:1.55;color:var(--muted);margin:0; }

/* ── BROWSER MOCKUP ── */
.mk-browser { border-radius:16px;border:1px solid var(--border);overflow:hidden;box-shadow:0 40px 80px rgba(0,0,0,.5),0 0 60px rgba(6,182,212,.06);opacity:0;transform:translateY(40px);transition:opacity .8s,transform .8s; }
.mk-browser.mk-visible { opacity:1;transform:translateY(0); }
.mk-browser__bar { display:flex;align-items:center;gap:8px;padding:12px 16px;background:#0a0f1f;border-bottom:1px solid var(--border); }
.mk-browser__dot { width:12px;height:12px;border-radius:50%;background:#ef4444; }
.mk-browser__dot--y { background:#eab308; }
.mk-browser__dot--g { background:#22c55e; }
.mk-browser__url { margin-left:12px;padding:4px 16px;border-radius:6px;background:rgba(255,255,255,.04);font-size:.75rem;color:var(--muted);font-family:'SF Mono','Fira Code',monospace; }
.mk-browser__body { display:flex;min-height:400px;background:#f1f5f9; }

.mk-mock-sidebar { width:190px;background:linear-gradient(180deg,#0f172a,#020617);padding:.75rem 0;flex-shrink:0;border-right:1px solid #1e293b; }
.mk-mock-sidebar__brand { display:flex;align-items:center;gap:.5rem;padding:.5rem 1rem .75rem;border-bottom:1px solid #1e293b;margin-bottom:.5rem;font-family:'Barlow Condensed',sans-serif;font-weight:700;font-size:.8rem;letter-spacing:.1em;color:#f1f5f9; }
.mk-mock-sidebar__logo { height:20px;width:auto; }
.mk-mock-sidebar__label { padding:.4rem 1rem .15rem;font-size:.5rem;font-weight:700;letter-spacing:.14em;text-transform:uppercase;color:#475569; }
.mk-mock-sidebar__item { padding:.35rem 1rem;font-size:.65rem;color:#94a3b8;font-family:'Barlow Condensed',sans-serif;font-weight:600;letter-spacing:.04em;text-transform:uppercase;border-radius:5px;margin:2px .4rem; }
.mk-mock-sidebar__item--active { background:rgba(6,182,212,.14);color:#22d3ee;border:1px solid rgba(6,182,212,.3); }

.mk-mock-main { flex:1;padding:1rem;display:flex;flex-direction:column;gap:.6rem;min-width:0; }
.mk-mock-topbar { display:flex;align-items:center;justify-content:space-between; }
.mk-mock-topbar__title { font-family:'Barlow Condensed',sans-serif;font-weight:700;font-size:1rem;text-transform:uppercase;letter-spacing:.05em;color:#0f172a; }
.mk-mock-badge { font-size:.55rem;font-weight:700;padding:.2rem .6rem;border-radius:20px;background:rgba(6,182,212,.12);color:#0891b2;text-transform:uppercase;letter-spacing:.06em; }
.mk-mock-search { padding:.5rem .75rem;border-radius:8px;background:#fff;border:1.5px solid #94a3b8;font-size:.7rem;color:#94a3b8; }
.mk-mock-cart { background:#fff;border-radius:12px;border:1px solid #cbd5e1;overflow:hidden;flex:1;box-shadow:0 1px 4px rgba(0,0,0,.05); }
.mk-mock-cart__head { display:grid;grid-template-columns:2fr .5fr 1fr 1fr;padding:.4rem .75rem;font-size:.5rem;font-weight:700;text-transform:uppercase;letter-spacing:.08em;color:#475569;background:#f1f5f9;border-bottom:2px solid #cbd5e1; }
.mk-mock-cart__row { display:grid;grid-template-columns:2fr .5fr 1fr 1fr;padding:.45rem .75rem;font-size:.65rem;color:#1e293b;border-bottom:1px solid #e2e8f0; }
.mk-mock-cart__row--hl { background:rgba(6,182,212,.06); }
.mk-mock-footer { background:#fff;border-radius:12px;border:1px solid #cbd5e1;padding:.6rem .75rem;box-shadow:0 1px 4px rgba(0,0,0,.05); }
.mk-mock-footer__line { display:flex;justify-content:space-between;padding:.2rem 0;font-size:.65rem;color:#475569; }
.mk-mock-footer__line--vat { border-bottom:1px solid #e2e8f0;padding-bottom:.35rem;margin-bottom:.25rem; }
.mk-mock-footer__line--total { font-size:.85rem;font-weight:700;color:#0f172a; }
.mk-mock-footer__btn { margin-top:.4rem;padding:.45rem;text-align:center;border-radius:8px;background:linear-gradient(180deg,#22d3ee,#06b6d4);color:#0f172a;font-weight:700;font-size:.65rem;text-transform:uppercase;letter-spacing:.06em; }

/* ── SPLIT SECTIONS ── */
.mk-split { display:grid;grid-template-columns:1fr 1fr;gap:3rem;align-items:center;opacity:0;transform:translateY(24px);transition:opacity .7s,transform .7s; }
.mk-split.mk-visible { opacity:1;transform:translateY(0); }
.mk-split--reverse { direction:rtl; }
.mk-split--reverse > * { direction:ltr; }
.mk-split__title { font-family:'Barlow Condensed',sans-serif;font-size:1.75rem;font-weight:700;text-transform:uppercase;letter-spacing:.03em;line-height:1.2;color:var(--text-hi);margin:0 0 1rem; }
.mk-split__desc { font-size:1.05rem;color:var(--muted);line-height:1.6;margin:0 0 1.5rem; }

.mk-check-list { list-style:none;padding:0;margin:0; }
.mk-check-list li { padding:.4rem 0 .4rem 1.5rem;font-size:.95rem;color:var(--text);position:relative; }
.mk-check-list li::before { content:'✓';position:absolute;left:0;color:var(--accent);font-weight:700; }

/* ── DEVICE MOCKUP ── */
.mk-device { width:260px;margin:0 auto;border:3px solid #334155;border-radius:28px;overflow:hidden;background:#0f172a;box-shadow:0 20px 60px rgba(0,0,0,.4); }
.mk-device__screen { padding:.75rem; }
.mk-device__bar { font-family:'Barlow Condensed',sans-serif;font-weight:700;font-size:.75rem;text-transform:uppercase;letter-spacing:.08em;color:var(--accent);padding:.5rem 0;border-bottom:1px solid #1e293b;margin-bottom:.5rem; }
.mk-device__row { padding:.4rem .5rem;border-radius:6px;background:rgba(255,255,255,.04);font-size:.65rem;color:#64748b;margin-bottom:.5rem; }
.mk-device__item { display:flex;justify-content:space-between;padding:.35rem 0;font-size:.7rem;color:#e2e8f0;border-bottom:1px solid #1e293b; }
.mk-device__qty { color:var(--accent);font-weight:700; }
.mk-device__total { display:flex;justify-content:space-between;padding:.5rem 0;font-size:.85rem;font-weight:700;color:var(--text-hi);border-top:1px solid var(--accent);margin-top:.35rem; }
.mk-device__btn { margin-top:.5rem;padding:.5rem;text-align:center;border-radius:8px;background:linear-gradient(135deg,var(--accent),#0891b2);color:#050a18;font-weight:700;font-size:.65rem;text-transform:uppercase;letter-spacing:.06em; }

/* ── MINI CARD MOCKUP ── */
.mk-mini-card { background:#fff;border-radius:14px;border:1px solid #cbd5e1;overflow:hidden;box-shadow:0 8px 30px rgba(0,0,0,.08);max-width:380px;margin:0 auto; }
.mk-mini-card__head { padding:.75rem 1rem;font-family:'Barlow Condensed',sans-serif;font-weight:700;font-size:.85rem;text-transform:uppercase;letter-spacing:.05em;color:#0f172a;background:#f8fafc;border-bottom:1px solid #e2e8f0; }
.mk-mini-card__row { display:grid;grid-template-columns:1fr 2fr .8fr .8fr;padding:.4rem 1rem;font-size:.6rem;color:#475569;font-weight:700;text-transform:uppercase;letter-spacing:.06em; }
.mk-mini-card__row--data { font-weight:400;color:#1e293b;text-transform:none;border-bottom:1px solid #f1f5f9; }
.mk-mini-card__bar { margin:.75rem 1rem .25rem;height:6px;border-radius:3px;background:#e2e8f0;overflow:hidden; }
.mk-mini-card__bar-fill { height:100%;background:linear-gradient(90deg,var(--accent),#0891b2);border-radius:3px; }
.mk-mini-card__foot { padding:.25rem 1rem .75rem;font-size:.65rem;color:#64748b; }
.mk-text-ok { color:#16a34a;font-weight:600; }
.mk-text-warn { color:#d97706;font-weight:600; }
.mk-pill { padding:.15rem .4rem;border-radius:4px;font-size:.5rem;font-weight:700;text-transform:uppercase;letter-spacing:.04em; }
.mk-pill--blue { background:#dbeafe;color:#1d4ed8; }
.mk-pill--grey { background:#f1f5f9;color:#475569; }
.mk-pill--green { background:#dcfce7;color:#15803d; }

/* ── HOSTING ── */
.mk-hosting-grid { display:grid;grid-template-columns:1fr 1fr;gap:1.5rem;margin-bottom:2rem;opacity:0;transform:translateY(24px);transition:opacity .7s,transform .7s; }
.mk-hosting-grid.mk-visible { opacity:1;transform:translateY(0); }
.mk-hosting-card { padding:2rem;background:var(--surface);border:1px solid var(--border);border-radius:16px;text-align:center; }
.mk-hosting-card p { font-size:.92rem;color:var(--muted);margin:.75rem 0 0;line-height:1.5; }
.mk-hosting-card__domain { font-family:'SF Mono','Fira Code',monospace;font-size:1rem;color:var(--accent);padding:.5rem 1rem;background:rgba(6,182,212,.06);border:1px solid rgba(6,182,212,.2);border-radius:8px;display:inline-block; }
.mk-hosting-features { display:flex;flex-wrap:wrap;justify-content:center;gap:.75rem;opacity:0;transform:translateY(16px);transition:opacity .7s .2s,transform .7s .2s; }
.mk-hosting-features.mk-visible { opacity:1;transform:translateY(0); }
.mk-hosting-features span { padding:.4rem 1rem;border-radius:20px;background:var(--surface);border:1px solid var(--border);font-size:.8rem;color:var(--text);font-weight:600; }

/* ── PRICING ── */
.mk-pricing-grid { display:grid;grid-template-columns:repeat(3,1fr);gap:1.5rem;opacity:0;transform:translateY(24px);transition:opacity .7s,transform .7s; }
.mk-pricing-grid.mk-visible { opacity:1;transform:translateY(0); }
.mk-pkg { position:relative;padding:2.25rem 1.75rem;background:var(--surface);border:1px solid var(--border);border-radius:18px;display:flex;flex-direction:column;transition:border-color .3s; }
.mk-pkg:hover { border-color:rgba(6,182,212,.3); }
.mk-pkg--featured { border-color:rgba(6,182,212,.5);box-shadow:0 0 50px rgba(6,182,212,.08);background:linear-gradient(180deg,var(--surface-2),var(--surface)); }
.mk-pkg__badge { position:absolute;top:-12px;left:50%;transform:translateX(-50%);padding:.3rem 1.25rem;border-radius:20px;background:linear-gradient(135deg,var(--accent),#0891b2);color:#050a18;font-size:.65rem;font-weight:700;text-transform:uppercase;letter-spacing:.06em;white-space:nowrap; }
.mk-pkg__name { font-family:'Barlow Condensed',sans-serif;font-size:1.5rem;font-weight:700;text-transform:uppercase;letter-spacing:.06em;color:var(--text-hi);margin:0 0 .35rem; }
.mk-pkg__desc { font-size:.88rem;color:var(--muted);margin:0 0 1.5rem;line-height:1.5; }
.mk-pkg__list { list-style:none;padding:0;margin:0 0 1.5rem;flex:1; }
.mk-pkg__list li { padding:.45rem 0 .45rem 1.5rem;font-size:.88rem;color:var(--text);position:relative;border-bottom:1px solid var(--border); }
.mk-pkg__list li::before { content:'✓';position:absolute;left:0;color:var(--accent);font-weight:700; }
.mk-pkg__list li:last-child { border-bottom:none; }
.mk-pkg .mk-btn { width:100%;text-align:center; }

/* ── CTA ── */
.mk-cta { position:relative;text-align:center;padding:7rem 2rem;overflow:hidden; }
.mk-cta__glow { position:absolute;width:600px;height:400px;border-radius:50%;background:radial-gradient(circle,rgba(6,182,212,.12),transparent 70%);top:50%;left:50%;transform:translate(-50%,-50%);pointer-events:none; }
.mk-cta__title { position:relative;font-family:'Barlow Condensed',sans-serif;font-size:2.25rem;font-weight:700;letter-spacing:.04em;text-transform:uppercase;color:var(--text-hi);margin:0 0 1rem; }
.mk-cta__text { position:relative;font-size:1.15rem;color:var(--muted);margin:0 0 2.5rem;line-height:1.6; }

/* ── FOOTER ── */
.mk-footer { border-top:1px solid var(--border);padding:3rem 2rem; }
.mk-footer__inner { max-width:1100px;margin:0 auto;display:flex;flex-wrap:wrap;align-items:center;justify-content:space-between;gap:1.5rem; }
.mk-footer__brand { display:flex;align-items:center;gap:.75rem; }
.mk-footer__icon { height:28px;width:auto;opacity:.6; }
.mk-footer__brand strong { display:block;font-family:'Barlow Condensed',sans-serif;font-size:1rem;font-weight:700;letter-spacing:.06em;text-transform:uppercase;color:var(--text-hi); }
.mk-footer__brand span { font-size:.75rem;color:var(--muted); }
.mk-footer__links { display:flex;gap:1.5rem; }
.mk-footer__links a,.mk-footer__links span { font-size:.85rem;color:var(--muted);text-decoration:none;cursor:pointer; }
.mk-footer__links a:hover { color:var(--accent); }
.mk-footer__copy { font-size:.85rem;color:var(--muted); }
.mk-footer__copy strong { color:var(--accent);font-weight:600; }

/* ── RESPONSIVE ── */
@media(max-width:900px) {
  .mk-split { grid-template-columns:1fr;gap:2rem; }
  .mk-split--reverse { direction:ltr; }
  .mk-pricing-grid { grid-template-columns:1fr; }
  .mk-hosting-grid { grid-template-columns:1fr; }
  .mk-features-grid { grid-template-columns:repeat(2,1fr); }
}

@media(max-width:768px) {
  .mk-hero { padding:6rem 1.25rem 3rem; }
  .mk-hero__indicators { flex-wrap:wrap;justify-content:center; }
  .mk-indicator { padding:.75rem 1.25rem; }
  .mk-hide-mobile { display:none; }
  .mk-nav__link { padding:.5rem .4rem;font-size:.8rem; }
  .mk-section { padding:4rem 1.25rem; }

  .mk-browser__body { flex-direction:column; }
  .mk-mock-sidebar { width:100%;padding:.5rem;display:flex;gap:.4rem;overflow-x:auto;flex-wrap:wrap; }
  .mk-mock-sidebar__brand { padding:.25rem .5rem;margin-bottom:0;border-bottom:none; }
  .mk-mock-sidebar__label { display:none; }
  .mk-mock-sidebar__item { white-space:nowrap;font-size:.55rem;padding:.25rem .5rem; }

  .mk-footer__inner { flex-direction:column;align-items:flex-start; }
}

@media(max-width:600px) {
  .mk-features-grid { grid-template-columns:1fr; }
  .mk-audience-grid { grid-template-columns:1fr; }
}
</style>
