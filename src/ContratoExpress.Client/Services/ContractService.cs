using ContratoExpress.Client.Models;

namespace ContratoExpress.Client.Services;

public class ContractService
{
    private const string S1 = "👤 Dados do Contratante";
    private const string S2 = "👤 Dados do Contratado";
    private const string S3 = "📋 Detalhes do Serviço";
    private const string S4 = "💰 Valor e Pagamento";
    private const string S5 = "⚖️ Penalidades e Multas";
    private const string S6 = "📍 Local e Foro";
    private const string S7 = "✍️ Testemunhas";

    private const string SS1 = "🩺 Dados do Profissional";
    private const string SS2 = "👤 Dados do Paciente/Contratante";
    private const string SS3 = "📋 Serviço Médico";
    private const string SC1 = "📊 Escritório Contábil";
    private const string SC2 = "🏢 Empresa Cliente";

    public List<ContractType> GetContractTypes() => new()
    {
        // ═════════════════════════════════════════════════════════════
        //  PRESTAÇÃO DE SERVIÇO
        // ═════════════════════════════════════════════════════════════
        new ContractType
        {
            Id = "prestacao", Icon = "⚡", Title = "Prestação de Serviço",
            Description = "Ideal para empresas e profissionais autônomos",
            AccentColor = "#6C5CE7",
            Category = "Geral",
            Fields = new()
            {
                // Contratante
                new() { Key = "contratante", Label = "Nome completo / Razão Social", Section = S1 },
                new() { Key = "nacionalidadeContratante", Label = "Nacionalidade", Section = S1 },
                new() { Key = "estadoCivilContratante", Label = "Estado Civil", Section = S1 },
                new() { Key = "profissaoContratante", Label = "Profissão", Section = S1 },
                new() { Key = "rgContratante", Label = "RG", Section = S1 },
                new() { Key = "cpfContratante", Label = "CPF/CNPJ", Section = S1 },
                new() { Key = "endContratante", Label = "Endereço completo", Section = S1 },
                new() { Key = "emailContratante", Label = "E-mail", Section = S1 },
                // Contratado
                new() { Key = "contratado", Label = "Nome completo / Razão Social", Section = S2 },
                new() { Key = "nacionalidadeContratado", Label = "Nacionalidade", Section = S2 },
                new() { Key = "estadoCivilContratado", Label = "Estado Civil", Section = S2 },
                new() { Key = "profissaoContratado", Label = "Profissão", Section = S2 },
                new() { Key = "rgContratado", Label = "RG", Section = S2 },
                new() { Key = "cpfContratado", Label = "CPF/CNPJ", Section = S2 },
                new() { Key = "endContratado", Label = "Endereço completo", Section = S2 },
                new() { Key = "emailContratado", Label = "E-mail", Section = S2 },
                // Serviço
                new() { Key = "servico", Label = "Descrição detalhada do Serviço", IsTextArea = true, Section = S3 },
                new() { Key = "localExecucao", Label = "Local de Execução", Section = S3 },
                new() { Key = "prazo", Label = "Prazo de Execução", Section = S3 },
                new() { Key = "dataInicio", Label = "Data de Início", Section = S3 },
                // Pagamento
                new() { Key = "valor", Label = "Valor Total (R$)", Section = S4 },
                new() { Key = "valorExtenso", Label = "Valor por Extenso", Section = S4 },
                new() { Key = "formaPagamento", Label = "Forma de Pagamento (parcelas, prazos)", IsTextArea = true, Section = S4 },
                // Multas
                new() { Key = "multaRescisao", Label = "Multa por Rescisão Antecipada (%)", Section = S5 },
                new() { Key = "multaAtraso", Label = "Multa por Atraso no Pagamento (%)", Section = S5 },
                new() { Key = "jurosAtraso", Label = "Juros de Mora (% ao mês)", Section = S5 },
                // Foro
                new() { Key = "cidade", Label = "Cidade/UF", Section = S6 },
                new() { Key = "foro", Label = "Foro (Comarca)", Section = S6 },
                // Testemunhas
                new() { Key = "testemunha1", Label = "Testemunha 1 (Nome)", Section = S7 },
                new() { Key = "cpfTest1", Label = "CPF da Testemunha 1", Section = S7 },
                new() { Key = "testemunha2", Label = "Testemunha 2 (Nome)", Section = S7 },
                new() { Key = "cpfTest2", Label = "CPF da Testemunha 2", Section = S7 },
            }
        },

        // ═════════════════════════════════════════════════════════════
        //  FREELANCER / PJ
        // ═════════════════════════════════════════════════════════════
        new ContractType
        {
            Id = "freelancer", Icon = "💼", Title = "Freelancer / PJ",
            Description = "Para contratos entre empresas e prestadores PJ",
            AccentColor = "#0984E3",
            Category = "Geral",
            Fields = new()
            {
                // Empresa
                new() { Key = "empresa", Label = "Razão Social", Section = "🏢 Dados da Empresa (Contratante)" },
                new() { Key = "cnpjEmpresa", Label = "CNPJ", Section = "🏢 Dados da Empresa (Contratante)" },
                new() { Key = "ieEmpresa", Label = "Inscrição Estadual", Section = "🏢 Dados da Empresa (Contratante)" },
                new() { Key = "representante", Label = "Representante Legal", Section = "🏢 Dados da Empresa (Contratante)" },
                new() { Key = "cargoRepresentante", Label = "Cargo do Representante", Section = "🏢 Dados da Empresa (Contratante)" },
                new() { Key = "cpfRepresentante", Label = "CPF do Representante", Section = "🏢 Dados da Empresa (Contratante)" },
                new() { Key = "endEmpresa", Label = "Endereço", Section = "🏢 Dados da Empresa (Contratante)" },
                new() { Key = "emailEmpresa", Label = "E-mail", Section = "🏢 Dados da Empresa (Contratante)" },
                // Freelancer
                new() { Key = "freelancer", Label = "Nome / Razão Social", Section = "💻 Dados do Freelancer (Contratado)" },
                new() { Key = "cpfCnpjFreelancer", Label = "CPF/CNPJ", Section = "💻 Dados do Freelancer (Contratado)" },
                new() { Key = "endFreelancer", Label = "Endereço", Section = "💻 Dados do Freelancer (Contratado)" },
                new() { Key = "emailFreelancer", Label = "E-mail", Section = "💻 Dados do Freelancer (Contratado)" },
                // Escopo
                new() { Key = "escopo", Label = "Escopo detalhado do Trabalho", IsTextArea = true, Section = "📋 Escopo e Entregáveis" },
                new() { Key = "entregaveis", Label = "Entregáveis e Critérios de Aceite", IsTextArea = true, Section = "📋 Escopo e Entregáveis" },
                new() { Key = "ferramentas", Label = "Ferramentas / Tecnologias", Section = "📋 Escopo e Entregáveis" },
                new() { Key = "prazo", Label = "Prazo de Entrega", Section = "📋 Escopo e Entregáveis" },
                new() { Key = "dataInicio", Label = "Data de Início", Section = "📋 Escopo e Entregáveis" },
                new() { Key = "revisoesInclusas", Label = "Revisões Inclusas", Section = "📋 Escopo e Entregáveis" },
                new() { Key = "valorRevisaoExtra", Label = "Valor por Revisão Extra (R$)", Section = "📋 Escopo e Entregáveis" },
                // Pagamento
                new() { Key = "valorProjeto", Label = "Valor do Projeto (R$)", Section = S4 },
                new() { Key = "valorExtenso", Label = "Valor por Extenso", Section = S4 },
                new() { Key = "formaPagamento", Label = "Forma de Pagamento (parcelas, marcos)", IsTextArea = true, Section = S4 },
                // Multas
                new() { Key = "multaRescisao", Label = "Multa por Rescisão (%)", Section = S5 },
                new() { Key = "prazoSigilo", Label = "Prazo de Sigilo após término (meses)", Section = S5 },
                // Foro
                new() { Key = "cidade", Label = "Cidade/UF", Section = S6 },
                new() { Key = "foro", Label = "Foro (Comarca)", Section = S6 },
                // Testemunhas
                new() { Key = "testemunha1", Label = "Testemunha 1 (Nome)", Section = S7 },
                new() { Key = "cpfTest1", Label = "CPF da Testemunha 1", Section = S7 },
                new() { Key = "testemunha2", Label = "Testemunha 2 (Nome)", Section = S7 },
                new() { Key = "cpfTest2", Label = "CPF da Testemunha 2", Section = S7 },
            }
        },

        // ═════════════════════════════════════════════════════════════
        //  LOCAÇÃO DE IMÓVEL
        // ═════════════════════════════════════════════════════════════
        new ContractType
        {
            Id = "locacao", Icon = "🏠", Title = "Locação de Imóvel",
            Description = "Contrato residencial ou comercial completo",
            AccentColor = "#E17055",
            Category = "Geral",
            Fields = new()
            {
                // Locador
                new() { Key = "locador", Label = "Nome completo", Section = "👤 Dados do Locador (Proprietário)" },
                new() { Key = "nacionalidadeLocador", Label = "Nacionalidade", Section = "👤 Dados do Locador (Proprietário)" },
                new() { Key = "estadoCivilLocador", Label = "Estado Civil", Section = "👤 Dados do Locador (Proprietário)" },
                new() { Key = "profissaoLocador", Label = "Profissão", Section = "👤 Dados do Locador (Proprietário)" },
                new() { Key = "rgLocador", Label = "RG", Section = "👤 Dados do Locador (Proprietário)" },
                new() { Key = "cpfLocador", Label = "CPF/CNPJ", Section = "👤 Dados do Locador (Proprietário)" },
                new() { Key = "endLocador", Label = "Endereço", Section = "👤 Dados do Locador (Proprietário)" },
                // Locatário
                new() { Key = "locatario", Label = "Nome completo", Section = "👤 Dados do Locatário (Inquilino)" },
                new() { Key = "nacionalidadeLocatario", Label = "Nacionalidade", Section = "👤 Dados do Locatário (Inquilino)" },
                new() { Key = "estadoCivilLocatario", Label = "Estado Civil", Section = "👤 Dados do Locatário (Inquilino)" },
                new() { Key = "profissaoLocatario", Label = "Profissão", Section = "👤 Dados do Locatário (Inquilino)" },
                new() { Key = "rgLocatario", Label = "RG", Section = "👤 Dados do Locatário (Inquilino)" },
                new() { Key = "cpfLocatario", Label = "CPF/CNPJ", Section = "👤 Dados do Locatário (Inquilino)" },
                // Imóvel
                new() { Key = "endImovel", Label = "Endereço Completo do Imóvel", Section = "🏠 Dados do Imóvel" },
                new() { Key = "descImovel", Label = "Descrição (tipo, m², cômodos, vaga)", IsTextArea = true, Section = "🏠 Dados do Imóvel" },
                new() { Key = "matricula", Label = "Matrícula (Cartório/Nº)", Section = "🏠 Dados do Imóvel" },
                new() { Key = "finalidade", Label = "Finalidade (Residencial / Comercial)", Section = "🏠 Dados do Imóvel" },
                // Aluguel
                new() { Key = "aluguel", Label = "Aluguel Mensal (R$)", Section = "💰 Aluguel e Pagamento" },
                new() { Key = "aluguelExtenso", Label = "Aluguel por Extenso", Section = "💰 Aluguel e Pagamento" },
                new() { Key = "indiceReajuste", Label = "Índice de Reajuste (IGPM, IPCA)", Section = "💰 Aluguel e Pagamento" },
                new() { Key = "vencimento", Label = "Dia do Vencimento", Section = "💰 Aluguel e Pagamento" },
                new() { Key = "contaBancaria", Label = "Dados bancários para depósito", Section = "💰 Aluguel e Pagamento" },
                // Garantia
                new() { Key = "tipoGarantia", Label = "Tipo (caução, fiador, seguro)", Section = "🔒 Garantia Locatícia" },
                new() { Key = "garantiaDetalhe", Label = "Detalhes da Garantia", IsTextArea = true, Section = "🔒 Garantia Locatícia" },
                // Vigência
                new() { Key = "vigencia", Label = "Vigência (meses)", Section = "📅 Prazo e Vigência" },
                new() { Key = "dataInicio", Label = "Data de Início", Section = "📅 Prazo e Vigência" },
                // Multas
                new() { Key = "multaRescisao", Label = "Multa por Rescisão (nº de aluguéis)", Section = S5 },
                new() { Key = "multaAtraso", Label = "Multa por Atraso (%)", Section = S5 },
                new() { Key = "jurosAtraso", Label = "Juros de Mora (% ao mês)", Section = S5 },
                // Foro
                new() { Key = "cidade", Label = "Cidade/UF", Section = S6 },
                new() { Key = "foro", Label = "Foro (Comarca)", Section = S6 },
                // Testemunhas
                new() { Key = "testemunha1", Label = "Testemunha 1 (Nome)", Section = S7 },
                new() { Key = "cpfTest1", Label = "CPF da Testemunha 1", Section = S7 },
                new() { Key = "testemunha2", Label = "Testemunha 2 (Nome)", Section = S7 },
                new() { Key = "cpfTest2", Label = "CPF da Testemunha 2", Section = S7 },
            }
        },

        // ═════════════════════════════════════════════════════════════
        //  NDA / CONFIDENCIALIDADE
        // ═════════════════════════════════════════════════════════════
        new ContractType
        {
            Id = "nda", Icon = "🔒", Title = "NDA / Confidencialidade",
            Description = "Proteja informações sensíveis entre partes",
            AccentColor = "#A29BFE",
            Category = "Geral",
            Fields = new()
            {
                // Parte Reveladora
                new() { Key = "parteA", Label = "Nome / Razão Social", Section = "👤 Parte Reveladora" },
                new() { Key = "cpfCnpjA", Label = "CPF/CNPJ", Section = "👤 Parte Reveladora" },
                new() { Key = "representanteA", Label = "Representante Legal (se PJ)", Section = "👤 Parte Reveladora" },
                new() { Key = "endA", Label = "Endereço", Section = "👤 Parte Reveladora" },
                new() { Key = "emailA", Label = "E-mail", Section = "👤 Parte Reveladora" },
                // Parte Receptora
                new() { Key = "parteB", Label = "Nome / Razão Social", Section = "👤 Parte Receptora" },
                new() { Key = "cpfCnpjB", Label = "CPF/CNPJ", Section = "👤 Parte Receptora" },
                new() { Key = "representanteB", Label = "Representante Legal (se PJ)", Section = "👤 Parte Receptora" },
                new() { Key = "endB", Label = "Endereço", Section = "👤 Parte Receptora" },
                new() { Key = "emailB", Label = "E-mail", Section = "👤 Parte Receptora" },
                // Acordo
                new() { Key = "bilateral", Label = "Tipo (Unilateral ou Bilateral)", Section = "📋 Detalhes do Acordo" },
                new() { Key = "objetivo", Label = "Objetivo / Contexto", IsTextArea = true, Section = "📋 Detalhes do Acordo" },
                new() { Key = "infoConfidencial", Label = "Informações Confidenciais", IsTextArea = true, Section = "📋 Detalhes do Acordo" },
                new() { Key = "exclusoes", Label = "Exclusões adicionais", IsTextArea = true, Section = "📋 Detalhes do Acordo" },
                // Vigência
                new() { Key = "vigencia", Label = "Vigência (anos)", Section = "📅 Vigência e Penalidades" },
                new() { Key = "sobrevivencia", Label = "Sobrevivência após término (anos)", Section = "📅 Vigência e Penalidades" },
                new() { Key = "penalidade", Label = "Penalidade por Descumprimento (R$)", Section = "📅 Vigência e Penalidades" },
                new() { Key = "penalidadeExtenso", Label = "Penalidade por Extenso", Section = "📅 Vigência e Penalidades" },
                new() { Key = "jurisdicao", Label = "Legislação Aplicável", Section = "📅 Vigência e Penalidades" },
                // Foro
                new() { Key = "cidade", Label = "Cidade/UF", Section = S6 },
                new() { Key = "foro", Label = "Foro (Comarca)", Section = S6 },
                // Testemunhas
                new() { Key = "testemunha1", Label = "Testemunha 1 (Nome)", Section = S7 },
                new() { Key = "cpfTest1", Label = "CPF da Testemunha 1", Section = S7 },
                new() { Key = "testemunha2", Label = "Testemunha 2 (Nome)", Section = S7 },
                new() { Key = "cpfTest2", Label = "CPF da Testemunha 2", Section = S7 },
            }
        },

        // ═════════════════════════════════════════════════════════════
        //  DESENVOLVIMENTO DE SOFTWARE
        // ═════════════════════════════════════════════════════════════
        new ContractType
        {
            Id = "dev-software", Icon = "💻", Title = "Desenvolvimento de Software",
            Description = "Para projetos de desenvolvimento de sistemas e aplicações",
            AccentColor = "#0984E3",
            Category = "TI",
            Fields = new()
            {
                // Contratante
                new() { Key = "empresa", Label = "Razão Social", Section = "🏢 Dados do Contratante" },
                new() { Key = "cnpj", Label = "CNPJ", Section = "🏢 Dados do Contratante" },
                new() { Key = "representante", Label = "Representante Legal", Section = "🏢 Dados do Contratante" },
                new() { Key = "endEmpresa", Label = "Endereço", Section = "🏢 Dados do Contratante" },
                new() { Key = "emailEmpresa", Label = "E-mail", Section = "🏢 Dados do Contratante" },
                // Desenvolvedor
                new() { Key = "devNome", Label = "Nome / Razão Social", Section = "💻 Dados do Desenvolvedor" },
                new() { Key = "cpfDev", Label = "CPF/CNPJ", Section = "💻 Dados do Desenvolvedor" },
                new() { Key = "endDev", Label = "Endereço", Section = "💻 Dados do Desenvolvedor" },
                new() { Key = "emailDev", Label = "E-mail", Section = "💻 Dados do Desenvolvedor" },
                // Escopo
                new() { Key = "escopo", Label = "Escopo do Projeto", IsTextArea = true, Section = "📋 Escopo do Projeto" },
                new() { Key = "tecnologias", Label = "Tecnologias Utilizadas", Section = "📋 Escopo do Projeto" },
                new() { Key = "metodologia", Label = "Metodologia (Scrum / Kanban)", Section = "📋 Escopo do Projeto" },
                // Cronograma
                new() { Key = "sprints", Label = "Número de Sprints", Section = "⏱️ Cronograma e Sprints" },
                new() { Key = "dataInicio", Label = "Data de Início", Section = "⏱️ Cronograma e Sprints" },
                new() { Key = "prazoTotal", Label = "Prazo Total do Projeto", Section = "⏱️ Cronograma e Sprints" },
                new() { Key = "ambienteHomologacao", Label = "Ambiente de Homologação", Section = "⏱️ Cronograma e Sprints" },
                new() { Key = "sla", Label = "SLA — Tempo de Resposta para Bugs", Section = "⏱️ Cronograma e Sprints" },
                // Valor
                new() { Key = "valorProjeto", Label = "Valor do Projeto (R$)", Section = S4 },
                new() { Key = "valorExtenso", Label = "Valor por Extenso", Section = S4 },
                new() { Key = "formaPagamento", Label = "Forma de Pagamento (marcos, sprints)", IsTextArea = true, Section = S4 },
                // Propriedade Intelectual e SLA
                new() { Key = "propriedadeIP", Label = "Propriedade do Código-Fonte", Section = "⚖️ Propriedade Intelectual e SLA" },
                new() { Key = "licencaFontes", Label = "Licença dos Fontes", Section = "⚖️ Propriedade Intelectual e SLA" },
                new() { Key = "garantiaBugs", Label = "Garantia para Correção de Bugs (meses)", Section = "⚖️ Propriedade Intelectual e SLA" },
                // Foro
                new() { Key = "cidade", Label = "Cidade/UF", Section = S6 },
                new() { Key = "foro", Label = "Foro (Comarca)", Section = S6 },
                // Testemunhas
                new() { Key = "testemunha1", Label = "Testemunha 1 (Nome)", Section = S7 },
                new() { Key = "cpfTest1", Label = "CPF da Testemunha 1", Section = S7 },
                new() { Key = "testemunha2", Label = "Testemunha 2 (Nome)", Section = S7 },
                new() { Key = "cpfTest2", Label = "CPF da Testemunha 2", Section = S7 },
            }
        },

        // ═════════════════════════════════════════════════════════════
        //  SUPORTE TÉCNICO
        // ═════════════════════════════════════════════════════════════
        new ContractType
        {
            Id = "suporte-ti", Icon = "🖥️", Title = "Suporte Técnico",
            Description = "Contrato de suporte e manutenção de TI",
            AccentColor = "#00B4D8",
            Category = "TI",
            Fields = new()
            {
                // Contratante
                new() { Key = "contratante", Label = "Nome / Razão Social", Section = S1 },
                new() { Key = "cpfCnpjContratante", Label = "CPF/CNPJ", Section = S1 },
                new() { Key = "endContratante", Label = "Endereço", Section = S1 },
                new() { Key = "emailContratante", Label = "E-mail", Section = S1 },
                // Empresa TI
                new() { Key = "empresaTI", Label = "Razão Social", Section = "🖥️ Dados da Empresa de TI" },
                new() { Key = "cnpjTI", Label = "CNPJ", Section = "🖥️ Dados da Empresa de TI" },
                new() { Key = "representanteTI", Label = "Representante Legal", Section = "🖥️ Dados da Empresa de TI" },
                new() { Key = "endTI", Label = "Endereço", Section = "🖥️ Dados da Empresa de TI" },
                new() { Key = "emailTI", Label = "E-mail", Section = "🖥️ Dados da Empresa de TI" },
                // Detalhes do Suporte
                new() { Key = "nivelSuporte", Label = "Nível de Suporte (1 / 2 / 3)", Section = "🔧 Detalhes do Suporte" },
                new() { Key = "horarioAtendimento", Label = "Horário de Atendimento", Section = "🔧 Detalhes do Suporte" },
                new() { Key = "tempoResposta", Label = "SLA — Tempo de Resposta", Section = "🔧 Detalhes do Suporte" },
                new() { Key = "tempoResolucao", Label = "SLA — Tempo de Resolução", Section = "🔧 Detalhes do Suporte" },
                new() { Key = "canalAtendimento", Label = "Canal de Atendimento", Section = "🔧 Detalhes do Suporte" },
                new() { Key = "sistemasCobertos", Label = "Sistemas e Equipamentos Cobertos", IsTextArea = true, Section = "🔧 Detalhes do Suporte" },
                // Valor
                new() { Key = "valorMensal", Label = "Valor Mensal (R$)", Section = S4 },
                new() { Key = "valorExtenso", Label = "Valor por Extenso", Section = S4 },
                new() { Key = "formaPagamento", Label = "Forma de Pagamento", Section = S4 },
                // Vigência
                new() { Key = "vigencia", Label = "Vigência (meses)", Section = "📅 Vigência" },
                new() { Key = "dataInicio", Label = "Data de Início", Section = "📅 Vigência" },
                // Multas
                new() { Key = "multaRescisao", Label = "Multa por Rescisão (%)", Section = S5 },
                new() { Key = "multaIndisponibilidade", Label = "Multa por Indisponibilidade (%)", Section = S5 },
                // Foro
                new() { Key = "cidade", Label = "Cidade/UF", Section = S6 },
                new() { Key = "foro", Label = "Foro (Comarca)", Section = S6 },
                // Testemunhas
                new() { Key = "testemunha1", Label = "Testemunha 1 (Nome)", Section = S7 },
                new() { Key = "cpfTest1", Label = "CPF da Testemunha 1", Section = S7 },
                new() { Key = "testemunha2", Label = "Testemunha 2 (Nome)", Section = S7 },
                new() { Key = "cpfTest2", Label = "CPF da Testemunha 2", Section = S7 },
            }
        },

        // ═════════════════════════════════════════════════════════════
        //  LICENCIAMENTO SaaS
        // ═════════════════════════════════════════════════════════════
        new ContractType
        {
            Id = "saas", Icon = "☁️", Title = "Licenciamento SaaS",
            Description = "Contrato de licença de software como serviço",
            AccentColor = "#6C5CE7",
            Category = "TI",
            Fields = new()
            {
                // Fornecedor
                new() { Key = "fornecedor", Label = "Razão Social", Section = "🏢 Dados do Fornecedor" },
                new() { Key = "cnpjFornecedor", Label = "CNPJ", Section = "🏢 Dados do Fornecedor" },
                new() { Key = "representanteFornecedor", Label = "Representante Legal", Section = "🏢 Dados do Fornecedor" },
                new() { Key = "endFornecedor", Label = "Endereço", Section = "🏢 Dados do Fornecedor" },
                new() { Key = "emailFornecedor", Label = "E-mail", Section = "🏢 Dados do Fornecedor" },
                // Cliente
                new() { Key = "cliente", Label = "Nome / Razão Social", Section = "👤 Dados do Cliente" },
                new() { Key = "cpfCnpjCliente", Label = "CPF/CNPJ", Section = "👤 Dados do Cliente" },
                new() { Key = "endCliente", Label = "Endereço", Section = "👤 Dados do Cliente" },
                new() { Key = "emailCliente", Label = "E-mail", Section = "👤 Dados do Cliente" },
                // Detalhes da Licença
                new() { Key = "nomePlataforma", Label = "Nome da Plataforma", Section = "☁️ Detalhes da Licença" },
                new() { Key = "planoContratado", Label = "Plano Contratado", Section = "☁️ Detalhes da Licença" },
                new() { Key = "quantidadeUsuarios", Label = "Quantidade de Usuários", Section = "☁️ Detalhes da Licença" },
                new() { Key = "uptimeGarantido", Label = "Uptime Garantido (ex: 99,9%)", Section = "☁️ Detalhes da Licença" },
                new() { Key = "suporteIncluso", Label = "Suporte Incluso", Section = "☁️ Detalhes da Licença" },
                new() { Key = "backupFrequencia", Label = "Frequência de Backup", Section = "☁️ Detalhes da Licença" },
                // Valor
                new() { Key = "valorMensal", Label = "Valor Mensal (R$)", Section = S4 },
                new() { Key = "formaPagamento", Label = "Forma de Pagamento", Section = S4 },
                new() { Key = "reajusteAnual", Label = "Índice de Reajuste Anual", Section = S4 },
                // Dados e Cancelamento
                new() { Key = "propriedadeDados", Label = "Propriedade dos Dados", Section = "📋 Dados e Cancelamento" },
                new() { Key = "exportacaoDados", Label = "Formato de Exportação dos Dados", Section = "📋 Dados e Cancelamento" },
                new() { Key = "prazoExportacao", Label = "Prazo para Exportação após Cancelamento (dias)", Section = "📋 Dados e Cancelamento" },
                new() { Key = "vigencia", Label = "Vigência (meses)", Section = "📋 Dados e Cancelamento" },
                // Foro
                new() { Key = "cidade", Label = "Cidade/UF", Section = S6 },
                new() { Key = "foro", Label = "Foro (Comarca)", Section = S6 },
                // Testemunhas
                new() { Key = "testemunha1", Label = "Testemunha 1 (Nome)", Section = S7 },
                new() { Key = "cpfTest1", Label = "CPF da Testemunha 1", Section = S7 },
                new() { Key = "testemunha2", Label = "Testemunha 2 (Nome)", Section = S7 },
                new() { Key = "cpfTest2", Label = "CPF da Testemunha 2", Section = S7 },
            }
        },

        // ═════════════════════════════════════════════════════════════
        //  TRATAMENTO DE DADOS LGPD
        // ═════════════════════════════════════════════════════════════
        new ContractType
        {
            Id = "lgpd", Icon = "🛡️", Title = "Tratamento de Dados LGPD",
            Description = "Acordo de tratamento de dados pessoais conforme a LGPD",
            AccentColor = "#00B894",
            Category = "TI",
            Fields = new()
            {
                // Controlador
                new() { Key = "controlador", Label = "Nome / Razão Social", Section = "🏢 Controlador" },
                new() { Key = "cnpjControlador", Label = "CNPJ", Section = "🏢 Controlador" },
                new() { Key = "representanteControlador", Label = "Representante Legal", Section = "🏢 Controlador" },
                new() { Key = "dpo", Label = "Encarregado (DPO)", Section = "🏢 Controlador" },
                new() { Key = "emailDpo", Label = "E-mail do DPO", Section = "🏢 Controlador" },
                // Operador
                new() { Key = "operador", Label = "Nome / Razão Social", Section = "🔧 Operador" },
                new() { Key = "cnpjOperador", Label = "CNPJ", Section = "🔧 Operador" },
                new() { Key = "representanteOperador", Label = "Representante Legal", Section = "🔧 Operador" },
                new() { Key = "endOperador", Label = "Endereço", Section = "🔧 Operador" },
                new() { Key = "emailOperador", Label = "E-mail", Section = "🔧 Operador" },
                // Tratamento de Dados
                new() { Key = "finalidade", Label = "Finalidade do Tratamento", IsTextArea = true, Section = "📋 Tratamento de Dados" },
                new() { Key = "baseLegal", Label = "Base Legal (art. 7º LGPD)", Section = "📋 Tratamento de Dados" },
                new() { Key = "categoriasDados", Label = "Categorias de Dados Pessoais", IsTextArea = true, Section = "📋 Tratamento de Dados" },
                new() { Key = "titularesDados", Label = "Titulares dos Dados", Section = "📋 Tratamento de Dados" },
                new() { Key = "compartilhamento", Label = "Compartilhamento com Terceiros", IsTextArea = true, Section = "📋 Tratamento de Dados" },
                // Medidas de Segurança
                new() { Key = "medidasTecnicas", Label = "Medidas Técnicas e Administrativas", IsTextArea = true, Section = "🔒 Medidas de Segurança" },
                new() { Key = "prazoNotificacao", Label = "Prazo para Notificação de Incidente", Section = "🔒 Medidas de Segurança" },
                new() { Key = "prazoRetencao", Label = "Prazo de Retenção dos Dados", Section = "🔒 Medidas de Segurança" },
                new() { Key = "descarteDados", Label = "Método de Descarte dos Dados", Section = "🔒 Medidas de Segurança" },
                // Foro
                new() { Key = "cidade", Label = "Cidade/UF", Section = S6 },
                new() { Key = "foro", Label = "Foro (Comarca)", Section = S6 },
                // Testemunhas
                new() { Key = "testemunha1", Label = "Testemunha 1 (Nome)", Section = S7 },
                new() { Key = "cpfTest1", Label = "CPF da Testemunha 1", Section = S7 },
                new() { Key = "testemunha2", Label = "Testemunha 2 (Nome)", Section = S7 },
                new() { Key = "cpfTest2", Label = "CPF da Testemunha 2", Section = S7 },
            }
        },

        // ═════════════════════════════════════════════════════════════
        //  HONORÁRIOS ADVOCATÍCIOS
        // ═════════════════════════════════════════════════════════════
        new ContractType
        {
            Id = "honorarios", Icon = "⚖️", Title = "Honorários Advocatícios",
            Description = "Contrato de prestação de serviços advocatícios",
            AccentColor = "#6C5CE7",
            Category = "Direito",
            Fields = new()
            {
                // Advogado
                new() { Key = "nomeAdvogado", Label = "Nome do Advogado", Section = "⚖️ Dados do Advogado" },
                new() { Key = "oab", Label = "OAB (Seccional/Nº)", Section = "⚖️ Dados do Advogado" },
                new() { Key = "cpfAdvogado", Label = "CPF", Section = "⚖️ Dados do Advogado" },
                new() { Key = "endAdvogado", Label = "Endereço Profissional", Section = "⚖️ Dados do Advogado" },
                new() { Key = "emailAdvogado", Label = "E-mail", Section = "⚖️ Dados do Advogado" },
                // Cliente
                new() { Key = "nomeCliente", Label = "Nome Completo", Section = "👤 Dados do Cliente" },
                new() { Key = "cpfCliente", Label = "CPF/CNPJ", Section = "👤 Dados do Cliente" },
                new() { Key = "endCliente", Label = "Endereço", Section = "👤 Dados do Cliente" },
                new() { Key = "emailCliente", Label = "E-mail", Section = "👤 Dados do Cliente" },
                // Objeto
                new() { Key = "tipoAcao", Label = "Tipo de Ação / Serviço", Section = "📋 Objeto" },
                new() { Key = "descricaoCausa", Label = "Descrição da Causa", IsTextArea = true, Section = "📋 Objeto" },
                new() { Key = "valorCausa", Label = "Valor da Causa (R$)", Section = "📋 Objeto" },
                new() { Key = "instancia", Label = "Instância (1ª, 2ª, Superior)", Section = "📋 Objeto" },
                // Honorários
                new() { Key = "honorariosIniciais", Label = "Honorários Iniciais (R$)", Section = "💰 Honorários" },
                new() { Key = "honorariosMensais", Label = "Honorários Mensais (R$)", Section = "💰 Honorários" },
                new() { Key = "honorariosExito", Label = "Honorários de Êxito (%)", Section = "💰 Honorários" },
                new() { Key = "formaPagamento", Label = "Forma de Pagamento", Section = "💰 Honorários" },
                // Foro
                new() { Key = "cidade", Label = "Cidade/UF", Section = S6 },
                new() { Key = "foro", Label = "Foro (Comarca)", Section = S6 },
                // Testemunhas
                new() { Key = "testemunha1", Label = "Testemunha 1 (Nome)", Section = S7 },
                new() { Key = "cpfTest1", Label = "CPF da Testemunha 1", Section = S7 },
                new() { Key = "testemunha2", Label = "Testemunha 2 (Nome)", Section = S7 },
                new() { Key = "cpfTest2", Label = "CPF da Testemunha 2", Section = S7 },
            }
        },

        // ═════════════════════════════════════════════════════════════
        //  CONTRATO DE PARCERIA
        // ═════════════════════════════════════════════════════════════
        new ContractType
        {
            Id = "parceria", Icon = "🤝", Title = "Contrato de Parceria",
            Description = "Parceria comercial ou empresarial entre partes",
            AccentColor = "#E17055",
            Category = "Direito",
            Fields = new()
            {
                // Parceiro 1
                new() { Key = "parceiro1", Label = "Nome / Razão Social", Section = "👤 Parceiro 1" },
                new() { Key = "cpfCnpj1", Label = "CPF/CNPJ", Section = "👤 Parceiro 1" },
                new() { Key = "end1", Label = "Endereço", Section = "👤 Parceiro 1" },
                new() { Key = "email1", Label = "E-mail", Section = "👤 Parceiro 1" },
                // Parceiro 2
                new() { Key = "parceiro2", Label = "Nome / Razão Social", Section = "👤 Parceiro 2" },
                new() { Key = "cpfCnpj2", Label = "CPF/CNPJ", Section = "👤 Parceiro 2" },
                new() { Key = "end2", Label = "Endereço", Section = "👤 Parceiro 2" },
                new() { Key = "email2", Label = "E-mail", Section = "👤 Parceiro 2" },
                // Objeto da Parceria
                new() { Key = "objetivo", Label = "Objetivo da Parceria", IsTextArea = true, Section = "📋 Objeto da Parceria" },
                new() { Key = "aportes", Label = "Aportes de Cada Parte", IsTextArea = true, Section = "📋 Objeto da Parceria" },
                new() { Key = "divisaoLucros", Label = "Divisão de Lucros (%)", Section = "📋 Objeto da Parceria" },
                new() { Key = "gestao", Label = "Gestão / Administração", Section = "📋 Objeto da Parceria" },
                // Vigência
                new() { Key = "vigencia", Label = "Vigência (meses/anos)", Section = "📅 Vigência" },
                new() { Key = "dataInicio", Label = "Data de Início", Section = "📅 Vigência" },
                new() { Key = "condicoesTermino", Label = "Condições de Término", IsTextArea = true, Section = "📅 Vigência" },
                // Foro
                new() { Key = "cidade", Label = "Cidade/UF", Section = S6 },
                new() { Key = "foro", Label = "Foro (Comarca)", Section = S6 },
                // Testemunhas
                new() { Key = "testemunha1", Label = "Testemunha 1 (Nome)", Section = S7 },
                new() { Key = "cpfTest1", Label = "CPF da Testemunha 1", Section = S7 },
                new() { Key = "testemunha2", Label = "Testemunha 2 (Nome)", Section = S7 },
                new() { Key = "cpfTest2", Label = "CPF da Testemunha 2", Section = S7 },
            }
        },

        // ═════════════════════════════════════════════════════════════
        //  DISTRATO / RESCISÃO
        // ═════════════════════════════════════════════════════════════
        new ContractType
        {
            Id = "distrato", Icon = "📄", Title = "Distrato / Rescisão",
            Description = "Instrumento de rescisão contratual amigável",
            AccentColor = "#636E72",
            Category = "Direito",
            Fields = new()
            {
                // Parte 1
                new() { Key = "parte1", Label = "Nome / Razão Social", Section = "👤 Parte 1" },
                new() { Key = "cpfCnpj1", Label = "CPF/CNPJ", Section = "👤 Parte 1" },
                new() { Key = "end1", Label = "Endereço", Section = "👤 Parte 1" },
                new() { Key = "email1", Label = "E-mail", Section = "👤 Parte 1" },
                // Parte 2
                new() { Key = "parte2", Label = "Nome / Razão Social", Section = "👤 Parte 2" },
                new() { Key = "cpfCnpj2", Label = "CPF/CNPJ", Section = "👤 Parte 2" },
                new() { Key = "end2", Label = "Endereço", Section = "👤 Parte 2" },
                new() { Key = "email2", Label = "E-mail", Section = "👤 Parte 2" },
                // Contrato Original
                new() { Key = "tipoContratoOriginal", Label = "Tipo do Contrato Original", Section = "📋 Contrato Original" },
                new() { Key = "dataContratoOriginal", Label = "Data do Contrato Original", Section = "📋 Contrato Original" },
                new() { Key = "objetoOriginal", Label = "Objeto do Contrato Original", IsTextArea = true, Section = "📋 Contrato Original" },
                // Motivo e Condições
                new() { Key = "motivoDistrato", Label = "Motivo do Distrato", IsTextArea = true, Section = "📋 Motivo e Condições" },
                new() { Key = "obrigacoesPendentes", Label = "Obrigações Pendentes", IsTextArea = true, Section = "📋 Motivo e Condições" },
                new() { Key = "valorRescisao", Label = "Valor da Rescisão (R$)", Section = "📋 Motivo e Condições" },
                new() { Key = "prazoQuitacao", Label = "Prazo para Quitação", Section = "📋 Motivo e Condições" },
                new() { Key = "devolucaoBens", Label = "Devolução de Bens / Materiais", IsTextArea = true, Section = "📋 Motivo e Condições" },
                // Foro
                new() { Key = "cidade", Label = "Cidade/UF", Section = S6 },
                new() { Key = "foro", Label = "Foro (Comarca)", Section = S6 },
                // Testemunhas
                new() { Key = "testemunha1", Label = "Testemunha 1 (Nome)", Section = S7 },
                new() { Key = "cpfTest1", Label = "CPF da Testemunha 1", Section = S7 },
                new() { Key = "testemunha2", Label = "Testemunha 2 (Nome)", Section = S7 },
                new() { Key = "cpfTest2", Label = "CPF da Testemunha 2", Section = S7 },
            }
        },

        // ═════════════════════════════════════════════════════════════
        //  CESSÃO DE DIREITOS
        // ═════════════════════════════════════════════════════════════
        new ContractType
        {
            Id = "cessao-direitos", Icon = "✍️", Title = "Cessão de Direitos",
            Description = "Transferência de direitos patrimoniais ou autorais",
            AccentColor = "#A29BFE",
            Category = "Direito",
            Fields = new()
            {
                // Cedente
                new() { Key = "cedente", Label = "Nome / Razão Social", Section = "👤 Cedente" },
                new() { Key = "cpfCnpjCedente", Label = "CPF/CNPJ", Section = "👤 Cedente" },
                new() { Key = "endCedente", Label = "Endereço", Section = "👤 Cedente" },
                new() { Key = "emailCedente", Label = "E-mail", Section = "👤 Cedente" },
                // Cessionário
                new() { Key = "cessionario", Label = "Nome / Razão Social", Section = "👤 Cessionário" },
                new() { Key = "cpfCnpjCessionario", Label = "CPF/CNPJ", Section = "👤 Cessionário" },
                new() { Key = "endCessionario", Label = "Endereço", Section = "👤 Cessionário" },
                new() { Key = "emailCessionario", Label = "E-mail", Section = "👤 Cessionário" },
                // Objeto da Cessão
                new() { Key = "direitosCedidos", Label = "Direitos Cedidos", IsTextArea = true, Section = "📋 Objeto da Cessão" },
                new() { Key = "tipoCessao", Label = "Tipo de Cessão (Parcial / Total)", Section = "📋 Objeto da Cessão" },
                new() { Key = "exclusividade", Label = "Exclusividade (Sim / Não)", Section = "📋 Objeto da Cessão" },
                new() { Key = "restricoes", Label = "Restrições de Uso", IsTextArea = true, Section = "📋 Objeto da Cessão" },
                // Remuneração
                new() { Key = "valorCessao", Label = "Valor da Cessão (R$)", Section = "💰 Remuneração" },
                new() { Key = "valorExtenso", Label = "Valor por Extenso", Section = "💰 Remuneração" },
                new() { Key = "formaPagamento", Label = "Forma de Pagamento", Section = "💰 Remuneração" },
                // Foro
                new() { Key = "cidade", Label = "Cidade/UF", Section = S6 },
                new() { Key = "foro", Label = "Foro (Comarca)", Section = S6 },
                // Testemunhas
                new() { Key = "testemunha1", Label = "Testemunha 1 (Nome)", Section = S7 },
                new() { Key = "cpfTest1", Label = "CPF da Testemunha 1", Section = S7 },
                new() { Key = "testemunha2", Label = "Testemunha 2 (Nome)", Section = S7 },
                new() { Key = "cpfTest2", Label = "CPF da Testemunha 2", Section = S7 },
            }
        },

        // ═════════════════════════════════════════════════════════════
        //  CONSULTA SAUDE
        // ═════════════════════════════════════════════════════════════
        new ContractType
        {
            Id = "consulta-saude", Icon = "🩺", Title = "Serviço Médico",
            Description = "Contrato de prestação de serviço médico ou de saúde",
            Category = "Saúde", AccentColor = "#00B894",
            Fields = new()
            {
                // Profissional
                new() { Key = "nomeProfissional", Label = "Nome completo do Profissional", Section = "🩺 Dados do Profissional" },
                new() { Key = "crm", Label = "CRM / Registro Profissional", Section = "🩺 Dados do Profissional" },
                new() { Key = "especialidade", Label = "Especialidade", Section = "🩺 Dados do Profissional" },
                new() { Key = "cpfProfissional", Label = "CPF/CNPJ", Section = "🩺 Dados do Profissional" },
                new() { Key = "endConsultorio", Label = "Endereço do Consultório", Section = "🩺 Dados do Profissional" },
                new() { Key = "emailProfissional", Label = "E-mail", Section = "🩺 Dados do Profissional" },
                // Paciente
                new() { Key = "nomePaciente", Label = "Nome completo do Paciente/Contratante", Section = "👤 Dados do Paciente/Contratante" },
                new() { Key = "cpfPaciente", Label = "CPF", Section = "👤 Dados do Paciente/Contratante" },
                new() { Key = "endPaciente", Label = "Endereço completo", Section = "👤 Dados do Paciente/Contratante" },
                new() { Key = "emailPaciente", Label = "E-mail", Section = "👤 Dados do Paciente/Contratante" },
                // Serviço
                new() { Key = "procedimento", Label = "Procedimento(s) / Serviço(s) a prestar", IsTextArea = true, Section = "📋 Serviço Médico" },
                new() { Key = "localAtendimento", Label = "Local de Atendimento", Section = "📋 Serviço Médico" },
                new() { Key = "periodicidade", Label = "Periodicidade (sessões, consultas)", Section = "📋 Serviço Médico" },
                new() { Key = "dataInicio", Label = "Data de Início", Section = "📋 Serviço Médico" },
                // Honorários
                new() { Key = "valorConsulta", Label = "Valor por Consulta/Sessão (R$)", Section = "💰 Honorários" },
                new() { Key = "valorExtenso", Label = "Valor por Extenso", Section = "💰 Honorários" },
                new() { Key = "formaPagamento", Label = "Forma de Pagamento", Section = "💰 Honorários" },
                // Foro
                new() { Key = "cidade", Label = "Cidade/UF", Section = S6 },
                new() { Key = "foro", Label = "Foro (Comarca)", Section = S6 },
                // Testemunhas
                new() { Key = "testemunha1", Label = "Testemunha 1 (Nome)", Section = S7 },
                new() { Key = "cpfTest1", Label = "CPF da Testemunha 1", Section = S7 },
                new() { Key = "testemunha2", Label = "Testemunha 2 (Nome)", Section = S7 },
                new() { Key = "cpfTest2", Label = "CPF da Testemunha 2", Section = S7 },
            }
        },

        // ═════════════════════════════════════════════════════════════
        //  CONSENTIMENTO INFORMADO
        // ═════════════════════════════════════════════════════════════
        new ContractType
        {
            Id = "consentimento", Icon = "📋", Title = "Termo de Consentimento Informado",
            Description = "Termo de consentimento livre e esclarecido para procedimentos de saúde",
            Category = "Saúde", AccentColor = "#00CEC9",
            Fields = new()
            {
                // Profissional
                new() { Key = "nomeProfissional", Label = "Nome do Profissional Responsável", Section = "🩺 Profissional Responsável" },
                new() { Key = "crm", Label = "CRM / Registro Profissional", Section = "🩺 Profissional Responsável" },
                new() { Key = "especialidade", Label = "Especialidade", Section = "🩺 Profissional Responsável" },
                // Paciente
                new() { Key = "nomePaciente", Label = "Nome completo do Paciente", Section = "👤 Paciente" },
                new() { Key = "cpfPaciente", Label = "CPF", Section = "👤 Paciente" },
                new() { Key = "dataNascimento", Label = "Data de Nascimento", Section = "👤 Paciente" },
                // Procedimento
                new() { Key = "procedimento", Label = "Procedimento Proposto", IsTextArea = true, Section = "📋 Procedimento" },
                new() { Key = "indicacao", Label = "Indicação Clínica", IsTextArea = true, Section = "📋 Procedimento" },
                new() { Key = "alternativas", Label = "Alternativas ao Procedimento", IsTextArea = true, Section = "📋 Procedimento" },
                new() { Key = "riscosEsperados", Label = "Riscos Esperados", IsTextArea = true, Section = "📋 Procedimento" },
                new() { Key = "complicacoesPossiveis", Label = "Complicações Possíveis", IsTextArea = true, Section = "📋 Procedimento" },
                new() { Key = "cuidadosPos", Label = "Cuidados Pós-Procedimento", IsTextArea = true, Section = "📋 Procedimento" },
                // Foro
                new() { Key = "cidade", Label = "Cidade/UF", Section = S6 },
                new() { Key = "foro", Label = "Foro (Comarca)", Section = S6 },
                // Testemunhas
                new() { Key = "testemunha1", Label = "Testemunha 1 (Nome)", Section = S7 },
                new() { Key = "cpfTest1", Label = "CPF da Testemunha 1", Section = S7 },
                new() { Key = "testemunha2", Label = "Testemunha 2 (Nome)", Section = S7 },
                new() { Key = "cpfTest2", Label = "CPF da Testemunha 2", Section = S7 },
            }
        },

        // ═════════════════════════════════════════════════════════════
        //  PARCERIA ENTRE CLINICAS
        // ═════════════════════════════════════════════════════════════
        new ContractType
        {
            Id = "clinica-parceria", Icon = "🏥", Title = "Parceria entre Clínicas",
            Description = "Contrato de parceria e compartilhamento de estrutura entre clínicas",
            Category = "Saúde", AccentColor = "#55A3E8",
            Fields = new()
            {
                // Clínica 1
                new() { Key = "nomeClinica1", Label = "Nome / Razão Social", Section = "🏥 Clínica 1" },
                new() { Key = "cnpjClinica1", Label = "CNPJ", Section = "🏥 Clínica 1" },
                new() { Key = "representante1", Label = "Representante Legal", Section = "🏥 Clínica 1" },
                new() { Key = "crm1", Label = "CRM do Responsável Técnico", Section = "🏥 Clínica 1" },
                new() { Key = "endClinica1", Label = "Endereço", Section = "🏥 Clínica 1" },
                new() { Key = "emailClinica1", Label = "E-mail", Section = "🏥 Clínica 1" },
                // Clínica 2
                new() { Key = "nomeClinica2", Label = "Nome / Razão Social", Section = "🏥 Clínica 2" },
                new() { Key = "cnpjClinica2", Label = "CNPJ", Section = "🏥 Clínica 2" },
                new() { Key = "representante2", Label = "Representante Legal", Section = "🏥 Clínica 2" },
                new() { Key = "crm2", Label = "CRM do Responsável Técnico", Section = "🏥 Clínica 2" },
                new() { Key = "endClinica2", Label = "Endereço", Section = "🏥 Clínica 2" },
                new() { Key = "emailClinica2", Label = "E-mail", Section = "🏥 Clínica 2" },
                // Objeto
                new() { Key = "especialidades", Label = "Especialidades Envolvidas", IsTextArea = true, Section = "📋 Objeto da Parceria" },
                new() { Key = "estruturaCompartilhada", Label = "Estrutura Compartilhada", IsTextArea = true, Section = "📋 Objeto da Parceria" },
                new() { Key = "divisaoReceitas", Label = "Divisão de Receitas", Section = "📋 Objeto da Parceria" },
                new() { Key = "gestaoAdministrativa", Label = "Gestão Administrativa", Section = "📋 Objeto da Parceria" },
                // Vigência
                new() { Key = "vigencia", Label = "Vigência (meses)", Section = "📅 Vigência" },
                new() { Key = "dataInicio", Label = "Data de Início", Section = "📅 Vigência" },
                // Valores
                new() { Key = "valorFixo", Label = "Valor Fixo Mensal (R$)", Section = "💰 Valores" },
                new() { Key = "percentualReceitas", Label = "Percentual sobre Receitas (%)", Section = "💰 Valores" },
                // Foro
                new() { Key = "cidade", Label = "Cidade/UF", Section = S6 },
                new() { Key = "foro", Label = "Foro (Comarca)", Section = S6 },
                // Testemunhas
                new() { Key = "testemunha1", Label = "Testemunha 1 (Nome)", Section = S7 },
                new() { Key = "cpfTest1", Label = "CPF da Testemunha 1", Section = S7 },
                new() { Key = "testemunha2", Label = "Testemunha 2 (Nome)", Section = S7 },
                new() { Key = "cpfTest2", Label = "CPF da Testemunha 2", Section = S7 },
            }
        },

        // ═════════════════════════════════════════════════════════════
        //  SERVICO CONTABIL
        // ═════════════════════════════════════════════════════════════
        new ContractType
        {
            Id = "contabilidade", Icon = "📊", Title = "Serviço Contábil",
            Description = "Contrato de prestação de serviços contábeis e fiscais",
            Category = "Contábil", AccentColor = "#E17055",
            Fields = new()
            {
                // Escritório
                new() { Key = "nomeEscritorio", Label = "Nome / Razão Social do Escritório", Section = "📊 Escritório Contábil" },
                new() { Key = "cnpjEscritorio", Label = "CNPJ", Section = "📊 Escritório Contábil" },
                new() { Key = "crc", Label = "CRC (Registro no Conselho)", Section = "📊 Escritório Contábil" },
                new() { Key = "responsavelTecnico", Label = "Responsável Técnico", Section = "📊 Escritório Contábil" },
                new() { Key = "endEscritorio", Label = "Endereço", Section = "📊 Escritório Contábil" },
                new() { Key = "emailEscritorio", Label = "E-mail", Section = "📊 Escritório Contábil" },
                // Empresa Cliente
                new() { Key = "nomeEmpresa", Label = "Razão Social", Section = "🏢 Empresa Cliente" },
                new() { Key = "cnpjEmpresa", Label = "CNPJ", Section = "🏢 Empresa Cliente" },
                new() { Key = "representante", Label = "Representante Legal", Section = "🏢 Empresa Cliente" },
                new() { Key = "endEmpresa", Label = "Endereço", Section = "🏢 Empresa Cliente" },
                new() { Key = "emailEmpresa", Label = "E-mail", Section = "🏢 Empresa Cliente" },
                new() { Key = "regimeTributario", Label = "Regime Tributário (Simples / Lucro Presumido / Lucro Real)", Section = "🏢 Empresa Cliente" },
                // Serviços
                new() { Key = "obrigacoesAcessorias", Label = "Obrigações Acessórias (DCTF, SPED, EFD, etc.)", IsTextArea = true, Section = "📋 Serviços Contratados" },
                new() { Key = "folhaPagamento", Label = "Inclui Folha de Pagamento? (Sim/Não)", Section = "📋 Serviços Contratados" },
                new() { Key = "quantidadeFuncionarios", Label = "Quantidade de Funcionários", Section = "📋 Serviços Contratados" },
                new() { Key = "consultoriaTributaria", Label = "Inclui Consultoria Tributária? (Sim/Não)", Section = "📋 Serviços Contratados" },
                // Honorários
                new() { Key = "valorMensal", Label = "Honorários Mensais (R$)", Section = "💰 Honorários" },
                new() { Key = "valorExtenso", Label = "Valor por Extenso", Section = "💰 Honorários" },
                new() { Key = "formaPagamento", Label = "Forma de Pagamento", Section = "💰 Honorários" },
                // Vigência
                new() { Key = "vigencia", Label = "Vigência (meses)", Section = "📅 Vigência" },
                new() { Key = "dataInicio", Label = "Data de Início", Section = "📅 Vigência" },
                // Foro
                new() { Key = "cidade", Label = "Cidade/UF", Section = S6 },
                new() { Key = "foro", Label = "Foro (Comarca)", Section = S6 },
                // Testemunhas
                new() { Key = "testemunha1", Label = "Testemunha 1 (Nome)", Section = S7 },
                new() { Key = "cpfTest1", Label = "CPF da Testemunha 1", Section = S7 },
                new() { Key = "testemunha2", Label = "Testemunha 2 (Nome)", Section = S7 },
                new() { Key = "cpfTest2", Label = "CPF da Testemunha 2", Section = S7 },
            }
        },

        // ═════════════════════════════════════════════════════════════
        //  CONSULTORIA FISCAL / TRIBUTARIA
        // ═════════════════════════════════════════════════════════════
        new ContractType
        {
            Id = "consultoria-fiscal", Icon = "💰", Title = "Consultoria Fiscal/Tributária",
            Description = "Contrato de consultoria fiscal e planejamento tributário",
            Category = "Contábil", AccentColor = "#FDCB6E",
            Fields = new()
            {
                // Consultor
                new() { Key = "nomeConsultor", Label = "Nome / Razão Social do Consultor", Section = "💼 Consultor" },
                new() { Key = "cpfCnpj", Label = "CPF/CNPJ", Section = "💼 Consultor" },
                new() { Key = "crc", Label = "CRC (se aplicável)", Section = "💼 Consultor" },
                new() { Key = "endConsultor", Label = "Endereço", Section = "💼 Consultor" },
                new() { Key = "emailConsultor", Label = "E-mail", Section = "💼 Consultor" },
                // Empresa
                new() { Key = "nomeEmpresa", Label = "Razão Social", Section = "🏢 Empresa" },
                new() { Key = "cnpjEmpresa", Label = "CNPJ", Section = "🏢 Empresa" },
                new() { Key = "representante", Label = "Representante Legal", Section = "🏢 Empresa" },
                new() { Key = "endEmpresa", Label = "Endereço", Section = "🏢 Empresa" },
                new() { Key = "emailEmpresa", Label = "E-mail", Section = "🏢 Empresa" },
                new() { Key = "setorAtuacao", Label = "Setor de Atuação", Section = "🏢 Empresa" },
                // Escopo
                new() { Key = "escopoConsultoria", Label = "Escopo da Consultoria", IsTextArea = true, Section = "📋 Escopo da Consultoria" },
                new() { Key = "tributosFoco", Label = "Tributos em Foco (ICMS, ISS, IR, CSLL, etc.)", IsTextArea = true, Section = "📋 Escopo da Consultoria" },
                new() { Key = "periodoAnalise", Label = "Período de Análise", Section = "📋 Escopo da Consultoria" },
                new() { Key = "entregas", Label = "Entregas / Deliverables", IsTextArea = true, Section = "📋 Escopo da Consultoria" },
                // Honorários
                new() { Key = "valorProjeto", Label = "Valor do Projeto (R$)", Section = "💰 Honorários" },
                new() { Key = "valorExtenso", Label = "Valor por Extenso", Section = "💰 Honorários" },
                new() { Key = "formaPagamento", Label = "Forma de Pagamento", Section = "💰 Honorários" },
                // Foro
                new() { Key = "cidade", Label = "Cidade/UF", Section = S6 },
                new() { Key = "foro", Label = "Foro (Comarca)", Section = S6 },
                // Testemunhas
                new() { Key = "testemunha1", Label = "Testemunha 1 (Nome)", Section = S7 },
                new() { Key = "cpfTest1", Label = "CPF da Testemunha 1", Section = S7 },
                new() { Key = "testemunha2", Label = "Testemunha 2 (Nome)", Section = S7 },
                new() { Key = "cpfTest2", Label = "CPF da Testemunha 2", Section = S7 },
            }
        },

        // ═════════════════════════════════════════════════════════════
        //  ABERTURA DE EMPRESA
        // ═════════════════════════════════════════════════════════════
        new ContractType
        {
            Id = "abertura-empresa", Icon = "🏢", Title = "Abertura de Empresa",
            Description = "Contrato para abertura e constituição de pessoa jurídica",
            Category = "Contábil", AccentColor = "#A29BFE",
            Fields = new()
            {
                // Prestador
                new() { Key = "nomeEscritorio", Label = "Nome / Razão Social do Escritório", Section = "💼 Prestador de Serviço" },
                new() { Key = "cnpjEscritorio", Label = "CNPJ", Section = "💼 Prestador de Serviço" },
                new() { Key = "crc", Label = "CRC", Section = "💼 Prestador de Serviço" },
                new() { Key = "representante", Label = "Representante Legal", Section = "💼 Prestador de Serviço" },
                new() { Key = "emailEscritorio", Label = "E-mail", Section = "💼 Prestador de Serviço" },
                // Cliente
                new() { Key = "nomeCliente", Label = "Nome completo do Cliente", Section = "👤 Cliente" },
                new() { Key = "cpfCliente", Label = "CPF", Section = "👤 Cliente" },
                new() { Key = "emailCliente", Label = "E-mail", Section = "👤 Cliente" },
                // Dados da Nova Empresa
                new() { Key = "nomeEmpresarial", Label = "Nome Empresarial Pretendido", Section = "📋 Dados da Nova Empresa" },
                new() { Key = "tipoSocietario", Label = "Tipo Societário (MEI / LTDA / SA / EIRELI)", Section = "📋 Dados da Nova Empresa" },
                new() { Key = "atividadePrincipal", Label = "Atividade Principal (CNAE)", Section = "📋 Dados da Nova Empresa" },
                new() { Key = "atividadesSecundarias", Label = "Atividades Secundárias", IsTextArea = true, Section = "📋 Dados da Nova Empresa" },
                new() { Key = "capitalSocial", Label = "Capital Social (R$)", Section = "📋 Dados da Nova Empresa" },
                new() { Key = "enderecoSede", Label = "Endereço da Sede", Section = "📋 Dados da Nova Empresa" },
                new() { Key = "socios", Label = "Sócios (Nome, CPF, % participação)", IsTextArea = true, Section = "📋 Dados da Nova Empresa" },
                // Honorários
                new() { Key = "valorServico", Label = "Valor do Serviço (R$)", Section = "💰 Honorários" },
                new() { Key = "valorExtenso", Label = "Valor por Extenso", Section = "💰 Honorários" },
                new() { Key = "formaPagamento", Label = "Forma de Pagamento", Section = "💰 Honorários" },
                new() { Key = "prazoEstimado", Label = "Prazo Estimado para Conclusão", Section = "💰 Honorários" },
                // Foro
                new() { Key = "cidade", Label = "Cidade/UF", Section = S6 },
                new() { Key = "foro", Label = "Foro (Comarca)", Section = S6 },
                // Testemunhas
                new() { Key = "testemunha1", Label = "Testemunha 1 (Nome)", Section = S7 },
                new() { Key = "cpfTest1", Label = "CPF da Testemunha 1", Section = S7 },
                new() { Key = "testemunha2", Label = "Testemunha 2 (Nome)", Section = S7 },
                new() { Key = "cpfTest2", Label = "CPF da Testemunha 2", Section = S7 },
            }
        }
    };

    // ═══════════════════════════════════════════════════════════════════════
    //  HTML GENERATION (identical contract templates as before)
    // ═══════════════════════════════════════════════════════════════════════

    public string GenerateHtml(ContractType type, Dictionary<string, string> data)
    {
        var dateStr = DateTime.Now.ToString("dd 'de' MMMM 'de' yyyy",
            new System.Globalization.CultureInfo("pt-BR"));

        string F(string key) =>
            data.TryGetValue(key, out var val) && !string.IsNullOrWhiteSpace(val)
                ? $"<span class=\"field\">{System.Net.WebUtility.HtmlEncode(val)}</span>"
                : "<span class=\"field\">_______________</span>";

        string R(string key) =>
            data.TryGetValue(key, out var val) ? System.Net.WebUtility.HtmlEncode(val ?? "") : "";

        var body = type.Id switch
        {
            "prestacao" => GenPrestacao(F, R, dateStr),
            "freelancer" => GenFreelancer(F, R, dateStr),
            "locacao" => GenLocacao(F, R, dateStr),
            "nda" => GenNda(F, R, dateStr),
            "dev-software" => GenDevSoftware(F, R, dateStr),
            "suporte-ti" => GenSuporteTI(F, R, dateStr),
            "saas" => GenSaas(F, R, dateStr),
            "lgpd" => GenLgpd(F, R, dateStr),
            "honorarios" => GenHonorarios(F, R, dateStr),
            "parceria" => GenParceria(F, R, dateStr),
            "distrato" => GenDistrato(F, R, dateStr),
            "cessao-direitos" => GenCessaoDireitos(F, R, dateStr),
            "consulta-saude" => GenConsultaSaude(F, R, dateStr),
            "consentimento" => GenConsentimento(F, R, dateStr),
            "clinica-parceria" => GenClinicaParceria(F, R, dateStr),
            "contabilidade" => GenContabilidade(F, R, dateStr),
            "consultoria-fiscal" => GenConsultoriaFiscal(F, R, dateStr),
            "abertura-empresa" => GenAberturaEmpresa(F, R, dateStr),
            _ => "<p>Modelo não encontrado.</p>"
        };

        return $@"<!DOCTYPE html>
<html><head><meta charset=""UTF-8"">
<style>
  @import url('https://fonts.googleapis.com/css2?family=Merriweather:wght@400;700&family=Source+Sans+3:wght@400;600&display=swap');
  * {{ margin: 0; padding: 0; box-sizing: border-box; }}
  body {{ font-family: 'Source Sans 3', sans-serif; color: #1a1a1a; line-height: 1.9; padding: 56px 64px; max-width: 820px; margin: 0 auto; font-size: 13.5px; }}
  .header {{ text-align: center; border-bottom: 3px double #222; padding-bottom: 20px; margin-bottom: 32px; }}
  .header h1 {{ font-family: 'Merriweather', serif; font-size: 19px; font-weight: 700; text-transform: uppercase; letter-spacing: 3px; margin-bottom: 4px; }}
  .header .subtitle {{ font-size: 12px; color: #555; letter-spacing: 1.5px; text-transform: uppercase; }}
  .preambulo {{ margin-bottom: 24px; font-style: italic; text-align: justify; color: #333; }}
  .cl {{ margin-bottom: 20px; }}
  .cl-t {{ font-family: 'Merriweather', serif; font-weight: 700; font-size: 12.5px; margin-bottom: 8px; text-transform: uppercase; letter-spacing: 1.2px; color: #111; }}
  .cl p {{ text-align: justify; margin-bottom: 5px; }}
  p.s {{ padding-left: 20px; }}
  p.ss {{ padding-left: 36px; font-size: 13px; }}
  .sigs {{ margin-top: 70px; display: flex; justify-content: space-between; gap: 50px; }}
  .sig {{ flex: 1; text-align: center; padding-top: 6px; border-top: 1px solid #222; }}
  .sig .n {{ font-weight: 700; font-size: 12px; margin-top: 3px; }}
  .sig .d {{ font-size: 11px; color: #444; }}
  .wits {{ margin-top: 44px; display: flex; justify-content: space-between; gap: 50px; }}
  .wit {{ flex: 1; text-align: center; padding-top: 6px; border-top: 1px solid #888; }}
  .wit .n {{ font-weight: 600; font-size: 11px; margin-top: 3px; color: #333; }}
  .wit .d {{ font-size: 10px; color: #666; }}
  .footer {{ margin-top: 36px; text-align: center; font-size: 10.5px; color: #999; border-top: 1px solid #ddd; padding-top: 14px; line-height: 1.5; }}
  .field {{ font-weight: 700; }}
  .wm {{ position: fixed; top: 50%; left: 50%; transform: translate(-50%, -50%) rotate(-30deg); font-size: 72px; color: rgba(0,0,0,0.025); font-family: 'Merriweather', serif; pointer-events: none; z-index: -1; }}
</style>
</head><body>
<div class=""wm"">CONTRATO</div>
{body}
<div class=""footer"">Documento gerado eletronicamente por ContratoExpress.<br/>Este modelo é meramente referencial e não substitui a orientação de advogado habilitado.</div>
</body></html>";
    }

    private string Wit(Func<string, string> R) => $@"
<div class=""wits"">
<div class=""wit""><div class=""n"">{(string.IsNullOrWhiteSpace(R("testemunha1")) ? "Testemunha 1" : R("testemunha1"))}</div><div class=""d"">CPF: {R("cpfTest1")}</div></div>
<div class=""wit""><div class=""n"">{(string.IsNullOrWhiteSpace(R("testemunha2")) ? "Testemunha 2" : R("testemunha2"))}</div><div class=""d"">CPF: {R("cpfTest2")}</div></div>
</div>";

    private string Fecho(Func<string, string> F, string date) => $@"
<p style=""margin-top:28px; text-align:justify; font-size:13px;"">E por estarem assim justas e contratadas, as partes declaram ter lido e compreendido integralmente todas as cláusulas e condições deste instrumento, firmando-o em 2 (duas) vias de igual teor e forma, juntamente com as testemunhas abaixo identificadas, para que produza seus jurídicos e legais efeitos.</p>
<p style=""margin-top:14px; text-align:center; font-size:13px;"">{F("cidade")}, {date}.</p>";

    // Templates are identical to previous version - keeping them inline for single-file simplicity
    private string GenPrestacao(Func<string, string> F, Func<string, string> R, string d) => $@"
<div class=""header""><h1>Contrato de Prestação de Serviços</h1><div class=""subtitle"">Instrumento Particular firmado nos termos dos arts. 593 a 609 do Código Civil</div></div>
<p class=""preambulo"">Pelo presente instrumento particular e na melhor forma de direito, as partes a seguir qualificadas resolvem celebrar o presente Contrato de Prestação de Serviços, que se regerá pelas cláusulas e condições adiante estipuladas, bem como pelas disposições legais aplicáveis, em especial os artigos 593 a 609 da Lei nº 10.406/2002 (Código Civil Brasileiro).</p>
<div class=""cl""><div class=""cl-t"">Cláusula 1ª — Da Qualificação das Partes</div>
<p><strong>1.1. CONTRATANTE:</strong> {F("contratante")}, nacionalidade {F("nacionalidadeContratante")}, estado civil {F("estadoCivilContratante")}, profissão {F("profissaoContratante")}, portador(a) da cédula de identidade RG nº {F("rgContratante")}, inscrito(a) no CPF/CNPJ sob o nº {F("cpfContratante")}, residente e domiciliado(a) no endereço {F("endContratante")}, endereço eletrônico {F("emailContratante")}, doravante denominado(a) simplesmente <strong>CONTRATANTE</strong>.</p>
<p><strong>1.2. CONTRATADO(A):</strong> {F("contratado")}, nacionalidade {F("nacionalidadeContratado")}, estado civil {F("estadoCivilContratado")}, profissão {F("profissaoContratado")}, portador(a) da cédula de identidade RG nº {F("rgContratado")}, inscrito(a) no CPF/CNPJ sob o nº {F("cpfContratado")}, residente e domiciliado(a) no endereço {F("endContratado")}, endereço eletrônico {F("emailContratado")}, doravante denominado(a) simplesmente <strong>CONTRATADO(A)</strong>.</p></div>
<div class=""cl""><div class=""cl-t"">Cláusula 2ª — Do Objeto</div>
<p><strong>2.1.</strong> O presente contrato tem por objeto a prestação, pelo(a) CONTRATADO(A) ao(à) CONTRATANTE, dos seguintes serviços especializados: {F("servico")}.</p>
<p><strong>2.2.</strong> Os serviços serão executados em: {F("localExecucao")}.</p>
<p><strong>2.3.</strong> Quaisquer serviços adicionais não previstos neste instrumento deverão ser objeto de Termo Aditivo específico.</p></div>
<div class=""cl""><div class=""cl-t"">Cláusula 3ª — Do Prazo</div>
<p><strong>3.1.</strong> O prazo para execução é de {F("prazo")}, com início em {F("dataInicio")}.</p>
<p><strong>3.2.</strong> Eventuais atrasos por caso fortuito ou força maior (art. 393 CC) não serão imputados ao CONTRATADO(A), desde que comunicados em 48h.</p></div>
<div class=""cl""><div class=""cl-t"">Cláusula 4ª — Do Preço e Pagamento</div>
<p><strong>4.1.</strong> Valor total: R$ {F("valor")} ({F("valorExtenso")}). Condições: {F("formaPagamento")}.</p>
<p><strong>4.2.</strong> Atraso acarretará multa de {F("multaAtraso")}, juros de {F("jurosAtraso")} ao mês pro rata die, e correção pelo IPCA/IBGE.</p></div>
<div class=""cl""><div class=""cl-t"">Cláusula 5ª — Das Obrigações do Contratado</div>
<p>O CONTRATADO(A) obriga-se a: a) executar com zelo e diligência; b) cumprir prazos; c) manter sigilo; d) comunicar impedimentos em 5 dias úteis; e) responsabilizar-se por danos (arts. 186/927 CC); f) arcar com despesas de execução; g) fornecer relatórios quando solicitado.</p></div>
<div class=""cl""><div class=""cl-t"">Cláusula 6ª — Das Obrigações do Contratante</div>
<p>O CONTRATANTE obriga-se a: a) pagar nos prazos; b) fornecer informações e materiais; c) comunicar alterações de escopo; d) designar ponto de contato; e) aprovar entregas em 5 dias úteis (aceite tácito).</p></div>
<div class=""cl""><div class=""cl-t"">Cláusula 7ª — Da Inexistência de Vínculo</div>
<p>Contrato de natureza civil (arts. 593+ CC). Sem vínculo empregatício. CONTRATADO(A) responsável por tributos e encargos.</p></div>
<div class=""cl""><div class=""cl-t"">Cláusula 8ª — Da Propriedade Intelectual</div>
<p>Criações são propriedade do CONTRATANTE após pagamento integral (Leis 9.610/98 e 9.279/96). Cessão irrevogável e universal.</p></div>
<div class=""cl""><div class=""cl-t"">Cláusula 9ª — Da Confidencialidade</div>
<p>Sigilo por 2 anos após término. Violação sujeita a perdas e danos e sanções penais (arts. 153/154/325 CP, art. 195 Lei 9.279/96).</p></div>
<div class=""cl""><div class=""cl-t"">Cláusula 10ª — Da Rescisão</div>
<p>Rescisão por: a) mútuo acordo; b) unilateral com 15 dias de aviso; c) inadimplemento não sanado em 10 dias; d) falência/recuperação judicial. Multa de {F("multaRescisao")} (arts. 408-416 CC).</p></div>
<div class=""cl""><div class=""cl-t"">Cláusula 11ª — Força Maior</div><p>Art. 393 CC. Notificação em 48h com documentação.</p></div>
<div class=""cl""><div class=""cl-t"">Cláusula 12ª — Responsabilidade Civil</div><p>Arts. 186/187/927 CC. Limitada ao valor pago, exceto dolo/fraude.</p></div>
<div class=""cl""><div class=""cl-t"">Cláusula 13ª — Proteção de Dados</div><p>LGPD (Lei 13.709/2018). Medidas técnicas adequadas.</p></div>
<div class=""cl""><div class=""cl-t"">Cláusula 14ª — Comunicações</div><p>Por escrito aos endereços das partes. Recebimento em 3 dias úteis.</p></div>
<div class=""cl""><div class=""cl-t"">Cláusula 15ª — Disposições Gerais</div><p>Vincula herdeiros e sucessores. Tolerância não implica novação. Alterações por Termo Aditivo. Nulidade parcial não afeta demais cláusulas.</p></div>
<div class=""cl""><div class=""cl-t"">Cláusula 16ª — Do Foro</div><p>Comarca de {F("foro")} (art. 63 CPC).</p></div>
{Fecho(F, d)}
<div class=""sigs""><div class=""sig""><div class=""n"">{R("contratante")}</div><div class=""d"">CPF/CNPJ: {R("cpfContratante")}</div></div><div class=""sig""><div class=""n"">{R("contratado")}</div><div class=""d"">CPF/CNPJ: {R("cpfContratado")}</div></div></div>
{Wit(R)}";

    private string GenFreelancer(Func<string, string> F, Func<string, string> R, string d) => $@"
<div class=""header""><h1>Contrato de Prestação de Serviços — PJ / Freelancer</h1><div class=""subtitle"">Instrumento Particular nos termos dos arts. 593 a 609 do Código Civil</div></div>
<p class=""preambulo"">Pelo presente instrumento particular e na melhor forma de direito, as partes celebram este Contrato de Prestação de Serviços Autônomos.</p>
<div class=""cl""><div class=""cl-t"">Cláusula 1ª — Das Partes</div>
<p><strong>1.1. CONTRATANTE:</strong> {F("empresa")}, CNPJ {F("cnpjEmpresa")}, IE {F("ieEmpresa")}, sede em {F("endEmpresa")}, representada por {F("representante")}, {F("cargoRepresentante")}, CPF {F("cpfRepresentante")}, e-mail {F("emailEmpresa")}.</p>
<p><strong>1.2. CONTRATADO(A):</strong> {F("freelancer")}, CPF/CNPJ {F("cpfCnpjFreelancer")}, endereço {F("endFreelancer")}, e-mail {F("emailFreelancer")}.</p></div>
<div class=""cl""><div class=""cl-t"">Cláusula 2ª — Do Escopo</div><p><strong>2.1.</strong> Serviços: {F("escopo")}. <strong>2.2.</strong> Ferramentas: {F("ferramentas")}. <strong>2.3.</strong> Alterações de escopo dependem de Termo Aditivo.</p></div>
<div class=""cl""><div class=""cl-t"">Cláusula 3ª — Entregáveis e Aceite</div><p><strong>3.1.</strong> Entregáveis: {F("entregaveis")}. <strong>3.2.</strong> Aceite em 5 dias úteis (tácito). <strong>3.3.</strong> {F("revisoesInclusas")} revisão(ões) inclusa(s). <strong>3.4.</strong> Revisão extra: R$ {F("valorRevisaoExtra")}.</p></div>
<div class=""cl""><div class=""cl-t"">Cláusula 4ª — Prazo</div><p>{F("prazo")}, início em {F("dataInicio")}. Prorrogação automática por atraso do CONTRATANTE.</p></div>
<div class=""cl""><div class=""cl-t"">Cláusula 5ª — Valor e Pagamento</div><p>R$ {F("valorProjeto")} ({F("valorExtenso")}). Condições: {F("formaPagamento")}. NF/RPA obrigatório. Atraso: multa 2% + juros 1%/mês. Atraso &gt;30 dias: suspensão dos serviços.</p></div>
<div class=""cl""><div class=""cl-t"">Cláusula 6ª — Propriedade Intelectual</div><p>Propriedade do CONTRATANTE após pagamento integral (Leis 9.610/98, 9.279/96). Sem pagamento: retenção pelo CONTRATADO(A). Portfólio permitido sem dados confidenciais.</p></div>
<div class=""cl""><div class=""cl-t"">Cláusula 7ª — Inexistência de Vínculo</div><p>Natureza civil. Sem vínculo empregatício. Autonomia técnica e administrativa.</p></div>
<div class=""cl""><div class=""cl-t"">Cláusula 8ª — Subcontratação</div><p>Vedada sem autorização escrita. CONTRATADO(A) permanece responsável.</p></div>
<div class=""cl""><div class=""cl-t"">Cláusula 9ª — Confidencialidade</div><p>Sigilo por {F("prazoSigilo")} meses após término. Violação: perdas e danos + sanções penais.</p></div>
<div class=""cl""><div class=""cl-t"">Cláusula 10ª — Não Concorrência</div><p>Permitido atender outros clientes, sem concorrência direta.</p></div>
<div class=""cl""><div class=""cl-t"">Cláusula 11ª — Garantia</div><p>30 dias para correção de defeitos. Responsabilidade limitada ao valor pago.</p></div>
<div class=""cl""><div class=""cl-t"">Cláusula 12ª — Rescisão</div><p>Mútuo acordo, unilateral com 15 dias, ou inadimplemento. Multa: {F("multaRescisao")} (arts. 408-416 CC).</p></div>
<div class=""cl""><div class=""cl-t"">Cláusula 13ª — Força Maior</div><p>Art. 393 CC.</p></div>
<div class=""cl""><div class=""cl-t"">Cláusula 14ª — LGPD</div><p>Lei 13.709/2018.</p></div>
<div class=""cl""><div class=""cl-t"">Cláusula 15ª — Comunicações</div><p>Por escrito. Recebimento presumido em 3 dias úteis.</p></div>
<div class=""cl""><div class=""cl-t"">Cláusula 16ª — Disposições Gerais</div><p>Vincula herdeiros. Tolerância ≠ novação. Alterações por aditivo. Nulidade parcial preserva demais.</p></div>
<div class=""cl""><div class=""cl-t"">Cláusula 17ª — Foro</div><p>Comarca de {F("foro")} (art. 63 CPC).</p></div>
{Fecho(F, d)}
<div class=""sigs""><div class=""sig""><div class=""n"">{R("empresa")}</div><div class=""d"">CNPJ: {R("cnpjEmpresa")}</div></div><div class=""sig""><div class=""n"">{R("freelancer")}</div><div class=""d"">CPF/CNPJ: {R("cpfCnpjFreelancer")}</div></div></div>
{Wit(R)}";

    private string GenLocacao(Func<string, string> F, Func<string, string> R, string d) => $@"
<div class=""header""><h1>Contrato de Locação de Imóvel</h1><div class=""subtitle"">Instrumento Particular — Lei nº 8.245/91 e Código Civil</div></div>
<p class=""preambulo"">Pelo presente instrumento particular de locação, as partes celebram este contrato regido pela Lei nº 8.245/91 (Lei do Inquilinato) e subsidiariamente pelo Código Civil.</p>
<div class=""cl""><div class=""cl-t"">Cláusula 1ª — Das Partes</div>
<p><strong>1.1. LOCADOR(A):</strong> {F("locador")}, {F("nacionalidadeLocador")}, {F("estadoCivilLocador")}, {F("profissaoLocador")}, RG {F("rgLocador")}, CPF/CNPJ {F("cpfLocador")}, endereço {F("endLocador")}.</p>
<p><strong>1.2. LOCATÁRIO(A):</strong> {F("locatario")}, {F("nacionalidadeLocatario")}, {F("estadoCivilLocatario")}, {F("profissaoLocatario")}, RG {F("rgLocatario")}, CPF/CNPJ {F("cpfLocatario")}.</p></div>
<div class=""cl""><div class=""cl-t"">Cláusula 2ª — Do Imóvel</div><p>Endereço: {F("endImovel")}. Matrícula: {F("matricula")}. Descrição: {F("descImovel")}. Imóvel livre de ônus.</p></div>
<div class=""cl""><div class=""cl-t"">Cláusula 3ª — Destinação</div><p>Exclusivamente para {F("finalidade")}. Vedada mudança sem autorização.</p></div>
<div class=""cl""><div class=""cl-t"">Cláusula 4ª — Prazo</div><p>{F("vigencia")} meses, início em {F("dataInicio")}. Prorrogação automática por prazo indeterminado sem manifestação em 30 dias.</p></div>
<div class=""cl""><div class=""cl-t"">Cláusula 5ª — Aluguel</div><p>R$ {F("aluguel")} ({F("aluguelExtenso")}), vencimento dia {F("vencimento")}. Pagamento via {F("contaBancaria")}. Atraso: multa {F("multaAtraso")} + juros {F("jurosAtraso")}/mês + correção {F("indiceReajuste")}. Atraso &gt;60 dias: ação de despejo (arts. 9/62 Lei 8.245/91).</p></div>
<div class=""cl""><div class=""cl-t"">Cláusula 6ª — Reajuste</div><p>Anual pelo {F("indiceReajuste")} acumulado 12 meses.</p></div>
<div class=""cl""><div class=""cl-t"">Cláusula 7ª — Garantia</div><p>Tipo: {F("tipoGarantia")} (art. 37 Lei 8.245/91). Detalhes: {F("garantiaDetalhe")}. Manutenção obrigatória durante vigência.</p></div>
<div class=""cl""><div class=""cl-t"">Cláusula 8ª — Encargos</div><p>LOCATÁRIO: condomínio ordinário, água, luz, gás, telecomunicações. LOCADOR: IPTU, condomínio extraordinário, manutenção estrutural.</p></div>
<div class=""cl""><div class=""cl-t"">Cláusula 9ª — Obrigações do Locatário</div><p>Art. 23 Lei 8.245/91: a) pagar pontualmente; b) uso adequado; c) manutenção ordinária; d) restituir no estado recebido; e) não modificar sem autorização; f) não sublocar; g) permitir vistoria (48h); h) comunicar danos; i) repassar notificações.</p></div>
<div class=""cl""><div class=""cl-t"">Cláusula 10ª — Obrigações do Locador</div><p>Art. 22 Lei 8.245/91: a) entregar em condições; b) garantir uso pacífico; c) manter forma/destino; d) responder por vícios; e) fornecer recibos; f) manutenção estrutural.</p></div>
<div class=""cl""><div class=""cl-t"">Cláusula 11ª — Vistoria</div><p>Laudo descritivo e fotográfico na entrega e devolução. Sem laudo: presume-se perfeito estado.</p></div>
<div class=""cl""><div class=""cl-t"">Cláusula 12ª — Benfeitorias</div><p>Art. 35 Lei 8.245/91. Necessárias: indenizáveis com retenção. Úteis: se autorizadas. Voluptuárias: não indenizáveis, retiráveis sem dano.</p></div>
<div class=""cl""><div class=""cl-t"">Cláusula 13ª — Seguro</div><p>Obrigatório contra incêndio. Apólice em 30 dias.</p></div>
<div class=""cl""><div class=""cl-t"">Cláusula 14ª — Rescisão</div><p>Pelo LOCATÁRIO: multa de {F("multaRescisao")} aluguel(éis), proporcional ao cumprido (art. 4º Lei 8.245/91). Pelo LOCADOR: apenas hipóteses legais (arts. 9/47). Prazo indeterminado: 30 dias sem multa.</p></div>
<div class=""cl""><div class=""cl-t"">Cláusula 15ª — Devolução</div><p>Perfeitas condições, limpo, com chaves. Danos descontados da garantia.</p></div>
<div class=""cl""><div class=""cl-t"">Cláusula 16ª — LGPD</div><p>Lei 13.709/2018.</p></div>
<div class=""cl""><div class=""cl-t"">Cláusula 17ª — Disposições Gerais</div><p>Vincula herdeiros. Tolerância ≠ novação. Subsidiariamente: Lei 8.245/91 e CC.</p></div>
<div class=""cl""><div class=""cl-t"">Cláusula 18ª — Foro</div><p>Comarca de {F("foro")} (art. 63 CPC).</p></div>
{Fecho(F, d)}
<div class=""sigs""><div class=""sig""><div class=""n"">{R("locador")}</div><div class=""d"">CPF/CNPJ: {R("cpfLocador")}</div></div><div class=""sig""><div class=""n"">{R("locatario")}</div><div class=""d"">CPF/CNPJ: {R("cpfLocatario")}</div></div></div>
{Wit(R)}";

    private string GenNda(Func<string, string> F, Func<string, string> R, string d) => $@"
<div class=""header""><h1>Acordo de Confidencialidade e Sigilo</h1><div class=""subtitle"">NDA — Non-Disclosure Agreement</div></div>
<p class=""preambulo"">Pelo presente instrumento particular, as partes celebram este Acordo de Confidencialidade, regido pelo Código Civil, Lei 9.279/96, Lei 9.610/98 e LGPD (Lei 13.709/2018).</p>
<div class=""cl""><div class=""cl-t"">Cláusula 1ª — Das Partes</div>
<p><strong>1.1. PARTE REVELADORA:</strong> {F("parteA")}, CPF/CNPJ {F("cpfCnpjA")}, representada por {F("representanteA")}, endereço {F("endA")}, e-mail {F("emailA")}.</p>
<p><strong>1.2. PARTE RECEPTORA:</strong> {F("parteB")}, CPF/CNPJ {F("cpfCnpjB")}, representada por {F("representanteB")}, endereço {F("endB")}, e-mail {F("emailB")}.</p>
<p><strong>1.3.</strong> Natureza: {F("bilateral")}.</p></div>
<div class=""cl""><div class=""cl-t"">Cláusula 2ª — Objetivo</div><p>Proteção de informações no contexto de: {F("objetivo")}.</p></div>
<div class=""cl""><div class=""cl-t"">Cláusula 3ª — Informações Confidenciais</div><p>Incluem: {F("infoConfidencial")}. Também: dados técnicos, listas de clientes, códigos-fonte, algoritmos, know-how, planos de negócio, dados financeiros, e informações marcadas como confidenciais.</p></div>
<div class=""cl""><div class=""cl-t"">Cláusula 4ª — Obrigações da Parte Receptora</div><p>a) Sigilo absoluto; b) não divulgar sem autorização escrita; c) uso exclusivo para a finalidade; d) proteção com grau razoável de cuidado; e) acesso restrito a quem precisa; f) registro de acessos; g) notificação imediata de vazamentos; h) devolução/destruição em 10 dias úteis.</p></div>
<div class=""cl""><div class=""cl-t"">Cláusula 5ª — Exclusões</div><p>a) Domínio público; b) conhecimento prévio documentado; c) recebidas de terceiros sem restrição; d) desenvolvimento independente; e) determinação judicial (com notificação prévia). {(string.IsNullOrWhiteSpace(R("exclusoes")) ? "" : $"Exclusões adicionais: {F("exclusoes")}.")}</p></div>
<div class=""cl""><div class=""cl-t"">Cláusula 6ª — Propriedade</div><p>Informações permanecem da Parte Reveladora. Sem cessão de direitos.</p></div>
<div class=""cl""><div class=""cl-t"">Cláusula 7ª — Vigência</div><p>{F("vigencia")} ano(s). Sobrevivência: {F("sobrevivencia")} ano(s) adicionais.</p></div>
<div class=""cl""><div class=""cl-t"">Cláusula 8ª — Penalidades</div><p>Multa: R$ {F("penalidade")} ({F("penalidadeExtenso")}). Cumulável com perdas e danos (arts. 408-416 CC). Tutela de urgência autorizada.</p></div>
<div class=""cl""><div class=""cl-t"">Cláusula 9ª — Não Obrigatoriedade</div><p>Divulgação é voluntária.</p></div>
<div class=""cl""><div class=""cl-t"">Cláusula 10ª — Ausência de Vínculo</div><p>Não gera obrigação comercial ou societária.</p></div>
<div class=""cl""><div class=""cl-t"">Cláusula 11ª — Cessão</div><p>Vedada sem consentimento escrito.</p></div>
<div class=""cl""><div class=""cl-t"">Cláusula 12ª — Tutela Judicial</div><p>Danos irreparáveis autorizam medidas de urgência.</p></div>
<div class=""cl""><div class=""cl-t"">Cláusula 13ª — Legislação</div><p>{F("jurisdicao")}. CC, Lei 9.279/96, Lei 9.610/98, LGPD.</p></div>
<div class=""cl""><div class=""cl-t"">Cláusula 14ª — LGPD</div><p>Lei 13.709/2018. Medidas técnicas adequadas.</p></div>
<div class=""cl""><div class=""cl-t"">Cláusula 15ª — Disposições Gerais</div><p>Entendimento integral. Nulidade parcial preserva demais. Tolerância ≠ novação. Alterações por aditivo.</p></div>
<div class=""cl""><div class=""cl-t"">Cláusula 16ª — Foro</div><p>Comarca de {F("foro")} (art. 63 CPC).</p></div>
{Fecho(F, d)}
<div class=""sigs""><div class=""sig""><div class=""n"">{R("parteA")}</div><div class=""d"">CPF/CNPJ: {R("cpfCnpjA")}</div></div><div class=""sig""><div class=""n"">{R("parteB")}</div><div class=""d"">CPF/CNPJ: {R("cpfCnpjB")}</div></div></div>
{Wit(R)}";

    // ═══════════════════════════════════════════════════════════════════════
    //  TI CATEGORY TEMPLATES
    // ═══════════════════════════════════════════════════════════════════════

    private string GenDevSoftware(Func<string, string> F, Func<string, string> R, string d) => $@"
<div class=""header""><h1>Contrato de Desenvolvimento de Software</h1><div class=""subtitle"">Instrumento Particular nos termos dos arts. 593 a 609 do Código Civil e Lei 9.609/98</div></div>
<p class=""preambulo"">Pelo presente instrumento particular e na melhor forma de direito, as partes a seguir qualificadas resolvem celebrar o presente Contrato de Desenvolvimento de Software, que se regerá pelas cláusulas e condições adiante estipuladas, em conformidade com a Lei nº 9.609/98 (Lei de Software), Lei nº 9.610/98 (Direitos Autorais), o Marco Civil da Internet (Lei nº 12.965/2014) e subsidiariamente pelo Código Civil Brasileiro.</p>
<div class=""cl""><div class=""cl-t"">Cláusula 1ª — Das Partes</div>
<p><strong>1.1. CONTRATANTE:</strong> {F("empresa")}, CNPJ {F("cnpj")}, representada por {F("representante")}, com sede em {F("endEmpresa")}, e-mail {F("emailEmpresa")}, doravante denominada simplesmente <strong>CONTRATANTE</strong>.</p>
<p><strong>1.2. DESENVOLVEDORA:</strong> {F("devNome")}, CPF/CNPJ {F("cpfDev")}, com endereço em {F("endDev")}, e-mail {F("emailDev")}, doravante denominada simplesmente <strong>DESENVOLVEDORA</strong>.</p></div>
<div class=""cl""><div class=""cl-t"">Cláusula 2ª — Do Objeto</div>
<p><strong>2.1.</strong> O presente contrato tem por objeto o desenvolvimento do seguinte sistema/aplicação: {F("escopo")}.</p>
<p><strong>2.2.</strong> Tecnologias a serem utilizadas: {F("tecnologias")}.</p>
<p><strong>2.3.</strong> Metodologia de desenvolvimento: {F("metodologia")}.</p>
<p><strong>2.4.</strong> Quaisquer alterações de escopo deverão ser formalizadas por Termo Aditivo, com renegociação de prazo e valor.</p></div>
<div class=""cl""><div class=""cl-t"">Cláusula 3ª — Do Cronograma</div>
<p><strong>3.1.</strong> O projeto será executado em {F("sprints")} sprint(s), com início em {F("dataInicio")} e prazo total de {F("prazoTotal")}.</p>
<p><strong>3.2.</strong> Ao final de cada sprint, será realizada apresentação dos entregáveis para validação da CONTRATANTE, que terá 5 (cinco) dias úteis para aprovação ou solicitação de ajustes.</p>
<p><strong>3.3.</strong> Ambiente de homologação: {F("ambienteHomologacao")}.</p></div>
<div class=""cl""><div class=""cl-t"">Cláusula 4ª — Do SLA e Suporte Pós-Entrega</div>
<p><strong>4.1.</strong> Durante o desenvolvimento, o tempo de resposta para correção de bugs críticos será de {F("sla")}.</p>
<p><strong>4.2.</strong> Após a entrega final, a DESENVOLVEDORA garantirá suporte para correção de bugs pelo período de {F("garantiaBugs")} meses, sem custo adicional.</p>
<p><strong>4.3.</strong> Bugs são definidos como comportamentos divergentes das especificações aprovadas. Novas funcionalidades não se enquadram como bug.</p></div>
<div class=""cl""><div class=""cl-t"">Cláusula 5ª — Do Valor e Pagamento</div>
<p><strong>5.1.</strong> Valor total do projeto: R$ {F("valorProjeto")} ({F("valorExtenso")}).</p>
<p><strong>5.2.</strong> Condições de pagamento: {F("formaPagamento")}.</p>
<p><strong>5.3.</strong> Atraso no pagamento acarretará multa de 2% sobre o valor devido, acrescida de juros de 1% ao mês pro rata die e correção monetária pelo IPCA/IBGE.</p>
<p><strong>5.4.</strong> Atraso superior a 30 (trinta) dias autoriza a suspensão dos trabalhos pela DESENVOLVEDORA, sem prejuízo das demais penalidades.</p></div>
<div class=""cl""><div class=""cl-t"">Cláusula 6ª — Da Propriedade Intelectual</div>
<p><strong>6.1.</strong> A propriedade do código-fonte será: {F("propriedadeIP")}.</p>
<p><strong>6.2.</strong> Licenciamento dos fontes: {F("licencaFontes")}.</p>
<p><strong>6.3.</strong> Bibliotecas de terceiros (open source) seguirão suas respectivas licenças, cabendo à DESENVOLVEDORA informar todas as dependências utilizadas.</p>
<p><strong>6.4.</strong> A transferência de propriedade intelectual, quando aplicável, ocorrerá somente após o pagamento integral, nos termos das Leis 9.609/98 e 9.610/98.</p></div>
<div class=""cl""><div class=""cl-t"">Cláusula 7ª — Da Confidencialidade</div>
<p>Ambas as partes comprometem-se a manter sigilo absoluto sobre informações técnicas, comerciais e estratégicas trocadas durante a vigência deste contrato, pelo prazo de 2 (dois) anos após o término. Violação sujeita a perdas e danos (arts. 186/927 CC) e sanções penais aplicáveis.</p></div>
<div class=""cl""><div class=""cl-t"">Cláusula 8ª — Da Inexistência de Vínculo</div>
<p>O presente contrato tem natureza exclusivamente civil (arts. 593 a 609 CC), não gerando vínculo empregatício, societário ou de agência entre as partes. A DESENVOLVEDORA possui total autonomia técnica e administrativa.</p></div>
<div class=""cl""><div class=""cl-t"">Cláusula 9ª — Da Subcontratação</div>
<p>A subcontratação de terceiros pela DESENVOLVEDORA depende de autorização prévia e escrita da CONTRATANTE. Em qualquer hipótese, a DESENVOLVEDORA permanece integralmente responsável pela qualidade e prazo dos entregáveis.</p></div>
<div class=""cl""><div class=""cl-t"">Cláusula 10ª — Da Rescisão</div>
<p>Rescisão por: a) mútuo acordo escrito; b) unilateral com 30 dias de aviso prévio; c) inadimplemento não sanado em 15 dias após notificação; d) falência ou recuperação judicial de qualquer das partes. Em caso de rescisão, serão devidos os valores proporcionais aos serviços efetivamente entregues e aceitos.</p></div>
<div class=""cl""><div class=""cl-t"">Cláusula 11ª — Da Força Maior</div>
<p>Eventos de força maior ou caso fortuito (art. 393 CC) suspenderão as obrigações pelo período de sua duração, devendo a parte afetada notificar a outra em 48 horas, com documentação comprobatória.</p></div>
<div class=""cl""><div class=""cl-t"">Cláusula 12ª — Da Proteção de Dados</div>
<p>As partes comprometem-se a observar a Lei Geral de Proteção de Dados (Lei 13.709/2018), adotando medidas técnicas e administrativas adequadas para proteção de dados pessoais eventualmente tratados durante o desenvolvimento.</p></div>
<div class=""cl""><div class=""cl-t"">Cláusula 13ª — Das Comunicações</div>
<p>Todas as comunicações entre as partes deverão ser realizadas por escrito, preferencialmente por e-mail, aos endereços informados neste instrumento, presumindo-se recebidas em até 3 (três) dias úteis.</p></div>
<div class=""cl""><div class=""cl-t"">Cláusula 14ª — Das Disposições Gerais</div>
<p>Este contrato vincula herdeiros e sucessores. Tolerância não implica novação ou renúncia. Alterações somente por Termo Aditivo escrito. Nulidade de cláusula individual não prejudica as demais. Este instrumento constitui o entendimento integral entre as partes sobre o objeto contratado.</p></div>
<div class=""cl""><div class=""cl-t"">Cláusula 15ª — Do Foro</div>
<p>Fica eleito o foro da Comarca de {F("foro")}, com exclusão de qualquer outro, por mais privilegiado que seja, para dirimir quaisquer litígios oriundos deste contrato (art. 63 CPC).</p></div>
{Fecho(F, d)}
<div class=""sigs""><div class=""sig""><div class=""n"">{R("empresa")}</div><div class=""d"">CNPJ: {R("cnpj")}</div></div><div class=""sig""><div class=""n"">{R("devNome")}</div><div class=""d"">CPF/CNPJ: {R("cpfDev")}</div></div></div>
{Wit(R)}";

    private string GenSuporteTI(Func<string, string> F, Func<string, string> R, string d) => $@"
<div class=""header""><h1>Contrato de Suporte Técnico em TI</h1><div class=""subtitle"">Instrumento Particular de Prestação de Serviços de Suporte e Manutenção</div></div>
<p class=""preambulo"">Pelo presente instrumento particular e na melhor forma de direito, as partes a seguir qualificadas resolvem celebrar o presente Contrato de Suporte Técnico em Tecnologia da Informação, regido pelos artigos 593 a 609 do Código Civil Brasileiro e pelo Marco Civil da Internet (Lei nº 12.965/2014).</p>
<div class=""cl""><div class=""cl-t"">Cláusula 1ª — Das Partes</div>
<p><strong>1.1. CONTRATANTE:</strong> {F("contratante")}, CPF/CNPJ {F("cpfCnpjContratante")}, com endereço em {F("endContratante")}, e-mail {F("emailContratante")}, doravante denominada simplesmente <strong>CONTRATANTE</strong>.</p>
<p><strong>1.2. PRESTADORA:</strong> {F("empresaTI")}, CNPJ {F("cnpjTI")}, representada por {F("representanteTI")}, com sede em {F("endTI")}, e-mail {F("emailTI")}, doravante denominada simplesmente <strong>PRESTADORA</strong>.</p></div>
<div class=""cl""><div class=""cl-t"">Cláusula 2ª — Do Objeto</div>
<p><strong>2.1.</strong> O presente contrato tem por objeto a prestação de serviços de suporte técnico em Tecnologia da Informação, compreendendo atendimento, diagnóstico, manutenção preventiva e corretiva dos sistemas e equipamentos da CONTRATANTE.</p>
<p><strong>2.2.</strong> Nível de suporte contratado: {F("nivelSuporte")}.</p>
<p><strong>2.3.</strong> Sistemas e equipamentos cobertos: {F("sistemasCobertos")}.</p></div>
<div class=""cl""><div class=""cl-t"">Cláusula 3ª — Do Acordo de Nível de Serviço (SLA)</div>
<p><strong>3.1.</strong> Horário de atendimento: {F("horarioAtendimento")}.</p>
<p><strong>3.2.</strong> Tempo máximo de resposta (primeiro contato): {F("tempoResposta")}.</p>
<p><strong>3.3.</strong> Tempo máximo de resolução: {F("tempoResolucao")}.</p>
<p><strong>3.4.</strong> Canal de atendimento: {F("canalAtendimento")}.</p>
<p><strong>3.5.</strong> Chamados fora do horário contratado serão atendidos mediante acordo prévio e poderão ter custo adicional.</p></div>
<div class=""cl""><div class=""cl-t"">Cláusula 4ª — Das Obrigações da Prestadora</div>
<p>A PRESTADORA obriga-se a: a) atender os chamados dentro dos prazos de SLA; b) manter equipe técnica qualificada; c) realizar manutenção preventiva conforme cronograma acordado; d) documentar todos os atendimentos em sistema de tickets; e) emitir relatórios mensais de atendimento; f) manter sigilo sobre informações da CONTRATANTE; g) comunicar riscos identificados proativamente.</p></div>
<div class=""cl""><div class=""cl-t"">Cláusula 5ª — Das Obrigações da Contratante</div>
<p>A CONTRATANTE obriga-se a: a) fornecer acesso necessário aos sistemas e equipamentos; b) designar ponto de contato técnico; c) seguir as recomendações técnicas da PRESTADORA; d) pagar pontualmente; e) comunicar mudanças no ambiente de TI; f) não realizar intervenções sem consulta prévia à PRESTADORA.</p></div>
<div class=""cl""><div class=""cl-t"">Cláusula 6ª — Do Valor e Pagamento</div>
<p><strong>6.1.</strong> Valor mensal: R$ {F("valorMensal")} ({F("valorExtenso")}).</p>
<p><strong>6.2.</strong> Forma de pagamento: {F("formaPagamento")}.</p>
<p><strong>6.3.</strong> Atraso no pagamento acarretará multa de 2% sobre o valor devido, acrescida de juros de 1% ao mês e correção monetária pelo IPCA/IBGE.</p></div>
<div class=""cl""><div class=""cl-t"">Cláusula 7ª — Da Vigência</div>
<p><strong>7.1.</strong> O presente contrato terá vigência de {F("vigencia")} meses, com início em {F("dataInicio")}.</p>
<p><strong>7.2.</strong> O contrato será renovado automaticamente por iguais períodos, salvo manifestação contrária de qualquer das partes com antecedência mínima de 30 (trinta) dias.</p></div>
<div class=""cl""><div class=""cl-t"">Cláusula 8ª — Das Penalidades por Descumprimento de SLA</div>
<p><strong>8.1.</strong> O descumprimento dos prazos de SLA por culpa da PRESTADORA acarretará desconto de {F("multaIndisponibilidade")} sobre o valor mensal, proporcional ao período de indisponibilidade.</p>
<p><strong>8.2.</strong> Multa por rescisão antecipada: {F("multaRescisao")}.</p></div>
<div class=""cl""><div class=""cl-t"">Cláusula 9ª — Da Confidencialidade</div>
<p>A PRESTADORA compromete-se a manter absoluto sigilo sobre todas as informações, dados, sistemas e processos da CONTRATANTE a que tiver acesso, por prazo indeterminado, sujeitando-se às penalidades civis e penais aplicáveis em caso de violação.</p></div>
<div class=""cl""><div class=""cl-t"">Cláusula 10ª — Da Proteção de Dados</div>
<p>As partes comprometem-se a cumprir integralmente a Lei Geral de Proteção de Dados (Lei 13.709/2018), adotando medidas técnicas e administrativas adequadas para proteção de dados pessoais tratados durante a prestação dos serviços.</p></div>
<div class=""cl""><div class=""cl-t"">Cláusula 11ª — Da Rescisão</div>
<p>O contrato poderá ser rescindido por: a) mútuo acordo; b) unilateral com 30 dias de aviso prévio; c) inadimplemento não sanado em 15 dias após notificação; d) descumprimento reiterado de SLA (3 ou mais ocorrências em 60 dias).</p></div>
<div class=""cl""><div class=""cl-t"">Cláusula 12ª — Da Responsabilidade</div>
<p>A responsabilidade da PRESTADORA limita-se ao valor equivalente a 12 (doze) mensalidades, exceto em caso de dolo ou fraude. A PRESTADORA não se responsabiliza por danos decorrentes de alterações realizadas pela CONTRATANTE sem autorização.</p></div>
<div class=""cl""><div class=""cl-t"">Cláusula 13ª — Da Força Maior</div>
<p>Eventos de força maior ou caso fortuito (art. 393 CC) suspenderão as obrigações pelo período de sua duração, devendo a parte afetada comunicar a outra em 24 horas.</p></div>
<div class=""cl""><div class=""cl-t"">Cláusula 14ª — Das Disposições Gerais</div>
<p>Vincula herdeiros e sucessores. Tolerância não implica novação. Alterações somente por Termo Aditivo. Nulidade parcial não afeta demais cláusulas.</p></div>
<div class=""cl""><div class=""cl-t"">Cláusula 15ª — Do Foro</div>
<p>Fica eleito o foro da Comarca de {F("foro")}, com exclusão de qualquer outro, para dirimir quaisquer litígios oriundos deste contrato (art. 63 CPC).</p></div>
{Fecho(F, d)}
<div class=""sigs""><div class=""sig""><div class=""n"">{R("contratante")}</div><div class=""d"">CPF/CNPJ: {R("cpfCnpjContratante")}</div></div><div class=""sig""><div class=""n"">{R("empresaTI")}</div><div class=""d"">CNPJ: {R("cnpjTI")}</div></div></div>
{Wit(R)}";

    private string GenSaas(Func<string, string> F, Func<string, string> R, string d) => $@"
<div class=""header""><h1>Contrato de Licenciamento SaaS</h1><div class=""subtitle"">Instrumento Particular de Licença de Software como Serviço — Lei 9.609/98</div></div>
<p class=""preambulo"">Pelo presente instrumento particular e na melhor forma de direito, as partes a seguir qualificadas resolvem celebrar o presente Contrato de Licenciamento de Software como Serviço (SaaS), regido pela Lei nº 9.609/98 (Lei de Software), pelo Marco Civil da Internet (Lei nº 12.965/2014), pela LGPD (Lei nº 13.709/2018) e subsidiariamente pelo Código Civil Brasileiro.</p>
<div class=""cl""><div class=""cl-t"">Cláusula 1ª — Das Partes</div>
<p><strong>1.1. FORNECEDORA:</strong> {F("fornecedor")}, CNPJ {F("cnpjFornecedor")}, representada por {F("representanteFornecedor")}, com sede em {F("endFornecedor")}, e-mail {F("emailFornecedor")}, doravante denominada simplesmente <strong>FORNECEDORA</strong>.</p>
<p><strong>1.2. CLIENTE:</strong> {F("cliente")}, CPF/CNPJ {F("cpfCnpjCliente")}, com endereço em {F("endCliente")}, e-mail {F("emailCliente")}, doravante denominado(a) simplesmente <strong>CLIENTE</strong>.</p></div>
<div class=""cl""><div class=""cl-t"">Cláusula 2ª — Do Objeto</div>
<p><strong>2.1.</strong> O presente contrato tem por objeto a concessão de licença de uso não exclusiva da plataforma {F("nomePlataforma")}, na modalidade SaaS (Software as a Service), acessível via internet.</p>
<p><strong>2.2.</strong> Plano contratado: {F("planoContratado")}.</p>
<p><strong>2.3.</strong> Quantidade de usuários: {F("quantidadeUsuarios")}.</p>
<p><strong>2.4.</strong> A licença é intransferível e não pode ser sublicenciada sem autorização prévia e escrita da FORNECEDORA.</p></div>
<div class=""cl""><div class=""cl-t"">Cláusula 3ª — Da Disponibilidade e SLA</div>
<p><strong>3.1.</strong> A FORNECEDORA garante uptime mínimo de {F("uptimeGarantido")} mensal, excluindo manutenções programadas comunicadas com 48h de antecedência.</p>
<p><strong>3.2.</strong> Suporte incluso: {F("suporteIncluso")}.</p>
<p><strong>3.3.</strong> Frequência de backup: {F("backupFrequencia")}.</p>
<p><strong>3.4.</strong> Em caso de indisponibilidade superior ao garantido, o CLIENTE terá direito a desconto proporcional na mensalidade.</p></div>
<div class=""cl""><div class=""cl-t"">Cláusula 4ª — Do Valor e Pagamento</div>
<p><strong>4.1.</strong> Valor mensal: R$ {F("valorMensal")}.</p>
<p><strong>4.2.</strong> Forma de pagamento: {F("formaPagamento")}.</p>
<p><strong>4.3.</strong> Reajuste anual pelo índice: {F("reajusteAnual")}.</p>
<p><strong>4.4.</strong> Atraso no pagamento acarretará multa de 2% acrescida de juros de 1% ao mês. Atraso superior a 15 dias autoriza a suspensão do acesso.</p></div>
<div class=""cl""><div class=""cl-t"">Cláusula 5ª — Da Propriedade dos Dados</div>
<p><strong>5.1.</strong> Propriedade dos dados: {F("propriedadeDados")}.</p>
<p><strong>5.2.</strong> Formato de exportação: {F("exportacaoDados")}.</p>
<p><strong>5.3.</strong> Prazo para exportação após cancelamento: {F("prazoExportacao")} dias.</p>
<p><strong>5.4.</strong> Após o prazo de exportação, a FORNECEDORA poderá excluir definitivamente os dados do CLIENTE.</p></div>
<div class=""cl""><div class=""cl-t"">Cláusula 6ª — Da Propriedade Intelectual</div>
<p>A plataforma, incluindo código-fonte, interface, arquitetura e documentação, é propriedade exclusiva da FORNECEDORA, protegida pelas Leis 9.609/98 e 9.610/98. O CLIENTE adquire apenas o direito de uso conforme este contrato.</p></div>
<div class=""cl""><div class=""cl-t"">Cláusula 7ª — Das Obrigações da Fornecedora</div>
<p>A FORNECEDORA obriga-se a: a) manter a plataforma disponível conforme SLA; b) realizar backups regulares; c) aplicar atualizações de segurança; d) prestar suporte técnico; e) notificar incidentes de segurança em 72h; f) cumprir a LGPD integralmente.</p></div>
<div class=""cl""><div class=""cl-t"">Cláusula 8ª — Das Obrigações do Cliente</div>
<p>O CLIENTE obriga-se a: a) pagar pontualmente; b) manter credenciais em sigilo; c) utilizar a plataforma de forma lícita; d) não realizar engenharia reversa; e) respeitar os limites do plano contratado; f) comunicar vulnerabilidades identificadas.</p></div>
<div class=""cl""><div class=""cl-t"">Cláusula 9ª — Da Proteção de Dados (LGPD)</div>
<p>As partes comprometem-se a cumprir integralmente a Lei Geral de Proteção de Dados (Lei 13.709/2018). A FORNECEDORA atuará como operadora de dados pessoais inseridos pelo CLIENTE, adotando medidas técnicas e administrativas adequadas conforme art. 46 da LGPD.</p></div>
<div class=""cl""><div class=""cl-t"">Cláusula 10ª — Da Confidencialidade</div>
<p>Ambas as partes comprometem-se a manter sigilo sobre informações confidenciais trocadas durante a vigência deste contrato, por prazo indeterminado. Violação sujeita a perdas e danos.</p></div>
<div class=""cl""><div class=""cl-t"">Cláusula 11ª — Da Vigência</div>
<p>Vigência de {F("vigencia")} meses. Renovação automática por iguais períodos, salvo manifestação contrária com 30 dias de antecedência.</p></div>
<div class=""cl""><div class=""cl-t"">Cláusula 12ª — Da Rescisão</div>
<p>O contrato poderá ser rescindido por: a) mútuo acordo; b) unilateral com 30 dias de aviso prévio; c) inadimplemento não sanado em 15 dias; d) violação de dados pessoais por negligência comprovada.</p></div>
<div class=""cl""><div class=""cl-t"">Cláusula 13ª — Da Limitação de Responsabilidade</div>
<p>A responsabilidade da FORNECEDORA limita-se ao valor equivalente a 12 (doze) mensalidades, exceto em caso de dolo, fraude ou violação da LGPD.</p></div>
<div class=""cl""><div class=""cl-t"">Cláusula 14ª — Das Disposições Gerais</div>
<p>Vincula herdeiros e sucessores. Tolerância não implica novação. Alterações por Termo Aditivo. Nulidade parcial preserva demais cláusulas.</p></div>
<div class=""cl""><div class=""cl-t"">Cláusula 15ª — Do Foro</div>
<p>Fica eleito o foro da Comarca de {F("foro")}, com exclusão de qualquer outro, para dirimir quaisquer litígios oriundos deste contrato (art. 63 CPC).</p></div>
{Fecho(F, d)}
<div class=""sigs""><div class=""sig""><div class=""n"">{R("fornecedor")}</div><div class=""d"">CNPJ: {R("cnpjFornecedor")}</div></div><div class=""sig""><div class=""n"">{R("cliente")}</div><div class=""d"">CPF/CNPJ: {R("cpfCnpjCliente")}</div></div></div>
{Wit(R)}";

    private string GenLgpd(Func<string, string> F, Func<string, string> R, string d) => $@"
<div class=""header""><h1>Acordo de Tratamento de Dados Pessoais</h1><div class=""subtitle"">Instrumento Particular nos termos da Lei nº 13.709/2018 (LGPD)</div></div>
<p class=""preambulo"">Pelo presente instrumento particular e na melhor forma de direito, as partes a seguir qualificadas resolvem celebrar o presente Acordo de Tratamento de Dados Pessoais, em conformidade com a Lei nº 13.709/2018 (Lei Geral de Proteção de Dados Pessoais — LGPD), o Decreto nº 8.771/2016, e demais normas regulamentares da Autoridade Nacional de Proteção de Dados (ANPD).</p>
<div class=""cl""><div class=""cl-t"">Cláusula 1ª — Das Partes</div>
<p><strong>1.1. CONTROLADOR:</strong> {F("controlador")}, CNPJ {F("cnpjControlador")}, representado por {F("representanteControlador")}, Encarregado (DPO): {F("dpo")}, e-mail do DPO: {F("emailDpo")}, doravante denominado simplesmente <strong>CONTROLADOR</strong>.</p>
<p><strong>1.2. OPERADOR:</strong> {F("operador")}, CNPJ {F("cnpjOperador")}, representado por {F("representanteOperador")}, com sede em {F("endOperador")}, e-mail {F("emailOperador")}, doravante denominado simplesmente <strong>OPERADOR</strong>.</p></div>
<div class=""cl""><div class=""cl-t"">Cláusula 2ª — Das Definições</div>
<p>Para fins deste acordo, aplicam-se as definições do art. 5º da LGPD, em especial: dado pessoal, dado pessoal sensível, tratamento, controlador, operador, encarregado, titular, consentimento e eliminação.</p></div>
<div class=""cl""><div class=""cl-t"">Cláusula 3ª — Da Finalidade do Tratamento</div>
<p><strong>3.1.</strong> Finalidade: {F("finalidade")}.</p>
<p><strong>3.2.</strong> Base legal para o tratamento (art. 7º LGPD): {F("baseLegal")}.</p>
<p><strong>3.3.</strong> O OPERADOR realizará o tratamento exclusivamente para as finalidades descritas, sendo vedado o uso para fins próprios ou incompatíveis.</p></div>
<div class=""cl""><div class=""cl-t"">Cláusula 4ª — Dos Dados Tratados</div>
<p><strong>4.1.</strong> Categorias de dados pessoais: {F("categoriasDados")}.</p>
<p><strong>4.2.</strong> Titulares dos dados: {F("titularesDados")}.</p>
<p><strong>4.3.</strong> Compartilhamento com terceiros: {F("compartilhamento")}.</p></div>
<div class=""cl""><div class=""cl-t"">Cláusula 5ª — Das Obrigações do Operador</div>
<p>O OPERADOR obriga-se a: a) tratar dados exclusivamente conforme instruções do CONTROLADOR; b) manter registro das operações de tratamento (art. 37 LGPD); c) adotar medidas de segurança (art. 46 LGPD); d) comunicar incidentes ao CONTROLADOR no prazo estipulado; e) garantir que colaboradores com acesso aos dados estejam sob dever de confidencialidade; f) auxiliar o CONTROLADOR no atendimento a solicitações de titulares; g) eliminar dados ao término do tratamento, salvo obrigação legal de conservação.</p></div>
<div class=""cl""><div class=""cl-t"">Cláusula 6ª — Das Obrigações do Controlador</div>
<p>O CONTROLADOR obriga-se a: a) fornecer instruções claras e documentadas ao OPERADOR; b) garantir que o tratamento possui base legal adequada; c) atender solicitações de titulares conforme arts. 17 a 22 da LGPD; d) comunicar a ANPD e os titulares sobre incidentes relevantes (art. 48 LGPD); e) manter registro das operações de tratamento.</p></div>
<div class=""cl""><div class=""cl-t"">Cláusula 7ª — Das Medidas de Segurança</div>
<p><strong>7.1.</strong> Medidas técnicas e administrativas: {F("medidasTecnicas")}.</p>
<p><strong>7.2.</strong> As medidas deverão ser compatíveis com o nível de risco do tratamento, conforme art. 46 da LGPD e orientações da ANPD.</p></div>
<div class=""cl""><div class=""cl-t"">Cláusula 8ª — Dos Incidentes de Segurança</div>
<p><strong>8.1.</strong> Prazo para notificação de incidente ao CONTROLADOR: {F("prazoNotificacao")}.</p>
<p><strong>8.2.</strong> A notificação deverá conter: natureza dos dados afetados, titulares impactados, medidas adotadas e recomendações de mitigação.</p>
<p><strong>8.3.</strong> O OPERADOR cooperará com o CONTROLADOR na investigação e remediação do incidente.</p></div>
<div class=""cl""><div class=""cl-t"">Cláusula 9ª — Da Retenção e Eliminação</div>
<p><strong>9.1.</strong> Prazo de retenção dos dados: {F("prazoRetencao")}.</p>
<p><strong>9.2.</strong> Método de descarte: {F("descarteDados")}.</p>
<p><strong>9.3.</strong> Ao término do tratamento ou do contrato, os dados serão eliminados conforme art. 16 da LGPD, salvo obrigação legal ou regulatória de conservação.</p></div>
<div class=""cl""><div class=""cl-t"">Cláusula 10ª — Da Subcontratação</div>
<p>A subcontratação de sub-operadores pelo OPERADOR depende de autorização prévia e escrita do CONTROLADOR. O sub-operador deverá assumir as mesmas obrigações previstas neste acordo.</p></div>
<div class=""cl""><div class=""cl-t"">Cláusula 11ª — Da Transferência Internacional</div>
<p>Eventual transferência internacional de dados pessoais somente ocorrerá em conformidade com o art. 33 da LGPD, mediante autorização do CONTROLADOR e adoção das garantias previstas em lei.</p></div>
<div class=""cl""><div class=""cl-t"">Cláusula 12ª — Da Auditoria</div>
<p>O CONTROLADOR poderá realizar auditorias periódicas para verificar o cumprimento das obrigações previstas neste acordo, mediante notificação prévia de 15 (quinze) dias. O OPERADOR compromete-se a fornecer todas as informações e acessos necessários.</p></div>
<div class=""cl""><div class=""cl-t"">Cláusula 13ª — Da Responsabilidade</div>
<p>O OPERADOR responderá solidariamente por danos causados a titulares em decorrência de violação da LGPD, quando descumprir as obrigações deste acordo ou agir em desconformidade com as instruções do CONTROLADOR (art. 42 LGPD).</p></div>
<div class=""cl""><div class=""cl-t"">Cláusula 14ª — Das Disposições Gerais</div>
<p>Este acordo integra e complementa o contrato principal entre as partes. Nulidade parcial preserva demais cláusulas. Alterações somente por Termo Aditivo. Prevalece sobre disposições contraditórias do contrato principal no que tange ao tratamento de dados pessoais.</p></div>
<div class=""cl""><div class=""cl-t"">Cláusula 15ª — Do Foro</div>
<p>Fica eleito o foro da Comarca de {F("foro")}, com exclusão de qualquer outro, para dirimir quaisquer litígios oriundos deste acordo (art. 63 CPC).</p></div>
{Fecho(F, d)}
<div class=""sigs""><div class=""sig""><div class=""n"">{R("controlador")}</div><div class=""d"">CNPJ: {R("cnpjControlador")}</div></div><div class=""sig""><div class=""n"">{R("operador")}</div><div class=""d"">CNPJ: {R("cnpjOperador")}</div></div></div>
{Wit(R)}";

    // ═══════════════════════════════════════════════════════════════════════
    //  DIREITO CATEGORY TEMPLATES
    // ═══════════════════════════════════════════════════════════════════════

    private string GenHonorarios(Func<string, string> F, Func<string, string> R, string d) => $@"
<div class=""header""><h1>Contrato de Honorários Advocatícios</h1><div class=""subtitle"">Instrumento Particular nos termos do Estatuto da OAB (Lei 8.906/94) e Código Civil</div></div>
<p class=""preambulo"">Pelo presente instrumento particular e na melhor forma de direito, as partes a seguir qualificadas resolvem celebrar o presente Contrato de Honorários Advocatícios, regido pela Lei nº 8.906/94 (Estatuto da Advocacia e da OAB), pelo Código de Ética e Disciplina da OAB, e subsidiariamente pelo Código Civil Brasileiro.</p>
<div class=""cl""><div class=""cl-t"">Cláusula 1ª — Das Partes</div>
<p><strong>1.1. ADVOGADO(A):</strong> {F("nomeAdvogado")}, inscrito(a) na OAB {F("oab")}, CPF {F("cpfAdvogado")}, com escritório profissional em {F("endAdvogado")}, e-mail {F("emailAdvogado")}, doravante denominado(a) simplesmente <strong>ADVOGADO(A)</strong>.</p>
<p><strong>1.2. CLIENTE:</strong> {F("nomeCliente")}, CPF/CNPJ {F("cpfCliente")}, residente/sediado em {F("endCliente")}, e-mail {F("emailCliente")}, doravante denominado(a) simplesmente <strong>CLIENTE</strong>.</p></div>
<div class=""cl""><div class=""cl-t"">Cláusula 2ª — Do Objeto</div>
<p><strong>2.1.</strong> Tipo de ação/serviço jurídico: {F("tipoAcao")}.</p>
<p><strong>2.2.</strong> Descrição da causa: {F("descricaoCausa")}.</p>
<p><strong>2.3.</strong> Valor da causa: R$ {F("valorCausa")}.</p>
<p><strong>2.4.</strong> Instância(s) abrangida(s): {F("instancia")}.</p>
<p><strong>2.5.</strong> Serviços não previstos neste instrumento, como recursos a instâncias superiores, demandas incidentais ou reconvenções, serão objeto de contratação suplementar.</p></div>
<div class=""cl""><div class=""cl-t"">Cláusula 3ª — Dos Honorários</div>
<p><strong>3.1.</strong> Honorários iniciais (entrada): R$ {F("honorariosIniciais")}.</p>
<p><strong>3.2.</strong> Honorários mensais: R$ {F("honorariosMensais")}.</p>
<p><strong>3.3.</strong> Honorários de êxito: {F("honorariosExito")} sobre o proveito econômico obtido, observados os limites da Tabela de Honorários da OAB.</p>
<p><strong>3.4.</strong> Forma de pagamento: {F("formaPagamento")}.</p>
<p><strong>3.5.</strong> Os honorários são devidos independentemente do resultado da demanda, salvo disposição expressa em contrário neste instrumento (art. 22 Lei 8.906/94).</p></div>
<div class=""cl""><div class=""cl-t"">Cláusula 4ª — Das Obrigações do Advogado</div>
<p>O(A) ADVOGADO(A) obriga-se a: a) patrocinar a causa com zelo, diligência e competência; b) manter o CLIENTE informado sobre o andamento processual; c) comparecer aos atos processuais; d) respeitar os prazos legais; e) manter sigilo profissional (art. 7º, XIX, Lei 8.906/94); f) prestar contas de valores recebidos em nome do CLIENTE.</p></div>
<div class=""cl""><div class=""cl-t"">Cláusula 5ª — Das Obrigações do Cliente</div>
<p>O CLIENTE obriga-se a: a) pagar os honorários nos prazos pactuados; b) fornecer documentos e informações necessários; c) comparecer a audiências quando convocado; d) manter dados cadastrais atualizados; e) não contratar outro advogado para a mesma causa sem comunicação prévia; f) arcar com custas processuais, perícias e demais despesas.</p></div>
<div class=""cl""><div class=""cl-t"">Cláusula 6ª — Do Substabelecimento</div>
<p>O(A) ADVOGADO(A) poderá substabelecer poderes a colegas de confiança, com ou sem reservas, para melhor andamento da causa, permanecendo responsável pela condução do processo.</p></div>
<div class=""cl""><div class=""cl-t"">Cláusula 7ª — Da Revogação e Renúncia</div>
<p><strong>7.1.</strong> O CLIENTE poderá revogar o mandato a qualquer tempo, permanecendo devidos os honorários proporcionais ao trabalho realizado (art. 22 Lei 8.906/94).</p>
<p><strong>7.2.</strong> O(A) ADVOGADO(A) poderá renunciar ao mandato, continuando a representar o CLIENTE por 10 (dez) dias a partir da notificação, conforme art. 5º, §3º, Lei 8.906/94.</p></div>
<div class=""cl""><div class=""cl-t"">Cláusula 8ª — Do Atraso no Pagamento</div>
<p>O atraso no pagamento dos honorários acarretará multa de 2% sobre o valor devido, acrescida de juros de 1% ao mês pro rata die e correção monetária pelo IPCA/IBGE. Atraso superior a 60 dias autoriza a suspensão dos serviços, mediante notificação prévia.</p></div>
<div class=""cl""><div class=""cl-t"">Cláusula 9ª — Do Sigilo Profissional</div>
<p>O(A) ADVOGADO(A) manterá sigilo absoluto sobre todas as informações e documentos confiados pelo CLIENTE, em conformidade com o art. 7º, XIX, da Lei 8.906/94 e o Código de Ética e Disciplina da OAB.</p></div>
<div class=""cl""><div class=""cl-t"">Cláusula 10ª — Da Proteção de Dados</div>
<p>As partes comprometem-se a cumprir a LGPD (Lei 13.709/2018) no tratamento de dados pessoais relacionados à causa.</p></div>
<div class=""cl""><div class=""cl-t"">Cláusula 11ª — Das Disposições Gerais</div>
<p>Honorários são crédito privilegiado (art. 24 Lei 8.906/94). Vincula herdeiros e sucessores. Tolerância não implica novação. Alterações por Termo Aditivo. Nulidade parcial preserva demais cláusulas.</p></div>
<div class=""cl""><div class=""cl-t"">Cláusula 12ª — Do Foro</div>
<p>Fica eleito o foro da Comarca de {F("foro")}, com exclusão de qualquer outro, para dirimir quaisquer litígios oriundos deste contrato (art. 63 CPC).</p></div>
{Fecho(F, d)}
<div class=""sigs""><div class=""sig""><div class=""n"">{R("nomeAdvogado")}</div><div class=""d"">OAB: {R("oab")}</div></div><div class=""sig""><div class=""n"">{R("nomeCliente")}</div><div class=""d"">CPF/CNPJ: {R("cpfCliente")}</div></div></div>
{Wit(R)}";

    private string GenParceria(Func<string, string> F, Func<string, string> R, string d) => $@"
<div class=""header""><h1>Contrato de Parceria</h1><div class=""subtitle"">Instrumento Particular nos termos dos arts. 981 a 1.038 do Código Civil</div></div>
<p class=""preambulo"">Pelo presente instrumento particular e na melhor forma de direito, as partes a seguir qualificadas resolvem celebrar o presente Contrato de Parceria, regido pelos artigos 981 a 1.038 do Código Civil Brasileiro (Sociedade em Conta de Participação / Parceria Empresarial) e demais disposições legais aplicáveis.</p>
<div class=""cl""><div class=""cl-t"">Cláusula 1ª — Das Partes</div>
<p><strong>1.1. PARCEIRO 1:</strong> {F("parceiro1")}, CPF/CNPJ {F("cpfCnpj1")}, com endereço em {F("end1")}, e-mail {F("email1")}, doravante denominado(a) simplesmente <strong>PARCEIRO 1</strong>.</p>
<p><strong>1.2. PARCEIRO 2:</strong> {F("parceiro2")}, CPF/CNPJ {F("cpfCnpj2")}, com endereço em {F("end2")}, e-mail {F("email2")}, doravante denominado(a) simplesmente <strong>PARCEIRO 2</strong>.</p></div>
<div class=""cl""><div class=""cl-t"">Cláusula 2ª — Do Objeto</div>
<p><strong>2.1.</strong> Objetivo da parceria: {F("objetivo")}.</p>
<p><strong>2.2.</strong> A parceria não constitui sociedade formal, salvo disposição expressa em contrário, mantendo cada parte sua individualidade jurídica e fiscal.</p></div>
<div class=""cl""><div class=""cl-t"">Cláusula 3ª — Dos Aportes</div>
<p><strong>3.1.</strong> Aportes de cada parte: {F("aportes")}.</p>
<p><strong>3.2.</strong> Os aportes serão realizados conforme cronograma acordado e comprovados mediante recibo entre as partes.</p></div>
<div class=""cl""><div class=""cl-t"">Cláusula 4ª — Da Divisão de Resultados</div>
<p><strong>4.1.</strong> Divisão de lucros: {F("divisaoLucros")}.</p>
<p><strong>4.2.</strong> As perdas serão divididas na mesma proporção dos lucros, salvo acordo diverso formalizado por Termo Aditivo.</p>
<p><strong>4.3.</strong> A apuração de resultados será realizada mensalmente, com prestação de contas até o 10º dia útil do mês subsequente.</p></div>
<div class=""cl""><div class=""cl-t"">Cláusula 5ª — Da Gestão</div>
<p><strong>5.1.</strong> A gestão e administração da parceria será exercida por: {F("gestao")}.</p>
<p><strong>5.2.</strong> Decisões estratégicas (investimentos acima de 10% do capital, alteração de objeto, admissão de novos parceiros) dependerão de aprovação unânime.</p>
<p><strong>5.3.</strong> O gestor prestará contas detalhadas mensalmente aos demais parceiros.</p></div>
<div class=""cl""><div class=""cl-t"">Cláusula 6ª — Da Vigência</div>
<p><strong>6.1.</strong> Vigência: {F("vigencia")}, com início em {F("dataInicio")}.</p>
<p><strong>6.2.</strong> Renovação automática por iguais períodos, salvo manifestação contrária com 60 dias de antecedência.</p></div>
<div class=""cl""><div class=""cl-t"">Cláusula 7ª — Das Obrigações dos Parceiros</div>
<p>Cada parceiro obriga-se a: a) cumprir os aportes e obrigações pactuados; b) agir com lealdade e boa-fé; c) não concorrer diretamente com a parceria; d) manter sigilo sobre informações estratégicas; e) dedicar esforços conforme acordado; f) comunicar conflitos de interesse.</p></div>
<div class=""cl""><div class=""cl-t"">Cláusula 8ª — Da Confidencialidade</div>
<p>Todas as informações estratégicas, financeiras e comerciais compartilhadas entre os parceiros são confidenciais, pelo prazo de 3 (três) anos após o término da parceria. Violação sujeita a perdas e danos.</p></div>
<div class=""cl""><div class=""cl-t"">Cláusula 9ª — Da Propriedade Intelectual</div>
<p>Criações intelectuais desenvolvidas no âmbito da parceria serão de propriedade conjunta, na proporção dos aportes, salvo acordo específico. Utilização individual depende de autorização do outro parceiro.</p></div>
<div class=""cl""><div class=""cl-t"">Cláusula 10ª — Da Rescisão</div>
<p><strong>10.1.</strong> Condições de término: {F("condicoesTermino")}.</p>
<p><strong>10.2.</strong> Em caso de rescisão, será realizado balanço patrimonial e os ativos serão divididos conforme a proporção dos aportes.</p>
<p><strong>10.3.</strong> Obrigações assumidas perante terceiros durante a vigência permanecem válidas até seu cumprimento integral.</p></div>
<div class=""cl""><div class=""cl-t"">Cláusula 11ª — Da Resolução de Conflitos</div>
<p>Eventuais divergências serão resolvidas preferencialmente por mediação. Não havendo acordo em 30 dias, as partes poderão recorrer à arbitragem ou ao Poder Judiciário.</p></div>
<div class=""cl""><div class=""cl-t"">Cláusula 12ª — Da LGPD</div>
<p>As partes comprometem-se a cumprir a Lei Geral de Proteção de Dados (Lei 13.709/2018) no tratamento de dados pessoais no âmbito da parceria.</p></div>
<div class=""cl""><div class=""cl-t"">Cláusula 13ª — Das Disposições Gerais</div>
<p>Vincula herdeiros e sucessores. Tolerância não implica novação. Alterações somente por Termo Aditivo. Nulidade parcial preserva demais cláusulas. Este instrumento constitui o entendimento integral entre as partes.</p></div>
<div class=""cl""><div class=""cl-t"">Cláusula 14ª — Do Foro</div>
<p>Fica eleito o foro da Comarca de {F("foro")}, com exclusão de qualquer outro, para dirimir quaisquer litígios oriundos deste contrato (art. 63 CPC).</p></div>
{Fecho(F, d)}
<div class=""sigs""><div class=""sig""><div class=""n"">{R("parceiro1")}</div><div class=""d"">CPF/CNPJ: {R("cpfCnpj1")}</div></div><div class=""sig""><div class=""n"">{R("parceiro2")}</div><div class=""d"">CPF/CNPJ: {R("cpfCnpj2")}</div></div></div>
{Wit(R)}";

    private string GenDistrato(Func<string, string> F, Func<string, string> R, string d) => $@"
<div class=""header""><h1>Instrumento de Distrato / Rescisão Contratual</h1><div class=""subtitle"">Instrumento Particular nos termos dos arts. 472 a 480 do Código Civil</div></div>
<p class=""preambulo"">Pelo presente instrumento particular de distrato e na melhor forma de direito, as partes a seguir qualificadas resolvem, de comum acordo, rescindir o contrato originalmente celebrado entre si, nos termos dos artigos 472 a 480 do Código Civil Brasileiro, mediante as cláusulas e condições a seguir estipuladas.</p>
<div class=""cl""><div class=""cl-t"">Cláusula 1ª — Das Partes</div>
<p><strong>1.1. PARTE 1:</strong> {F("parte1")}, CPF/CNPJ {F("cpfCnpj1")}, com endereço em {F("end1")}, e-mail {F("email1")}, doravante denominada simplesmente <strong>PARTE 1</strong>.</p>
<p><strong>1.2. PARTE 2:</strong> {F("parte2")}, CPF/CNPJ {F("cpfCnpj2")}, com endereço em {F("end2")}, e-mail {F("email2")}, doravante denominada simplesmente <strong>PARTE 2</strong>.</p></div>
<div class=""cl""><div class=""cl-t"">Cláusula 2ª — Do Contrato Original</div>
<p><strong>2.1.</strong> Tipo do contrato original: {F("tipoContratoOriginal")}.</p>
<p><strong>2.2.</strong> Data de celebração: {F("dataContratoOriginal")}.</p>
<p><strong>2.3.</strong> Objeto original: {F("objetoOriginal")}.</p></div>
<div class=""cl""><div class=""cl-t"">Cláusula 3ª — Do Motivo do Distrato</div>
<p><strong>3.1.</strong> Motivo: {F("motivoDistrato")}.</p>
<p><strong>3.2.</strong> As partes declaram que o presente distrato é celebrado de livre e espontânea vontade, sem qualquer coação ou vício de consentimento.</p></div>
<div class=""cl""><div class=""cl-t"">Cláusula 4ª — Das Obrigações Pendentes</div>
<p><strong>4.1.</strong> Obrigações pendentes: {F("obrigacoesPendentes")}.</p>
<p><strong>4.2.</strong> As obrigações pendentes listadas acima deverão ser cumpridas integralmente, mesmo após a rescisão do contrato original.</p></div>
<div class=""cl""><div class=""cl-t"">Cláusula 5ª — Do Valor da Rescisão</div>
<p><strong>5.1.</strong> Valor da rescisão: R$ {F("valorRescisao")}.</p>
<p><strong>5.2.</strong> Prazo para quitação: {F("prazoQuitacao")}.</p>
<p><strong>5.3.</strong> O pagamento do valor de rescisão importará em quitação plena e irrevogável das obrigações financeiras decorrentes do contrato original, ressalvadas as obrigações expressamente mantidas neste instrumento.</p></div>
<div class=""cl""><div class=""cl-t"">Cláusula 6ª — Da Devolução de Bens e Materiais</div>
<p><strong>6.1.</strong> Devolução de bens/materiais: {F("devolucaoBens")}.</p>
<p><strong>6.2.</strong> A devolução deverá ocorrer no prazo máximo de 15 (quinze) dias a contar da assinatura deste instrumento, mediante termo de entrega e recebimento.</p></div>
<div class=""cl""><div class=""cl-t"">Cláusula 7ª — Da Quitação</div>
<p>Cumpridas integralmente as obrigações previstas neste distrato, as partes darão mutuamente plena, rasa, geral e irrevogável quitação, para nada mais reclamarem uma da outra, seja a que título for, relativamente ao contrato original rescindido.</p></div>
<div class=""cl""><div class=""cl-t"">Cláusula 8ª — Da Confidencialidade</div>
<p>As obrigações de confidencialidade previstas no contrato original permanecem vigentes pelo prazo nele estipulado, ou por 2 (dois) anos a contar deste distrato, o que for maior.</p></div>
<div class=""cl""><div class=""cl-t"">Cláusula 9ª — Da Não Concorrência</div>
<p>Eventuais cláusulas de não concorrência previstas no contrato original permanecem vigentes conforme seus termos originais, salvo acordo diverso entre as partes.</p></div>
<div class=""cl""><div class=""cl-t"">Cláusula 10ª — Da Propriedade Intelectual</div>
<p>Os direitos de propriedade intelectual já transferidos no âmbito do contrato original permanecem com seus respectivos titulares conforme ali definido. Direitos em desenvolvimento serão tratados conforme o contrato original.</p></div>
<div class=""cl""><div class=""cl-t"">Cláusula 11ª — Da Proteção de Dados</div>
<p>As partes comprometem-se a cumprir as obrigações da LGPD (Lei 13.709/2018) relativas a dados pessoais tratados durante a vigência do contrato original, inclusive quanto à eliminação ou devolução dos dados conforme aplicável.</p></div>
<div class=""cl""><div class=""cl-t"">Cláusula 12ª — Da Irrevogabilidade</div>
<p>O presente distrato é irrevogável e irretratável, obrigando as partes, seus herdeiros e sucessores a qualquer título, produzindo efeitos a partir da data de sua assinatura.</p></div>
<div class=""cl""><div class=""cl-t"">Cláusula 13ª — Das Disposições Gerais</div>
<p>Tolerância não implica novação. Nulidade parcial preserva demais cláusulas. Alterações somente por Termo Aditivo.</p></div>
<div class=""cl""><div class=""cl-t"">Cláusula 14ª — Do Foro</div>
<p>Fica eleito o foro da Comarca de {F("foro")}, com exclusão de qualquer outro, para dirimir quaisquer litígios oriundos deste instrumento (art. 63 CPC).</p></div>
{Fecho(F, d)}
<div class=""sigs""><div class=""sig""><div class=""n"">{R("parte1")}</div><div class=""d"">CPF/CNPJ: {R("cpfCnpj1")}</div></div><div class=""sig""><div class=""n"">{R("parte2")}</div><div class=""d"">CPF/CNPJ: {R("cpfCnpj2")}</div></div></div>
{Wit(R)}";

    private string GenCessaoDireitos(Func<string, string> F, Func<string, string> R, string d) => $@"
<div class=""header""><h1>Contrato de Cessão de Direitos</h1><div class=""subtitle"">Instrumento Particular nos termos dos arts. 286 a 298 do Código Civil e Leis 9.610/98 e 9.279/96</div></div>
<p class=""preambulo"">Pelo presente instrumento particular e na melhor forma de direito, as partes a seguir qualificadas resolvem celebrar o presente Contrato de Cessão de Direitos, regido pelos artigos 286 a 298 do Código Civil Brasileiro, pela Lei nº 9.610/98 (Direitos Autorais), pela Lei nº 9.279/96 (Propriedade Industrial) e demais disposições legais aplicáveis.</p>
<div class=""cl""><div class=""cl-t"">Cláusula 1ª — Das Partes</div>
<p><strong>1.1. CEDENTE:</strong> {F("cedente")}, CPF/CNPJ {F("cpfCnpjCedente")}, com endereço em {F("endCedente")}, e-mail {F("emailCedente")}, doravante denominado(a) simplesmente <strong>CEDENTE</strong>.</p>
<p><strong>1.2. CESSIONÁRIO(A):</strong> {F("cessionario")}, CPF/CNPJ {F("cpfCnpjCessionario")}, com endereço em {F("endCessionario")}, e-mail {F("emailCessionario")}, doravante denominado(a) simplesmente <strong>CESSIONÁRIO(A)</strong>.</p></div>
<div class=""cl""><div class=""cl-t"">Cláusula 2ª — Do Objeto</div>
<p><strong>2.1.</strong> Direitos cedidos: {F("direitosCedidos")}.</p>
<p><strong>2.2.</strong> Tipo de cessão: {F("tipoCessao")}.</p>
<p><strong>2.3.</strong> Exclusividade: {F("exclusividade")}.</p>
<p><strong>2.4.</strong> O CEDENTE declara ser o legítimo titular dos direitos objeto desta cessão, garantindo que estão livres e desembaraçados de quaisquer ônus, gravames ou pretensões de terceiros.</p></div>
<div class=""cl""><div class=""cl-t"">Cláusula 3ª — Das Restrições</div>
<p><strong>3.1.</strong> Restrições de uso: {F("restricoes")}.</p>
<p><strong>3.2.</strong> O(A) CESSIONÁRIO(A) compromete-se a respeitar integralmente as restrições aqui previstas, sob pena de rescisão imediata e indenização por perdas e danos.</p></div>
<div class=""cl""><div class=""cl-t"">Cláusula 4ª — Da Remuneração</div>
<p><strong>4.1.</strong> Valor da cessão: R$ {F("valorCessao")} ({F("valorExtenso")}).</p>
<p><strong>4.2.</strong> Forma de pagamento: {F("formaPagamento")}.</p>
<p><strong>4.3.</strong> Atraso no pagamento acarretará multa de 2% sobre o valor devido, acrescida de juros de 1% ao mês pro rata die e correção monetária pelo IPCA/IBGE.</p>
<p><strong>4.4.</strong> A transferência efetiva dos direitos ocorrerá somente após o pagamento integral do valor estipulado.</p></div>
<div class=""cl""><div class=""cl-t"">Cláusula 5ª — Da Abrangência</div>
<p>A cessão abrange todo o território nacional. Para utilização internacional, será necessário Termo Aditivo específico, com eventual renegociação de valores e condições.</p></div>
<div class=""cl""><div class=""cl-t"">Cláusula 6ª — Dos Direitos Morais</div>
<p>Em se tratando de direitos autorais, ficam resguardados os direitos morais do autor (arts. 24 a 27 da Lei 9.610/98), que são inalienáveis e irrenunciáveis, incluindo o direito de paternidade e integridade da obra.</p></div>
<div class=""cl""><div class=""cl-t"">Cláusula 7ª — Da Garantia de Titularidade</div>
<p>O CEDENTE garante: a) ser o legítimo titular dos direitos cedidos; b) não haver cessão anterior dos mesmos direitos a terceiros; c) não existirem litígios ou pretensões de terceiros sobre os direitos; d) indenizar o(a) CESSIONÁRIO(A) por perdas e danos em caso de evicção.</p></div>
<div class=""cl""><div class=""cl-t"">Cláusula 8ª — Da Cessão a Terceiros</div>
<p>O(A) CESSIONÁRIO(A) não poderá ceder ou transferir os direitos adquiridos a terceiros sem autorização prévia e escrita do CEDENTE, salvo em caso de cessão total, quando a transferência ocorrerá de forma integral.</p></div>
<div class=""cl""><div class=""cl-t"">Cláusula 9ª — Da Confidencialidade</div>
<p>Ambas as partes comprometem-se a manter sigilo sobre os termos deste contrato e sobre informações confidenciais trocadas durante a negociação e execução da cessão, por prazo indeterminado.</p></div>
<div class=""cl""><div class=""cl-t"">Cláusula 10ª — Da Rescisão</div>
<p>O contrato poderá ser rescindido por: a) mútuo acordo; b) inadimplemento não sanado em 15 dias após notificação; c) falsidade nas declarações de titularidade; d) utilização dos direitos em desacordo com as restrições previstas. Em caso de rescisão por culpa do(a) CESSIONÁRIO(A), os valores pagos não serão devolvidos.</p></div>
<div class=""cl""><div class=""cl-t"">Cláusula 11ª — Da Proteção de Dados</div>
<p>As partes comprometem-se a cumprir a LGPD (Lei 13.709/2018) no tratamento de dados pessoais eventualmente envolvidos na cessão.</p></div>
<div class=""cl""><div class=""cl-t"">Cláusula 12ª — Do Registro</div>
<p>Quando aplicável, a cessão será registrada nos órgãos competentes (INPI, Biblioteca Nacional, Cartório de Registro de Títulos e Documentos), cabendo ao(à) CESSIONÁRIO(A) arcar com os custos de registro.</p></div>
<div class=""cl""><div class=""cl-t"">Cláusula 13ª — Das Disposições Gerais</div>
<p>Vincula herdeiros e sucessores. Tolerância não implica novação. Alterações somente por Termo Aditivo. Nulidade parcial preserva demais cláusulas. Este instrumento constitui o entendimento integral entre as partes sobre o objeto da cessão.</p></div>
<div class=""cl""><div class=""cl-t"">Cláusula 14ª — Do Foro</div>
<p>Fica eleito o foro da Comarca de {F("foro")}, com exclusão de qualquer outro, para dirimir quaisquer litígios oriundos deste contrato (art. 63 CPC).</p></div>
{Fecho(F, d)}
<div class=""sigs""><div class=""sig""><div class=""n"">{R("cedente")}</div><div class=""d"">CPF/CNPJ: {R("cpfCnpjCedente")}</div></div><div class=""sig""><div class=""n"">{R("cessionario")}</div><div class=""d"">CPF/CNPJ: {R("cpfCnpjCessionario")}</div></div></div>
{Wit(R)}";

    // ─────────────────────────────────────────────────────────────────────────
    //  CONSULTA SAUDE
    // ─────────────────────────────────────────────────────────────────────────
    private string GenConsultaSaude(Func<string, string> F, Func<string, string> R, string d) => $@"
<div class=""header""><h1>Contrato de Prestação de Serviços Médicos</h1><div class=""subtitle"">Instrumento Particular — arts. 593 a 609 do Código Civil e Código de Ética Médica (Resolução CFM nº 2.217/2018)</div></div>
<p class=""preambulo"">Pelo presente instrumento particular e na melhor forma de direito, as partes a seguir qualificadas celebram o presente Contrato de Prestação de Serviços Médicos, que se regerá pelas cláusulas e condições adiante estipuladas, bem como pelas disposições da Lei nº 10.406/2002 (Código Civil), Código de Defesa do Consumidor (Lei nº 8.078/90) e Código de Ética Médica (Resolução CFM nº 2.217/2018).</p>

<div class=""cl""><div class=""cl-t"">Cláusula 1ª — Da Qualificação das Partes</div>
<p><strong>1.1. PROFISSIONAL DE SAÚDE:</strong> {F("nomeProfissional")}, inscrito(a) no CRM sob o nº {F("crm")}, especialidade {F("especialidade")}, CPF/CNPJ nº {F("cpfProfissional")}, com consultório situado em {F("endConsultorio")}, e-mail {F("emailProfissional")}, doravante denominado(a) simplesmente <strong>PROFISSIONAL</strong>.</p>
<p><strong>1.2. PACIENTE/CONTRATANTE:</strong> {F("nomePaciente")}, inscrito(a) no CPF sob o nº {F("cpfPaciente")}, residente e domiciliado(a) em {F("endPaciente")}, e-mail {F("emailPaciente")}, doravante denominado(a) simplesmente <strong>PACIENTE</strong>.</p></div>

<div class=""cl""><div class=""cl-t"">Cláusula 2ª — Do Objeto</div>
<p><strong>2.1.</strong> O presente contrato tem por objeto a prestação, pelo(a) PROFISSIONAL ao(à) PACIENTE, dos seguintes serviços de saúde: {F("procedimento")}.</p>
<p><strong>2.2.</strong> Os serviços serão prestados no seguinte local: {F("localAtendimento")}.</p>
<p><strong>2.3.</strong> O presente instrumento não estabelece obrigação de resultado, tratando-se de obrigação de meio, na qual o PROFISSIONAL se compromete a empregar todos os recursos técnicos e científicos disponíveis na execução dos serviços.</p></div>

<div class=""cl""><div class=""cl-t"">Cláusula 3ª — Da Periodicidade e Prazo</div>
<p><strong>3.1.</strong> A periodicidade dos atendimentos será: {F("periodicidade")}, com início previsto para {F("dataInicio")}.</p>
<p><strong>3.2.</strong> O cronograma poderá ser ajustado de comum acordo entre as partes, considerando a evolução clínica do PACIENTE.</p></div>

<div class=""cl""><div class=""cl-t"">Cláusula 4ª — Das Obrigações do Profissional</div>
<p>O PROFISSIONAL obriga-se a: a) prestar os serviços com zelo, diligência e observância das normas técnicas e éticas aplicáveis, em conformidade com o Código de Ética Médica (Resolução CFM nº 2.217/2018); b) manter atualizado o prontuário médico do PACIENTE (Resolução CFM nº 1.638/2002); c) informar ao PACIENTE de forma clara e completa sobre o diagnóstico, prognóstico, riscos e objetivos do tratamento; d) respeitar a autonomia e a dignidade do PACIENTE; e) guardar sigilo profissional nos termos do art. 73 do Código de Ética Médica; f) encaminhar o PACIENTE a outro profissional quando o caso fugir à sua competência.</p></div>

<div class=""cl""><div class=""cl-t"">Cláusula 5ª — Das Obrigações do Paciente</div>
<p>O PACIENTE obriga-se a: a) fornecer informações verdadeiras e completas sobre seu histórico de saúde; b) seguir as orientações e prescrições do PROFISSIONAL; c) comparecer às consultas agendadas ou cancelar com antecedência mínima de 24 horas; d) efetuar os pagamentos nos prazos estipulados; e) informar ao PROFISSIONAL sobre uso de outros medicamentos ou tratamentos em curso.</p></div>

<div class=""cl""><div class=""cl-t"">Cláusula 6ª — Dos Honorários</div>
<p><strong>6.1.</strong> O valor por consulta/sessão será de R$ {F("valorConsulta")} ({F("valorExtenso")}), a ser pago mediante {F("formaPagamento")}.</p>
<p><strong>6.2.</strong> O não comparecimento à consulta sem cancelamento prévio de 24 horas poderá ensejar a cobrança integral da sessão.</p>
<p><strong>6.3.</strong> Os honorários poderão ser reajustados anualmente com base no IPCA/IBGE, mediante comunicação prévia de 30 dias.</p></div>

<div class=""cl""><div class=""cl-t"">Cláusula 7ª — Do Sigilo Médico e Confidencialidade</div>
<p><strong>7.1.</strong> O PROFISSIONAL se compromete a manter sigilo absoluto sobre todas as informações obtidas no exercício de sua atividade profissional, nos termos do art. 73 do Código de Ética Médica e art. 154 do Código Penal.</p>
<p><strong>7.2.</strong> A quebra de sigilo somente será admitida nas hipóteses previstas em lei, tais como: dever legal, justa causa ou autorização expressa do PACIENTE.</p></div>

<div class=""cl""><div class=""cl-t"">Cláusula 8ª — Da Responsabilidade Civil</div>
<p><strong>8.1.</strong> A responsabilidade do PROFISSIONAL será apurada mediante verificação de culpa (art. 14, §4º, do CDC), sendo subjetiva conforme a natureza da obrigação de meio.</p>
<p><strong>8.2.</strong> O PROFISSIONAL não se responsabiliza por resultados adversos decorrentes da não observância pelo PACIENTE das orientações e prescrições fornecidas.</p></div>

<div class=""cl""><div class=""cl-t"">Cláusula 9ª — Do Cancelamento e Rescisão</div>
<p><strong>9.1.</strong> O presente contrato poderá ser rescindido por qualquer das partes, mediante comunicação por escrito com antecedência mínima de 15 dias.</p>
<p><strong>9.2.</strong> A rescisão não exime o PACIENTE do pagamento das sessões já realizadas.</p>
<p><strong>9.3.</strong> Em caso de rescisão por inadimplemento, aplicam-se as disposições dos arts. 408 a 416 do Código Civil.</p></div>

<div class=""cl""><div class=""cl-t"">Cláusula 10ª — Da Proteção de Dados (LGPD)</div>
<p>As partes se comprometem a observar a Lei Geral de Proteção de Dados (Lei nº 13.709/2018), especialmente no que tange ao tratamento de dados pessoais sensíveis de saúde. O PROFISSIONAL adotará medidas técnicas e administrativas adequadas para proteger os dados pessoais do PACIENTE.</p></div>

<div class=""cl""><div class=""cl-t"">Cláusula 11ª — Disposições Gerais</div>
<p>Tolerância não implica novação. Nulidade parcial preserva as demais cláusulas. Alterações somente por Termo Aditivo escrito e assinado por ambas as partes.</p></div>

<div class=""cl""><div class=""cl-t"">Cláusula 12ª — Do Foro</div>
<p>As partes elegem o foro da Comarca de {F("foro")} para dirimir quaisquer controvérsias oriundas deste instrumento, com renúncia a qualquer outro, por mais privilegiado que seja (art. 63 do CPC).</p></div>
{Fecho(F, d)}
<div class=""sigs""><div class=""sig""><div class=""n"">{R("nomeProfissional")}</div><div class=""d"">CRM: {R("crm")}</div></div><div class=""sig""><div class=""n"">{R("nomePaciente")}</div><div class=""d"">CPF: {R("cpfPaciente")}</div></div></div>
{Wit(R)}";

    // ─────────────────────────────────────────────────────────────────────────
    //  CONSENTIMENTO INFORMADO
    // ─────────────────────────────────────────────────────────────────────────
    private string GenConsentimento(Func<string, string> F, Func<string, string> R, string d) => $@"
<div class=""header""><h1>Termo de Consentimento Livre e Esclarecido</h1><div class=""subtitle"">Em conformidade com o art. 22 do Código de Ética Médica (Resolução CFM nº 2.217/2018)</div></div>

<div class=""cl""><div class=""cl-t"">1 — Identificação do Profissional</div>
<p><strong>Profissional Responsável:</strong> {F("nomeProfissional")}, inscrito(a) no CRM sob o nº {F("crm")}, especialidade {F("especialidade")}.</p></div>

<div class=""cl""><div class=""cl-t"">2 — Identificação do Paciente</div>
<p><strong>Paciente:</strong> {F("nomePaciente")}, inscrito(a) no CPF sob o nº {F("cpfPaciente")}, data de nascimento {F("dataNascimento")}.</p></div>

<div class=""cl""><div class=""cl-t"">3 — Procedimento Proposto</div>
<p><strong>3.1. Descrição do Procedimento:</strong> {F("procedimento")}.</p>
<p><strong>3.2. Indicação Clínica:</strong> {F("indicacao")}.</p></div>

<div class=""cl""><div class=""cl-t"">4 — Alternativas ao Procedimento</div>
<p>Foram apresentadas ao paciente as seguintes alternativas terapêuticas ao procedimento proposto: {F("alternativas")}.</p></div>

<div class=""cl""><div class=""cl-t"">5 — Riscos Esperados</div>
<p>Os seguintes riscos são inerentes ao procedimento proposto e foram explicados ao paciente: {F("riscosEsperados")}.</p></div>

<div class=""cl""><div class=""cl-t"">6 — Complicações Possíveis</div>
<p>Embora incomuns, as seguintes complicações podem ocorrer: {F("complicacoesPossiveis")}.</p></div>

<div class=""cl""><div class=""cl-t"">7 — Cuidados Pós-Procedimento</div>
<p>O paciente foi orientado quanto aos seguintes cuidados após o procedimento: {F("cuidadosPos")}.</p></div>

<div class=""cl""><div class=""cl-t"">8 — Declaração do Paciente</div>
<p>Eu, {F("nomePaciente")}, CPF nº {F("cpfPaciente")}, <strong>DECLARO</strong> que:</p>
<p class=""s"">a) Fui informado(a), de forma clara e em linguagem acessível, pelo(a) Dr(a). {F("nomeProfissional")} (CRM {F("crm")}), sobre o procedimento acima descrito, incluindo sua natureza, objetivos, riscos, benefícios esperados, alternativas existentes e possíveis complicações;</p>
<p class=""s"">b) Tive a oportunidade de fazer perguntas e todas as minhas dúvidas foram satisfatoriamente esclarecidas;</p>
<p class=""s"">c) Compreendo que o resultado do procedimento não pode ser garantido, tratando-se de obrigação de meio;</p>
<p class=""s"">d) Estou ciente de que posso revogar este consentimento a qualquer momento antes da realização do procedimento, sem qualquer prejuízo ao meu atendimento;</p>
<p class=""s"">e) Autorizo, de forma livre e esclarecida, a realização do procedimento descrito neste termo;</p>
<p class=""s"">f) Recebi uma cópia deste Termo de Consentimento devidamente assinada.</p></div>

<div class=""cl""><div class=""cl-t"">9 — Revogação</div>
<p>O presente consentimento poderá ser revogado a qualquer tempo antes da realização do procedimento, mediante manifestação expressa do PACIENTE, sem que isso acarrete qualquer forma de penalidade ou prejuízo ao atendimento, conforme art. 22 do Código de Ética Médica.</p></div>

<div class=""cl""><div class=""cl-t"">10 — Foro</div>
<p>Para dirimir eventuais controvérsias, as partes elegem o foro da Comarca de {F("foro")} (art. 63 do CPC).</p></div>

<p style=""margin-top:28px; text-align:center; font-size:13px;"">{F("cidade")}, {d}.</p>

<div class=""sigs""><div class=""sig""><div class=""n"">{R("nomePaciente")}</div><div class=""d"">CPF: {R("cpfPaciente")}<br/>Paciente</div></div><div class=""sig""><div class=""n"">{R("nomeProfissional")}</div><div class=""d"">CRM: {R("crm")}<br/>Profissional Responsável</div></div></div>
{Wit(R)}";

    // ─────────────────────────────────────────────────────────────────────────
    //  PARCERIA ENTRE CLINICAS
    // ─────────────────────────────────────────────────────────────────────────
    private string GenClinicaParceria(Func<string, string> F, Func<string, string> R, string d) => $@"
<div class=""header""><h1>Contrato de Parceria entre Clínicas</h1><div class=""subtitle"">Instrumento Particular — Código Civil e normas do CFM/ANVISA</div></div>
<p class=""preambulo"">Pelo presente instrumento particular e na melhor forma de direito, as partes a seguir qualificadas celebram o presente Contrato de Parceria, que se regerá pelas cláusulas e condições adiante estipuladas, pela Lei nº 10.406/2002 (Código Civil), normas do Conselho Federal de Medicina e regulamentações da ANVISA.</p>

<div class=""cl""><div class=""cl-t"">Cláusula 1ª — Das Partes</div>
<p><strong>1.1. CLÍNICA 1:</strong> {F("nomeClinica1")}, CNPJ nº {F("cnpjClinica1")}, representada por {F("representante1")}, CRM {F("crm1")}, com sede em {F("endClinica1")}, e-mail {F("emailClinica1")}, doravante denominada <strong>PARCEIRA 1</strong>.</p>
<p><strong>1.2. CLÍNICA 2:</strong> {F("nomeClinica2")}, CNPJ nº {F("cnpjClinica2")}, representada por {F("representante2")}, CRM {F("crm2")}, com sede em {F("endClinica2")}, e-mail {F("emailClinica2")}, doravante denominada <strong>PARCEIRA 2</strong>.</p></div>

<div class=""cl""><div class=""cl-t"">Cláusula 2ª — Do Objeto</div>
<p><strong>2.1.</strong> O presente contrato tem por objeto o estabelecimento de parceria entre as PARCEIRAS para a prestação conjunta de serviços de saúde, envolvendo as seguintes especialidades: {F("especialidades")}.</p>
<p><strong>2.2.</strong> A parceria não constitui sociedade, joint venture ou qualquer forma de associação societária entre as partes, que mantêm sua independência jurídica e administrativa.</p></div>

<div class=""cl""><div class=""cl-t"">Cláusula 3ª — Da Estrutura Compartilhada</div>
<p><strong>3.1.</strong> As PARCEIRAS compartilharão a seguinte estrutura: {F("estruturaCompartilhada")}.</p>
<p><strong>3.2.</strong> Cada PARCEIRA é responsável pela manutenção dos equipamentos e materiais de sua propriedade.</p>
<p><strong>3.3.</strong> Os custos de manutenção da estrutura compartilhada serão rateados conforme definido na gestão administrativa.</p></div>

<div class=""cl""><div class=""cl-t"">Cláusula 4ª — Da Gestão Administrativa</div>
<p>A gestão administrativa da parceria será realizada da seguinte forma: {F("gestaoAdministrativa")}.</p></div>

<div class=""cl""><div class=""cl-t"">Cláusula 5ª — Da Divisão de Receitas</div>
<p><strong>5.1.</strong> A divisão de receitas será realizada conforme: {F("divisaoReceitas")}.</p>
<p><strong>5.2.</strong> Valor fixo mensal: R$ {F("valorFixo")}. Percentual sobre receitas: {F("percentualReceitas")}%.</p>
<p><strong>5.3.</strong> A prestação de contas será mensal, com relatório detalhado de atendimentos e receitas.</p></div>

<div class=""cl""><div class=""cl-t"">Cláusula 6ª — Das Responsabilidades Profissionais</div>
<p><strong>6.1.</strong> Cada PARCEIRA é individualmente responsável pelos atos profissionais de seus respectivos médicos e colaboradores, respondendo civil e eticamente perante os conselhos profissionais competentes.</p>
<p><strong>6.2.</strong> As PARCEIRAS obrigam-se a manter regulares todas as suas inscrições perante o CRM, ANVISA e demais órgãos reguladores.</p></div>

<div class=""cl""><div class=""cl-t"">Cláusula 7ª — Dos Pacientes e Prontuários</div>
<p><strong>7.1.</strong> Os prontuários médicos serão mantidos em conformidade com a Resolução CFM nº 1.638/2002 e com a LGPD (Lei nº 13.709/2018).</p>
<p><strong>7.2.</strong> O compartilhamento de informações de pacientes entre as PARCEIRAS somente ocorrerá mediante consentimento expresso do paciente e para fins estritamente clínicos.</p></div>

<div class=""cl""><div class=""cl-t"">Cláusula 8ª — Da Confidencialidade</div>
<p>As PARCEIRAS obrigam-se a manter sigilo absoluto sobre informações comerciais, financeiras, estratégicas e de pacientes, durante a vigência e por 2 (dois) anos após o encerramento deste contrato.</p></div>

<div class=""cl""><div class=""cl-t"">Cláusula 9ª — Da Conformidade Regulatória</div>
<p>As PARCEIRAS comprometem-se a manter conformidade com as normas da ANVISA (RDC nº 50/2002 e demais aplicáveis), do CFM, dos CRMs estaduais e demais legislações sanitárias vigentes.</p></div>

<div class=""cl""><div class=""cl-t"">Cláusula 10ª — Da Vigência</div>
<p>O presente contrato vigorará pelo prazo de {F("vigencia")} meses, a partir de {F("dataInicio")}, podendo ser prorrogado mediante Termo Aditivo.</p></div>

<div class=""cl""><div class=""cl-t"">Cláusula 11ª — Da Rescisão</div>
<p><strong>11.1.</strong> O presente contrato poderá ser rescindido: a) por mútuo acordo entre as partes; b) unilateralmente, mediante comunicação por escrito com antecedência mínima de 60 dias; c) por inadimplemento de qualquer cláusula, não sanado em 30 dias após notificação; d) por cassação ou suspensão do registro profissional de qualquer das partes.</p>
<p><strong>11.2.</strong> Em caso de rescisão, os atendimentos já agendados deverão ser honrados ou transferidos, resguardando os interesses dos pacientes.</p></div>

<div class=""cl""><div class=""cl-t"">Cláusula 12ª — Do Foro</div>
<p>As partes elegem o foro da Comarca de {F("foro")} para dirimir quaisquer controvérsias (art. 63 do CPC).</p></div>
{Fecho(F, d)}
<div class=""sigs""><div class=""sig""><div class=""n"">{R("nomeClinica1")}</div><div class=""d"">CNPJ: {R("cnpjClinica1")}</div></div><div class=""sig""><div class=""n"">{R("nomeClinica2")}</div><div class=""d"">CNPJ: {R("cnpjClinica2")}</div></div></div>
{Wit(R)}";

    // ─────────────────────────────────────────────────────────────────────────
    //  SERVICO CONTABIL
    // ─────────────────────────────────────────────────────────────────────────
    private string GenContabilidade(Func<string, string> F, Func<string, string> R, string d) => $@"
<div class=""header""><h1>Contrato de Prestação de Serviços Contábeis</h1><div class=""subtitle"">Instrumento Particular — Código Civil, Resoluções do CFC e Normas Brasileiras de Contabilidade</div></div>
<p class=""preambulo"">Pelo presente instrumento particular e na melhor forma de direito, as partes a seguir qualificadas celebram o presente Contrato de Prestação de Serviços Contábeis, regido pela Lei nº 10.406/2002 (Código Civil), pelo Decreto-Lei nº 9.295/1946, pelas Resoluções do Conselho Federal de Contabilidade (CFC) e pelas Normas Brasileiras de Contabilidade (NBCs).</p>

<div class=""cl""><div class=""cl-t"">Cláusula 1ª — Das Partes</div>
<p><strong>1.1. ESCRITÓRIO CONTÁBIL:</strong> {F("nomeEscritorio")}, CNPJ nº {F("cnpjEscritorio")}, CRC nº {F("crc")}, responsável técnico {F("responsavelTecnico")}, com sede em {F("endEscritorio")}, e-mail {F("emailEscritorio")}, doravante denominado simplesmente <strong>ESCRITÓRIO</strong>.</p>
<p><strong>1.2. EMPRESA CLIENTE:</strong> {F("nomeEmpresa")}, CNPJ nº {F("cnpjEmpresa")}, representada por {F("representante")}, com sede em {F("endEmpresa")}, e-mail {F("emailEmpresa")}, regime tributário: {F("regimeTributario")}, doravante denominada simplesmente <strong>CLIENTE</strong>.</p></div>

<div class=""cl""><div class=""cl-t"">Cláusula 2ª — Do Objeto</div>
<p><strong>2.1.</strong> O presente contrato tem por objeto a prestação de serviços contábeis pelo ESCRITÓRIO à CLIENTE, compreendendo:</p>
<p class=""s"">a) Escrituração contábil e fiscal em conformidade com as Normas Brasileiras de Contabilidade;</p>
<p class=""s"">b) Obrigações acessórias: {F("obrigacoesAcessorias")};</p>
<p class=""s"">c) Folha de pagamento: {F("folhaPagamento")} — quantidade de funcionários: {F("quantidadeFuncionarios")};</p>
<p class=""s"">d) Consultoria tributária: {F("consultoriaTributaria")};</p>
<p class=""s"">e) Elaboração de demonstrações contábeis (Balanço Patrimonial, DRE, DMPL e Notas Explicativas).</p></div>

<div class=""cl""><div class=""cl-t"">Cláusula 3ª — Das Obrigações do Escritório</div>
<p>O ESCRITÓRIO obriga-se a: a) executar os serviços contábeis com zelo, diligência e observância das Normas Brasileiras de Contabilidade (NBCs) e das Resoluções do CFC; b) manter registro regular perante o CRC de sua jurisdição; c) cumprir os prazos de entrega das obrigações fiscais e acessórias; d) orientar a CLIENTE sobre procedimentos contábeis e fiscais; e) manter a CLIENTE informada sobre alterações na legislação tributária que afetem seus negócios; f) disponibilizar os livros e demonstrações contábeis quando solicitado; g) guardar sigilo sobre todas as informações da CLIENTE.</p></div>

<div class=""cl""><div class=""cl-t"">Cláusula 4ª — Das Obrigações da Cliente</div>
<p>A CLIENTE obriga-se a: a) fornecer tempestivamente todos os documentos, informações e dados necessários à execução dos serviços, até o dia 5 (cinco) do mês subsequente; b) comunicar ao ESCRITÓRIO quaisquer alterações societárias, cadastrais ou operacionais; c) efetuar os pagamentos nos prazos estipulados; d) manter organizados os documentos fiscais e contábeis; e) não praticar atos que possam comprometer a regularidade fiscal sem consulta prévia ao ESCRITÓRIO.</p></div>

<div class=""cl""><div class=""cl-t"">Cláusula 5ª — Dos Honorários</div>
<p><strong>5.1.</strong> Os honorários mensais serão de R$ {F("valorMensal")} ({F("valorExtenso")}), a serem pagos mediante {F("formaPagamento")}.</p>
<p><strong>5.2.</strong> Serviços extraordinários não contemplados neste contrato (tais como: auditorias, perícias, consultoria especial, defesas administrativas) serão objeto de orçamento prévio e cobrados separadamente.</p>
<p><strong>5.3.</strong> O atraso no pagamento acarretará multa de 2% sobre o valor em atraso, acrescido de juros de mora de 1% ao mês, pro rata die, e correção monetária pelo IPCA/IBGE.</p>
<p><strong>5.4.</strong> Os honorários serão reajustados anualmente com base no IPCA/IBGE.</p></div>

<div class=""cl""><div class=""cl-t"">Cláusula 6ª — Da Vigência</div>
<p>O presente contrato vigorará pelo prazo de {F("vigencia")} meses, a partir de {F("dataInicio")}, renovando-se automaticamente por iguais períodos, salvo manifestação contrária de qualquer das partes com antecedência mínima de 30 dias.</p></div>

<div class=""cl""><div class=""cl-t"">Cláusula 7ª — Da Confidencialidade</div>
<p>O ESCRITÓRIO se compromete a manter sigilo absoluto sobre todas as informações contábeis, financeiras, fiscais e operacionais da CLIENTE, durante a vigência do contrato e por prazo indeterminado após seu encerramento, em conformidade com o Código de Ética Profissional do Contador.</p></div>

<div class=""cl""><div class=""cl-t"">Cláusula 8ª — Da Responsabilidade</div>
<p><strong>8.1.</strong> O ESCRITÓRIO responde por prejuízos causados à CLIENTE exclusivamente em decorrência de erro, negligência ou imperícia na execução dos serviços contábeis.</p>
<p><strong>8.2.</strong> O ESCRITÓRIO não se responsabiliza por penalidades decorrentes de: a) informações incorretas ou incompletas fornecidas pela CLIENTE; b) atraso na entrega de documentos pela CLIENTE; c) decisões empresariais tomadas pela CLIENTE sem consulta prévia ao ESCRITÓRIO.</p></div>

<div class=""cl""><div class=""cl-t"">Cláusula 9ª — Da Guarda de Documentos</div>
<p><strong>9.1.</strong> O ESCRITÓRIO manterá em boa guarda os documentos que lhe forem confiados, pelo prazo legal de 5 (cinco) anos, contados do encerramento do exercício a que se referem.</p>
<p><strong>9.2.</strong> Ao término do contrato, o ESCRITÓRIO entregará à CLIENTE todos os documentos, livros contábeis e arquivos digitais em até 30 (trinta) dias, mediante protocolo.</p></div>

<div class=""cl""><div class=""cl-t"">Cláusula 10ª — Da Rescisão</div>
<p><strong>10.1.</strong> O presente contrato poderá ser rescindido: a) por mútuo acordo; b) unilateralmente, com aviso prévio de 30 dias; c) por inadimplemento não sanado em 15 dias após notificação; d) por cassação ou suspensão do CRC do ESCRITÓRIO.</p>
<p><strong>10.2.</strong> Em caso de rescisão, o ESCRITÓRIO concluirá as obrigações referentes ao mês em curso.</p></div>

<div class=""cl""><div class=""cl-t"">Cláusula 11ª — Da Proteção de Dados (LGPD)</div>
<p>As partes comprometem-se a observar a Lei Geral de Proteção de Dados (Lei nº 13.709/2018), adotando medidas técnicas e administrativas adequadas para proteger os dados pessoais tratados no âmbito deste contrato.</p></div>

<div class=""cl""><div class=""cl-t"">Cláusula 12ª — Das Comunicações</div>
<p>As comunicações entre as partes serão feitas por escrito aos endereços de e-mail indicados neste instrumento, sendo o recebimento presumido em 3 (três) dias úteis.</p></div>

<div class=""cl""><div class=""cl-t"">Cláusula 13ª — Disposições Gerais</div>
<p>Vincula herdeiros e sucessores. Tolerância não implica novação (art. 361 CC). Alterações somente por Termo Aditivo escrito. Nulidade parcial preserva as demais cláusulas.</p></div>

<div class=""cl""><div class=""cl-t"">Cláusula 14ª — Do Foro</div>
<p>As partes elegem o foro da Comarca de {F("foro")} para dirimir quaisquer controvérsias (art. 63 do CPC).</p></div>
{Fecho(F, d)}
<div class=""sigs""><div class=""sig""><div class=""n"">{R("nomeEscritorio")}</div><div class=""d"">CNPJ: {R("cnpjEscritorio")}<br/>CRC: {R("crc")}</div></div><div class=""sig""><div class=""n"">{R("nomeEmpresa")}</div><div class=""d"">CNPJ: {R("cnpjEmpresa")}</div></div></div>
{Wit(R)}";

    // ─────────────────────────────────────────────────────────────────────────
    //  CONSULTORIA FISCAL / TRIBUTARIA
    // ─────────────────────────────────────────────────────────────────────────
    private string GenConsultoriaFiscal(Func<string, string> F, Func<string, string> R, string d) => $@"
<div class=""header""><h1>Contrato de Consultoria Fiscal e Tributária</h1><div class=""subtitle"">Instrumento Particular — Código Civil e legislação tributária aplicável</div></div>
<p class=""preambulo"">Pelo presente instrumento particular e na melhor forma de direito, as partes a seguir qualificadas celebram o presente Contrato de Consultoria Fiscal e Tributária, regido pela Lei nº 10.406/2002 (Código Civil), pelo Código Tributário Nacional (Lei nº 5.172/1966) e legislação tributária aplicável.</p>

<div class=""cl""><div class=""cl-t"">Cláusula 1ª — Das Partes</div>
<p><strong>1.1. CONSULTOR(A):</strong> {F("nomeConsultor")}, CPF/CNPJ nº {F("cpfCnpj")}, CRC nº {F("crc")}, com endereço em {F("endConsultor")}, e-mail {F("emailConsultor")}, doravante denominado(a) simplesmente <strong>CONSULTOR(A)</strong>.</p>
<p><strong>1.2. EMPRESA:</strong> {F("nomeEmpresa")}, CNPJ nº {F("cnpjEmpresa")}, representada por {F("representante")}, com sede em {F("endEmpresa")}, e-mail {F("emailEmpresa")}, setor de atuação: {F("setorAtuacao")}, doravante denominada simplesmente <strong>EMPRESA</strong>.</p></div>

<div class=""cl""><div class=""cl-t"">Cláusula 2ª — Do Objeto e Escopo</div>
<p><strong>2.1.</strong> O presente contrato tem por objeto a prestação de serviços de consultoria fiscal e tributária pelo(a) CONSULTOR(A) à EMPRESA, abrangendo: {F("escopoConsultoria")}.</p>
<p><strong>2.2.</strong> Tributos em foco: {F("tributosFoco")}.</p>
<p><strong>2.3.</strong> Período de análise: {F("periodoAnalise")}.</p>
<p><strong>2.4.</strong> Quaisquer serviços que extrapolem o escopo definido nesta cláusula deverão ser objeto de Termo Aditivo ou contrato apartado.</p></div>

<div class=""cl""><div class=""cl-t"">Cláusula 3ª — Das Entregas</div>
<p>O(A) CONSULTOR(A) obriga-se a entregar os seguintes produtos: {F("entregas")}.</p></div>

<div class=""cl""><div class=""cl-t"">Cláusula 4ª — Das Obrigações do Consultor</div>
<p>O(A) CONSULTOR(A) obriga-se a: a) executar os serviços com diligência, competência técnica e observância da legislação vigente; b) fundamentar seus pareceres e recomendações em dispositivos legais e normativos aplicáveis; c) manter atualização profissional contínua; d) guardar sigilo absoluto sobre todas as informações obtidas; e) comunicar tempestivamente eventuais riscos fiscais identificados; f) cumprir os prazos de entrega acordados.</p></div>

<div class=""cl""><div class=""cl-t"">Cláusula 5ª — Das Obrigações da Empresa</div>
<p>A EMPRESA obriga-se a: a) fornecer tempestivamente todos os documentos, informações e dados necessários; b) disponibilizar acesso aos sistemas contábeis e fiscais pertinentes; c) indicar colaborador responsável pelo acompanhamento dos trabalhos; d) efetuar os pagamentos nos prazos estipulados; e) comunicar ao(à) CONSULTOR(A) quaisquer alterações em suas operações que possam impactar a análise tributária.</p></div>

<div class=""cl""><div class=""cl-t"">Cláusula 6ª — Dos Honorários</div>
<p><strong>6.1.</strong> O valor total do projeto será de R$ {F("valorProjeto")} ({F("valorExtenso")}), a ser pago mediante {F("formaPagamento")}.</p>
<p><strong>6.2.</strong> O atraso no pagamento acarretará multa de 2% sobre o valor em atraso, acrescido de juros de mora de 1% ao mês.</p></div>

<div class=""cl""><div class=""cl-t"">Cláusula 7ª — Da Confidencialidade</div>
<p>O(A) CONSULTOR(A) compromete-se a manter sigilo absoluto sobre todas as informações fiscais, contábeis, financeiras e estratégicas da EMPRESA, durante a vigência do contrato e por 3 (três) anos após seu encerramento.</p></div>

<div class=""cl""><div class=""cl-t"">Cláusula 8ª — Da Limitação de Responsabilidade</div>
<p><strong>8.1.</strong> O(A) CONSULTOR(A) presta serviço de natureza consultiva e opinativa. Os pareceres e recomendações não constituem garantia de resultado junto às autoridades fiscais.</p>
<p><strong>8.2.</strong> A decisão de adotar ou não as recomendações do(a) CONSULTOR(A) é de exclusiva responsabilidade da EMPRESA, que assume integralmente os riscos das decisões tributárias que vier a tomar.</p>
<p><strong>8.3.</strong> O(A) CONSULTOR(A) não se responsabiliza por autuações, multas ou penalidades decorrentes de: a) informações incorretas ou incompletas fornecidas pela EMPRESA; b) decisões tomadas pela EMPRESA em desacordo com as recomendações apresentadas; c) alterações legislativas posteriores à entrega dos pareceres.</p></div>

<div class=""cl""><div class=""cl-t"">Cláusula 9ª — Da Rescisão</div>
<p>O presente contrato poderá ser rescindido: a) por mútuo acordo; b) unilateralmente, com aviso prévio de 15 dias; c) por inadimplemento não sanado em 10 dias após notificação. A rescisão não exime a EMPRESA do pagamento dos serviços já prestados.</p></div>

<div class=""cl""><div class=""cl-t"">Cláusula 10ª — Da Proteção de Dados (LGPD)</div>
<p>As partes comprometem-se a observar a Lei Geral de Proteção de Dados (Lei nº 13.709/2018), adotando medidas técnicas e administrativas adequadas.</p></div>

<div class=""cl""><div class=""cl-t"">Cláusula 11ª — Disposições Gerais</div>
<p>Tolerância não implica novação. Nulidade parcial preserva as demais cláusulas. Alterações somente por Termo Aditivo escrito.</p></div>

<div class=""cl""><div class=""cl-t"">Cláusula 12ª — Do Foro</div>
<p>As partes elegem o foro da Comarca de {F("foro")} para dirimir quaisquer controvérsias (art. 63 do CPC).</p></div>
{Fecho(F, d)}
<div class=""sigs""><div class=""sig""><div class=""n"">{R("nomeConsultor")}</div><div class=""d"">CPF/CNPJ: {R("cpfCnpj")}<br/>CRC: {R("crc")}</div></div><div class=""sig""><div class=""n"">{R("nomeEmpresa")}</div><div class=""d"">CNPJ: {R("cnpjEmpresa")}</div></div></div>
{Wit(R)}";

    // ─────────────────────────────────────────────────────────────────────────
    //  ABERTURA DE EMPRESA
    // ─────────────────────────────────────────────────────────────────────────
    private string GenAberturaEmpresa(Func<string, string> F, Func<string, string> R, string d) => $@"
<div class=""header""><h1>Contrato de Prestação de Serviços para Abertura de Empresa</h1><div class=""subtitle"">Instrumento Particular — Código Civil e legislação empresarial</div></div>
<p class=""preambulo"">Pelo presente instrumento particular e na melhor forma de direito, as partes a seguir qualificadas celebram o presente Contrato de Prestação de Serviços para Abertura e Constituição de Pessoa Jurídica, regido pela Lei nº 10.406/2002 (Código Civil), Lei Complementar nº 123/2006 (Estatuto da Microempresa) e demais legislações aplicáveis.</p>

<div class=""cl""><div class=""cl-t"">Cláusula 1ª — Das Partes</div>
<p><strong>1.1. PRESTADOR DE SERVIÇO:</strong> {F("nomeEscritorio")}, CNPJ nº {F("cnpjEscritorio")}, CRC nº {F("crc")}, representado por {F("representante")}, e-mail {F("emailEscritorio")}, doravante denominado simplesmente <strong>PRESTADOR</strong>.</p>
<p><strong>1.2. CLIENTE:</strong> {F("nomeCliente")}, inscrito(a) no CPF sob o nº {F("cpfCliente")}, e-mail {F("emailCliente")}, doravante denominado(a) simplesmente <strong>CLIENTE</strong>.</p></div>

<div class=""cl""><div class=""cl-t"">Cláusula 2ª — Do Objeto</div>
<p>O presente contrato tem por objeto a prestação de serviços pelo PRESTADOR para a abertura e constituição de pessoa jurídica com as seguintes características:</p>
<p class=""s"">a) Nome empresarial pretendido: {F("nomeEmpresarial")};</p>
<p class=""s"">b) Tipo societário: {F("tipoSocietario")};</p>
<p class=""s"">c) Atividade principal (CNAE): {F("atividadePrincipal")};</p>
<p class=""s"">d) Atividades secundárias: {F("atividadesSecundarias")};</p>
<p class=""s"">e) Capital social: R$ {F("capitalSocial")};</p>
<p class=""s"">f) Endereço da sede: {F("enderecoSede")};</p>
<p class=""s"">g) Quadro societário: {F("socios")}.</p></div>

<div class=""cl""><div class=""cl-t"">Cláusula 3ª — Do Escopo dos Serviços</div>
<p>O PRESTADOR realizará as seguintes atividades:</p>
<p class=""s"">a) Consulta prévia de viabilidade de nome empresarial junto à Junta Comercial;</p>
<p class=""s"">b) Elaboração do Contrato Social ou Requerimento de Empresário;</p>
<p class=""s"">c) Registro na Junta Comercial do Estado;</p>
<p class=""s"">d) Inscrição no Cadastro Nacional de Pessoas Jurídicas (CNPJ) junto à Receita Federal;</p>
<p class=""s"">e) Inscrição Estadual (se aplicável);</p>
<p class=""s"">f) Inscrição Municipal e obtenção de Alvará de Funcionamento;</p>
<p class=""s"">g) Obtenção de Certificado Digital (e-CNPJ);</p>
<p class=""s"">h) Enquadramento no regime tributário adequado;</p>
<p class=""s"">i) Demais providências administrativas necessárias à regularização da empresa.</p></div>

<div class=""cl""><div class=""cl-t"">Cláusula 4ª — Dos Prazos</div>
<p><strong>4.1.</strong> O prazo estimado para conclusão dos serviços é de {F("prazoEstimado")}, contados a partir da entrega completa de toda a documentação pelo CLIENTE.</p>
<p><strong>4.2.</strong> O prazo poderá ser prorrogado em razão de: a) exigências ou pendências dos órgãos públicos; b) atraso na entrega de documentação pelo CLIENTE; c) caso fortuito ou força maior.</p></div>

<div class=""cl""><div class=""cl-t"">Cláusula 5ª — Das Obrigações do Cliente</div>
<p>O CLIENTE obriga-se a: a) fornecer tempestivamente todos os documentos pessoais e societários solicitados pelo PRESTADOR; b) prestar informações verdadeiras e completas; c) arcar com todas as taxas, emolumentos e custas de órgãos públicos (Junta Comercial, Receita Federal, Prefeitura, etc.); d) efetuar os pagamentos nos prazos estipulados; e) responder pela veracidade das informações prestadas para fins de registro.</p></div>

<div class=""cl""><div class=""cl-t"">Cláusula 6ª — Dos Honorários</div>
<p><strong>6.1.</strong> O valor dos serviços profissionais será de R$ {F("valorServico")} ({F("valorExtenso")}), a ser pago mediante {F("formaPagamento")}.</p>
<p><strong>6.2.</strong> O valor dos honorários não inclui taxas governamentais (Junta Comercial, DARE, emolumentos, certificado digital), que serão de responsabilidade exclusiva do CLIENTE.</p>
<p><strong>6.3.</strong> Serviços adicionais não previstos neste escopo serão objeto de orçamento prévio.</p></div>

<div class=""cl""><div class=""cl-t"">Cláusula 7ª — Da Responsabilidade</div>
<p><strong>7.1.</strong> O PRESTADOR se compromete a executar os serviços com zelo e competência técnica, em conformidade com a legislação vigente.</p>
<p><strong>7.2.</strong> O PRESTADOR não se responsabiliza por: a) indeferimento de registros por motivos alheios à sua atuação; b) informações falsas ou incorretas prestadas pelo CLIENTE; c) alterações legislativas supervenientes que inviabilizem o registro; d) demora de órgãos públicos no processamento dos pedidos.</p></div>

<div class=""cl""><div class=""cl-t"">Cláusula 8ª — Da Confidencialidade</div>
<p>O PRESTADOR compromete-se a manter sigilo sobre todas as informações pessoais, financeiras e societárias do CLIENTE, durante a vigência e por prazo indeterminado após o encerramento do contrato.</p></div>

<div class=""cl""><div class=""cl-t"">Cláusula 9ª — Da Rescisão</div>
<p><strong>9.1.</strong> O presente contrato poderá ser rescindido: a) por mútuo acordo; b) unilateralmente, com comunicação por escrito; c) por inadimplemento de qualquer das partes.</p>
<p><strong>9.2.</strong> Em caso de rescisão por desistência do CLIENTE após o início dos trabalhos, não haverá devolução dos valores referentes a serviços já executados e taxas governamentais já recolhidas.</p></div>

<div class=""cl""><div class=""cl-t"">Cláusula 10ª — Da Proteção de Dados (LGPD)</div>
<p>As partes comprometem-se a observar a Lei Geral de Proteção de Dados (Lei nº 13.709/2018), adotando medidas adequadas para proteger os dados pessoais tratados no âmbito deste contrato.</p></div>

<div class=""cl""><div class=""cl-t"">Cláusula 11ª — Disposições Gerais</div>
<p>Tolerância não implica novação. Nulidade parcial preserva as demais cláusulas. Alterações somente por Termo Aditivo escrito.</p></div>

<div class=""cl""><div class=""cl-t"">Cláusula 12ª — Do Foro</div>
<p>As partes elegem o foro da Comarca de {F("foro")} para dirimir quaisquer controvérsias (art. 63 do CPC).</p></div>
{Fecho(F, d)}
<div class=""sigs""><div class=""sig""><div class=""n"">{R("nomeEscritorio")}</div><div class=""d"">CNPJ: {R("cnpjEscritorio")}<br/>CRC: {R("crc")}</div></div><div class=""sig""><div class=""n"">{R("nomeCliente")}</div><div class=""d"">CPF: {R("cpfCliente")}</div></div></div>
{Wit(R)}";
}
