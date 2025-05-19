using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using WebTestApI.CoreLayer.ValueObjects;

namespace WebTestApI.InfrastructureLayer.Serialization.Converters
{
    public class ValueObjectJsonConverter<T> : JsonConverter<T> where T : class
    {
        private readonly MethodInfo _createMethod;
        private readonly PropertyInfo _valueProperty;

        public ValueObjectJsonConverter()
        {
            // اگر کلاس Password باشد، استفاده از این کانورتر مجاز نیست
            if (typeof(T) == typeof(Password))
            {
                throw new InvalidOperationException($"Use dedicated converter for type {typeof(T)}.");
            }

            // پیدا کردن متد استاتیک Create(string)
            _createMethod = typeof(T).GetMethod("Create", new[] { typeof(string) });
            if (_createMethod == null)
            {
                throw new InvalidOperationException(
                    $"Type {typeof(T)} must have a static Create(string) method.");
            }

            // پیدا کردن پراپرتی Value که مقدار داخلی را نگه می‌دارد
            _valueProperty = typeof(T).GetProperty("Value");
            if (_valueProperty == null)
            {
                throw new InvalidOperationException(
                    $"Type {typeof(T)} must have a 'Value' property.");
            }
        }

        public override T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var stringValue = reader.GetString();
            if (stringValue == null)
                return null;

            // ساخت آبجکت از مقدار رشته‌ای با استفاده از متد Create
            return (T)_createMethod.Invoke(null, new object[] { stringValue });
        }

        public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
        {
            // خواندن مقدار Value از آبجکت و نوشتن آن در JSON
            var stringValue = (string)_valueProperty.GetValue(value);
            writer.WriteStringValue(stringValue);
        }
    }
}
