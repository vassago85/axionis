# Axionis POS — Project Context

## Tech stack

- **Backend**: .NET 8 (C#), EF Core, SQLite, QuestPDF, JWT auth
- **Frontend**: Vue 3, TypeScript, Vite, vite-plugin-pwa
- **Hosting**: Docker Compose (api + nginx containers)
- **TLS**: Terminated upstream (Nginx Proxy Manager or similar), not in these containers

## Key paths (local dev)

- API project: `src/AxionisPos.Api/`
- Web project: `src/axionis-web/`
- Docker Compose: `docker-compose.yml` (root)
- Nginx config: `src/axionis-web/nginx.conf`

## Deployment

- **Data directory**: configurable via `AXIONIS_DATA_DIR` environment variable
- **Database**: SQLite at `{AXIONIS_DATA_DIR}/axionis.db`
- **PDFs**: `{AXIONIS_DATA_DIR}/pdfs/`
- **API internal port**: `8080` (container-only, proxied by nginx in the web container)

## Deploy command (on server)

```bash
cd /opt/axionis && sudo git pull origin main && sudo docker compose up -d --build
```

## .env keys (on server, not committed)

```
OWNER_EMAIL=...
OWNER_PASSWORD=...
JWT_KEY=...
AXIONIS_DATA_DIR=/opt/axionis/data
PUBLIC_BASE_URL=https://your-domain.example
WEB_PORT=8080
```

## Conventions

- Hash router (`createWebHashHistory`) — no server-side URL rewriting needed for SPA routes
- All API calls go through `/api/` prefix, proxied by nginx to the api container
- Role hierarchy: Dev > Owner > Admin > Sales
- Currency: ZAR (South African Rand)
