using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestExercises.Models
{
    [Serializable]
    public class SelectedUser
    {

        public int Rank { get; set; } = default;
        public string Name { get; set; } = default;
        public string Status { get; set; } = default;
        public double Average { get; set; } = default;
        public uint Best { get; set; } = default;
        public uint Worst { get; set; } = default;
        public SelectedUser()
        { }
        public SelectedUser(int rank, string name, string status, double average, uint best, uint worst)
        {
            Rank = rank;
            Name = name;
            Status = status;
            Average = average;
            Best = best;
            Worst = worst;
        }
    }
}
