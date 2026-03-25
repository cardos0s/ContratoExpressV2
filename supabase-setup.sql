-- ═══════════════════════════════════════════════════════
-- ContratoExpress V2 — Supabase Database Setup
-- Execute no SQL Editor do Supabase Dashboard
-- ═══════════════════════════════════════════════════════

-- 1. Tabela de contratos gerados
CREATE TABLE IF NOT EXISTS public.user_contracts (
    id TEXT PRIMARY KEY,
    user_id UUID NOT NULL REFERENCES auth.users(id) ON DELETE CASCADE,
    contract_type TEXT NOT NULL,
    status TEXT NOT NULL DEFAULT 'used',
    created_at TIMESTAMPTZ NOT NULL DEFAULT NOW()
);

CREATE INDEX IF NOT EXISTS idx_uc_user ON public.user_contracts(user_id);
CREATE INDEX IF NOT EXISTS idx_uc_status ON public.user_contracts(status);

-- 2. Tabela de compras de crédito (pacotes)
CREATE TABLE IF NOT EXISTS public.credit_purchases (
    id TEXT PRIMARY KEY,
    user_id UUID NOT NULL REFERENCES auth.users(id) ON DELETE CASCADE,
    billing_id TEXT NOT NULL,
    billing_url TEXT,
    status TEXT NOT NULL DEFAULT 'pending' CHECK (status IN ('pending', 'paid', 'failed')),
    created_at TIMESTAMPTZ NOT NULL DEFAULT NOW()
);

CREATE INDEX IF NOT EXISTS idx_cp_user ON public.credit_purchases(user_id);
CREATE INDEX IF NOT EXISTS idx_cp_billing ON public.credit_purchases(billing_id);
CREATE INDEX IF NOT EXISTS idx_cp_status ON public.credit_purchases(status);

-- 3. Row Level Security
ALTER TABLE public.user_contracts ENABLE ROW LEVEL SECURITY;
ALTER TABLE public.credit_purchases ENABLE ROW LEVEL SECURITY;

-- Usuários veem seus próprios dados
CREATE POLICY "Users view own contracts" ON public.user_contracts
    FOR SELECT USING (auth.uid() = user_id);

CREATE POLICY "Users view own purchases" ON public.credit_purchases
    FOR SELECT USING (auth.uid() = user_id);

-- Service role (backend) pode tudo
CREATE POLICY "Service full access contracts" ON public.user_contracts
    FOR ALL USING (true) WITH CHECK (true);

CREATE POLICY "Service full access purchases" ON public.credit_purchases
    FOR ALL USING (true) WITH CHECK (true);

-- Pronto!
SELECT 'Setup concluído! Tabelas user_contracts e credit_purchases criadas.' AS resultado;
