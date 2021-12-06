using PlayGenericType.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PlayGenericType
{
    class Program
    {
        static void Main(string[] args)
        {
            ExampleGenericType();
            PrinterGenericType();

        }

        private static void PrinterGenericType()
        {
            Printer printer = new Printer();
            printer.PrintData<int>(1);
            printer.PrintData<string>("Hello");
        }

        private static void ExampleGenericType()
        {
            DataStored<int> myNumber = new DataStored<int>();
            myNumber.Value = int.MaxValue;
            Console.WriteLine($"MyNumber : {myNumber.Value}");

            DataStored<string> myString = new DataStored<string>();
            myString.Value = "Hello World !";
            Console.WriteLine($"MyString : {myString.Value}");

            DataStored<int> dataStored = new DataStored<int>();
            dataStored.MyLists.Add(1);
            //Map 
            var newList = dataStored.MyLists.Select(r => r *2);
            foreach(var item in newList)
            {
                Console.WriteLine($"{item}");
            }

            //Dictionary string
            myString.AddOrUpdateDictionaries(1, "A");
            myString.AddOrUpdateDictionaries(2, "B");
            myString.AddOrUpdateDictionaries(3, "C");
            foreach(var item in myString.MyDictionaries)
            {
                Console.WriteLine($"{item}");
            }

            var b = myString.GetDataInDictionaries(2);
            Console.WriteLine(b);

        }
    }
    class Printer
    {
        public void PrintData<T>(T data)
        {
            Console.WriteLine(data);
        }
    }
}
