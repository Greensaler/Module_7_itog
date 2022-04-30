using System;
// Создано для выполнения заданий 6 и 7 модуля
namespace Task7_1
{
    //Новый класс
    public class Human
    {
        //Поля класса
        public string name;
        public int age;
        //Метод класса
        public void Greetings()
        {
            Console.WriteLine("Меня зовут {0}, мне {1}", name, age);
        }
        //конструктор 1
        public Human()
        {
            name = "Неизвестно";
            age = 20;
        }
        //конструктор 2
        public Human(string n)
        {
            name = n;
            age = 200;
        }
        //конструктор 3
        public Human(string n, int a)
        {
            name = n;
            age = a;
        }

    }
    //Cтруктура
    struct Animal
    {
        //Поля структуры
        public string type;
        public string name;
        public int age;
        //Метод структуры
        public void Greetings()
        {
            Console.WriteLine("Это {0} по кличке {1}, ему {2}", type, name, age);
        }

    }

    //Задание 6.2.2 создание класса Pen
    class Pen
    {
        public string color;
        public int cost;
        
        public void PenShow()
        {
            Console.WriteLine("Цвет {0} стоимость {1}", color, cost);
        }

        
        //конструктор 1
        public Pen()
        {
            color = "Черный";
            cost = 100;
        }
        //конструктор 2
        public Pen(string penColor, int penCost)
            {
            color = penColor;
            cost = penCost;
            }
    }

    //Класс выполнения программмы
    class Program
    {
        static void Main(string[] args)
        {
            Human human = new Human
            {
                name = "Дмитрий",
                age = 23
            };
            human.Greetings();

            human = new Human();
            human.Greetings();

            human = new Human("Жорик");
            human.Greetings();

            human = new Human("Степан Сегреевич", 28);
            human.Greetings();

            //вызов структуры
            Animal animal = new Animal();
            animal.type = "Пес";
            animal.name = "Тузик";
            animal.age = 3;
            animal.Greetings();
            //вызов класса
            string j1 = "зеленый";
            int j2 = 200;
            Pen pen = new Pen(j1, j2);
            pen.PenShow();

            Console.ReadKey();
        }
    }
}
