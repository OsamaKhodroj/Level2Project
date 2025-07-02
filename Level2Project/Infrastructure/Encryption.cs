using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class Encryption
    {
        public static string Hash(string text)
        {
            if (string.IsNullOrEmpty(text))
                throw new ArgumentException("Text to hash cannot be null or empty.", nameof(text));
             
            var result = BCrypt.Net.BCrypt.HashPassword(text);
            return result;
        }

        public static bool Verfiy(string text, string hash)
        {
            if (string.IsNullOrEmpty(text))
                throw new ArgumentException("Text to verify cannot be null or empty.", nameof(text));
            if (string.IsNullOrEmpty(hash))
                throw new ArgumentException("Hash to verify against cannot be null or empty.", nameof(hash));

            var result = BCrypt.Net.BCrypt.Verify(text, hash);
            return result;
        } 
    }
}
