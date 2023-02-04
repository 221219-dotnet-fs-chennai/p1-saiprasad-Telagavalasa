

namespace Models
{
    public class Trainer
    {
        public Trainer()
        {
        }
        public int TrainerId { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Name { get; set; }

        public byte? Age { get; set; }

        public string? Gender { get; set; }

        public string? PhoneNumber { get; set; }

        public string? City { get; set; }

        public string? Zipcode { get; set; }


        public override string ToString()
        {
            return $"Email : {Email}\n Name:{Name}\n Age:{Age}\nGender:{Gender}\nPhone_Number : {PhoneNumber}\nCity : {City}\nzipcode:{Zipcode}";
        }
    }
}




    

