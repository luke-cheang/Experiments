using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDapper
{
    class Program
    {
        static void Main(string[] args)
        {
            FaxinRepository fc = new FaxinRepository();
            fc.GetFaxinCase("EB202002120002", 0, 0);
        }   // Main();

    }   // Program

}   // MyDapper
