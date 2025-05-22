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
        public string Value => HashedValue;

        // برای EF (Entity Framework)
        private Password() { }

            private Password(string hashedValue)
            {
                HashedValue = hashedValue;
            }

            public Password(Password password)
            {
                if (password == null)
                    throw new ArgumentNullException(nameof(password));

                HashedValue = password.HashedValue;
            }

            // ساخت پسورد از رمز خام و هش کردن آن
            public static Password Create(string plainTextPassword, IPasswordHasher passwordHasher)
            {
                if (string.IsNullOrWhiteSpace(plainTextPassword))
                    throw new ArgumentException("رمز عبور نمی‌تواند خالی باشد.", nameof(plainTextPassword));

                if (passwordHasher is null)
                    throw new ArgumentNullException(nameof(passwordHasher));

                var hashed = passwordHasher.HashPassword(plainTextPassword);

                return new Password(hashed);
            }

            // ساخت پسورد از مقدار هش‌شده (مثلاً هنگام بازیابی از دیتابیس یا جیسون)
            public static Password CreateFromHashed(string hashedValue)
            {
                if (string.IsNullOrWhiteSpace(hashedValue))
                    throw new ArgumentException("مقدار هش نمی‌تواند خالی باشد.", nameof(hashedValue));

                return new Password(hashedValue);
            }

            protected override IEnumerable<object> GetEqualityComponents()
            {
                yield return HashedValue;
            }

            public override string ToString() => HashedValue;

        /*  public static Password Create(Password password, IPasswordHasher passwordHasher)
          {
              throw new NotImplementedException();
          }*/
        

        // ✅ اضافه کردن operator های مقایسه
        public static bool operator ==(Password left,Password right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Password left, Password right)
        {
            return !Equals(left, right);
        }
    }
    }

       