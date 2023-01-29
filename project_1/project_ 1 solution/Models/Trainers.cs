

namespace Models
{
    public class Trainers
    {
        public Trainers()
        {
        }
        public int Trainer_ID { get; set; }
        public string Email { set; get; }
        public string Password { set; get; }
        public string Name { set; get; }
        public int  Age { set; get; }
        public string Gender { set; get; }
        public string Phone_Number { set; get; }
        public string City { set; get; }
        public string zipcode { set; get; }
        

        public override string ToString()
        {
            return $"Email : {Email}\n Name:{Name}\n Age:{Age}\nGender:{Gender}\nPhone_Number : {Phone_Number}\nCity : {City}\nzipcode:{zipcode}";
        }
    }
}
