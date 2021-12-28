using System.IO;

namespace MindboxShapes
{
    public abstract class BaseShape : IShape
    {
        public abstract BaseShape SetFromConsole(TextReader textReader, TextWriter textWriter);
        public abstract double GetSquare();
        public abstract void ReportToConsole(TextWriter textWriter);

        public virtual ShapeType ShapeType => ShapeType.None;

        //TODO common logic
    }


}
