//https://github.com/Vgltu-kostik/algebra-miapo

class Algebra
{
    public static void Main()
    {
        var a = -2.9;
        var b = -2.8;
        var accuracy = Math.Pow(10, -3);
        var c = FindConvergence(a, b);
        var x = (a == c) ? b : a;

        Console.WriteLine($"По методу касательных(Ньютона) = {NewtonMethod(c, accuracy)}");
        Console.WriteLine($"По методу хорд(секущих) = {ChordMethod(x, c, accuracy)}");
    }
    // 2 Вариант
    private static double Function(double x)
        => x - (10 * Math.Sin(x));
    private static double DiffFunction(double x)
        => 1 - (10 * Math.Cos(x));
    private static double DoubleDiffFunction(double x)
        => 10 * Math.Sin(x);
    // Итерации для методов
    private static double ChordIteration(double x, double c)
        => (c * Function(x) - x * Function(c)) / (Function(x) - Function(c));
    private static double NewtonIteration(double x)
        => x - (Function(x) / DiffFunction(x));
    // Находим сходимость
    private static double FindConvergence(double a, double b)
    {
        var funcA = Function(a);
        var difFuncA = DoubleDiffFunction(funcA);

        return (funcA * difFuncA > 0) ? a : b;
    }
    // Методы нахождения корней
    private static double ChordMethod(double x, double c, double accuracy)
    {
        if (Math.Abs(Function(x)) < accuracy)
            return x;

        var currentIteration = ChordIteration(x, c);
        return ChordMethod(currentIteration, c, accuracy);
    }
    private static double NewtonMethod(double x, double accuracy)
    {
        if (Math.Abs(Function(x)) < accuracy)
            return x;

        var currentIteration = NewtonIteration(x);
        return NewtonMethod(currentIteration, accuracy);
    }
}