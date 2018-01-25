using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Island
{
    class Firm: IWork
    {
        private Random rnd;

        private double currentCostProductA;
        private double currentCostProductB;

        private double mony;

        public Firm(Random rnd)
        {
            this.rnd = rnd;
            currentCostProductA = 10.0;
            currentCostProductB = 1000.0;
        }

        public double GetCost(int typeProduct)
        {
            if (typeProduct == 0)
                return currentCostProductA;
            
            return currentCostProductB;
        }

        public void Update(ArrayList products, ArrayList citizens)
        {
            int countWorkers = 0;

            foreach (Сitizen citizen in citizens)
                if (citizen.GetWork() == this) countWorkers++;

            // Устанавливаем новую цену
            // TODO
            //^ Устанавливаем новую цену

            // Создаем товар
            products.Add(new Product(0, countWorkers * 100, this));
        }

        public void AddMony(double firmMony)
        {
            mony += firmMony;
        }

        public double GetMony(double _mony)
        {
            if (_mony > mony)
                return 0.0;

            mony -= _mony;

            return _mony;
        }

        public double GetSizeSalary()
        {
            return 20.0; // TODO Заменить константу на алгоритм расчета зарплаты
        }

    }
}
