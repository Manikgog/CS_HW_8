using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CS_HW_8
{
    internal class Truck : Car
    {
        private int odometr = 0;

        public Truck(int maxSpeed, string carBrand, string model) : base(maxSpeed, carBrand, model) { }

        public int GetOdometr()
        {
            return odometr;
        }

        public override string ToString()
        {
            return carBrand + " " + model;
        }
        public override int Move()
        {
            Random seed = new Random();
            Random rnd = new Random(seed.Next(100));
            speed = rnd.Next(maxSpeed) + maxSpeed - 10;
            odometr += speed;
            return odometr;
        }
    }
}
