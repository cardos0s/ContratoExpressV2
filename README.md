# ContratoExpress  📄⚡

**Micro SaaS — Gerador de Contratos Profissionais**
Blazor WASM + ASP.NET API + Supabase Auth + AbacatePay

## 🏗️ Arquitetura

```
┌─────────────────┐     ┌──────────────────┐     ┌──────────────┐
│  Blazor WASM    │────▶│  ASP.NET API     │────▶│  Supabase    │
│  (Frontend)     │     │  (Backend)       │     │  (Auth + DB) │
│  :5002          │     │  :5001           │     └──────────────┘
└─────────────────┘     │                  │     ┌──────────────┐
                        │                  │────▶│  AbacatePay  │
                        └──────────────────┘     │  (Pagamento) │
                               ▲                 └──────┬───────┘
                               │     Webhook            │
                               └────────────────────────┘
```

## 💰 Modelo de Negócio

- **1º contrato**: Grátis (cadastro obrigatório)
- **A partir do 2º**: R$ 4,90 por contrato via PIX (AbacatePay)
- **Taxa AbacatePay**: R$ 0,80 por transação → **Lucro: R$ 4,10/contrato**

## 🚀 Setup Passo a Passo

### 1. Supabase (Auth + Banco de Dados)

1. Crie uma conta em [supabase.com](https://supabase.com)
2. Crie um novo projeto
3. Vá em **Settings > API** e copie:
   - `Project URL` → coloque em `appsettings.json > Supabase:Url`
   - `anon public` key → coloque em `Supabase:AnonKey`
   - `service_role` key → coloque em `Supabase:ServiceRoleKey`
4. Vá em **Settings > API > JWT Settings** e copie:
   - `JWT Secret` → coloque em `Supabase:JwtSecret`
5. Vá em **SQL Editor** e execute o conteúdo do arquivo `supabase-setup.sql`
6. Em **Authentication > Providers**, habilite o provedor **Email** (já vem habilitado por padrão)

### 2. AbacatePay (Pagamentos)

1. Crie uma conta em [abacatepay.com](https://www.abacatepay.com)
2. No dashboard, vá em **API Keys** e copie sua chave
3. Coloque em `appsettings.json > AbacatePay:ApiKey`
4. Configure o **Webhook**:
   - URL: `https://SEU-DOMINIO/api/webhook/abacatepay`
   - Eventos: `billing.paid`
5. Para testes, use o **Dev Mode** (ativado por padrão)

### 3. Configuração Local

Edite `src/ContratoExpress.Server/appsettings.json`:

```json
{
  "Supabase": {
    "Url": "https://xxxxx.supabase.co",
    "AnonKey": "eyJ...",
    "ServiceRoleKey": "eyJ...",
    "JwtSecret": "seu-jwt-secret"
  },
  "AbacatePay": {
    "ApiKey": "abc_xxxxxxxx",
    "BaseUrl": "https://api.abacatepay.com",
    "PriceInCents": 490,
    "ReturnUrl": "https://localhost:5002",
    "CompletionUrl": "https://localhost:5002/pagamento-confirmado"
  },
  "App": {
    "FreeContracts": 1,
    "ClientUrl": "https://localhost:5002"
  }
}
```

### 4. Rodar

Abra **2 terminais**:

```bash
# Terminal 1 — Backend (API)
cd src/ContratoExpress.Server
dotnet restore
dotnet run
# Roda em https://localhost:5001

# Terminal 2 — Frontend (Blazor WASM)
cd src/ContratoExpress.Client
dotnet restore
dotnet run
# Roda em https://localhost:5002
```

Acesse: **https://localhost:5002**

## 📁 Estrutura do Projeto

```
ContratoExpressV2/
├── ContratoExpress.sln
├── supabase-setup.sql           ← SQL para criar tabelas
├── src/
│   ├── ContratoExpress.Server/  ← API Backend
│   │   ├── Program.cs           ← Endpoints (auth, billing, webhook)
│   │   ├── Services/
│   │   │   ├── AbacatePayService.cs       ← Integração AbacatePay
│   │   │   └── ContractTrackingService.cs ← CRUD Supabase
│   │   ├── Models/Models.cs     ← DTOs
│   │   └── appsettings.json     ← ⚠️ SUAS CHAVES AQUI
│   │
│   └── ContratoExpress.Client/  ← Blazor WASM Frontend
│       ├── Program.cs           ← DI e bootstrap
│       ├── Services/
│       │   ├── AuthService.cs   ← Login/register/JWT
│       │   ├── BillingService.cs ← API de pagamento
│       │   └── ContractService.cs ← Templates de contrato
│       ├── Pages/
│       │   ├── Home.razor       ← Landing page
│       │   ├── ContractForm.razor ← Formulário + paywall
│       │   ├── Login.razor      ← Login/registro
│       │   └── PaymentConfirmed.razor ← Pós-pagamento
│       └── wwwroot/
│           ├── css/app.css      ← Estilos
│           └── index.html       ← Entry point
```

## 🔄 Fluxo do Usuário

```
Landing → Escolhe modelo → Preenche formulário → Clica "Gerar"
    │                                                    │
    │                                          ┌─────────┴──────────┐
    │                                          │ Está logado?       │
    │                                          └─────────┬──────────┘
    │                                             NÃO │        │ SIM
    │                                                 ▼        ▼
    │                                            /login    Backend verifica
    │                                                    contratos usados
    │                                                         │
    │                                          ┌──────────────┴──────────┐
    │                                          │ Tem grátis disponível?  │
    │                                          └──────────────┬──────────┘
    │                                              SIM │           │ NÃO
    │                                                  ▼           ▼
    │                                           Gera PDF      Modal paywall
    │                                                         R$ 4,90 PIX
    │                                                              │
    │                                                              ▼
    │                                                      AbacatePay link
    │                                                              │
    │                                                    Webhook confirma
    │                                                              │
    │                                                              ▼
    │                                                      Gera PDF ✅
```

## 🧪 Testando Pagamentos

O AbacatePay tem **Dev Mode** que simula pagamentos sem dinheiro real.

1. No dashboard AbacatePay, certifique-se que Dev Mode está ativado
2. Crie um contrato e clique em "Pagar com PIX"
3. Na página de pagamento, o PIX será simulado automaticamente
4. O webhook notifica seu backend → contrato liberado

## 🌐 Deploy

### Opção 1: Azure (recomendado pra .NET)
```bash
# Backend
cd src/ContratoExpress.Server
dotnet publish -c Release
# Deploy no Azure App Service

# Frontend
cd src/ContratoExpress.Client
dotnet publish -c Release
# Deploy no Azure Static Web Apps
```

### Opção 2: Railway/Render (backend) + Vercel/Netlify (frontend)
```bash
# Frontend: build estático
cd src/ContratoExpress.Client
dotnet publish -c Release -o ./publish
# Upload do publish/wwwroot para Vercel/Netlify
```

### Lembrete pós-deploy:
- Atualize `CompletionUrl` e `ReturnUrl` no `appsettings.json` com URLs de produção
- Configure o webhook do AbacatePay com a URL de produção
- Desative o Dev Mode no AbacatePay quando for pra produção
- Atualize `App:ClientUrl` com a URL do frontend em produção

## 📝 Licença

MIT
