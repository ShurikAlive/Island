using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Island
{
    class Сitizen
    {
        private Random rnd;

        private int sex;// 1 - М; 0 - Ж
        private int age;// Возраст в неделях. 1 год = 48 недель
        private bool isAlive;// Живой ли человек

        public Сitizen(Random rnd, bool isChildren)
        {
            this.rnd = rnd;

            if (isChildren)
                InitChildrenСitizen();
            else
                InitСitizen();
        }

        private void InitChildrenСitizen()
        {
            sex = rnd.Next(0,2);
            age = 0;
            isAlive = true;
        }

        private void InitСitizen()
        {
            sex = rnd.Next(0, 2);
            age = rnd.Next(0, 4320);
            isAlive = true;
        }

        public void LiveWeek()
        {
            if (!isAlive) return;

            age++;

            // Проверяем, не погиб ли житель
            if ((age >= 2880) & (age <= 4320))
            {
                int deth = rnd.Next(0, 6);
                if ((deth > 2) || (age == 4320))
                {
                    isAlive = false;
                    return;
                }
            }


        }

        public bool IsAlive()
        {
            return isAlive;
        }

        public int GetAge()
        {
            return age;
        }

        public int GetSex()
        {
            return sex;
        }
    }
}
