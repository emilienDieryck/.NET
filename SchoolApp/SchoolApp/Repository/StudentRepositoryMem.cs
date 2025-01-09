using School.Repository;
using SchoolApp.Models;

namespace SchoolApp.Repositories
{
    class StudentRepositoryMem : IRepository<Student>
    {
        private List<Student> _students = new List<Student>();

        public void Delete(Student entity)
        {
            throw new NotImplementedException();
        }

        public IList<Student> GetAll()
        {
            return _students;
        }

        public Student GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Student entity)
        {
            _students.Add(entity);
        }

        public IList<Student> SearchFor(System.Linq.Expressions.Expression<Func<Student, bool>> predicate)
        {
            return _students.Where(predicate.Compile()).ToList();
        }

        public bool Save(Student entity, System.Linq.Expressions.Expression<Func<Student, bool>> predicate)
        {
            Student ent = (SearchFor(predicate)).FirstOrDefault();

            if (ent == null)
            {
                Insert(entity);
                return true;
            }
            return false;
        }
    }

}
