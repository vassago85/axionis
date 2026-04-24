# Axionis POS — Deployment Guide

## Prerequisites

- Linux server (Ubuntu 22.04+ recommended)
- Docker and Docker Compose installed
- A domain pointed to the server
- TLS termination (Nginx Proxy Manager, Caddy, or Cloudflare)

## Step-by-step

### 1. Clone the repository

```bash
sudo mkdir -p /opt/axionis
cd /opt/axionis
sudo git clone https://github.com/vassago85/axionis.git .
```

### 2. Create the data directory

```bash
sudo mkdir -p /opt/axionis/data
```

### 3. Configure environment

```bash
sudo cp .env.client.example .env
sudo nano .env
```

Fill in all values:

| Variable | Description |
|----------|-----------|
| `OWNER_EMAIL` | Email for the first owner account |
| `OWNER_PASSWORD` | Password for the owner account |
| `JWT_KEY` | Random string, at least 32 characters |
| `AXIONIS_DATA_DIR` | `/opt/axionis/data` |
| `PUBLIC_BASE_URL` | `https://pos.your-domain.com` |
| `WEB_PORT` | `9095` (or any available port) |
| `MAILGUN_API_KEY` | Your Mailgun API key |
| `MAILGUN_DOMAIN` | Your Mailgun sending domain |
| `MAILGUN_FROM` | `Business Name <sales@domain.com>` |

### 4. Build and start

```bash
sudo docker compose up -d --build
```

### 5. Configure TLS / reverse proxy

Point your domain to the server, then configure your reverse proxy to forward traffic to `http://localhost:9095`.

**Nginx Proxy Manager example:**
- Domain: `pos.your-domain.com`
- Forward to: `http://server-ip:9095`
- Enable SSL with Let's Encrypt

### 6. Verify

Open `https://pos.your-domain.com` and log in with the owner credentials from `.env`.

## Updating

```bash
cd /opt/axionis
sudo git pull origin main
sudo docker compose up -d --build
```

## Backups

The SQLite database is a single file at `/opt/axionis/data/axionis.db`. Back it up regularly:

```bash
sudo cp /opt/axionis/data/axionis.db /opt/axionis/data/axionis-backup-$(date +%Y%m%d).db
```

PDFs are stored at `/opt/axionis/data/pdfs/`.

## Multiple clients on one server

Each client gets their own clone of the repo with a unique:
- Port (`WEB_PORT`)
- Data directory (`AXIONIS_DATA_DIR`)
- Domain
- JWT key
- Container names (edit `docker-compose.yml` container_name values)

See [CLIENT-ONBOARDING.md](CLIENT-ONBOARDING.md) for details.
