# Axionis POS

**Built for mobility. Designed for real-world operations.**

A mobile-first POS, stock control, quotes, invoices and consignment management platform for businesses that need speed, control, and clean operations.

## Tech Stack

| Layer | Technology |
|-------|-----------|
| Backend | .NET 8 (C#), EF Core, SQLite, QuestPDF, JWT auth |
| Frontend | Vue 3, TypeScript, Vite, PWA |
| Hosting | Docker Compose (API + Nginx containers) |
| TLS | Terminated upstream (Nginx Proxy Manager or similar) |

## Features

- **Point of Sale** — Barcode-driven, discount support, customer lookup, instant invoicing
- **Stock Control** — Supplier tracking, receipts, imports, label printing, quantity tracking
- **Consignment Management** — Receive, check, reconcile consignment and owned stock
- **Quotes & Invoices** — PDF generation, email delivery, public view links, quote-to-invoice conversion
- **Reports** — Revenue, margins, sales by rep, stock value, vendor performance
- **PWA** — Installable on tablets, phones, and desktops
- **Per-client branding** — Logo, colors, business name, email sender, domain

## Quick Start (Local Development)

**Prerequisites:** Docker and Docker Compose

```bash
# 1. Clone the repo
git clone https://github.com/vassago85/axionis.git
cd axionis

# 2. Create your .env
cp .env.example .env
# Edit .env with your values

# 3. Build and run
docker compose -f docker-compose.local.yml up --build

# 4. Open the app
# API: http://localhost:5288
# Web: Run `npm run dev` in src/axionis-web/ for hot-reload at http://localhost:5173
```

**Frontend dev server (with hot-reload):**

```bash
cd src/axionis-web
npm install
npm run dev
```

## Production Deployment

See [DEPLOYMENT.md](DEPLOYMENT.md) for full instructions.

```bash
# Quick deploy
cp .env.client.example .env
# Edit .env with real values
docker compose up -d --build
```

## Client Onboarding

See [CLIENT-ONBOARDING.md](CLIENT-ONBOARDING.md) for per-client setup instructions.

## Project Structure

```
axionis/
├── src/
│   ├── AxionisPos.Api/     # .NET 8 API
│   └── axionis-web/        # Vue 3 frontend
├── tests/
│   └── AxionisPos.Api.Tests/
├── tools/
│   └── ExportCsv/
├── samples/                # Demo data files
├── scripts/                # Utility scripts
├── docker-compose.yml      # Production compose
├── docker-compose.local.yml # Local dev compose
└── .env.example            # Environment template
```

## Roles

| Role | Access |
|------|--------|
| Dev | Full system access |
| Owner | Business settings, team, all features |
| Admin | Stock, imports, reports, POS |
| Sales | POS, price lookup, limited stock view |

## License

Proprietary. All rights reserved.

---

Built by **Charsley Digital**
