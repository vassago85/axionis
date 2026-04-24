# Axionis POS — Client Onboarding

Each client gets a fully isolated Axionis POS instance: their own database, containers, branding, and domain.

## Setting up a new client

### 1. Create the client directory

```bash
CLIENT=clientname
sudo mkdir -p /opt/axionis-$CLIENT
cd /opt/axionis-$CLIENT
sudo git clone https://github.com/vassago85/axionis.git .
sudo mkdir -p data
```

### 2. Configure environment

```bash
sudo cp .env.client.example .env
sudo nano .env
```

Set unique values for this client:

```env
OWNER_EMAIL=owner@clientbusiness.com
OWNER_PASSWORD=SecureClientPassword
JWT_KEY=unique-random-string-for-this-client
AXIONIS_DATA_DIR=/opt/axionis-clientname/data
PUBLIC_BASE_URL=https://pos.clientbusiness.com
WEB_PORT=9101   # unique port per client
MAILGUN_API_KEY=key-xxx
MAILGUN_DOMAIN=mg.clientbusiness.com
MAILGUN_FROM=Client Business <sales@clientbusiness.com>
```

### 3. Update container names

Edit `docker-compose.yml` to avoid Docker name conflicts:

```yaml
services:
  api:
    container_name: axionis-clientname-api
  web:
    container_name: axionis-clientname-web
```

### 4. Build and launch

```bash
sudo docker compose up -d --build
```

### 5. Configure reverse proxy

Add a proxy rule for the client's domain pointing to `http://localhost:9101`.

### 6. First login

The owner logs in at `https://pos.clientbusiness.com` with the credentials from `.env`.

## Configuring branding

After first login, go to **Settings > Business Settings**:

1. **Business name** — Appears on invoices, quotes, receipts
2. **Logo** — Upload via the branding settings page
3. **Colors** — Primary, secondary, accent colors for the app shell
4. **Contact info** — Phone, email, address, website
5. **VAT number** — Shown on invoices
6. **Quote/Invoice labels** — Customize the labels used in the UI
7. **Terms & policies** — Quote terms, invoice terms, return policy, receipt footer

## Email configuration

Each client needs their own email sending configuration:

1. Set up a Mailgun (or compatible) account for the client's domain
2. Configure DNS records (SPF, DKIM, CNAME)
3. Add the API key and domain to the client's `.env`
4. Alternatively, configure email settings from **Setup > Email** in the app

## Updating a client

```bash
cd /opt/axionis-$CLIENT
sudo git pull origin main
sudo docker compose up -d --build
```

## Isolation checklist

Each client instance must have:

- [ ] Unique `JWT_KEY`
- [ ] Unique `WEB_PORT`
- [ ] Unique `AXIONIS_DATA_DIR`
- [ ] Unique Docker container names
- [ ] Unique domain / subdomain
- [ ] Own Mailgun credentials
- [ ] Own database file (automatic — stored in their data dir)
