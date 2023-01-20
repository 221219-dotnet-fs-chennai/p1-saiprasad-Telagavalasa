using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainersData
{
    public interface ITrainer
    {

          void Display(Trainer t);

         Trainer AddDetails(Trainer t);
         Trainer getData(Trainer t);

         void Display2(Trainer t);
         Trainer ModifyData(Trainer t);
         Trainer DeleteTrainer(Trainer t);
         Trainer  DisplayTrainerData(Trainer t);



       // Trainer (string email);


        /// <returns>List of all Trainers objects in the collection of Type List<Trainer></returns>
        // List<Trainer> GetAllTrainers();

    }
}
