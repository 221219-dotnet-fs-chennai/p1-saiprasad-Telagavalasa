using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public interface IRepo<T>
    {


        List<T> DisplayTrainer();
        //  T Add(T t);
       void AddTrainerSignup(T trainer);
       
         //void AddTrainer(T trainer);
        T RemoveTrainer(string email);
        void UpdateTrainer(T trainer);

    }   
}
