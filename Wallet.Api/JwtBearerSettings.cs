public class JwtBearerSettings
{
    public string Authority { get; set; }
    public string Audience { get; set; }
    // TODO: Configure Https support.
    public bool RequireHttpsMetadata => false;
    public IEnumerable<string> ValidTypes { get; set; }
}
