using System;

class Plane
{
    double A, B, C, D;
    public Plane(double a, double b, double c, double d)
    { A=a; B=b; C=c; D=d; Console.WriteLine($"✅ Створено: {A}x+{B}y+{C}z+{D}=0"); }
    ~Plane() { Console.WriteLine($"❌ Знищено: {A}x+{B}y+{C}z+{D}=0"); }
    public bool HasPoint(double x, double y, double z) => Math.Abs(A*x+B*y+C*z+D)<1e-9;
}

class Program
{
    static void Main()
    {
        Console.Write("n = "); int n=int.Parse(Console.ReadLine());
        var planes=new Plane[n];
        for(int i=0;i<n;i++){
            Console.WriteLine($"Площина {i+1}:");
            double A=double.Parse(Console.ReadLine()),
                   B=double.Parse(Console.ReadLine()),
                   C=double.Parse(Console.ReadLine()),
                   D=double.Parse(Console.ReadLine());
            planes[i]=new Plane(A,B,C,D);
        }

        Console.WriteLine("\nКоординати точки:");
        double x=double.Parse(Console.ReadLine()),
               y=double.Parse(Console.ReadLine()),
               z=double.Parse(Console.ReadLine());

        Console.WriteLine("\nПлощини, через які проходить точка:");
        bool ok=false;
        for(int i=0;i<n;i++)
            if(planes[i].HasPoint(x,y,z)){ Console.WriteLine($"→ {i+1}"); ok=true; }
        if(!ok) Console.WriteLine("Жодна.");

        planes=null;
        GC.Collect(); GC.WaitForPendingFinalizers();
        Console.WriteLine("\nКінець програми.");
    }
}