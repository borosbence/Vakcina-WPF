using System;
using System.Collections.Generic;
using System.Linq;
using Vakcina.API.Models;

namespace Vakcina.WPF.Repositories
{
    public class VakcinaContext
    {
        public VakcinaContext()
        {
            GenerateData();
        }

        /// <summary>
        /// Memóriában lévő orvos adatok
        /// </summary>
        public IEnumerable<orvos> Orvosok { get; set; } = null!;

        /// <summary>
        /// Memóriában lévő vakcina adatok
        /// </summary>
        public IEnumerable<vakcina> Vakcinak { get; set; } = null!;

        /// <summary>
        /// Memóriában lévő oltás adatok
        /// </summary>
        public IEnumerable<oltas> Oltasok { get; set; } = null!;

        private void GenerateData()
        {
            #region Orvosok generálása
            Orvosok = new List<orvos>()
            {
                new orvos()
                {
                    id = 1,
                    felhasznalo_nev = "admin",
                    jelszo = "admin",
                    megjelenitendo_nev = "Dr. Adminisz Sztaniszláv",
                    admin = true
                },
                new orvos()
                {
                    id = 2,
                    felhasznalo_nev = "zsivago",
                    jelszo = "zsivago",
                    megjelenitendo_nev = "Dr. Zsivágó Jurij Andrejevics",
                    admin = false
                },
                new orvos()
                {
                    id = 3,
                    felhasznalo_nev = "franky",
                    jelszo = "frankeinstein",
                    megjelenitendo_nev = "Dr. Victor Frankeinstein",
                    admin = false
                },
                new orvos()
                {
                    id = 4,
                    felhasznalo_nev = "drbrs",
                    jelszo = "berescsepp",
                    megjelenitendo_nev = "Dr. Béres József",
                    admin = false
                },
                new orvos()
                {
                    id = 5,
                    felhasznalo_nev = "emett",
                    jelszo = "visszaajovobe",
                    megjelenitendo_nev = "Dr. Emmett L. Brown",
                    admin = true
                },
                new orvos()
                {
                    id = 6,
                    felhasznalo_nev = "bubo",
                    jelszo = "kovetkezo",
                    megjelenitendo_nev = "Dr. Bubó Bodó",
                    admin = false
                }
            };
            #endregion

            #region Vakcinák generálása
            Vakcinak = new List<vakcina>()
            {
                new vakcina()
                {
                    id = 1,
                    megnevezes = "Pfizer-BioNtech",
                    szarmazasi_hely = "amerikai-német",
                    mennyiseg = 10874511,
                },
                new vakcina()
                {
                    id = 2,
                    megnevezes = "Moderna",
                    szarmazasi_hely = "amerikai",
                    mennyiseg = 1723610,
                },
                new vakcina()
                {
                    id = 3,
                    megnevezes = "AstraZeneca",
                    szarmazasi_hely = "brit-svéd",
                    mennyiseg = 6513460,
                },
                new vakcina()
                {
                    id = 4,
                    megnevezes = "Szputnyik",
                    szarmazasi_hely = "orosz",
                    mennyiseg = 2000000,
                },
                new vakcina()
                {
                    id = 5,
                    megnevezes = "Sinopharm",
                    szarmazasi_hely = "kínai",
                    mennyiseg = 5000000,
                },
            };
            #endregion

            #region Oltások generálása
            var _oltasok = new List<oltas>();

            IEnumerable<int> vakcinak = Enumerable.Range(1, 5);
            IEnumerable<int> orvosok = Enumerable.Range(1, 6);
            IEnumerable<int> oltasSzam = Enumerable.Range(1, 3);
            Random random = new Random();

            for (int i = 0; i < 100; i++)
            {
                int vakcina_id = random.Next(1, vakcinak.Count() + 1);
                int orvos_id = random.Next(1, orvosok.Count() + 1);
                _oltasok.Add(new oltas()
                {
                    taj_szam = (uint)random.Next(011111111, 999999999),
                    vakcina_id = vakcina_id,
                    oltas_szam = random.Next(1, 4),
                    datum_utolso = GetRandomDate(random),
                    orvos_id = orvos_id,
                    vakcina = Vakcinak.FirstOrDefault(x => x.id == vakcina_id),
                    orvos = Orvosok.FirstOrDefault(x => x.id == orvos_id)
                });
            }
            Oltasok = _oltasok;
            #endregion
        }

        private static DateTime GetRandomDate(Random random)
        {
            DateTime startDate = new DateTime(2022, 03, 01);
            DateTime endDate = new DateTime(2022, 04, 12);

            TimeSpan timeSpan = endDate - startDate;
            TimeSpan newSpan = new TimeSpan(0, random.Next(0, (int)timeSpan.TotalMinutes), 0);
            DateTime calcDate = startDate + newSpan;

            DateTime newDate = new DateTime(calcDate.Year, calcDate.Month, calcDate.Day);

            return newDate;
        }
    }
}
