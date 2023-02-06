using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public interface IRepo<Trainer>
    {


        List<Trainer> DisplayTrainer();
        //  T Add(T t);
       void AddTrainerSignup(Trainer trainer);
       
         //void AddTrainer(T trainer);
        Trainer RemoveTrainer(string email);
        void UpdateTrainer(Trainer trainer);

    }   
}
