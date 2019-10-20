using System;
using System.Collections.Generic;
using System.Linq;

namespace Vesta.Server.Domain
{
    public class Customer : Entity
    {
        private IList<Animal> _animals = new List<Animal>();

        protected Customer(Guid id) : base(id) { }
        public Customer(Guid id, long number, FullName name, Email email, Address address) : base(id)
        {
            Number = number;
            Name = name;
            Email = email;
            Address = address;
        }

        public long Number { get; private set; }
        public FullName Name { get; private set; }
        public Email Email { get; private set; }
        public Address Address { get; set; }
        public IEnumerable<Animal> Animals => _animals.ToList();

        public Animal AddAnimal(
            Guid id,
            string name,
            string gender,
            int yearOfBirth,
            string exterior,
            Address locatedAt,
            string medicalHistory)
        {
            var animal = new Animal(id, name, gender, yearOfBirth, exterior, locatedAt, medicalHistory);
            _animals.Add(animal);
            return animal;
        }
    }
}
