using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Reflection;

namespace lab4_ex4
{
    public class Vehicle
    {
        public static Random rnd = new Random();
        public int Wheels = 0;
        public virtual String GetInfo()
        {
            return "Транспорт";
        }
    }

    public enum BikesType {mountain, city, children}
    public class Bike : Vehicle
    {
        public int Radius = 0;
        public BikesType type = BikesType.mountain;

        public override String GetInfo()
        {
            var str = "Велосипед";
            switch (type)
            {
                case BikesType.mountain:
                    str += "\nТип: Горный";
                    break;
                case BikesType.city:
                    str += "\nТип: Городской";
                    break;
                case BikesType.children:
                    str += "\nТип: Детский";
                    break;
            }
            str += String.Format("\nРадиус: {0}", this.Radius);
            str += String.Format("\nКоличество колес: {0}", this.Wheels);
            return str;
        }

        public static Bike Generate()
        {
            return new Bike
            {
                Radius = rnd.Next(20, 30),
                type = (BikesType)rnd.Next(0, 3),
                Wheels = rnd.Next(2, 4)
            };
        }
    }

    public enum CarsType {bus, truck, SUV, passenger}
    public class Car : Vehicle
    {
        public int Engine = 0;
        public int Doors = 0;
        public CarsType type = CarsType.bus;

        public override String GetInfo()
        {
            var str = "Автомобиль";
            switch (type)
            {
                case CarsType.bus:
                    str += "\nТип: Автобус";
                    str += "\nКоличество дверей: 3";
                    break;
                case CarsType.truck:
                    str += "\nТип: Грузовик";
                    str += "\nКоличество дверей: 2";
                    break;
                case CarsType.SUV:
                    str += "\nТип: Внедорожник";
                    str += "\nКоличество дверей: 4";
                    break;
                case CarsType.passenger:
                    str += "\nТип: Легковой";
                    str += "\nКоличество дверей: 4";
                    break;
            }
            str += String.Format("\nМощность: {0} л.c.", this.Engine);
            //str += String.Format("\nКоличество дверей: {0}", this.Doors);
            str += String.Format("\nКоличество колес: {0}", this.Wheels);
            return str;
        }

        public static Car Generate()
        {
            return new Car
            {
                Engine = rnd.Next(67, 152),
                //Doors = rnd.Next(2, 5),
                type = (CarsType)rnd.Next(0, 4),
                Wheels = 4
            };
        }
    }

    public enum AirsType {screw, reactive, combined}
    public class Air : Vehicle
    {
        public int Height = 0;
        public AirsType type = AirsType.screw;

        public override String GetInfo()
        {
            var str = "Самолет";
            switch (type)
            {
                case AirsType.screw:
                    str += "\nТип: Винтовой";
                    break;
                case AirsType.reactive:
                    str += "\nТип: Реактивный";
                    break;
                case AirsType.combined:
                    str += "\nТип: Комбинированный";
                    break;
            }
            str += String.Format("\nМаксимальная высота: {0} метров", this.Height);
            str += String.Format("\nКоличество колес: {0}", this.Wheels);
            return str;
        }

        public static Air Generate()
        {
            return new Air
            {
                Height = rnd.Next(5000, 10000),
                type = (AirsType)rnd.Next(0, 3),
                Wheels = rnd.Next(16, 32)
            };
        }
    }
}
