
using Models;
using FluentApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace Bussiness_Logic
{
    public class Logic : ILogic
    {
        Validation v;// new Validation();
        Project1Context context;

        IRepo<FluentApi.Entities.Trainer> repo;
        public Logic(Project1Context _context, IRepo<FluentApi.Entities.Trainer> _repo,Validation _v)
        {
            repo = _repo;
            context= _context;
            v = _v;
        }

       public void AddTrainerSignup(Models.Trainer t)
        {
           // t.TrainerId = v.TrainerIdEmail(t);

            repo.AddTrainerSignup(Mapper.Map(t));
            
        }

        public IEnumerable<Models.Trainer> DisplayTrainer()
        {
            return Mapper.Map(repo.DisplayTrainer());

        }

        //public void AddTrainer(Models.Trainer t)
        //{
        //    //t.TrainerId = v.TrainerIdByEmail(t);
        //    var trainer = context.Trainers.Where(item => item.TrainerId == t.TrainerId).First();
        //    if (trainer != null)
        //    {

        //        trainer.Age = t.Age;
        //        trainer.Gender = t.Gender;
        //        trainer.PhoneNumber = t.PhoneNumber;
        //        trainer.City = t.City
        //        trainer.Zipcode = t.Zipcode;

        //        repo.AddTrainer(trainer);
        //    }
        //}
        public void UpdateTrainer(Models.Trainer t)
        {
            t.TrainerId = v.TrainerIdEmail(t);
            var trainer = context.Trainers.Where(item => item.TrainerId == t.TrainerId).First();
            if (trainer != null)
            {
                trainer.Email= t.Email;
                trainer.Password= t.Password;
                trainer.Name= t.Name;
                trainer.Age = t.Age;
                trainer.Gender = t.Gender;
                trainer.PhoneNumber = t.PhoneNumber;
                trainer.City = t.City;
                trainer.Zipcode = t.Zipcode;

                repo.UpdateTrainer(trainer);
            }

        }
        public Models.Trainer RemoveTrainerByName(string email)
             {
                var deletedTrainer = repo.RemoveTrainer(email);
           
                return Mapper.Map(deletedTrainer);
          
              
        }

       
    }
}






    
