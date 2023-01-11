using ApiCajero.IntegrationModels;
using ApiCajero.Models;

namespace ApiCajero.Services
{
    public class PersonService : IPersonService
    {
        private List<Person> people = null;
        public PersonService()
        {
            people = new List<Person>();
            people.Add(new Person { Id = 1, Dni = "XXXXXX", Name = "Name1", Surname = "Apellido1" });
            people.Add(new Person { Id = 2, Dni = "YYYYYY", Name = "Name2", Surname = "Apellido2" });
            people.Add(new Person { Id = 3, Dni = "ZZZZZZ", Name = "Name3", Surname = "Apellido3" });
            people.Add(new Person { Id = 4, Dni = "AAAAAA", Name = "Name4", Surname = "Apellido4" });
        }

        public ServiceResultSingleElement<Person> Get(string Dni)
        {
            var person = new ServiceResultSingleElement<Person>();
            var personBd = people.Where(c => c.Dni.Equals(Dni)).FirstOrDefault();
            if (personBd == null)
            {
                person.Errors.Add("Person not found");
                return person;
            }
            person.Element = personBd;

            return person;
        }

        public ServiceResultSingleElement<Person> Get(int id)
        {
            var person = new ServiceResultSingleElement<Person>();
            var personBd = people.Where(c => c.Id.Equals(id)).FirstOrDefault();
            if (personBd == null)
            {
                person.Errors.Add("Person not found");
                return person;
            }
            person.Element = personBd;

            return person;
        }
    }
}
