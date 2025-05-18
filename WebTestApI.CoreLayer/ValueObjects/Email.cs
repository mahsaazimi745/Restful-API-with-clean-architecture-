using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WebTestApI.CoreLayer.ValueObjects
{
    public class Email:ValueObject
    {
        public string Value { get; }

        public Email(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("ایمیل نمی‌تواند خالی باشد.");

            if (!Regex.IsMatch(value, @"^[\w\.-]+@[\w\.-]+\.\w+$"))
                throw new ArgumentException("فرمت ایمیل معتبر نیست.");

            Value = value;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value.ToLower(); // برای نادیده گرفتن بزرگی حروف
        }

        public override string ToString() => Value;

        public static Email Create(Email email)
        {
            throw new NotImplementedException();
        }
    }

}

 