using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTestApI.CoreLayer.ValueObjects;

namespace WebTestApI.ApplicationLayer.Dtos
{
     public class CoachRegisterDto
    {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string FatherName { get; set; }
            public int Age { get; set; }
            public string NationalCode { get; set; }
            public PhoneNumber PhoneNumber { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
            // می‌تونی فیلدهای اضافی برای مربی هم اضافه کنی مثل رشته تخصصی یا سطح
        }

    }

