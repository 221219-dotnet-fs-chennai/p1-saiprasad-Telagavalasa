
using Models;
using FluentApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace Bussiness_Logic
{
    public class Logic:ILogic
    {
        private static Project1Context context =new Project1Context();
        ITrainer<Trainer> repo;
        public Logic() 
        {
            repo=new EFRepo();
        }

        public void AddTrainer(Trainers t)
        {
            
           
            repo.AddTrainer(Mapper.MapAddTrainer(t));
        }

       

        public void AddTrainerSignup(Trainers t)
        {
            //Trainer trainer = ;
            repo.AddTrainerSignup(Mapper.MapTrainerSignup(t));
            //throw new NotImplementedException();
        }

        public IEnumerable<Models.Trainers> DisplayTrainer()
        {
            return Mapper.Map(repo.DisplayTrainer());
        }

  

        //public void TrainerSignUp(FluentApi.Entities.Trainer t)
        //{
        //    Mapper.MapTrainerSignUp(repo.Add(t));
        //}
       

        
    }
}