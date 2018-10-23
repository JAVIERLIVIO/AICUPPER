using System;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Text;

namespace aicupper.util
{
    public class hasher
    {
        private string SALTED_STRING = "k6NOjpoaQTRxRnqtx47Uow==";
        private string hashed = "";
        public hasher(string salter, string password) {
            this.SALTED_STRING = salter;
            this.hash(password);
        }
        public hasher(string password) {
            this.hash(password);
        }
        
        public string HashedPassword {
            get { return hashed;}
        }
        private void hash(string password) {
            // generate a 128-bit salt using a secure PRNG
            byte[] salt = new byte[128 / 8];

            // derive a 256-bit subkey (use HMACSHA1 with 10,000 iterations)
            this.hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: Encoding.ASCII.GetBytes(SALTED_STRING),
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8)); 
        } 
        public string GenerateSalterText() {
            byte[] salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
                return Convert.ToBase64String(salt);
            } 
        }
    }
}