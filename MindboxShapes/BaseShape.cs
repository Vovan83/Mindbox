namespace MindboxShapes
{
    public abstract class BaseShape : IShape
    {
        public abstract void SetFromConsole();
        public abstract double GetSquare();
        public abstract void ReportToConsole();

        //TODO common logic
    }


}
