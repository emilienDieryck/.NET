using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET1
{
    public class PersonList
    {

        private static PersonList? instance = null;
        private IDictionary<string, Person> personMap;

        private PersonList()
        {
            personMap = new Dictionary<string, Person>();
        }


        public static PersonList Instance
        {
            get
            {
                if (instance == null)
                    instance = new PersonList();

                return instance;
            }
        }


        public void AddPerson(Person person)
        {
            if (person == null)
                throw new ArgumentNullException(nameof(person), "erreur ici");
            personMap.Add(person.Name, person);
        }

        public IEnumerator<Person> personList()
        {
            return personMap.Values.GetEnumerator();
        }

    }
}
