using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.JWT
{
    public class TokenOptions
    { 
    public string Audience { get; set; }//Bizim token'ımızın kullanıcı kitlesi
    public string Issuer { get; set; }// imlzayanı
    public int AccessTokenExpiration { get; set; }//Token gerçerlilik süresi 
    public string SecurityKey { get; set; }
    }
}
