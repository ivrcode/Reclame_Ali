using System.Security.Cryptography;
using System.Text;

namespace Gsn_ReclameAli.Common
{
    public static class Helpers
    {
        const string _chave = "abcdefghijklmnopqrstBRB-VIAGENSuvwxyzABCDEFGHIJKLMNOPQKRSTUVWXYZ1234567890@#$%";

     

        public static bool IsSenhaUsuarioCorreta(string input, string senha)
        {
            if (string.IsNullOrEmpty(input) || string.IsNullOrEmpty(senha))
                return false;

            byte[] inputBytes = Convert.FromBase64String(input);
            byte[] key;

            using (SHA256 sha = SHA256.Create())
                key = sha.ComputeHash(Encoding.UTF8.GetBytes(senha));

            int lenIV = inputBytes[0];
            byte[] iv = new byte[lenIV];
            Buffer.BlockCopy(inputBytes, 1, iv, default, lenIV);

            byte[] encrypted = new byte[inputBytes.Length - 1 - lenIV];
            Buffer.BlockCopy(inputBytes, 1 + lenIV, encrypted, default, encrypted.Length);

            string decrypted = string.Empty;
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Mode = CipherMode.ECB;
                aesAlg.Padding = PaddingMode.Zeros;
                aesAlg.IV = iv;
                aesAlg.Key = key;

                ICryptoTransform decryptor = aesAlg.CreateDecryptor();
                using MemoryStream msDecrypt = new(encrypted);
                using CryptoStream csDecrypt = new(msDecrypt, decryptor, CryptoStreamMode.Read);
                using StreamReader srDecrypt = new(csDecrypt);
                decrypted = srDecrypt.ReadToEnd();
            }

            return decrypted.StartsWith(_chave);
        }
    }
}
