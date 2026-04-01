namespace ContratoExpress.Client.Models;
public class ContractField
{
    public string Key { get; set; } = "";
    public string Label { get; set; } = "";
    public bool IsTextArea { get; set; }
    public string? Section { get; set; }
}

public class ContractType
{
    public string Id { get; set; } = "";
    public string Icon { get; set; } = "";
    public string Title { get; set; } = "";
    public string Description { get; set; } = "";
    public string AccentColor { get; set; } = "";
    public string Category { get; set; } = "Geral";
    public string? ImageUrl { get; set; }
    public List<ContractField> Fields { get; set; } = new();
}
