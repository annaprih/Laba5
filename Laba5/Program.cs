using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba5
{
    class Program
    {
        static void Main(string[] args)
        {
            Round round_1 = new Round(12);
            Round round_2 = new Round(18);
            Round round_3 = new Round(14);
            Round round_4 = new Round(8);

            Console.WriteLine(round_1);
            Console.WriteLine(round_2);
            Console.WriteLine(round_3);
            Console.WriteLine(round_4);
            Console.WriteLine(new String('-', 10));

            User user = new User();
            user.ReviewEvent += round_1.Review;
            user.ReviewEvent += round_2.Review;
            user.ReviewEvent += round_3.Review;

            user.ZipEvent += round_1.Zip;
            user.ZipEvent += round_3.Zip;
            user.ZipEvent += round_4.Zip;

            user.Zip(2);

            Console.WriteLine(round_1);
            Console.WriteLine(round_2);
            Console.WriteLine(round_3);
            Console.WriteLine(round_4);
            Console.WriteLine(new String('-', 10));
            
            user.Review(10);

            Console.WriteLine(round_1);
            Console.WriteLine(round_2);
            Console.WriteLine(round_3);
            Console.WriteLine(round_4);
            Console.WriteLine(new String('-', 10));


            Console.WriteLine(new String('-', 10));
            Reflector.Field(round_1);
            Console.WriteLine(new String('-', 10));
            Reflector.Interfece(round_1);
            Console.WriteLine(new String('-', 10));
            Reflector.Method(round_1);
            Console.WriteLine(new String('-', 10));
            Reflector.MethodForType(round_1, typeof(int));
            Console.WriteLine(new String('-', 10));
            Reflector.Woke(round_1, "FunctionForReflector");
            Console.WriteLine(new String('-', 10));
            Reflector.WriteToFile(round_1);
            Console.WriteLine(new String('-', 10));
            Console.WriteLine(new String('-', 10));

            Reflector.Field(new Int32());
            Console.WriteLine(new String('-', 10));
            Reflector.Interfece(new Int32());
            Console.WriteLine(new String('-', 10));
            Reflector.Method(new Int32());
            Console.WriteLine(new String('-', 10));
            Reflector.MethodForType(new Int32(), typeof(int));
            Console.WriteLine(new String('-', 10));
            Console.WriteLine(new String('-', 10));

            Console.ReadKey();
        }
    }
}
