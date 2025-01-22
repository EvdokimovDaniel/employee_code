using System.IO.Pipelines;
using System.Reflection.Metadata;
using System.Reflection.PortableExecutable;
using System.Security.AccessControl;



//Основной класс
    // Абстрактный класс
    abstract class Animal
    {
        public string Name;

        public Animal(string name)
        {
            Name = name;
        }

        // Абстрактный метод (не имеет реализации)
        public abstract void Speak();
    }

    // Класс-наследник от абстрактного класса
    class Cat : Animal
    {
        public string Breed;

        public Cat(string name, string breed) : base(name)
        {
            Breed = breed;
        }

        // Реализация абстрактного метода
        public override void Speak()
        {
            Console.WriteLine($"{Name} says Meow!");
        }
    }



public class Program
{   
    public static void Main()
    {    
        //Создаем новые объекты класса
        Cat cat1 = new Cat("Бобик","дворняга");
        cat1.Speak();

    }
}

































