using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WebTestApI.CoreLayer.ValueObjects
{

    public class NationalCode:ValueObject
    {
        public string Value { get; private set; }

        // برای EF نیاز به constructor بدون پارامتر داری
        private NationalCode() { }

        private NationalCode(string value)
        {
            Value = value;
        }

        public static NationalCode Create(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("کد ملی نمی‌تواند خالی باشد.", nameof(value));

            if (!IsValid(value))
                throw new ArgumentException("کد ملی معتبر نیست.", nameof(value));

            return new NationalCode(value);
        }

        private static bool IsValid(string code)
        {
            if (!Regex.IsMatch(code, @"^\d{10}$"))
                return false;

            var check = int.Parse(code[9].ToString());
            var sum = Enumerable.Range(0, 9)
                .Select(i => int.Parse(code[i].ToString()) * (10 - i))
                .Sum();

            var remainder = sum % 11;

            return (remainder < 2 && check == remainder) ||
                   (remainder >= 2 && check == (11 - remainder));
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

        public override string ToString() => Value;

        public static NationalCode Create(NationalCode nationalCode)
        {
            throw new NotImplementedException();
        }
    }


}
  