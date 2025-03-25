class Program
{
    static readonly string[] ZADANIA_OPCJE = { "1", "2", "3" };
    static readonly string[] DZIALANIA_OPCJE = { "+", "-", "*", "/" };

    static double Kalkulator(double liczba1, double liczba2, string dzialanie)
    {
        return dzialanie switch
        {
            "+" => liczba1 + liczba2,
            "-" => liczba1 - liczba2,
            "*" => liczba1 * liczba2,
            "/" => liczba2 == 0 ? throw new DivideByZeroException("Nie można dzielić przez zero!") : liczba1 / liczba2,
            _ => throw new ArgumentException("Niepoprawne działanie!")
        };
    }

    static void Main()
    {
        Console.WriteLine("Wybierz zadanie wpisując odpowiednią cyfrę: 1 - kalkulator, 2 - konwerter temperatur, 3 - średnia ocen ucznia.");
        string wybraneZadanie = Console.ReadLine();
        if (!ZADANIA_OPCJE.Contains(wybraneZadanie))
        {
            throw new ArgumentException("Wprowadzono niepoprawną wartość!");
        }

        switch (wybraneZadanie)
        {
            case "1":
                Console.WriteLine("Wpisz wartość pierwszej liczby:");
                double liczba1 = double.Parse(Console.ReadLine());
                Console.WriteLine("Wpisz wartość drugiej liczby:");
                double liczba2 = double.Parse(Console.ReadLine());
                Console.WriteLine("Wybierz działanie [+ - * /]:");
                string dzialanie = Console.ReadLine();
                if (!DZIALANIA_OPCJE.Contains(dzialanie))
                {
                    throw new ArgumentException("Wprowadzono niepoprawną wartość!");
                }
                double wynik = Kalkulator(liczba1, liczba2, dzialanie);
                Console.WriteLine($"Otrzymany wynik: {wynik}");
                break;
        }
    }
}