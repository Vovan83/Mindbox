using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace MindboxShapes
{
    public class SimpleShapeFactory : IShapeFactory
    {
        static readonly IDictionary<string, Type> shapesDictionary = typeof(BaseShape)
            .Assembly.GetTypes()
            .Where(x => !x.IsInterface && !x.IsAbstract && x.FindInterfaces(MyInterfaceFilter, typeof(IShape)).Any())
            .ToDictionary(x => x.Name.ToLower());

        public IShape CreateShapeFromName(string shapeName) =>
            (IShape)Activator.CreateInstance(shapesDictionary[shapeName.ToLower()]);

        public IEnumerable<string> GetShapeNames() => shapesDictionary.Keys;

        static bool MyInterfaceFilter(Type typeObj, Object criteriaObj) => typeObj.ToString() == criteriaObj.ToString();
    }
}
