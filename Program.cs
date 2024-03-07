internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Parte reale e immaginaria");
        float a = float.Parse(Console.ReadLine());
        float b = float.Parse(Console.ReadLine());

        Complessi c = new Complessi(a, b);
        Console.WriteLine($"{c}");
        Console.WriteLine($"{c.Modulo}");
        Console.WriteLine($"{c.Angolo}");

        Console.ReadKey();
    }
}

class Complessi
{
    private readonly float _a;
    private readonly float _b;

    public Complessi() { }

    public Complessi(float a, float b)
    {
        _a = a;
        _b = b;
    }

    public float Modulo
    {
        get { return (float)Math.Sqrt(_a * _a + _b * _b); }
    }

    public float Angolo
    {
        get { return (float)((Math.Atan2(_b, _a) * 180) / Math.PI); }
    }

    public static Complessi Parse(string real, string immaginary)
    {
        if(float.TryParse(real, out float r) && float.TryParse(immaginary, out float i))
        {
            return new Complessi(r, i);
        } else
        {
            throw new FormatException("Formato non valido");
        }
    }

    public static bool TryParse(string real, string immaginary, out Complessi nC)
    {
        if(float.TryParse(real, out float r) && float.TryParse(immaginary, out float i))
        {
            nC = new Complessi(r, i);
            return true;
        } else
        {
            nC = default;
            return false;
        }
    }

    public override string ToString()
    {
        return $"{_a} + {_b}i";
    }
}