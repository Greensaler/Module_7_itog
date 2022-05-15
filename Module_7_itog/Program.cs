using System;

//Итоговый проект SF CDEV-16 модуль 7
//Система классов с использованием принципов и инструментов ООП
//Интернет магазин

namespace Module_7_itog
{
    //Класс программ запускает консольное приложение
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Итоговое задание модуль 7");
            Order order = new Order();
            order.DisplayOrderInfo();

        }

    }


    //КЛАССЫ ПОЛЬЗОВАТЕЛЬСКИЕ
    //Абстрактный родительский класс "Доставка" служит для создания других классов.
    abstract class Delivery
    {
        protected Guid Id;

        protected string FirstName { set; get; }
        protected string LastName { set; get; }
        protected string Adress { set; get; }

        private int age;
        protected int Age
        {
            get
            {
                return age;
            }

            set
            {
                if (value < 18)
                {
                    Console.WriteLine("Возраст должен быть не меньше 18");
                }
                else
                {
                    age = value;
                }
            }
        }

        protected Delivery(string firstName, string lastName, string adress, int age)
        {
            FirstName = firstName;
            LastName = lastName;
            Adress = adress;
            Age = age;
        }
        public virtual void DisplayClientInfo()
        {
            Id = Guid.NewGuid();
            Console.WriteLine("Информация о клиенте:");
            Console.WriteLine($"ID:{Id},\nИмя: {FirstName}," +
             $"\nФамилия: {LastName},\nАдресс: {Adress}" +
             $"\nВозраст: {Age}");
        }
        public abstract void Describe();

    }

    //Класс "Доставка на дом" создан от класса "Доставка.
    class HomeDelivery : Delivery
    {
        // Булевый флаг, сообщающий, нужна ли доставка на дом
        protected bool IsOnShift1;

        public HomeDelivery(string firstName, string lastName, string adress,
            int age, bool isOnShift) : base(firstName, lastName, adress, age)
        {
            IsOnShift1 = isOnShift;
        }
        // Переопределение обязательного абстрактоно метода
        public override void Describe()
        {
            Console.WriteLine("ОПЦИЯ ДОСТАВКИ НА ДОМ АКТИВНА");
        }
    }

    //Класс "Доставка в пункт выдачи" создан от класса "Доставка".
    class PickPointDelivery : Delivery
    {
        // Дата и время прибытия в пункт выдачи
        public DateTime ArrivalDate;
        public string Point;


        public PickPointDelivery(string firstName, string lastName, string adress,
            int age, DateTime arrivalDate, string point) : base(firstName, lastName, adress, age)
        {
            ArrivalDate = arrivalDate;
            Point = point;
        }
                // Переопределение обязательного абстрактоно метода
        public override void Describe()
        {
            Console.WriteLine("ОПЦИЯ ДОСТАВКИ КУРЬЕРОМ В ПУНКТ ВЫДАЧИ НА ОПРЕДЕЛЕННОЕ ВРЕМЯ АКТИВНА");
              
        }
        // Переопределение виртуального метода
        public override void DisplayClientInfo()
        {
            Console.WriteLine("Информация о клиенте:");
            Console.WriteLine($"ID:{Id},\nИмя: {FirstName}," +
             $"\nФамилия: {LastName},\nАдресс: {Adress}" +
             $"\nВозраст: {Age}\nВремя прыбытия в пункт выдачи {ArrivalDate}" +
             $"\nПункт выдачи {Point}");
        }
    }

    //Класс "Доставка магазина" создан от класса "Доставка".
    class ShopDelivery : Delivery
    {
        public bool IsOnShift2;
        public ShopDelivery(string firstName, string lastName, string adress,
         int age, bool isOnShift) : base(firstName, lastName, adress, age)
        {
            IsOnShift2 = isOnShift;
        }
        public override void Describe()
        {
            Console.WriteLine("ОПЦИЯ ДОСТАВКИ НА БЛИЖАЙШЕЕ ВРЕМЯ АКТИВНА");

        }
    }





    //Класс "Заказ"
    public class Order
    {

        public bool IsOnShift1;
        public bool IsOnShift2;



        // Метод сбора данных о клиенте
        protected (string firstName, string lastName, string adress, int age, bool isOnShift1, bool isOnShift2, DateTime arrivalDate, string point) EnterClientInfo()
        {
            (string firstName, string lastName, string adress, int age, bool isOnShift1, bool isOnShift2, DateTime arrivalDate, string point) Client;

            Client.firstName = "Сергей";
            Client.lastName = "Воробьев";
            Client.adress = "РФ. г. Белово";
            Client.age = 25;
            //Client.isOnShift1 = true; // флажок нужна ли доставка на дом
            Console.WriteLine("Заказать доставку на дом? Введите да/нет");
            string Option1 = Console.ReadLine();

            if (Option1 == "да" || Option1 == "Да" || Option1 == "ДА" || Option1 == "дА")
            {
                Client.isOnShift1 = true;
                Console.WriteLine("Клиент заказал доставку на дом");
            }
            else
            {
                Client.isOnShift1 = false;
                Console.WriteLine("Не требуется доставка на дом");
            }

            //Client.isOnShift2 = false; // флажок нужна ли доставка курьером (false - доставка магазина на ближайшее время)
            Console.WriteLine("Заказать доставку на ближайшее время? Введите да/нет");
            string Option2 = Console.ReadLine();

            if (Option2 == "да" || Option2 == "Да" || Option2 == "ДА" || Option2 == "дА")
            {
                Client.isOnShift2 = true;
                Console.WriteLine($"Клиент заказал доставку на ближайшее время." +
               $"\nДоставка выполняется внутренними средствами компании"); ;
            }
            else
            {
                Client.isOnShift2 = false;
                Console.WriteLine($"Клиент заказал доставку на точное время в пункт выдачи." +
                $"\nДоставка выполняется сторонним курьером");
            }

            Client.arrivalDate = new DateTime(2022, 5, 15);
            Client.point = "Бабанаково";

            return Client;
        }


        public void DisplayOrderInfo()
        {
            var Client = EnterClientInfo();
            HomeDelivery homeDelivery = new HomeDelivery(Client.firstName, Client.lastName, Client.adress, Client.age, Client.isOnShift1);
            PickPointDelivery pickPointDelivery = new PickPointDelivery(Client.firstName, Client.lastName, Client.adress, Client.age, Client.arrivalDate, Client.point);
            ShopDelivery shopDelivery = new ShopDelivery(Client.firstName, Client.lastName, Client.adress, Client.age, Client.isOnShift2);

            if (Client.isOnShift2 == true)
            {
                shopDelivery.Describe();
                shopDelivery.DisplayClientInfo();
            }
            else
            {
                pickPointDelivery.Describe();
                pickPointDelivery.DisplayClientInfo();
            }

        }



    }
}

