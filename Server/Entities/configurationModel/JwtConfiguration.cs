namespace Entities.configurationModel;

public class JwtConfiguration
{
    public string Section { get; set; } = "JwtSettings";
    public string Secret { get; set; } = "make it securesdddddddddddsdsdsdsdsdffsddddddaaaaewtettttetetewtewtwetewtewtwe";
    public string ValidIssuer { get; set; }
    public string ValidAudience { get; set; }
    public int Expires { get; set; }
}