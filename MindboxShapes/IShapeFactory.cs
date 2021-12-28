using System;
using System.Collections.Generic;
using System.Text;

namespace MindboxShapes
{
    public interface IShapeFactory
    {
        IShape CreateShapeFromName(string shapeName);
        IEnumerable<string> GetShapeNames();
    }
}
