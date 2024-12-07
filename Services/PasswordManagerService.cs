using System;
using System.Collections.Generic;
using System.Linq;
using PasswordManager.Models;

namespace PasswordManager.Services
{
    public class PasswordManagerService
    {
        private List<PasswordEntry> passwords;

        public PasswordManagerService()
        {
            passwords = new List<PasswordEntry>();
        }

        public void AddPassword(PasswordEntry entry)
        {
            passwords.Add(entry);
        }

        public IEnumerable<PasswordEntry> GetAllPasswords()
        {
            return passwords;
        }

        public bool DeletePassword(string service)
        {
            var entry = passwords.FirstOrDefault(p => p.Service.Equals(service, StringComparison.OrdinalIgnoreCase));
            if (entry != null)
            {
                passwords.Remove(entry);
                return true;
            }
            return false;
        }
    }
} 