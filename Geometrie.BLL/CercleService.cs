using Geometrie.BLL;
using Geometrie.DAL;
using System.Collections.Generic;

namespace Geometrie.Service
{
    public class CercleService : ICercleService
    {
        private readonly CercleRepository _repository;

        public CercleService(CercleRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Cercle> GetAll()
        {
            return _repository.GetAll().Select(c => new Cercle(
                new Point(c.Centre.X, c.Centre.Y),
                c.Rayon));
        }

        public Cercle? GetById(int id)
        {
            var cercle = _repository.GetById(id);
            return cercle != null ? new Cercle(new Point(c.Centre.X, c.Centre.Y), cercle.Rayon) : null;
        }

        public Cercle Add(Cercle cercle)
        {
            var cercleDAL = new Cercle_DAL
            {
                Rayon = cercle.Rayon,
                Centre = new Point_DAL(cercle.Centre.X, cercle.Centre.Y)
            };
            _repository.Add(cercleDAL);
            return cercle;
        }

        public bool Delete(int id)
        {
            return _repository.Delete(id);
        }

        public double CalculateTotalArea(IEnumerable<int> ids)
        {
            return _repository.CalculateTotalArea(ids);
        }
    }
}
