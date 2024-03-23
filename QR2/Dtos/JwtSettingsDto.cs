namespace QR2.Dtos
{
    public class JwtSettingsDto
    {
    public bool ValidateIssuerSigninKey { get; set; }
    public string IssuerSigninKey { get; set; } = string.Empty;
    public bool ValidateIssuer { get; set; } = true;
    public string ValidIssuer { get; set; } = string.Empty;
    public bool ValidateAudience {  get; set; } = true;
    public string ValidAudience { get; set; } = string.Empty;
    public bool RequireExpirationTime { get; set; }
    public bool FlagExpirationTimeHours { get; set; }
    public int ExpirationTimeHours { get; set; }
    public bool FlagExpirationTimeMinutes { get; set; }
    public int ExpirationTimeMinutes { get; set; }
        public bool ValidateLifetime { get; set; } = true;
    }
}
