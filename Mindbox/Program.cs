using MindboxShapes;
using System;
using System.Linq;
using System.Reflection;

namespace Mindbox
{
    class Program
    {
        static void Main(string[] args)
        {
            var assembly = System.Reflection.Assembly.GetAssembly(typeof(MindboxShapes.BaseShape));
            TypeFilter myFilter = new TypeFilter(MyInterfaceFilter);
            var shapesDictionary = assembly.GetTypes().Where(x => !x.IsInterface
                && !x.IsAbstract && x.FindInterfaces(myFilter, typeof(IShape)).Any()).ToDictionary(x=>x.Name);
            Console.WriteLine("Введите одно из допустимых названий фигуры ({0}). Для выхода введите пустую строку", string.Join(", ", shapesDictionary.Keys));
            var classShape = Console.ReadLine();
            if (string.IsNullOrEmpty(classShape))
            {
                return;
            }
            if (shapesDictionary.ContainsKey(classShape)) 
            {
                IShape shape = (IShape)shapesDictionary[classShape].GetConstructor(new Type[] { }).Invoke(new object[] { });
                if (shape != null)
                {
                    try
                    {
                        shape.SetFromConsole();
                        shape.ReportToConsole();
                    }
                    catch (Exception ex) 
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
            Console.ReadLine();
        }

        public static bool MyInterfaceFilter(Type typeObj, Object criteriaObj)
        {
            if (typeObj.ToString() == criteriaObj.ToString())
                return true;
            else
                return false;
        }
    }
}
