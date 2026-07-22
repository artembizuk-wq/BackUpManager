using _1СBackUpManager.Models;
using System.Security.Cryptography;
using System.Text;



namespace _1СBackUpManager.Services
{
    internal class CredentialService
    {
       
        // 32 байти = AES-256
        private static readonly byte[] Key =
        [
            0x15,0x83,0x49,0x91,0x27,0x52,0x66,0x70,
            0x88,0x11,0xC4,0x8A,0xD1,0x34,0xA0,0xB3,
            0x61,0x9F,0x55,0x22,0x73,0x84,0x45,0xC8,
            0x12,0x94,0x67,0x31,0x5A,0x9D,0xEF,0x10
        ];

        private static readonly byte[] IV =
        [
            0x31,0x44,0x82,0x91,
            0x17,0x63,0x55,0x70,
            0xA1,0x19,0x24,0xF5,
            0x66,0x41,0x72,0x90
        ];

        public void Save(Credentials credentials)
        {
            string text = $"{credentials.UserName}\n{credentials.Password}";

            byte[] bytes = Encoding.UTF8.GetBytes(text);

            using Aes aes = Aes.Create();

            aes.Key = Key;
            aes.IV = IV;

            using FileStream fs = File.Create(AppPaths.CredentialsFilePath);
            using CryptoStream crypto = new(fs, aes.CreateEncryptor(), CryptoStreamMode.Write);

            crypto.Write(bytes);
        }

        public Credentials Load()
        {
            using Aes aes = Aes.Create();
            aes.Key = Key;
            aes.IV = IV;

            using FileStream fileStream = File.OpenRead(AppPaths.CredentialsFilePath);
            using CryptoStream crypto = new(fileStream, aes.CreateDecryptor(), CryptoStreamMode.Read);
            using StreamReader reader = new(crypto);

            string[] lines = reader.ReadToEnd().Split('\n');

            return new Credentials
            {
                UserName = lines[0],
                Password = lines[1]
            };
        }
    }
}
