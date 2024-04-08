using Microsoft.VisualBasic;

namespace Multishop.IdentityServer.Tools
{
    public class JwtTokenDefaults
    {
        //Tokenımıza vereceğimiz özel bir bilgidir. Bu bilgi ile tokenımız oluşacak ve eğer gelen tokendaki bu bilgi farklı ise giriş işlemi başarısız olacaktır.
        //ValidateAudience: Request isteğinde gelen tokenın ValidAudience bilgisinin doğruluğunun kontrol edilip edilmemesi kısmı.Eğer bu özellik false olursa tokenın ValidAudience değerinin bir önemi yoktur.
        public const string ValidAudience = "http://localhost";

        //— ValidIssuer: Tokenın hangi sunucu tarafından oluşturulduğu bilgisinin verildiği kısımdır. Token’a verdiğimiz ekstra güvenlik bilgisi gibi düşünebiliriz.
        //ValidateIssuer: Request isteğinde gelen tokenın ValidIssuer bilgisinin doğruluğunun kontrol edilip edilmemesi kısmı.Eğer bu özellik false olursa tokenın ValidIssuer değerinin bir önemi yoktur.
        public const string ValidIssuer = "http://localhost";

        // Tokenımızı oluştururken kullanacağımız secret keyimizdir. Tokenımızın güvenlik anahtarı diyebiliriz.
        //— ValidateIssuerSigningKey: Request isteğinde gelen tokenın IssuerSigningKey bilgisinin doğruluğunun kontrol edilip edilmemesi kısmı. Eğer bu özellik false olursa tokenın IssuerSigningKey değerinin bir önemi yoktur.
        public const string Key = "MultiShop..0102030405Asp.NetCore6.0.28*/+-";

        //Tokenın ömrünün(expires) kullanılıp kullanılmayacağının belirlendiği kısımdır.Eğer bu özellik false olursa tokenın ömrünün bir önemi yoktur.
        public const int Expire = 60;
    }
}
