using ClassLibrary10Lab;
using Лабораторная_работа_12_4;
namespace Лабораторная_работа__13
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
            MyObservableCollection<Watch> collection1 = new MyObservableCollection<Watch>();
            MyObservableCollection<AnalogWatch> collection2 = new MyObservableCollection<AnalogWatch>();
            Journal journal1 = new Journal();
            Journal journal2 = new Journal();
            int numberMenu;
            do //меню для 2 части
            {
                Console.WriteLine("1.Создание коллекций, объектов типа journal и подписок");
                Console.WriteLine("2.добавить и удалить элементы из коллекций");
                Console.WriteLine("3.Вывести данные объектов Journal");
                Console.WriteLine("4.Выход");
                numberMenu = NumberCheck();
                switch (numberMenu)
                {
                    case 1: //создание подписок 
                        {
                            collection1.CollectionCountChanged += (sender, e) => journal1.Log(new JournalEntry("Collection1", e.ChangeType, e.RelatedObject.ToString()));
                            collection2.CollectionCountChanged += (sender, e) => journal2.Log(new JournalEntry("Collection2", e.ChangeType, e.RelatedObject.ToString()));

                            collection1.CollectionReferenceChanged += (sender, e) => journal1.Log(new JournalEntry("Collection1", e.ChangeType, e.RelatedObject.ToString()));

                            collection2.CollectionReferenceChanged += (sender, e) =>
                            {
                                journal1.Log(new JournalEntry("Collection2", e.ChangeType, e.RelatedObject.ToString()));
                                journal2.Log(new JournalEntry("Collection2", e.ChangeType, e.RelatedObject.ToString()));
                            };
                            Console.WriteLine("объекты созданы");//сообщение для пользователя
                            break;
                        };
                    case 2://add and remove
                        {
                           
                            Watch c = new Watch();
                            c.RandomInit();
                            Watch c2 = new Watch();
                            c2.RandomInit();
                            collection1.Add(c);
                            collection1.Add(c2);
                            //collection1[0] = "Hi";
                            collection1.Remove(c2);
                            break;
                        };
                    case 3://write journal
                        {
                            Console.WriteLine(journal1);
                            Console.WriteLine(journal2);
                            break;
                        };
                    case 4: { break; } //возвращение в главное меню
                    default: { Console.WriteLine("Неправильно задан пункт меню \nПопробуйте еще раз"); break; };
                }
            } while (numberMenu != 4);
        }
    }
}
