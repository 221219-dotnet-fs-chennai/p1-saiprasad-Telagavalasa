
using FluentApi.Entities;
using Microsoft.EntityFrameworkCore;
using Models;


namespace FluentApi.Entities
{
    public class EFRepo : IRepo<Trainer>

    {

        Project1Context context = new Project1Context();

        List<Trainer> IRepo<Trainer>.DisplayTrainer()
        {
            return context.Trainers.ToList();
        }




      


        public Entities.Trainer Add(Entities.Trainer trainer)
        {
            return trainer;
        }
 


     

        public void  AddTrainerSignup(Trainer t)
        {
            context.Trainers.Add(t);
              context.SaveChanges();
            

        }

        public void AddTrainer(Entities.Trainer trainer)
        {
            context.Trainers.Update(trainer);
            context.SaveChanges();
        }

        //public Entities.Trainer RemoveRestaurant(string name)
        //{
        //    var find = context.Trainers.Where(trainer => trainer.Name == name).FirstOrDefault();
        //    if (find!= null)
        //    {
        //        context.Trainers.Remove(find);
        //        context.SaveChanges();
        //    }
        //    return find;
        //}

        public Trainer RemoveTrainer(Entities.Trainer t)
        {
            var find = context.Trainers.Where(x => x.Email==t.Email).First();
            if (find != null)
            {
                context.Trainers.Remove(find);
                context.SaveChanges();
            }
            return find;
        }
    }
    }


        
    
       