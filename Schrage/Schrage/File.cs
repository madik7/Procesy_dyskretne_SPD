using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schrage
{
    class File
    {
        public int numberOfTasks;
        public List<Task> listOfTasks;

        public File()
        {
            listOfTasks = new List<Task>();
        }

        public void readFile(string fileName)
        {
            try
            {
                using (StreamReader reader = new StreamReader(fileName))
                {
                    numberOfTasks = Int32.Parse(reader.ReadLine());

                    for (int j = 0; j < numberOfTasks; j++)
                    {
                        string text = reader.ReadLine();
                        string[] values = text.Split(' ');

                        Task task = new Task(int.Parse(values[0]), int.Parse(values[1]), int.Parse(values[2]));

                        listOfTasks.Add(task);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Problem z odczytaniem pliku");
                Console.WriteLine(e.Message);
            }
        }
    }
}
