namespace Task2
{
    abstract class Animal
    {
        internal void Talk()
        {
            if (this is Cat)
                Console.WriteLine("Кошка мяучит 'мяу-мяу'");
            else if (this is Dog)
                Console.WriteLine("Собака гавкает 'гав-гав-гав'");
            else if (this is Goose)
                Console.WriteLine("Гусь гогочет 'га-га-га'");
        }
    }

    class Cat : Animal { }

    class Dog : Animal { }

    class Goose : Animal { }

    public class Task2
    {
        public static void Main(string[] args)
        {
            RunTest();
        }

        internal static void RunTest()
        {
            foreach (var animal in new List<Animal> { new Cat(), new Dog(), new Goose() })
            {
                animal.Talk();
            }
        }
    }
}