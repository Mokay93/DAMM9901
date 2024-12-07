using System;

namespace PasswordManager.Models
{
    public class PasswordEntry
    {
        public string Service { get; set; }
        public string Username { get; set; }
        public string EncryptedPassword { get; private set; }
        public string DecryptedPassword => EncryptionService.Decrypt(EncryptedPassword);

        public PasswordEntry(string service, string username, string password)
        {
            Service = service;
            Username = username;
            EncryptedPassword = EncryptionService.Encrypt(password);
        }
    }
} 