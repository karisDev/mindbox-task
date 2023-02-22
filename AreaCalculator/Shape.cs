namespace AreaCalculator
{
  /// <summary>
  /// Вычисляет площадь фигуры с заданными размерами, не зная типа фигуры.
  /// <remarks>
  /// Поддерживаемые фигуры:
  /// <list type="bullet">
  ///   <item>
  ///     <term>Окружность</term>
  ///     <description>Требуется 1 радиус</description>
  ///   </item>
  ///   <item>
  ///     <term>Треугольник</term>
  ///     <description>Требуется 3 стороны</description>
  ///   </item>
  /// </list>
  /// </remarks>
  /// </summary>
  public class Shape
  {
    /// <summary>
    /// Возвращает вычисленную площадь фигуры.
    /// </summary>
    public double Area { get; private set; }

    private readonly double[] dimensions;
    private enum ShapeType
    {
      Circle,
      Triangle
    }
    private ShapeType type;

    /// <summary>
    /// Инициализирует новый экземпляр класса <see cref="Shape"/> с заданными измерениями.
    /// </summary>
    /// <param name="dimensions">Массив размеров, представляющих стороны или радиус фигуры.</param>
    /// <exception cref="ArgumentException">Вызывается, если массив dimensions имеет не поддерживаемую длину</exception>
    /// <exception cref="ArgumentOutOfRangeException">Вызывается, если массив dimensions содержит отрицательное или нулевое значение.</exception>
    public Shape(double[] dimensions)
    {
      switch (dimensions.Length)
      {
        case 0:
          throw new ArgumentException("Требуется хотя бы одно измерение");
        case 1: // круг
          type = ShapeType.Circle;
          double radius = dimensions[0];
          CalculateCircleArea(radius);
          break;
        case 3: // треугольник
          type = ShapeType.Triangle;
          double a = dimensions[0];
          double b = dimensions[1];
          double c = dimensions[2];
          CalculateTriangleArea(a, b, c);
          break;
        default:
          throw new ArgumentException("Размеры не соответствуют ни одной поддерживаемой фигуре.");
      }
      this.dimensions = dimensions;
    }

    private void CalculateCircleArea(double radius)
    {
      if (radius <= 0)
      {
        throw new ArgumentOutOfRangeException(nameof(radius), "Радиус должен быть положительным");
      }

      Area = Math.PI * radius * radius;
    }

    private void CalculateTriangleArea(double a, double b, double c)
    {
      if (a + b <= c || b + c <= a || c + a <= b)
      {
        throw new ArgumentException("Стороны не образуют допустимый треугольник.");
      }
      double p = (a + b + c) / 2;
      Area = Math.Sqrt(p * (p - a) * (p - b) * (p - c));
    }

    /// <summary>
    /// Определяет, является ли треугольник с заданной длиной сторон прямоугольным.
    /// </summary>
    /// <exception cref="InvalidOperationException">Вызывается, если фигура не является треугольником.</exception>
    /// <returns>true, если треугольник является прямоугольным; false в противном случае.</returns>
    public bool IsRightTriangle()
    {
      if (type != ShapeType.Triangle)
      {
        throw new InvalidOperationException("Метод доступен только для треугольников");
      }

      double a = dimensions[0];
      double b = dimensions[1];
      double c = dimensions[2];
      // По теореме пифагора
      return a * a + b * b == c * c || a * a + c * c == b * b || b * b + c * c == a * a;
    }
  }
}
