
using Models;
using FluentApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace Bussiness_Logic
{
    public class Logic : ILogic
    {
        private static Project1Context context = new Project1Context();
        IRepo<FluentApi.Entities.Trainer> repo;
        public Logic()
        {
            repo = new FluentApi.Entities.EFRepo();
        }

        //public FluentApi.Entities.Trainer AddTrainer(Models.Trainer t)
        //{
        // repo.AddTrainer(Mapper.MapAddTrainer(t));
        //var trainer = context.Trainers.Where(item => item.TrainerId == t.Trainer_ID).First();
        //if (trainer != null)
        //{

        //    trainer.Age = (byte?)t.Age;
        //    trainer.Gender = t.Gender;
        //    trainer.PhoneNumber = t.Phone_Number;
        //    trainer.City = t.City;
        //    trainer.Zipcode = t.zipcode;
        //    context.Update(trainer);

        //    //trainer = repo.AddTrainer(trainer);
        //   // context.SaveChanges();

        //}
        //return Mapper.MapTrainerSignup(trainer);

        // }






        public void AddTrainerSignup(Models.Trainer t)
        {
            //Trainer trainer = ;
            repo.AddTrainerSignup(Mapper.Map(t));
            //throw new NotImplementedException();
        }

        public IEnumerable<Models.Trainer> DisplayTrainer()
        {
            return Mapper.Map(repo.DisplayTrainer());

        }

        public void AddTrainer(Models.Trainer t)
        {
            var trainer = context.Trainers.Where(item => item.TrainerId == t.Trainer_ID).First();
            if (trainer != null)
            {

                trainer.Age = (byte?)t.Age;
                trainer.Gender = t.Gender;
                trainer.PhoneNumber = t.Phone_Number;
                trainer.City = t.City;
                trainer.Zipcode = t.zipcode;
                //context.Update(trainer);

                repo.AddTrainer(trainer);
                // context.SaveChanges();

            }

            // return Mapper.MapAddTrainer(trainer);
        }
        public Models.Trainer RemoveTrainerByName(Models.Trainer t)
        {
            var deletedTrainer = repo.RemoveTrainer(Mapper.Map(t));
           
                return Mapper.Map(deletedTrainer);
          
              
        }


    }
}






    
