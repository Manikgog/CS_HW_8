using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CS_HW_8.Game;

namespace CS_HW_8
{
    internal abstract class Car
    {
        protected int speed = 0;
        protected int maxSpeed;
        protected string carBrand;
        protected string model;
        public Car(int maxSpeed, string carBrand, string model) 
        {
            this.maxSpeed = maxSpeed;
            this.carBrand = carBrand;
            this.model = model;
        }
        public abstract int Move();

        public override abstract string ToString();

        public abstract int GetOdometr();

        public abstract void Finish();
        

    }
}
