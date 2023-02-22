using AreaCalculator;

double[] circleSides = { 4 };
Shape circle = new(circleSides);
Console.WriteLine("Площадь круга: " + circle.Area);

double[] triangleSides = { 3.0, 4.0, 5.0 };
Shape triangle = new(triangleSides);
Console.WriteLine("Площадь треугольника: " + triangle.Area);

if (triangle.IsRightTriangle())
{
  Console.WriteLine("Треугольник правильный");
}
else
{
  Console.WriteLine("Треугольник не правильный");
}
