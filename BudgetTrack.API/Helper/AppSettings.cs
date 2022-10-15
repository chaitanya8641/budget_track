namespace BudgetTrack.API.Helper
{
    public class AppSettings
    {
        public string SecretKey { get; set; } = null!;
        public string Expires { get; set; } = null!;
        public string Issuer { get; set; } = null!;
        public string Audience { get; set; } = null!;
    }
}
