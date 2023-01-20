

using System.Numerics;
using System.Text.RegularExpressions;
namespace TrainersData
{
    public class Trainer
    {
        
        public string zipcode,email;
        //public long phone_Number;
        public int  User_ID { get; set; }
        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                string pattern = "^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,}$";
                var IsEmailCorrect = Regex.IsMatch(value, pattern);
                if (IsEmailCorrect)
                    email = value;
                else
                    Console.WriteLine("Please add a valid email address");
            }
        }
        public string Password { get; set; }
        public string Name { get; set; }
        public byte Age { get; set; }
        public string Gender { get; set; }
        public long Phone_Number { get; set; }
    //   public long Phone_Number
    //    {
    //       get
    //        {
    //            return phone_Number;
    //        }

    //set
    //        {
    //            string pattern = @"[6-9]\d{9}";
    //var IsPhoneCorrect = Regex.IsMatch(value, pattern);
    //            if (IsPhoneCorrect)
    //                phone_Number = value;
    //            else
    //                Console.WriteLine("Please add a valid mobile phone with 10 digits only");
    //        }
    //    }
        public string City { get; set; }
       // public string ZipCode { get; set; }
        public string ZipCode
        {
            get
            {
                return zipcode;
            }

            set
            {
                string pattern = @"[1-9]\d{5}";
                var ZipCode = Regex.IsMatch(value, pattern);
                if (ZipCode)
                    zipcode = value;
                else
                    Console.WriteLine("Please enter a valid zipcode starts with [1-9] digits only");
            }
        }
        public override string ToString()
        {
            return $" Email::{Email}\n Password::{Password}\n Name::{Name}\n Age::{Age}\n Gender::{Gender}\n Mobile::{Phone_Number} \nCity::{City}\n zipcode::{ZipCode} ";
        }

    }
}



  
     
        
