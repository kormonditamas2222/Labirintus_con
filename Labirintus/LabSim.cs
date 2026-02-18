using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labirintus
{
    internal class LabSim
    {
        private List<string> adatsorok;
        private char[,] lab;
        public LabSim(string forras) 
        {
            adatsorok = new List<string>();
            BeolvasAdatsorok(forras);
            lab = new char[SorokSzama, OszlopokSzama];
            FeltoltLab();
        }

        public bool KeresesKesz { get; set; }
        public int KijaratOszlopIndex => OszlopokSzama - 1;
        public int KijaratSorIndex => SorokSzama - 2;
        public bool NincsMegoldas { get; set; }
        public int OszlopokSzama => adatsorok[0].Length;
        public int SorokSzama => adatsorok.Count;

        private void BeolvasAdatsorok(string forras) 
        {
            foreach (var sor in File.ReadAllLines(forras))
            {
                adatsorok.Add(sor);
            }
        }
        private void FeltoltLab() 
        {
            for (int i = 0; i < SorokSzama; i++)
            {
                for (int j = 0; j < OszlopokSzama; j++)
                {
                    lab[i, j] = adatsorok[i][j];
                }
            }
        }
        public void KiirLab() 
        {
            for (int i = 0; i < SorokSzama; i++)
            {
                for (int j = 0; j < OszlopokSzama; j++)
                {
                    Console.Write(lab[i, j]);  
                }
                Console.WriteLine();
            }
        }  
        public void Utkereses() 
        {
            KeresesKesz = false;
            NincsMegoldas = false;
            int r = 1;
            int c = 0;
            while (!KeresesKesz && !NincsMegoldas)
            {
                lab[r, c] = 'O';
                if (lab[r, c+1] ==  ' ')
                {
                    c++;
                }
                else if (lab[r+1, c] == ' ')
                {
                    r++;
                }
                else
                {
                    lab[r, c] = '-';
                    if (lab[r, c-1] == 'O')
                    {
                        c--;
                    }
                    else
                    {
                        r--;
                    }
                }
                KeresesKesz = r == KijaratSorIndex && c == KijaratOszlopIndex;
                if (KeresesKesz) lab[r, c] = 'O';
                NincsMegoldas = r == 1 && c == 0;
                KiirLab();
                if (KeresesKesz) Console.WriteLine("Útvonal megtalálva");
                else if (NincsMegoldas) Console.WriteLine("Nincs megoldás");
                Thread.Sleep(500);
            }
        }
    }
}
