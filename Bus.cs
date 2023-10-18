using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CS_HW_8
{
    internal class Bus : Car
    {
        private int odometr = 0;

        public Bus(int speed, string carBrand, string model) : base(speed, carBrand, model) { }

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
