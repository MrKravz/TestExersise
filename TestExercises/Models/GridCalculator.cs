using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestExercises.Models
{
    public static class GridCalculator
    {
        public static double CalculateAverage(string name)
        {
            return MyJsonSerializer.GetAllUsers().Where(x => x.Name == name).Sum(x => x.Steps) / new DirectoryInfo("C:\\ApplicationData\\").GetFiles().Length;
        }
        public static uint CalculateMax(string name)
        {
            uint max = MyJsonSerializer.GetUserStepsByDay(name, 1);
            for (int i = 2; i < new DirectoryInfo("C:\\ApplicationData\\").GetFiles().Length + 1; i++)
            {
                if (max < MyJsonSerializer.GetUserStepsByDay(name, i))
                {
                    max = MyJsonSerializer.GetUserStepsByDay(name, i);
                }
            }
            return max;
        }
        public static uint CalculateMin(string name)
        {
            uint min = MyJsonSerializer.GetUserStepsByDay(name, 1);
            for (int i = 2; i < new DirectoryInfo("C:\\ApplicationData\\").GetFiles().Length + 1; i++)
            {
                if (min > MyJsonSerializer.GetUserStepsByDay(name, i))
                {
                    min = MyJsonSerializer.GetUserStepsByDay(name, i);
                }
            }
            return min;
        }
    }
}
