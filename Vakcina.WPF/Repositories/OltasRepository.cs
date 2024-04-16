using System;
using System.Collections.Generic;
using System.Linq;
using Vakcina.API.Models;

namespace Vakcina.WPF.Repositories
{
    public class OltasRepository
    {
        private readonly VakcinaContext _context;

        public OltasRepository(VakcinaContext context)
        {
            _context = context;
        }

        public int TotalItems;

        public List<oltas> GetAll(
            int page = 1, int itemsPerPage = 20,
            string? search = null,
            string? sortBy = null, bool ascending = true)
        {
            var query = _context.Oltasok;

            // TODO: 08. Bejelentkezett felhasználóra szűkíteni az adatokat, ha nem 'admin' szerepkörű

            // TODO: 02.a Keresés készítése (szöveg, szám, dátum értékekkel)
            // Keresés

            // TODO: 03 Sorbarendezés készítése

            // Összes találat kiszámítása
            TotalItems = query.Count();

            // Oldaltördelés
            if (page + itemsPerPage > 0)
            {
                query = query.Skip((page - 1) * itemsPerPage).Take(itemsPerPage);
            }
            return query.ToList();
        }
    }
}