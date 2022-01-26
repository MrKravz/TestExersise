using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestExercises.Models
{
    public class UserGridInfo
    {
        public string Name { get; set; } = default;
        public double Average { get; set; } = default;
        public uint Best { get; set; } = default;
        public uint Worst { get; set; } = default;
        public UserGridInfo()
        {

        }
        public UserGridInfo(string name, double average, uint best, uint worst)
        {
            Name = name;
            Average = average;
            Best = best;
            Worst = worst;
        }
    }
}
