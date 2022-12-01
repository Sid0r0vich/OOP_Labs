namespace Task3
{
    abstract class Creature
    {
    }

    class Human : Creature
    {
        internal string Greeting() => "Привет, я человек!";
    }

    class Dog : Creature
    {
        internal string Bark() => "Гав!";
    }

    class Alien : Creature
    {
        internal string Command() => "Ты меня не видишь";
    }

    public class Task3
    {
        internal static void PrintMessageFrom(Creature creature)
        {
            string Message = String.Empty;

            if (creature is Human)
                Message = (creature as Human)!.Greeting();
            else if (creature is Dog)
                Message = (creature as Dog)!.Bark();
            else if (creature is Alien)
                Message = (creature as Alien)!.Command();

            if (!String.IsNullOrEmpty(Message)) Console.WriteLine(Message);

        }

        static List<Dog> FindDogs(List<Creature> creatures) => (List<Dog>)creatures.Where(creature => creature is Dog).Select(creature => (Dog)creature).ToList();

        public static void Main(string[] args)
        {
            RunTest();
        }

        internal static void RunTest()
        {
            var creatures = new List<Creature> { new Alien(), new Dog(), new Human(), new Dog() };
            Console.WriteLine("Все сообщения:");

            foreach (var creature in creatures)
            {
                PrintMessageFrom(creature);
            }

            Console.WriteLine();
            Console.WriteLine("Сообщения только от собак:");
            foreach (var dog in FindDogs(creatures))
            {
                Console.WriteLine(dog.Bark());
            }
        }
    }
}