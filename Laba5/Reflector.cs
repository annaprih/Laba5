using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Laba5
{
    static class Reflector
    {
        static public void WriteToFile(object obj)
        {
            Type type = obj.GetType();

            FieldInfo[] fields = type.GetFields(BindingFlags.Instance | BindingFlags.Static 
                | BindingFlags.Public | BindingFlags.NonPublic);

            PropertyInfo[] propertys = type.GetProperties();

            using (StreamWriter log = new StreamWriter(@"Reflector.txt"))
            {
                log.WriteLine("Имя класса: " + type.FullName);

                log.WriteLine("Поля класса:");
                foreach (FieldInfo field in fields)
                {
                    log.WriteLine(field.Name + " = " + field.GetValue(obj));
                }

                log.WriteLine("Свойства класса:");
                foreach (PropertyInfo property in propertys)
                {
                    log.WriteLine(property.Name + " = " + property.GetValue(obj));
                }
            }
            Console.WriteLine("Запись в файл выполнена!");
        }

        static public void Method(object obj)
        {
            Type type = obj.GetType();
            MethodInfo[] methods = type.GetMethods(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);
            Console.WriteLine("Методы класса:");
            foreach (MethodInfo method in methods)
            {
                Console.WriteLine(method.Name);
            }
        }

        static public void Field(object obj)
        {
            Type type = obj.GetType();
            FieldInfo[] fields = type.GetFields(BindingFlags.Instance | BindingFlags.Static
                | BindingFlags.Public | BindingFlags.NonPublic);

            PropertyInfo[] propertys = type.GetProperties();

            Console.WriteLine("Поля класса:");
            foreach (FieldInfo field in fields)
            {
                Console.WriteLine(field.Name + " = " + field.GetValue(obj));
            }

            Console.WriteLine("Свойства класса:");
            foreach (PropertyInfo property in propertys)
            {
                Console.WriteLine(property.Name + " = " + property.GetValue(obj));
            }
        }

        static public void Interfece(object obj)
        {
            Type type = obj.GetType();
            Type[] interfeces = type.GetInterfaces();

            Console.WriteLine("Интерфейсы класса:");
            foreach (Type interfece in interfeces)
            {
                Console.WriteLine(interfece.Name);
            }
        }

        static public void MethodForType(object obj, Type parametr)
        {
            Type type = obj.GetType();

            MethodInfo[] methods = type.GetMethods(BindingFlags.Instance | BindingFlags.Static
                | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.DeclaredOnly);

            Console.WriteLine($"Методы класса содержащие в качестве параметра тип {parametr.Name}:");
            foreach (MethodInfo method in methods)
            {
                ParameterInfo[] parameters = method.GetParameters();
                for (int i = 0; i < parameters.Length; i++)
                {
                    if (parameters[i].ParameterType.Name.Equals(parametr.Name))
                    {
                        Console.WriteLine(method.Name);
                        break;
                    }
                }
            }
        }

        static public void Woke(object obj, string methode)
        {
            Type type = obj.GetType();

            MethodInfo methods = type.GetMethod(methode, BindingFlags.Instance | BindingFlags.Static
                | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.DeclaredOnly);

            List<string> list = new List<string>();

            using (StreamReader reader = new StreamReader("Parametr.txt"))
            {
                while (!reader.EndOfStream)
                {
                    list.Add(reader.ReadLine());
                }
            };

            object[] masPar = list.ToArray();
            methods.Invoke(obj, masPar);
        }
    }
}
