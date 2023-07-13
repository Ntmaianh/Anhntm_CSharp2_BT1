using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSHARP2
{
    internal class Bike
    {
        private int id;
        private string name;
        private string hsx;

        public Bike()
        {

        }

        public Bike(int id, string name, string hsx)
        {
            this.id = id;
            this.name = name;
            this.hsx = hsx;
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Hsx { get => hsx; set => hsx = value; }

        public void InThongTin()
        {
            Console.WriteLine($"Thông tin xe đạp: {id}|{name}|{hsx}");
        }
        public string ObjToString()
        {
            return ($"{id}|{name}|{hsx}\n");
        }
    }
}
