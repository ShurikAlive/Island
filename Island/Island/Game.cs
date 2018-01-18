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

        private ArrayList firms;
        private int weeksForCreateFirm;

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
            InitFirms();
        }

        private void InitFirms()
        {
            firms = new ArrayList();
            weeksForCreateFirm = 0;
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
            UpdateFirms();
        }

        private void UpdateFirms()
        {
            weeksForCreateFirm++;

            if (weeksForCreateFirm == 4)//48)
            {
                int countNoWorkPeoples = 0;

                // подсчет безработных
                foreach (Сitizen citizen in citizens)
                {
                    // Кол во безработных совершеннолетних
                    if ((citizen.GetWork() == null) & (citizen.GetAge() >= 864))
                    {
                        countNoWorkPeoples++;
                    }
                }

                int fivePercentsPeople = Convert.ToInt32(citizens.Count * 0.05);

                // Создаем новую фирму если есть 5% безработных
                if (countNoWorkPeoples >= fivePercentsPeople)
                {
                    IWork newFirm = new Firm(rnd);

                    int peopleDoWork = 0;

                    foreach (Сitizen citizen in citizens)
                    {
                        if ((citizen.GetWork() == null) &(citizen.GetAge() >= 864))
                        {
                            peopleDoWork++;
                            citizen.SetWork(newFirm);

                            if (peopleDoWork >= fivePercentsPeople)
                            {
                                break;
                            }
                        }
                    }

                    weeksForCreateFirm = 0;
                }
            }
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

        }


    }
}
