<script setup lang="ts">
import { ref, onMounted, onUnmounted } from 'vue'

const visible = ref(new Set<string>())
const showStickyBar = ref(false)
const openFaq = ref<number | null>(null)

function toggleFaq(i: number) {
  openFaq.value = openFaq.value === i ? null : i
}

function handleScroll() {
  showStickyBar.value = window.scrollY > window.innerHeight * 0.6
}

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
  window.addEventListener('scroll', handleScroll, { passive: true })
})

onUnmounted(() => {
  window.removeEventListener('scroll', handleScroll)
})

function isVisible(id: string) {
  return visible.value.has(id)
}

const features = [
  { title: 'Point of Sale', desc: 'Scan a barcode, add to cart, complete the sale. Pricing, discounts, and customer lookup happen automatically.', icon: 'pos' },
  { title: 'Barcode Scanning', desc: 'Use a hardware scanner or your device camera. Both work out of the box — no plugins, no config.', icon: 'scan' },
  { title: 'Stock Control', desc: 'Track quantities, costs, suppliers, and stock movements. Import from CSV or add products one by one.', icon: 'stock' },
  { title: 'Consignment', desc: 'Receive supplier stock, check it against their invoice, and track what you owe vs. what you own.', icon: 'consignment' },
  { title: 'Quotes & Invoices', desc: 'Build a quote, send it as a PDF, and convert it to an invoice when the customer says yes.', icon: 'quotes' },
  { title: 'Customer Records', desc: 'Store names, companies, VAT numbers. They get linked to every quote and invoice automatically.', icon: 'customers' },
  { title: 'Pricing Rules', desc: 'Set default markups, per-product overrides, specials, and promotional pricing. The POS does the maths.', icon: 'pricing' },
  { title: 'Reports', desc: 'Sales by day, margins by supplier, payment method breakdowns. Filter by date range and export to CSV.', icon: 'reports' },
  { title: 'Branded PDFs', desc: 'Your logo, your colours, your details on every invoice, quote, and consignment checklist.', icon: 'pdf' },
  { title: 'Works on Tablets', desc: 'Install it like an app on any device. Designed for touch screens first, desktop second.', icon: 'pwa' }
]

const faqs = [
  { q: 'Can I import my existing stock?', a: 'Yes. You can import products from a CSV file — SKUs, descriptions, costs, sell prices, suppliers. There\'s a column mapper so it works with whatever format you export from your current system.' },
  { q: 'Do I need special hardware?', a: 'No. Axionis runs in a browser. Any tablet, laptop, or phone will work. If you have a USB or Bluetooth barcode scanner, it plugs straight in. You can also scan with your device camera.' },
  { q: 'What happens if I cancel?', a: 'You stop paying. We can export your data as CSV files before we shut down your instance. There are no lock-in contracts.' },
  { q: 'Is my data safe?', a: 'Each client gets their own isolated database on South African infrastructure. Backups run daily. If something goes wrong, we restore it — that\'s included in the monthly fee.' },
  { q: 'How long does setup take?', a: 'Usually under 24 hours. We deploy your instance, set up your domain and branding, create your staff accounts, and walk you through it over a call.' },
  { q: 'Can multiple people use it at the same time?', a: 'Yes. There\'s no user limit. Your whole team can be logged in on different devices at the same time — POS on the counter, stock management in the back.' }
]
</script>

<template>
  <div class="mk">
    <!-- NAV -->
    <nav class="mk-nav">
      <div class="mk-nav__inner">
        <img src="/brand/axionis-icon.png" alt="Axionis" class="mk-nav__icon" />
        <span class="mk-nav__wordmark">AXIONIS</span>
        <div class="mk-nav__spacer" />
        <a href="#features" class="mk-nav__link">Features</a>
        <a href="#pricing" class="mk-nav__link">Pricing</a>
        <a href="#faq" class="mk-nav__link mk-hide-mobile">FAQ</a>
        <router-link to="/login" class="mk-nav__cta">Sign In</router-link>
      </div>
    </nav>

    <!-- HERO -->
    <section class="mk-hero">
      <div class="mk-hero__grid-bg" />
      <div class="mk-hero__glow" />
      <div class="mk-hero__glow mk-hero__glow--2" />

      <div class="mk-hero__content">
        <img src="/brand/axionis-dark-bg.png" alt="Axionis POS" class="mk-hero__logo" />
        <h1 class="mk-hero__headline">
          POS, stock, and consignment —
          <span class="mk-hero__accent">simple enough to just start using.</span>
        </h1>
        <p class="mk-hero__sub">
          Built for businesses that sell from shop counters, market stalls, warehouses, and tablets.
          Not businesses that sit in meetings about their POS system.
        </p>
        <div class="mk-hero__actions">
          <a href="mailto:hello@charsleydigital.com?subject=Axionis%20POS%20—%20Let's%20talk" class="mk-btn mk-btn--glow">Let's talk</a>
          <a href="#features" class="mk-btn mk-btn--ghost">See what's included</a>
        </div>
      </div>

      <div class="mk-hero__proof">
        <span>Built and hosted in South Africa</span>
        <span class="mk-hero__proof-dot" />
        <span>Same stack running live retail operations</span>
        <span class="mk-hero__proof-dot" />
        <span>Daily backups included</span>
      </div>
    </section>

    <!-- PREVIEW -->
    <section id="preview" class="mk-section mk-section--wide" data-animate>
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
            <div class="mk-mock-topbar"><span class="mk-mock-topbar__title">Point of Sale</span><span class="mk-mock-badge">Manager</span></div>
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
      <p class="mk-browser__caption">This is the actual interface. What you see is what your team uses.</p>
    </section>

    <!-- FEATURES -->
    <section id="features" class="mk-section" data-animate>
      <h2 class="mk-section-title">What you get<span class="mk-section-title__line" /></h2>
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

    <!-- CONSIGNMENT — different rhythm, no checklist -->
    <section id="consignment" class="mk-section mk-section--highlight" data-animate>
      <div class="mk-highlight" :class="{ 'mk-visible': isVisible('consignment') }">
        <h2 class="mk-highlight__title">If you deal with consignment stock, this was built for you.</h2>
        <p class="mk-highlight__desc">
          Most POS systems treat consignment as an afterthought. Axionis was designed around it.
          Receive a batch from a supplier, check it line by line against their invoice, track what's
          yours vs. what's theirs, and generate return packing lists when stock goes back.
        </p>
        <div class="mk-highlight__grid">
          <div class="mk-highlight__item">Supplier-linked stock</div>
          <div class="mk-highlight__item">Batch receiving</div>
          <div class="mk-highlight__item">Expected vs checked quantities</div>
          <div class="mk-highlight__item">Return packing lists</div>
          <div class="mk-highlight__item">Owned vs consignment tracking</div>
          <div class="mk-highlight__item">Supplier invoice PDF parsing</div>
        </div>
      </div>
    </section>

    <!-- MOBILE / TABLET -->
    <section id="mobile" class="mk-section" data-animate>
      <div class="mk-split" :class="{ 'mk-visible': isVisible('mobile') }">
        <div class="mk-split__text">
          <h2 class="mk-split__title">It runs on a tablet. That's the point.</h2>
          <p class="mk-split__desc">
            Your staff shouldn't need a desktop PC to ring up a sale.
            Axionis installs like an app on any tablet or phone. Camera scanning is built in.
            Touch targets are sized for fingers, not mouse cursors.
          </p>
          <p class="mk-split__note">No app store needed — it's a Progressive Web App. Open the URL, tap "Add to Home Screen", done.</p>
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

    <!-- HOSTING — shorter, less corporate -->
    <section id="hosting" class="mk-section" data-animate>
      <h2 class="mk-section-title">Your own instance<span class="mk-section-title__line" /></h2>
      <p class="mk-section-sub">
        Every client gets a separate deployment. Your data doesn't sit in a shared database with other businesses.
      </p>
      <div class="mk-hosting-grid" :class="{ 'mk-visible': isVisible('hosting') }">
        <div class="mk-hosting-card">
          <div class="mk-hosting-card__domain">yourshop.axionis.co.za</div>
          <p>Axionis subdomain — live in minutes.</p>
        </div>
        <div class="mk-hosting-card">
          <div class="mk-hosting-card__domain">pos.yourbusiness.co.za</div>
          <p>Your own domain — we set it up for you.</p>
        </div>
      </div>
    </section>

    <!-- PRICING -->
    <section id="pricing" class="mk-section" data-animate>
      <h2 class="mk-section-title">Pricing<span class="mk-section-title__line" /></h2>
      <p class="mk-section-sub">One plan. Everything included. No per-user fees, no transaction cuts.</p>
      <div class="mk-price-row" :class="{ 'mk-visible': isVisible('pricing') }">
        <div class="mk-price-box">
          <div class="mk-price-box__label">Once-off</div>
          <div class="mk-price-box__amount">R 3,500</div>
          <div class="mk-price-box__period">setup</div>
          <p class="mk-price-box__desc">We deploy your instance, configure your domain and branding, set up staff accounts, and walk you through everything on a call.</p>
        </div>
        <div class="mk-price-box mk-price-box--featured">
          <div class="mk-price-box__badge">Everything included</div>
          <div class="mk-price-box__label">Monthly</div>
          <div class="mk-price-box__amount">R 1,000</div>
          <div class="mk-price-box__period">per month</div>
          <p class="mk-price-box__desc">Hosting, daily backups, software updates, and support. Unlimited users. Cancel anytime — no contracts.</p>
        </div>
      </div>
      <div class="mk-price-cta" :class="{ 'mk-visible': isVisible('pricing') }">
        <a href="mailto:hello@charsleydigital.com?subject=Axionis%20POS%20—%20Let's%20get%20started" class="mk-btn mk-btn--glow">Get in touch</a>
      </div>
    </section>

    <!-- FAQ -->
    <section id="faq" class="mk-section" data-animate>
      <h2 class="mk-section-title">Common questions<span class="mk-section-title__line" /></h2>
      <div class="mk-faq" :class="{ 'mk-visible': isVisible('faq') }">
        <div v-for="(f, i) in faqs" :key="i" class="mk-faq__item" :class="{ 'mk-faq__item--open': openFaq === i }" @click="toggleFaq(i)">
          <div class="mk-faq__q">
            <span>{{ f.q }}</span>
            <svg viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2"><path d="M6 9l6 6 6-6"/></svg>
          </div>
          <div class="mk-faq__a">{{ f.a }}</div>
        </div>
      </div>
    </section>

    <!-- FINAL CTA — conversational -->
    <section class="mk-cta">
      <div class="mk-cta__glow" />
      <h2 class="mk-cta__title">Want to see if it fits?</h2>
      <p class="mk-cta__text">
        Drop us an email. We'll set up a call, show you the system, and answer whatever you need to know.
        No pitch decks, no sales process.
      </p>
      <a href="mailto:hello@charsleydigital.com?subject=Axionis%20POS%20—%20Let's%20talk" class="mk-btn mk-btn--glow mk-btn--lg">Let's talk</a>
    </section>

    <!-- FOOTER — with founder note -->
    <footer class="mk-footer">
      <div class="mk-footer__inner">
        <div class="mk-footer__brand">
          <img src="/brand/axionis-icon.png" alt="" class="mk-footer__icon" />
          <div>
            <strong>Axionis POS</strong>
            <span>Built by <a href="mailto:hello@charsleydigital.com" class="mk-footer__cd">Charsley Digital</a> in South Africa.</span>
          </div>
        </div>
        <div class="mk-footer__links">
          <a href="mailto:hello@charsleydigital.com">Contact</a>
          <span>Privacy</span>
          <span>Terms</span>
        </div>
      </div>
    </footer>

    <!-- Sticky mobile CTA -->
    <div class="mk-sticky" :class="{ 'mk-sticky--show': showStickyBar }">
      <a href="mailto:hello@charsleydigital.com?subject=Axionis%20POS%20—%20Let's%20talk" class="mk-sticky__btn">Let's talk</a>
      <a href="#pricing" class="mk-sticky__link">Pricing</a>
    </div>
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

/* NAV */
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

/* BUTTONS */
.mk-btn { display:inline-flex;align-items:center;justify-content:center;padding:.85rem 2.25rem;border-radius:10px;font-size:.95rem;font-weight:700;text-decoration:none;letter-spacing:.04em;transition:all .25s;border:none;cursor:pointer; }
.mk-btn--glow { background:linear-gradient(135deg,var(--accent),#0891b2);color:#050a18;box-shadow:0 0 30px var(--accent-glow),0 4px 15px rgba(0,0,0,.3); }
.mk-btn--glow:hover { background:linear-gradient(135deg,var(--accent-lt),var(--accent));box-shadow:0 0 50px var(--accent-glow),0 8px 25px rgba(0,0,0,.3);transform:translateY(-2px); }
.mk-btn--ghost { background:transparent;color:var(--accent);border:1.5px solid rgba(6,182,212,.4); }
.mk-btn--ghost:hover { background:rgba(6,182,212,.08);border-color:var(--accent); }
.mk-btn--lg { padding:1.1rem 3rem;font-size:1.05rem; }

/* HERO */
.mk-hero { position:relative;min-height:100vh;display:flex;flex-direction:column;align-items:center;justify-content:center;padding:7rem 2rem 4rem;text-align:center;overflow:hidden; }
.mk-hero__grid-bg { position:absolute;inset:0;background-image:linear-gradient(rgba(6,182,212,.03) 1px,transparent 1px),linear-gradient(90deg,rgba(6,182,212,.03) 1px,transparent 1px);background-size:60px 60px;mask-image:radial-gradient(ellipse 70% 60% at 50% 40%,black,transparent); }
.mk-hero__glow { position:absolute;width:700px;height:700px;border-radius:50%;background:radial-gradient(circle,rgba(6,182,212,.15),transparent 70%);top:-15%;left:50%;transform:translateX(-50%);pointer-events:none;animation:pulse 6s ease-in-out infinite alternate; }
.mk-hero__glow--2 { width:500px;height:500px;background:radial-gradient(circle,rgba(59,130,246,.1),transparent 70%);top:20%;left:30%;animation-delay:-3s;animation-duration:8s; }
@keyframes pulse { from{opacity:.6;transform:translateX(-50%) scale(1)} to{opacity:1;transform:translateX(-50%) scale(1.15)} }
.mk-hero__content { position:relative;z-index:1;max-width:750px; }
.mk-hero__logo { max-width:min(400px,80vw);height:auto;margin-bottom:2.5rem;filter:drop-shadow(0 0 40px rgba(6,182,212,.2)); }
.mk-hero__headline { font-family:'Barlow Condensed',sans-serif;font-size:clamp(1.7rem,4.5vw,2.8rem);font-weight:700;letter-spacing:.02em;text-transform:uppercase;line-height:1.2;color:var(--text-hi);margin:0 0 1.25rem; }
.mk-hero__accent { background:linear-gradient(135deg,var(--accent),#3b82f6);-webkit-background-clip:text;-webkit-text-fill-color:transparent;background-clip:text; }
.mk-hero__sub { font-size:1.1rem;line-height:1.7;color:var(--muted);max-width:600px;margin:0 auto 2.5rem; }
.mk-hero__actions { display:flex;gap:1rem;justify-content:center;flex-wrap:wrap; }

.mk-hero__proof { position:relative;z-index:1;display:flex;flex-wrap:wrap;align-items:center;justify-content:center;gap:.75rem;margin-top:3.5rem;font-size:.8rem;color:var(--muted); }
.mk-hero__proof-dot { width:4px;height:4px;border-radius:50%;background:var(--border); }

/* SECTIONS */
.mk-section { padding:6rem 2rem;max-width:1100px;margin:0 auto; }
.mk-section--wide { max-width:1200px; }
.mk-section--highlight { max-width:100%;padding:6rem 2rem;background:var(--surface); }
.mk-section-title { text-align:center;font-family:'Barlow Condensed',sans-serif;font-size:2rem;font-weight:700;letter-spacing:.04em;text-transform:uppercase;color:var(--text-hi);margin:0 0 .5rem;display:flex;flex-direction:column;align-items:center; }
.mk-section-title__line { display:block;width:60px;height:3px;background:linear-gradient(90deg,var(--accent),transparent);border-radius:2px;margin-top:.75rem; }
.mk-section-sub { text-align:center;font-size:1.05rem;color:var(--muted);max-width:580px;margin:.5rem auto 3rem;line-height:1.6; }

/* FEATURES */
.mk-features-grid { display:grid;grid-template-columns:repeat(auto-fill,minmax(260px,1fr));gap:1.25rem; }
.mk-fcard { padding:1.75rem;background:var(--surface);border:1px solid var(--border);border-radius:14px;transition:border-color .3s,box-shadow .3s,opacity .6s,transform .6s;opacity:0;transform:translateY(20px); }
.mk-fcard.mk-visible { opacity:1;transform:translateY(0); }
.mk-fcard:hover { border-color:rgba(6,182,212,.35);box-shadow:0 0 24px rgba(6,182,212,.05); }
.mk-fcard__icon { display:inline-flex;align-items:center;justify-content:center;width:44px;height:44px;border-radius:10px;background:rgba(6,182,212,.08);border:1px solid rgba(6,182,212,.15);color:var(--accent);margin-bottom:1rem; }
.mk-fcard__icon svg { width:22px;height:22px; }
.mk-fcard__title { font-family:'Barlow Condensed',sans-serif;font-size:1.05rem;font-weight:700;text-transform:uppercase;letter-spacing:.04em;color:var(--text-hi);margin:0 0 .5rem; }
.mk-fcard__desc { font-size:.88rem;line-height:1.55;color:var(--muted);margin:0; }

/* BROWSER MOCKUP */
.mk-browser { border-radius:16px;border:1px solid var(--border);overflow:hidden;box-shadow:0 40px 80px rgba(0,0,0,.5),0 0 60px rgba(6,182,212,.06);opacity:0;transform:translateY(40px);transition:opacity .8s,transform .8s; }
.mk-browser.mk-visible { opacity:1;transform:translateY(0); }
.mk-browser__bar { display:flex;align-items:center;gap:8px;padding:12px 16px;background:#0a0f1f;border-bottom:1px solid var(--border); }
.mk-browser__dot { width:12px;height:12px;border-radius:50%;background:#ef4444; }
.mk-browser__dot--y { background:#eab308; }
.mk-browser__dot--g { background:#22c55e; }
.mk-browser__url { margin-left:12px;padding:4px 16px;border-radius:6px;background:rgba(255,255,255,.04);font-size:.75rem;color:var(--muted);font-family:'SF Mono','Fira Code',monospace; }
.mk-browser__body { display:flex;min-height:400px;background:#f1f5f9; }
.mk-browser__caption { text-align:center;font-size:.85rem;color:var(--muted);margin:1.25rem 0 0;font-style:italic; }

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

/* HIGHLIGHT SECTION (consignment) */
.mk-highlight { max-width:900px;margin:0 auto;opacity:0;transform:translateY(24px);transition:opacity .7s,transform .7s; }
.mk-highlight.mk-visible { opacity:1;transform:translateY(0); }
.mk-highlight__title { font-family:'Barlow Condensed',sans-serif;font-size:1.75rem;font-weight:700;text-transform:uppercase;letter-spacing:.03em;line-height:1.2;color:var(--text-hi);margin:0 0 1.25rem; }
.mk-highlight__desc { font-size:1.05rem;color:var(--muted);line-height:1.7;margin:0 0 2rem;max-width:700px; }
.mk-highlight__grid { display:flex;flex-wrap:wrap;gap:.6rem; }
.mk-highlight__item { padding:.5rem 1.25rem;border-radius:8px;background:rgba(6,182,212,.06);border:1px solid rgba(6,182,212,.15);font-size:.85rem;font-weight:600;color:var(--text); }

/* SPLIT */
.mk-split { display:grid;grid-template-columns:1fr 1fr;gap:3rem;align-items:center;opacity:0;transform:translateY(24px);transition:opacity .7s,transform .7s; }
.mk-split.mk-visible { opacity:1;transform:translateY(0); }
.mk-split__title { font-family:'Barlow Condensed',sans-serif;font-size:1.75rem;font-weight:700;text-transform:uppercase;letter-spacing:.03em;line-height:1.2;color:var(--text-hi);margin:0 0 1rem; }
.mk-split__desc { font-size:1.05rem;color:var(--muted);line-height:1.6;margin:0 0 1rem; }
.mk-split__note { font-size:.88rem;color:var(--muted);font-style:italic;margin:0;padding:.75rem 0;border-top:1px solid var(--border); }

/* DEVICE */
.mk-device { width:260px;margin:0 auto;border:3px solid #334155;border-radius:28px;overflow:hidden;background:#0f172a;box-shadow:0 20px 60px rgba(0,0,0,.4); }
.mk-device__screen { padding:.75rem; }
.mk-device__bar { font-family:'Barlow Condensed',sans-serif;font-weight:700;font-size:.75rem;text-transform:uppercase;letter-spacing:.08em;color:var(--accent);padding:.5rem 0;border-bottom:1px solid #1e293b;margin-bottom:.5rem; }
.mk-device__row { padding:.4rem .5rem;border-radius:6px;background:rgba(255,255,255,.04);font-size:.65rem;color:#64748b;margin-bottom:.5rem; }
.mk-device__item { display:flex;justify-content:space-between;padding:.35rem 0;font-size:.7rem;color:#e2e8f0;border-bottom:1px solid #1e293b; }
.mk-device__qty { color:var(--accent);font-weight:700; }
.mk-device__total { display:flex;justify-content:space-between;padding:.5rem 0;font-size:.85rem;font-weight:700;color:var(--text-hi);border-top:1px solid var(--accent);margin-top:.35rem; }
.mk-device__btn { margin-top:.5rem;padding:.5rem;text-align:center;border-radius:8px;background:linear-gradient(135deg,var(--accent),#0891b2);color:#050a18;font-weight:700;font-size:.65rem;text-transform:uppercase;letter-spacing:.06em; }

/* HOSTING */
.mk-hosting-grid { display:grid;grid-template-columns:1fr 1fr;gap:1.5rem;opacity:0;transform:translateY(24px);transition:opacity .7s,transform .7s; }
.mk-hosting-grid.mk-visible { opacity:1;transform:translateY(0); }
.mk-hosting-card { padding:2rem;background:var(--surface);border:1px solid var(--border);border-radius:16px;text-align:center; }
.mk-hosting-card p { font-size:.92rem;color:var(--muted);margin:.75rem 0 0;line-height:1.5; }
.mk-hosting-card__domain { font-family:'SF Mono','Fira Code',monospace;font-size:1rem;color:var(--accent);padding:.5rem 1rem;background:rgba(6,182,212,.06);border:1px solid rgba(6,182,212,.2);border-radius:8px;display:inline-block; }

/* PRICING */
.mk-price-row { display:grid;grid-template-columns:1fr 1fr;gap:2rem;max-width:700px;margin:0 auto 2.5rem;align-items:start;opacity:0;transform:translateY(24px);transition:opacity .7s,transform .7s; }
.mk-price-row.mk-visible { opacity:1;transform:translateY(0); }
.mk-price-box { position:relative;padding:2.5rem 2rem;background:var(--surface);border:1px solid var(--border);border-radius:20px;text-align:center; }
.mk-price-box--featured { border-color:rgba(6,182,212,.5);box-shadow:0 0 50px rgba(6,182,212,.1);background:linear-gradient(180deg,var(--surface-2),var(--surface)); }
.mk-price-box__badge { position:absolute;top:-12px;left:50%;transform:translateX(-50%);padding:.3rem 1.25rem;border-radius:20px;background:linear-gradient(135deg,var(--accent),#0891b2);color:#050a18;font-size:.65rem;font-weight:700;text-transform:uppercase;letter-spacing:.06em;white-space:nowrap; }
.mk-price-box__label { font-size:.75rem;font-weight:700;text-transform:uppercase;letter-spacing:.12em;color:var(--muted);margin-bottom:.5rem; }
.mk-price-box__amount { font-family:'Barlow Condensed',sans-serif;font-size:3rem;font-weight:700;color:var(--text-hi);line-height:1; }
.mk-price-box--featured .mk-price-box__amount { color:var(--accent-lt); }
.mk-price-box__period { font-size:.9rem;color:var(--muted);margin-bottom:1rem; }
.mk-price-box__desc { font-size:.88rem;color:var(--muted);line-height:1.5;margin:0; }
.mk-price-cta { text-align:center;opacity:0;transform:translateY(12px);transition:opacity .7s .15s,transform .7s .15s; }
.mk-price-cta.mk-visible { opacity:1;transform:translateY(0); }

/* FAQ */
.mk-faq { max-width:700px;margin:0 auto;opacity:0;transform:translateY(24px);transition:opacity .7s,transform .7s; }
.mk-faq.mk-visible { opacity:1;transform:translateY(0); }
.mk-faq__item { border-bottom:1px solid var(--border);cursor:pointer; }
.mk-faq__q { display:flex;align-items:center;justify-content:space-between;padding:1.25rem 0;gap:1rem; }
.mk-faq__q span { font-size:1.05rem;font-weight:600;color:var(--text-hi); }
.mk-faq__q svg { width:20px;height:20px;color:var(--muted);flex-shrink:0;transition:transform .25s; }
.mk-faq__item--open .mk-faq__q svg { transform:rotate(180deg); }
.mk-faq__a { max-height:0;overflow:hidden;transition:max-height .35s ease,padding .35s ease;font-size:.95rem;color:var(--muted);line-height:1.6;padding:0; }
.mk-faq__item--open .mk-faq__a { max-height:300px;padding:0 0 1.25rem; }

/* CTA */
.mk-cta { position:relative;text-align:center;padding:7rem 2rem;overflow:hidden; }
.mk-cta__glow { position:absolute;width:600px;height:400px;border-radius:50%;background:radial-gradient(circle,rgba(6,182,212,.12),transparent 70%);top:50%;left:50%;transform:translate(-50%,-50%);pointer-events:none; }
.mk-cta__title { position:relative;font-family:'Barlow Condensed',sans-serif;font-size:2.25rem;font-weight:700;letter-spacing:.04em;text-transform:uppercase;color:var(--text-hi);margin:0 0 1rem; }
.mk-cta__text { position:relative;font-size:1.1rem;color:var(--muted);margin:0 auto 2.5rem;line-height:1.6;max-width:520px; }

/* FOOTER */
.mk-footer { border-top:1px solid var(--border);padding:2.5rem 2rem; }
.mk-footer__inner { max-width:1100px;margin:0 auto;display:flex;flex-wrap:wrap;align-items:center;justify-content:space-between;gap:1.5rem; }
.mk-footer__brand { display:flex;align-items:center;gap:.75rem; }
.mk-footer__icon { height:28px;width:auto;opacity:.6; }
.mk-footer__brand strong { display:block;font-family:'Barlow Condensed',sans-serif;font-size:1rem;font-weight:700;letter-spacing:.06em;text-transform:uppercase;color:var(--text-hi); }
.mk-footer__brand span { font-size:.8rem;color:var(--muted); }
.mk-footer__cd { color:var(--accent);text-decoration:none; }
.mk-footer__cd:hover { text-decoration:underline; }
.mk-footer__links { display:flex;gap:1.5rem; }
.mk-footer__links a,.mk-footer__links span { font-size:.85rem;color:var(--muted);text-decoration:none;cursor:pointer; }
.mk-footer__links a:hover { color:var(--accent); }

/* STICKY MOBILE CTA */
.mk-sticky { display:none; }

/* RESPONSIVE */
@media(max-width:900px) {
  .mk-split { grid-template-columns:1fr;gap:2rem; }
  .mk-hosting-grid { grid-template-columns:1fr; }
  .mk-features-grid { grid-template-columns:repeat(2,1fr); }
}

@media(max-width:768px) {
  .mk-hero { padding:6rem 1.25rem 3rem; }
  .mk-hero__proof { flex-direction:column;gap:.35rem; }
  .mk-hero__proof-dot { display:none; }
  .mk-hide-mobile { display:none; }
  .mk-nav__link { padding:.5rem .4rem;font-size:.8rem; }
  .mk-section { padding:4rem 1.25rem; }
  .mk-section--highlight { padding:4rem 1.25rem; }

  .mk-browser__body { flex-direction:column; }
  .mk-mock-sidebar { width:100%;padding:.5rem;display:flex;gap:.4rem;overflow-x:auto;flex-wrap:wrap; }
  .mk-mock-sidebar__brand { padding:.25rem .5rem;margin-bottom:0;border-bottom:none; }
  .mk-mock-sidebar__label { display:none; }
  .mk-mock-sidebar__item { white-space:nowrap;font-size:.55rem;padding:.25rem .5rem; }

  .mk-footer__inner { flex-direction:column;align-items:flex-start; }

  .mk-sticky { display:flex;position:fixed;bottom:0;left:0;right:0;z-index:99;padding:.75rem 1rem;background:rgba(5,10,24,.95);backdrop-filter:blur(12px);border-top:1px solid var(--border);gap:.75rem;align-items:center;justify-content:center;transform:translateY(100%);transition:transform .3s ease; }
  .mk-sticky--show { transform:translateY(0); }
  .mk-sticky__btn { flex:1;max-width:200px;display:inline-flex;align-items:center;justify-content:center;padding:.65rem 1rem;border-radius:8px;background:linear-gradient(135deg,var(--accent),#0891b2);color:#050a18;font-weight:700;font-size:.85rem;text-decoration:none;letter-spacing:.04em; }
  .mk-sticky__link { font-size:.8rem;font-weight:600;color:var(--accent);text-decoration:none; }

  .mk-footer { padding-bottom:5rem; }
}

@media(max-width:600px) {
  .mk-features-grid { grid-template-columns:1fr; }
  .mk-price-row { grid-template-columns:1fr; }
  .mk-highlight__grid { flex-direction:column; }
}
</style>
