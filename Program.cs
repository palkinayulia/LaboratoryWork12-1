using ClassLibrary10Lab;

namespace Лабораторная_работа_12._1
{
    internal class Program
    {
        static int NumberCheck() //проверка ввода числа
        {
            bool isConvert;
            int n;
            do
            {
                Console.Write("Введите число: ");
                string input = Console.ReadLine();
                isConvert = int.TryParse(input, out n);
                if (!isConvert || n <= 0) Console.WriteLine("Неправильно введено число \nПопробуйте еще раз.");
            } while (!isConvert || n <= 0);
            return n;
        }
        static void Main(string[] args)
        {
            MyList<Watch> list = new MyList<Watch>();
            int numberMenu;
            int size = 0;
            do //меню для 1 части
            {
                Console.WriteLine("1.Создать список");
                Console.WriteLine("2.Вывести список");
                Console.WriteLine("3.Добавить в список элемент с заданным номером");
                Console.WriteLine("4.Удалить из списка элемент с заданым именем");
                Console.WriteLine("5.Глубокое клонирование");
                Console.WriteLine("6.Удаление списка из памяти");
                Console.WriteLine("7.Выход");
                numberMenu = NumberCheck();
                switch (numberMenu)
                {
                    case 1: //создание списка
                        {
                            Console.Write("Введите размер списка - ");
                            size = NumberCheck();
                            list = new MyList<Watch>(size); //создаем список
                            Console.WriteLine("Список создан");//сообщение для пользователя
                            break;
                        };
                    case 2://печать списка
                        {
                            list.PrintList();//выводим список
                            break;
                        };
                    case 3://добавление
                        {
                            Console.WriteLine("Введите номер элемента для добавления: ");
                            int number = NumberCheck();
                            if (number > size + 1) Console.WriteLine($"В списке находится {size} элементов"); //проверка если число больше количества элементов
                            else 
                            { 
                                Watch clock = new Watch();
                                clock.RandomInit();
                                Console.WriteLine("Элемент для добавления - " + clock); //определяем элемен для добавления
                                if (number == 1) { list.AddToBegin(clock); } //добавление в начало
                                else if (number == size + 1) { list.AddToEnd(clock); } //добавление в конец
                                else { list.AddToSelectNumber(clock, number); }; //добавление в "середину"
                                Console.WriteLine("Элемент добавлен"); //сообщение для пользователя
                            }
                            break;
                        };
                    case 4://удаление
                        {
                            Watch clock = new Watch();
                            clock.Init(); //задаем информационных полей
                            if (!list.RemoveItem(clock)) Console.WriteLine("Элемент не найден в списке"); //если элемента нет в списке
                            else Console.WriteLine($"Элемент {clock} будет удален"); //сообщение для пользователя
                            break;
                        };
                    case 5://клонирование
                        { 
                            MyList<Watch> listClone = (MyList<Watch>)list.Clone(); //клонируем
                            Console.WriteLine("Клон списка: "); //выводим клона
                            listClone.PrintList();
                            break;
                        }
                    case 6://удаление из памяти
                        {
                            list = null;
                            GC.Collect(); //вызываем сборщик мусора
                            Console.WriteLine("Clean");
                            list.PrintList();
                            break;
                        }
                    case 7: { break; } //возвращение в главное меню
                    default: { Console.WriteLine("Неправильно задан пункт меню \nПопробуйте еще раз"); break; };
                }
            } while (numberMenu != 7);
        }
    }
}
