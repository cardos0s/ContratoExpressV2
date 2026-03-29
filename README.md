# ContratoExpress 

Production-ready contract generation SaaS built with Blazor WebAssembly and ASP.NET Core, featuring secure authentication, credit-based billing, and Stripe-powered payment processing.

The platform enables users to generate professional contracts with a scalable backend architecture, integrating webhook-driven payment confirmation and real-world monetization.

---

## 🚀 Overview

ContratoExpress is a SaaS platform designed to handle contract generation with integrated billing and secure workflows.

It demonstrates a full-stack architecture with real payment processing, making it closer to a production system than a simple demo application.

---

## 💳 Billing System (Stripe)

The platform implements a credit-based billing model using Stripe:

1. User selects a credit package  
2. Payment is processed via Stripe Checkout  
3. Stripe webhook confirms the transaction  
4. Credits are securely updated in the system  

This ensures reliability, idempotency, and scalability in payment processing.

---

## 🧠 Engineering Highlights

- Event-driven payment flow using Stripe webhooks  
- Secure authentication with JWT and access control  
- Clean Architecture-based backend structure  
- Separation of concerns between frontend and backend  
- Production-oriented billing system with real transactions  

---

## ⚙️ Tech Stack

### Backend
- ASP.NET Core (.NET 10)
- Clean Architecture
- CQRS
- PostgreSQL
- Supabase

### Frontend
- Blazor WebAssembly

### Payments
- Stripe Checkout
- Webhooks

### Infrastructure
- Cloud-ready architecture
- API-first design

---

## 🧩 Architecture

```text
Client (Blazor WASM)
        │
        ▼
API (ASP.NET Core)
        │
        ├── Authentication (JWT)
        ├── Billing (Stripe Webhooks)
        ├── Business Logic (Contracts / Credits)
        │
        ▼
Database (PostgreSQL / Supabase)



