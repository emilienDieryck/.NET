using School.Repository;
using SchoolApp.Models;

namespace SchoolApp.Repositories
{
    class SectionRepositoryMem : IRepository<Section>
    {
        private List<Section> _sections = new List<Section>();

        public void Delete(Section entity)
        {
            throw new NotImplementedException();
        }

        public IList<Section> GetAll()
        {
            return _sections;
        }

        public Section GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Section entity)
        {
            _sections.Add(entity);
        }

        public IList<Section> SearchFor(System.Linq.Expressions.Expression<Func<Section, bool>> predicate)
        {
            return _sections.Where(predicate.Compile()).ToList();
        }

        public bool Save(Section entity, System.Linq.Expressions.Expression<Func<Section, bool>> predicate)
        {
            Section ent = (SearchFor(predicate)).FirstOrDefault();

            if (ent == null)
            {
                Insert(entity);
                return true;
            }
            return false;
        }
    }
}