namespace VCA.Services.Invoices
{
    public interface IInvoiceRepository
    {
        Task<List<Dictionary<string, object>>> FindInvoiceByInvoiceIdAsync(int InvoiceId);
    }
}
