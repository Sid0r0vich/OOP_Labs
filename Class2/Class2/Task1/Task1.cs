using System.Diagnostics;
using System.Text.Json;

namespace Task1

{
    class JsonIntProperty
    {
        public static int InstanceCounter
        {
            get { return JsonIntProperty.InstanceCount; }
            set { JsonIntProperty.InstanceCount += value; }
        }
        private static int InstanceCount = 0;

        private string Name;
        private int SetCount = 0;
        private int value;
        public int Value
        {
            get { return value; }
            set { this.value = value; this.SetValueCounter = 1; }
        }

        public string StringRepresentation
        {
            get { return this.ToString(); }
            set 
            {
                string[] strings = value.Split(":");
                if (strings.Count() != 2)
                {
                    throw new System.ArgumentException($"Incorrect JSON property format: '{value}'");
                }

                int ParsedVal;
                if (strings[0].Replace(" ", "") != this.Name)
                    throw new System.ArgumentException("Property name is immutable");

                try
                {
                    ParsedVal = int.Parse(strings[1]);
                }
                catch
                {
                    throw new System.FormatException($"For input string: \"{strings[1].Replace(" ", "")}\"");
                }

                this.Value = ParsedVal;
            }
        }

        public int SetValueCounter
        {
            get { return this.SetCount; }
            set { this.SetCount += value; }
        }

        public JsonIntProperty(string name, int value = 0)
        {
            this.Name = name;
            this.Value = value;

            JsonIntProperty.InstanceCounter = 1;
        }

        public override string ToString()
        {
            return $"{this.Name}: {this.Value}"; 
        }

    }

    public class Task1
    {
        public static void Main(string[] args)
        {
            RunTest();
        }

        public static string GetExceptionMessage(Exception e)
        {
            return e.GetType().ToString() + ": " + e.Message;
        }
        
        internal static void RunTest()
        {
            var ageProperty = new JsonIntProperty("age", 21);
            Console.WriteLine(ageProperty);
            Console.WriteLine(ageProperty.StringRepresentation);
            ageProperty.Value += 1;
            Console.WriteLine(ageProperty);
            ageProperty.StringRepresentation = "age: 23";
            Console.WriteLine(ageProperty);
            ageProperty.StringRepresentation = "age   :   24";
            Console.WriteLine(ageProperty);
            try
            {
                ageProperty.StringRepresentation = "value : 10";
            }
            catch (Exception e)
            {
                Console.WriteLine(GetExceptionMessage(e));
            }

            try
            {
                ageProperty.StringRepresentation = "age: ?";
            }
            catch (Exception e)
            {
                Console.WriteLine(GetExceptionMessage(e));
            }

            try
            {
                ageProperty.StringRepresentation = "age = 10";
            }
            catch (Exception e)
            {
                Console.WriteLine(GetExceptionMessage(e));
            }

            Console.WriteLine($"JSON value of 'age' has been set {ageProperty.SetValueCounter} time(s)");
            var countProperty = new JsonIntProperty("count");
            Console.WriteLine(countProperty);
            Console.WriteLine($"JSON value of 'count' has been set {countProperty.SetValueCounter} time(s)");
            Console.WriteLine(
                $"Class 'JsonIntProperty' instance has been created {JsonIntProperty.InstanceCounter} time(s)");
                
        }

    }
}