using System.Security.Cryptography;

namespace ApartmentReservationWeb.RSATools
{
    public class RSAExtensions
    {
        public static RSA GetPrivateKey()
        {
            var key = File.ReadAllText(@"../ApartmentReservationWeb/Keys/private_key.pem");
            var rsa = RSA.Create();

            rsa.ImportFromPem(key);

            return rsa;
        }

        public static RSA GetPublicKey()
        {
            var key = File.ReadAllText(@"../ApartmentReservationWeb/Keys/public_key.pem");
            var rsa = RSA.Create();

            rsa.ImportFromPem(key);

            return rsa;
        }
    }
}
