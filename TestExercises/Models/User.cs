using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TestExercises.Models
{
    [Serializable]
    public class User
    {

        public int Rank { get; set; } = default;
        [JsonProperty("User")]

        public string Name { get; set; } = default;
        public string Status { get; set; } = default;
        public uint Steps { get; set; } = default;
        public User()
        { }
        public User(int rank, string name, string status, uint steps)
        {
            Rank = rank;
            Name = name;
            Status = status;
            Steps = steps;
        }
    }
}
