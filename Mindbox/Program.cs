using System.Collections.Generic;

IShapeFactory shapeFactory = new SimpleShapeFactory();
while (true)
{
    Console.WriteLine("Введите одно из допустимых названий фигуры ({0}).\r\nДля выхода введите пустую строку", string.Join(", ", shapeFactory.GetShapeNames()));
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
    catch (KeyNotFoundException)
    {
        Console.WriteLine($"{classShape} не найден");
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}