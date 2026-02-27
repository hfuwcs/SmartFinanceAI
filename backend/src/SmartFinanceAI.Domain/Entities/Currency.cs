using SmartFinanceAI.Domain.Common;

public class Currency : BaseEntity
{
    public string Code { get; set; } = string.Empty; // e.g., USD, EUR
    public string Name { get; set; } = string.Empty; // e.g., US Dollar, Euro
    public string Symbol { get; set; } = string.Empty; // e.g., $, €
}