using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentApi.Entities;
using Models;

namespace Bussiness_Logic
{
    public interface ILogic
    {
        IEnumerable<Trainers> DisplayTrainer();
        // void TrainerSignUp(FluentApi.Entities.Trainer t);
        void AddTrainerSignup(Trainers t);
        void AddTrainer(Trainers id);
    }
}
