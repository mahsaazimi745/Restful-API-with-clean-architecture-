using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTestApI.CoreLayer.ValueObjects;
using WebTestApI.CoreLayer.Interface;

namespace WebTestApI.CoreLayer.Entity
{
    /*  public class Admin:User
      {
          public Admin(string firstName, string lastName, string fatherName, int age,
                       NationalCode nationalCode, PhoneNumber phoneNumber,
                       Email email, Password password)
              : base(firstName, lastName, fatherName, age, nationalCode, phoneNumber, email, password)
          {
          }
      }*/
    public class Admin : User
    {
        // سازنده protected یا private برای جلوگیری از ساخت مستقیم
        protected Admin(string firstName, string lastName, string fatherName, int age,
                        NationalCode nationalCode, PhoneNumber phoneNumber,
                        Email email, Password password)
            : base(firstName, lastName, fatherName, age, nationalCode, phoneNumber, email, password)
        {
        }

        // متد فکتوری برای ساخت Admin جدید
        public static Admin Create(string firstName, string lastName, string fatherName, int age,
                                   NationalCode nationalCode, PhoneNumber phoneNumber,
                                   Email email, string plainTextPassword,
                                   IPasswordHasher passwordHasher)
        {
            if (passwordHasher == null)
                throw new ArgumentNullException(nameof(passwordHasher));

            var password = Password.Create(plainTextPassword, passwordHasher);

            return new Admin(firstName, lastName, fatherName, age, nationalCode, phoneNumber, email, password);
        }
    }

}
