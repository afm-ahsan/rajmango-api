namespace RajMango.Application.DTOs
{
    public class SslPaymentDto : AuditedDto
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public int TranId { get; set; }
        public DateTime TranDate { get; set; }
        public string ValId { get; set; }
        public decimal Amount { get; set; }
        public decimal StoreAmount { get; set; }
        public string CardType { get; set; }
        public string CardNo { get; set; }
        public string Currency { get; set; }
        public string BankTranId { get; set; }
        public string CardIssuer { get; set; }
        public string CardBrand { get; set; }
        public string CardIssuerCountry { get; set; }
        public string CardIssuerCountryCode { get; set; }
        public string CurrencyType { get; set; }
        public string CurrencyAmount { get; set; }
        public string ValueA { get; set; }
        public string ValueB { get; set; }
        public string ValueC { get; set; }
        public string ValueD { get; set; }
        public string VarifySign { get; set; }
        public string VerifyKey { get; set; }
        public byte RiskLevel { get; set; }
        public string RiskTitle { get; set; }
        public string Full { get; set; }
        public string Validation { get; set; }
    }
}
