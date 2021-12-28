using System.Reflection;

IShapeFactory shapeFactory = new SimpleShapeFactory();
while (true)
{
    Console.WriteLine("Введите одно из допустимых названий фигуры ({0}). Для выхода введите пустую строку", string.Join(", ", shapeFactory.GetShapeNames()));
    var classShape = Console.ReadLine();
    if (string.IsNullOrEmpty(classShape))
        return;
    try
    {
        var shape = shapeFactory.CreateShapeFromName(classShape);
        if (shape != null)
        {

            shape.SetFromConsole(Console.In, Console.Out)
                 .ReportToConsole(Console.Out);
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}