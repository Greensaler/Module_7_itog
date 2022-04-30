using System;

namespace Task6_3
{
    class Employee
    {
        public Department Department;
    }

    class Department
    {
        public Company Company;
    }

    class Company
    {
        public string Name;
    }

    class Bus
    {
        public int? Load;

        public void PrintStatus()
        {
            if (Load.HasValue)
            {
                Console.WriteLine("В авбтобусе {0} пассажиров", Load.Value);
            }
            else
            {
                Console.WriteLine("Автобус пуст!");
            }
        }
    }
   // Свойства являются специальными членами классов(и структур),
   // которые позволяют получать и изменять значение 
   //приватного поля, применяя некоторую логику для проверки(валидации) действий.
    class User
    {
        private int age;

        public int Age
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
    }
    //Автоматические свойства. Нужны если потом понадобится сделать стандартные свойства
    class User1
    {
        public string Login { get; set; }
        public int Age { get; set; }
    }
    //Класс программы
    class Program
    {
        static void Main(string[] args)
        {
            Employee employee = new Employee();
            string name;
            if (employee != null && employee.Department != null && employee.Department.Company != null)
            {
                name = employee.Department.Company.Name;
            }
            //упаковка
            int i = 123;
            object o = i;
            //распаковка только явным образом, лучше использовать обобщения
            int j = (int)o;

        }
    }
}
