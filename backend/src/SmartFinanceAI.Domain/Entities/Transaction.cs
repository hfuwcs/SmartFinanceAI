using SmartFinanceAI.Domain.Common;

public class Transaction: BaseEntity 
{
    public Guid UserId { get; set; }
    public DateTime TransactionDate { get; set; }
    public string ProviderName { get; set; } = string.Empty;
    public string Note { get; set; } = string.Empty;

    // Original amount in the transaction's currency
    public Guid CurrencyId { get; set; }
    public Currency Currency { get; set; } = null!;
    public decimal TotalAmount { get; set; }

    // Real time exchange rate at the time of transaction
    public decimal ExchangeRate { get; set; }

    public ICollection<TransactionItem> Items { get; set; } = new List<TransactionItem>();
}