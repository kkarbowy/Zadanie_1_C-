class Program
{
    static readonly string[] ZADANIA_OPCJE = { "1", "2", "3" };
    static readonly string[] DZIALANIA_OPCJE = { "+", "-", "*", "/" };
    static readonly string[] KONWERSJE_OPCJE = { "f", "c" };

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

    static double KonwerterTemperatur(string kierunekKonwersji, double temperatura)
    {
        return kierunekKonwersji switch
        {
            "c" => temperatura * 1.8 + 32,
            "f" => (temperatura - 32) / 1.8,
            _ => throw new ArgumentException("Niepoprawny kierunek konwersji!")
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

            case "2":
                Console.WriteLine("Wybierz konwersję ['c' - Celsjusz -> Fahrenheit, 'f' - Fahrenheit -> Celsjusz]:");
                string przelicznik = Console.ReadLine();
                Console.WriteLine("Wpisz wartość temperatury:");
                double temperatura = double.Parse(Console.ReadLine());
                if (!KONWERSJE_OPCJE.Contains(przelicznik))
                {
                    throw new ArgumentException("Wprowadzono niepoprawną wartość!");
                }
                string przelicznikString = przelicznik == "c" ? "Fahrenheita" : "Celsjusza";
                double wynik2 = KonwerterTemperatur(przelicznik, temperatura);
                Console.WriteLine($"Otrzymany wynik: {wynik2} stopni {przelicznikString}");
                break;
        }
    }
}