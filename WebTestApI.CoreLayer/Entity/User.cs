using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTestApI.CoreLayer.ValueObjects;

namespace WebTestApI.CoreLayer.Entity
{
    public class User
    {
        public Guid Id { get; private set; }
        public string FirstName { get; private set; }
        public string LatstName { get; private set; }
        public int Age { get; private set; }
        public string FatherName { get; private set; }
        public NationalCode NationalCode { get; private set; }
        public PhoneNumber PhoneNumber { get; private set; }
        public Email Email { get; private set; }
        public Password passwordHash { get; private set; }
        private User() { }
        public User(string firstName, string lastName, string fatherName, int age, NationalCode nationalCode, PhoneNumber phoneNumber, Email email, Password password)
        {
            Id = Guid.NewGuid();

            FirstName = firstName ?? throw new ArgumentNullException(nameof(firstName));
            LatstName = lastName ?? throw new ArgumentNullException(nameof(lastName));
            FatherName = fatherName ?? throw new ArgumentNullException(nameof(fatherName));

            Age = age > 0
                ? age
                : throw new ArgumentException("Age must be positive.", nameof(age));

            NationalCode = nationalCode ?? throw new ArgumentNullException(nameof(nationalCode));
            PhoneNumber = phoneNumber ?? throw new ArgumentNullException(nameof(phoneNumber));
            Email = email ?? throw new ArgumentNullException(nameof(email));
            passwordHash = password ?? throw new ArgumentNullException(nameof(password));

        }
        public string FullName => $"{FirstName} {LatstName}";
    }
}
