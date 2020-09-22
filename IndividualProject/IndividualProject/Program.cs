using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividualProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Interface inter = new Interface(new Data());
            inter.Initialize();

            
            Console.ReadKey();
        }
    }
}
