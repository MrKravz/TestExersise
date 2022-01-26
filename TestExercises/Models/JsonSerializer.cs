using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestExercises.Models
{
    public static class MyJsonSerializer
    {
        public static List<User> GetAllUsers()
        {
            List<User> persons = JsonConvert.DeserializeObject<List<User>>(File.ReadAllText("C:\\ApplicationData\\day1.json", Encoding.UTF8));
            for (int i = 2; i < new DirectoryInfo("C:\\ApplicationData\\").GetFiles().Length + 1; i++)
            {
                List<User> personsTemp = JsonConvert.DeserializeObject<List<User>>(File.ReadAllText($"C:\\ApplicationData\\day{i}.json", Encoding.UTF8));
                foreach (var personTemp in personsTemp)
                {
                    if (persons.Where(x => x.Name == personTemp.Name).Count() == 0)
                    {
                        persons.Add(personTemp);
                    }
                    else
                    {
                        foreach (var person in persons.Where(x => x.Name == personTemp.Name))
                        {
                            person.Steps += personTemp.Steps;
                        }
                    }
                }
            }
            return persons;
        }
        public static uint GetUserStepsByDay(string name, int day)
        {
            List<User> persons = JsonConvert.DeserializeObject<List<User>>(File.ReadAllText($"C:\\ApplicationData\\day{day}.json", Encoding.UTF8));
            if (persons.Where(x => x.Name == name).Count() > 0)
            {
                return persons.Where(x => x.Name == name).First().Steps;
            }
            return 0;
        }
        public static void Serialaize(SelectedUser selectedUser)
        {
            if (Directory.Exists("C:\\ApplicationData\\ExportedInfo\\"))
            {
                File.WriteAllText($"C:\\ApplicationData\\ExportedInfo\\exportInfo{new DirectoryInfo("C:\\ApplicationData\\ExportedInfo\\").GetFiles().Length + 1}.json", JsonConvert.SerializeObject(selectedUser));
            }
            else
            {
                Directory.CreateDirectory("C:\\ApplicationData\\ExportedInfo\\");
                File.WriteAllText("C:\\ApplicationData\\ExportedInfo\\exportInfo1.json", JsonConvert.SerializeObject(selectedUser));
            }

        }
    }
}
