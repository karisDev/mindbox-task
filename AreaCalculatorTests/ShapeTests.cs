using AreaCalculator;

namespace AreaCalculatorTests
{
  [TestClass]
  public class ShapeTests
  {
    [TestMethod]
    public void TestCircleArea()
    {
      var radius = 5.0;
      var circle = new Shape(new double[] { radius });

      var result = circle.Area;

      Assert.AreEqual(Math.PI * radius * radius, result, 0.0001);
    }

    [TestMethod]
    public void TestTriangleArea()
    {
      var a = 3.0;
      var b = 4.0;
      var c = 5.0;
      var triangle = new Shape(new double[] { a, b, c });

      var s = (a + b + c) / 2.0;
      var result = Math.Sqrt(s * (s - a) * (s - b) * (s - c));

      Assert.AreEqual(result, triangle.Area, 0.0001);
    }

    [TestMethod]
    public void TestRightTriangle()
    {
      var triangle = new Shape(new double[] { 3, 4, 5 });

      bool result = triangle.IsRightTriangle();

      Assert.IsTrue(result);
    }

    [TestMethod]
    public void TestNotRightTriangle()
    {
      var triangle = new Shape(new double[] { 3, 4, 6 });

      bool result = triangle.IsRightTriangle();

      Assert.IsFalse(result);
    }
  }
}
