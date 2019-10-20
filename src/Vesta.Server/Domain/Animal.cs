using System;
using System.Collections.Generic;
using System.Linq;

namespace Vesta.Server.Domain
{
    public class Animal : Entity
    {
        private IList<Journal> _journals = new List<Journal>();

        protected Animal(Guid id) : base(id) { }

        public Animal(
            Guid id,
            string name,
            string gender,
            int yearOfBirth,
            string exterior,
            Address locatedAt,
            string medicalHistory) : base(id)
        {
            Name = name;
            Gender = gender;
            YearOfBirth = yearOfBirth;
            Exterior = exterior;
            LocatedAt = locatedAt;
            MedicalHistory = medicalHistory;
        }

        public string Name { get; private set; }
        public string Gender { get; private set; }
        public int YearOfBirth { get; private set; }
        public string Exterior { get; private set; }
        public Address LocatedAt { get; private set; }
        public string MedicalHistory { get; private set; }

        public IEnumerable<Journal> Journals => _journals.ToList();

        public void AddJournal(
            Guid id,
            DateTime date,
            string findings,
            string workDone,
            string result,
            string followUp,
            string aftercare)
        {
            _journals.Add(new Journal(id, date, findings, workDone, result, followUp, aftercare));
        }
    }
}
