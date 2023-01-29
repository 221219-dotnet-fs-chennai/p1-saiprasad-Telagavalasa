using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using FluentApi;
using System.Threading.Tasks;

namespace Models
{
    public interface ITrainer<T>
    {


        List<T> DisplayTrainer();
        //  T Add(T t);
       void AddTrainerSignup(T trainer);
        void AddTrainer(T trainer);
  
    }   
}
