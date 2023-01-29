
using FluentApi.Entities;
using Models;


namespace FluentApi.Entities
{
    public class EFRepo : ITrainer<Trainer>

    {

        Project1Context context = new Project1Context();

        List<Trainer> ITrainer<Trainer>.DisplayTrainer()
        {
            return context.Trainers.ToList();
        }




        //public List<Trainer> AddTrainer(Models.Trainer trainer)
        //{
        //    context.Add(trainer);
        //    context.SaveChanges();
        //    return trainer;
        //}


        public Entities.Trainer Add(Entities.Trainer trainer)
        {
            return trainer;
        }
        // public Models.Trainers AddTrainerSignup(Models.Trainers trainer)
        //{
        //    context.Trainers.Add(t);
        //    context.SaveChanges();
        //    return trainer;


        //}

        public void AddTrainerSignup(Trainer t)
        {
            context.Trainers.Add(t);
            context.SaveChanges();


        }

        public void AddTrainer(Trainer t)
        {
            //var trainer = context.Trainers.Where(item => item.TrainerId == t.TrainerId).First();
            //if (trainer != null)
            //{

            //    trainer.Age = (byte?)t.Age;
            //    trainer.Gender = t.Gender;
            //    trainer.PhoneNumber = t.PhoneNumber;
            //    trainer.City = t.City;
            //    trainer.Zipcode = t.Zipcode;
              // context.Update(t);
               // context.SaveChanges();
            
        }
    }
}

        
    
       