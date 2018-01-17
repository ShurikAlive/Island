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
        private int startCountCitizens = 10000;

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
            int countAlive = 0;
            foreach (Сitizen citizen in citizens)
            {
                citizen.LiveWeek();
                if(citizen.IsAlive()) countAlive++;
            }

            MessageBox.Show(countAlive.ToString());
        }
    }
}
