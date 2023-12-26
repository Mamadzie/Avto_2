using Drive;
using System.Diagnostics;

Bus bus = new Bus("777", 10, 0);
Truck truck = new Truck("777", 60, 0);
int choice;

Console.WriteLine("Выберите ТС\n1 - Автобус.\n2 - Грузовик");
int choice_TC = int.Parse(Console.ReadLine()) - 1;
Console.Clear();
while (true)
{
    Console.WriteLine("Меню действий\n1 - Вывести информацию об ТС\n2 - Ехать\n3 - Изменить нагрузку\n4 - Изменить скорость\n5 - Заправка\n6 - Сменить ТС");
    choice = int.Parse(Console.ReadLine());

    switch (choice) {
        case 1:
            Console.Clear();
            if (choice_TC == 0)
            {
                bus.OutInfo();
            }
            else { 
                truck.OutInfo();
            }
            break;
        case 2:
            Console.Clear();
            Console.Write("Введите дальность поездки: ");

            float trip = int.Parse(Console.ReadLine());
            if (trip < 0)
            {
                Console.WriteLine("Введено неверное значение. Пожалуйста, введите положительное число.");
                Console.ReadKey();
            }

            if (choice_TC == 0)
            {
                float cargo = bus.ReturnCargo();
                bus.Dostup_Auto(2, trip, cargo);
            }
            else
            {
                float cargo = truck.ReturnCargo();
                truck.Dostup_Auto(2, trip, cargo);
            }

            Console.Clear();
            break;
        case 3:
            Console.Clear();
            Console.WriteLine("Изменить количество полезной нагрузки (целое число).");
            Console.WriteLine("1 - Добавить нагрузку. 2 - Уменьшить нагрузку");
            Console.Write("Ввод: ");

            int actionChoice = int.Parse(Console.ReadLine());
            Console.Write("На сколько изменить количество: ");
            int amount = int.Parse(Console.ReadLine());

            if (choice_TC == 0)
            {
                bus.Dostup_B(actionChoice, amount);
            }
            else truck.Dostup_T(actionChoice, amount);
            break;
        case 4:
            Console.Clear();
            Console.WriteLine("Изменить скорость.");
            Console.WriteLine("1 - Ускориться. 2 - Притормозить");
            int speed_choice = int.Parse(Console.ReadLine());
            Console.Write("На сколько изменить скорость: ");
            int a = int.Parse(Console.ReadLine());

            if (speed_choice == 1)
            {
                if (choice_TC == 0)
                {
                    bus.Dostup_Auto(3, 1, a);
                }
                else truck.Dostup_Auto(3, 1, a);
            }

            if (speed_choice == 2)
            {
                if (choice_TC == 0)
                {
                    bus.Dostup_Auto(3, 2, a);
                }
                else truck.Dostup_Auto(3, 1, a);
            }
            break;
        case 5:
            Console.Clear();
            Console.Write("Сколько топлива заправить: ");

            if (choice_TC == 0)
            {
                bus.Dostup_Auto(4, (float.Parse(Console.ReadLine())), 0);
            }
            else truck.Dostup_Auto(4, (float.Parse(Console.ReadLine())), 0);
            break;
        case 6:
            Console.Clear();
            Console.WriteLine("Выберите ТС\n1 - Автобус.\n2 - Грузовик");
            choice_TC = int.Parse(Console.ReadLine()) - 1;
            break;
    }

}
