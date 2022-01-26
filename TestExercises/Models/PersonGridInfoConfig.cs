using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestExercises.Models
{
    public class PersonGridInfoConfig
    {
        public UserGridInfo Generate(string name)
        {
            return new UserGridInfo(name, GridCalculator.CalculateAverage(name), GridCalculator.CalculateMax(name), GridCalculator.CalculateMin(name));
        }
    }
}
