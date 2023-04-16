using System.Linq;

namespace Vakcina.WPF.Repositories
{
    public class FelhasznaloRepository
    {
        private readonly VakcinaContext _context;

        public FelhasznaloRepository(VakcinaContext context)
        {
            _context = context;
        }

        public string Authenticate(string username, string password)
        {
            // TODO: 06. Authentikálás befejezése

            // Ha sikeres a belépés: 
            return "Sikeres bejelentkezés.";

            // TODO: 07. Bejelentkezett felhasználó adatainak tárolása
            // Ha elrontotta a jelszót, ezzel tér vissza: 
            return "Hibás felhasználónév vagy jelszó.";
            // Ha nem létezik ilyen felhasználó:
            return "A felhasználó nem létezik.";
        }
    }
}
