
using FluentApi.Entities;
using Microsoft.EntityFrameworkCore;
using Models;


namespace FluentApi.Entities
{
    public class EFRepo : IRepo<Trainer>

    {

        Project1Context context;// = new Project1Context();
        public EFRepo(Project1Context _context)
        {
            context = _context;
        }

        List<Trainer> IRepo<Trainer>.DisplayTrainer()
        {
            return context.Trainers.ToList();
        }

       public void  AddTrainerSignup(Trainer t)
        {
            context.Trainers.Add(t);
              context.SaveChanges();
            

        }

        //public void AddTrainer(Entities.Trainer trainer)
        //{
        //    context.Trainers.Update(trainer);
        //    context.SaveChanges();
        //}

        public void UpdateTrainer(Entities.Trainer trainer)
        {
            context.Trainers.Update(trainer);
            context.SaveChanges();
        }


        public Trainer RemoveTrainer(string email)
        {
            var find = context.Trainers.Where(x => x.Email==email).First();
            if (find != null)
            {
                context.Trainers.Remove(find);
                context.SaveChanges();
            }
            return find;
        }
    }
    }


        
    
       