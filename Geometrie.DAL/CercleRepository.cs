using System.Collections.Generic;
using System.Linq;

namespace Geometrie.DAL
{
    public class CercleRepository
    {
        private readonly GeometrieContext _context;

        public CercleRepository(GeometrieContext context)
        {
            _context = context;
        }

        public IEnumerable<Cercle_DAL> GetAll()
        {
            return _context.Cercles.ToList();
        }

        public Cercle_DAL? GetById(int id)
        {
            return _context.Cercles.Find(id);
        }

        public Cercle_DAL Add(Cercle_DAL cercle)
        {
            cercle.DateDeCreation = DateTime.Now;
            _context.Cercles.Add(cercle);
            _context.SaveChanges();
            return cercle;
        }

        public Cercle_DAL? Update(int id, Cercle_DAL updatedCercle)
        {
            var existing = _context.Cercles.Find(id);
            if (existing == null) return null;

            existing.Rayon = updatedCercle.Rayon;
            existing.Centre = updatedCercle.Centre;
            existing.DateDeModification = DateTime.Now;

            _context.SaveChanges();
            return existing;
        }

        public bool Delete(int id)
        {
            var cercle = _context.Cercles.Find(id);
            if (cercle == null) return false;

            _context.Cercles.Remove(cercle);
            _context.SaveChanges();
            return true;
        }

        public double CalculateTotalArea(IEnumerable<int> ids)
        {
            return _context.Cercles
                .Where(c => ids.Contains(c.Id.Value))
                .Sum(c => Math.PI * Math.Pow(c.Rayon, 2));
        }
    }
}
