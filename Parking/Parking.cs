using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Parking
{
    public class Parking
    {
        private List<Car> data;

        public Parking(string type, int capacity)
        {
            this.Type = type;
            this.Capacity = capacity;
            this.data = new List<Car>();
        }

        public string Type { get; set; }

        public int Capacity { get; set; }

        public int Count => this.data.Count;

        public void Add(Car car)
        {
            if (this.Capacity > this.data.Count)
            {
                this.data.Add(car);
            }
        }

        public bool Remove(string manufacturer, string model)
        {
            foreach (var Car in data)
            {
                if (Car.Manufacturer == manufacturer && Car.Model == model)
                {
                    this.data.Remove(Car);
                    return true;
                }
            }
            return false;
        }

        public Car GetLatestCar()
        {
            if (this.data.Count > 0)
            {
                Car latestCar = data.OrderByDescending(x => x.Year).FirstOrDefault();
                return latestCar;
            }
            else
            {
                return null;
            }
        }

        public Car GetCar(string manufacturer, string model)
        {
            foreach (var Car in data)
            {
                if (Car.Manufacturer == manufacturer && Car.Model == model)
                {
                    return Car;
                }
            }

            return null;
        }

        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"The cars are parked in {this.Type}:");

            foreach (var Car in this.data)
            {
                sb.AppendLine(Car.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
