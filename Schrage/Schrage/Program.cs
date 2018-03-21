using Priority_Queue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schrage
{
    class Program
    {
        private static int CompareDesc(float x, float y)
        {
            if (x < y) return 1;
            if (x == y) return 0;
            return -1;
        }
        static void Main(string[] args)
        {
            File file = new File();

            file.readFile("Data.txt");

            foreach (Task task in file.listOfTasks)
            {
               // Console.WriteLine(task.r.ToString() + " " + task.p.ToString() + " " + task.q.ToString());

            }

            float t = 0;
            float k = 0;
            float cmax = 0;


            SimplePriorityQueue<Task> G = new SimplePriorityQueue<Task>(CompareDesc);
            SimplePriorityQueue<Task> N = new SimplePriorityQueue<Task>();
            
            //int i = 1;
            foreach (Task task in file.listOfTasks)
            {
                N.Enqueue(task, task.r);
            }

             while (N.Count != 0 || G.Count != 0)
             {
                 while(N.Count != 0 && N.First.r <= t)
                 {
                    Task e2 = N.Dequeue();
                    
                    G.Enqueue(e2, e2.q);
                 }
                 if(G.Count == 0)
                 {
                    t = N.First.r;
                    continue;
                 }
                 //Si = t
                Task e = G.Dequeue();
                k = k + 1;
                t = t + e.p;
                cmax = Math.Max(cmax, t + e.q);
                //Di =  t + e.q

            }


            Console.WriteLine(cmax);
            Console.ReadLine();
        }
    }
}
