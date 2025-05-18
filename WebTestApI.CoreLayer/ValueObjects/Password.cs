using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTestApI.CoreLayer.Interface;

namespace WebTestApI.CoreLayer.ValueObjects
{
 public class Password : ValueObject
    {
        public string HashedValue { get; private set; }

        // برای EF
        private Password() { }


        private Password(string hashedValue)
        {
            HashedValue = hashedValue;
        }

        public Password(Password password)
        {
        }

        public static Password Create(string plainTextPassword, IPasswordHasher passwordHasher)
        {
            if (string.IsNullOrWhiteSpace(plainTextPassword))
                throw new ArgumentException("رمز عبور نمی‌تواند خالی باشد.", nameof(plainTextPassword));

            if (passwordHasher is null)
                throw new ArgumentNullException(nameof(passwordHasher));

            var hashed = passwordHasher.HashPassword(plainTextPassword);

            return new Password(hashed);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return HashedValue;
        }

        public override string ToString() => HashedValue;
    }
}
