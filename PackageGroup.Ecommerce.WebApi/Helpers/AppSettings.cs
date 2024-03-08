namespace PackageGroup.Ecommerce.WebApi.Helpers
{
    public class AppSettings
    {
        public string OriginCors { get; set; } = null!;
        public string Secret { get; set; } = null!;
        public string Issuer { get; set; } = null!;
        public string Audience { get; set; } = null!;
    }
}
