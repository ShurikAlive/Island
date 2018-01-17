using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Island
{
    class Game
    {
        private Random rnd;

        private ArrayList citizens;
        private int startCountCitizens = 10;

        private int week_number;

        public Game(Random rnd)
        {
            this.rnd = rnd;
            Initialization();
        }

        private void Initialization()
        {
            week_number = 0;
            InitCitizens();
        }

        private void InitCitizens()
        {
            citizens = new ArrayList();

            for (int i = 0; i < startCountCitizens; ++i)
            {
                bool isChildren = false;
                citizens.Add(new Сitizen(rnd, isChildren));
            }
        }

        public void NextWeek()
        {
            week_number++;

            UpdateCitizens();
        }

        private void UpdateCitizens()
        {
            // Прединициализация параметров на итерацию
            foreach (Сitizen citizen in citizens)
            {
                citizen.SetCalculateChildrenDateInThisWeek(false);
            }

            // Основной UPDATE
            for (int i = 0; i < citizens.Count; i++)
            {
                ((Сitizen)citizens[i]).LiveWeek(citizens);
            }

            // Убираем трупы
            for(int i = 0; i < citizens.Count; i ++)
            {
                if (! ((Сitizen)citizens[i]).IsAlive())
                {
                    Сitizen couple = ((Сitizen)citizens[i]).GetCouple();
                    if (couple != null) couple.SetCouple(null);
                    citizens.RemoveAt(i);
                }
            }

            MessageBox.Show(citizens.Count.ToString());
        }

        private object Citizen(object v)
        {
            throw new NotImplementedException();
        }
    }
}
