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
        }
    }
    
    //КЛАССЫ ПОЛЬЗОВАТЕЛЬСКИЕ
    //Абстрактный родительский класс "Доставка" служит для создания других классов.
    abstract class Delivery
    {
        public string Address;
    }

    //Класс "Домашняя доставка" создан от класса "Доставка.
    class HomeDelivery : Delivery
    {
        /* ... */
    }

    //Класс "Доставка в пункт выдачи" создан от класса "Доставка".
    class PickPointDelivery : Delivery
    {
        /* ... */
    }

    //Класс "Доставка магазина" создан от класса "Доставка".
    class ShopDelivery : Delivery
    {
        /* ... */
    }

    //Класс "Заказ"
    class Order<TDelivery,
    TStruct> where TDelivery : Delivery
    {
        public TDelivery Delivery;

        public int Number;

        public string Description;

        public void DisplayAddress()
        {
            Console.WriteLine(Delivery.Address);
        }

        // ... Другие поля
    }
}

