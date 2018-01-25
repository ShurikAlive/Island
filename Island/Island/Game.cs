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

        private ArrayList products;

        private Firm state;

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
            InitProducts();
            InitState();
        }

        private void InitState()
        {
            state = new Firm(rnd);
            state.AddMony(1000000.0);// Стартовый капитал государства =)
        }

        private void InitProducts()
        {
            products = new ArrayList();
            products.Add(new Product(0, startCountCitizens * 56 * 48, null));// Добавляем базово еды, что бы все могли купить =)
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
            CreateFirms();
            UpdateFirms();
            UpdateState();
        }

        private void UpdateState()
        {
            // Принимаем на работу =)
            int countCitizen = citizens.Count;
            int maxWorkers = Convert.ToInt32(citizens.Count * 0.3);

            int WorkInState = 0;

            // подсчет госработников
            foreach (Сitizen citizen in citizens)
            {
                if (citizen.GetWork() == state)
                {
                    WorkInState++;
                }
            }

            // Принимаем на работу =)
            if (maxWorkers > WorkInState)
            {
                int maxNormWorkers = maxWorkers - WorkInState;// Кол во человек, которое необходимо принять на работу =)

                // Рекрутируем =)
                foreach (Сitizen citizen in citizens)
                {
                    // безработных совершеннолетних
                    if ((maxNormWorkers > 0) & (citizen.GetWork() == null) & (citizen.GetAge() >= 864))
                    {
                        citizen.SetWork(state);
                        maxNormWorkers--;
                    }
                }
            }
            // ^ Принимаем на работу =)

            // Раздаем пособие по безработице
            foreach (Сitizen citizen in citizens)
            {
                if (citizen.GetWork() == null)
                {
                    double posobie = 10.0;
                    citizen.SetMony(state.GetMony(posobie) + citizen.GetMony());
                }
            }
            // ^ Раздаем пособие по безработице

            // Раздаем зарплату работникам
            foreach (Сitizen citizen in citizens)
            {
                if (citizen.GetWork() == state)
                {
                    double salary = state.GetSizeSalary();
                    double getMony = state.GetMony(salary);
                    citizen.SetMony(getMony + citizen.GetMony());
                }
            }
            // ^ Раздаем зарплату работникам

            // Собираем налоги
            double tax = 2.0;// TODO: Заменить статичное число динамичным расчетом налога

            foreach (Сitizen citizen in citizens)
            {
                citizen.SetMony(citizen.GetMony() - tax);
                state.AddMony(tax);
            }

            for (int i = 0; i < firms.Count; i++)
            {
                state.AddMony(((Firm)firms[i]).GetMony(tax));
            }
            // ^ Собираем налоги
        }

        private void UpdateFirms()
        {
            // Основной UPDATE
            for (int i = 0; i < firms.Count; i++)
            {
                ((Firm)firms[i]).Update(products, citizens);
            }
        }

        private void CreateFirms()
        {
            weeksForCreateFirm++;

            if (weeksForCreateFirm == 48)
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
                    firms.Add(newFirm);

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
                ((Сitizen)citizens[i]).LiveWeek(citizens, products);
            }

            // Убираем трупы
            ArrayList boofer = new ArrayList();

            for (int i = 0; i < citizens.Count; i ++)
            {
                if (((Сitizen)citizens[i]).IsAlive() == false)
                {
                    

                    Сitizen couple = ((Сitizen)citizens[i]).GetCouple();
                    if (couple != null) couple.SetCouple(null);
                    boofer.Add(citizens[i]);
                }
            }

            foreach (Object citizen in boofer)
            {
                citizens.Remove(citizen);
            }

            // Убираем израсходованные продукты
            ArrayList boofer1 = new ArrayList();

            for (int i = 0; i < products.Count; i++)
            {
                if (((Product)products[i]).GetQuantity() <= 0.0)
                {
                    boofer1.Add(products[i]);
                }
            }

            foreach (Object product in boofer1)
            {
                products.Remove(product);
            }

        }


    }
}
