namespace Labirintus
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LabSim ls = new LabSim("lab3.txt");
            Console.WriteLine("5. feladat: Labrintus adatai: ");
            Console.WriteLine("Sorok száma: " + ls.SorokSzama);
            Console.WriteLine("Oszlopok száma: " + ls.OszlopokSzama);
            Console.WriteLine("Kijárat indexe: sor :" + ls.KijaratSorIndex + " oszlop: " + ls.KijaratOszlopIndex);
            Console.WriteLine("6. feladat: A labirintus");
            ls.KiirLab();
            Console.WriteLine("8. feladat");
            ls.Utkereses();
        }
    }
}
