using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drive
{
    internal class Logik
    {
        string number;
        float topliva;

        float currentDistance;
        float speed = 50;
        float maxSpeed = 120;
        float maxtopliva = 100;


        public float RetSpees()
        {
            return speed;
        }

        public Logik(string number, float topliva)
        {
            this.number = number;
            this.topliva = topliva;
        }



        public virtual void OutInfo()
        {

            Console.WriteLine($"Информация\nНомер: {number}\nТопливо: {topliva}\nСкорость: {speed}");
            Console.WriteLine($"Пройденная дистанция: {currentDistance}");
        }

        protected void speedAdd(float addspeed)
        {
            if ((speed + addspeed) <= maxSpeed && addspeed > 0)
            {
                speed += addspeed;

            }
            else if ((speed + addspeed) > maxSpeed)
            {
                Console.WriteLine($"Мы не можем гнать больше {maxSpeed}. Набрали максимум.");
                speed = maxSpeed;

            }

        }

        protected void speedRemove(float addspeed)
        {
            if ((speed - addspeed) >= 0)
            {
                speed -= addspeed;

            }
            else { speed = 0; }

        }


        protected void zaprawka(float top)
        {

            if (top > 0)
            {
                if (top + topliva < maxtopliva)
                {
                    this.topliva += top;
                }
                else
                {
                    Console.WriteLine($"Бак ёмкостью {maxtopliva}, больше не взять. Залил максимум.");
                    this.topliva = maxtopliva;
                }
            }
            else
            {
                Console.WriteLine("Дружок пирожок, ты ввёл неправильное значение. Клуб шутников и кожевенного ремесла двумя этажами ниже.");
            }


        }

        protected void Move(float km, float cargo)
        {

            float time;
            float realFlow = (cargo * 0.25F) + (speed * 0.25F);

            if (speed > 0)
            {

                float ostatok = topliva - (km * realFlow / 100);


                if (ostatok >= 0)
                {
                    time = km / speed;
                    Console.WriteLine($"Мы доехали за {time:F2} час(а/ов)");
                    currentDistance += km;
                    topliva = ostatok;

                }
                if (ostatok < 0)
                {
                    float tempdist = km - (topliva / (realFlow / 100));
                    Console.WriteLine("Мы не доехали, осталось ещё " + tempdist);
                    ostatok = 0;
                    topliva = 0;
                    currentDistance += tempdist;
                    Console.WriteLine($"Пройденная дистанция: {currentDistance}");



                    Console.WriteLine("Едем дальше?\n1 - да\n2 - нет");
                    int vibar = int.Parse(Console.ReadLine());
                    if (vibar == 1)
                    {
                        Console.WriteLine("Чтобы доехать нужно заправиться. Вводи сколько зальём: ");
                        zaprawka(float.Parse(Console.ReadLine()));
                        Move(tempdist, cargo);
                    }
                    else if (vibar == 2)
                    {
                        Console.WriteLine("Ну и хрен с вами золотые рыбки.");//крылатая фраза
                    }
                }

            }
            else
            {
                Console.WriteLine("Скорость должна быть положительной, а так мы не поедем.");
            }
        }


        public void Dostup_Auto(int vibar2, float znach1, float znach2)
        {
            switch (vibar2)
            {
                case 1:
                    OutInfo();
                    break;
                case 2:
                    Move(znach1, znach2);
                    break;
                case 3:
                    if (znach1 == 1)
                    {
                        speedAdd(znach2);
                    }
                    else if (znach1 == 2)
                    {
                        speedRemove(znach2);
                    }
                    break;
                case 4:
                    zaprawka(znach1);
                    break;


            }
        }









    }
}