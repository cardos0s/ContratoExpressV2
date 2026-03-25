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
                ? $"<span class=\"field\">{val}</span>"
                : "<span class=\"field\">_______________</span>";

        string R(string key) =>
            data.TryGetValue(key, out var val) ? val ?? "" : "";

        var body = type.Id switch
        {
            "prestacao" => GenPrestacao(F, R, dateStr),
            "freelancer" => GenFreelancer(F, R, dateStr),
            "locacao" => GenLocacao(F, R, dateStr),
            "nda" => GenNda(F, R, dateStr),
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
}
