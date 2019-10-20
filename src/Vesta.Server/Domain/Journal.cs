using System;

namespace Vesta.Server.Domain
{
    public class Journal : Entity
    {
        protected Journal(Guid id) : base(id) { }

        public Journal(
            Guid id,
            DateTime date,
            string findings,
            string workDone,
            string result,
            string followUp,
            string aftercare) : base(id)
        {
            Date = date;
            Findings = findings;
            WorkDone = workDone;
            Result = result;
            FollowUp = followUp;
            Aftercare = aftercare;
        }

        public DateTime Date { get; private set; }
        public string Findings { get; private set; }
        public string WorkDone { get; private set; }
        public string Result { get; private set; }
        public string FollowUp { get; private set; }
        public string Aftercare { get; private set; }
    }


}
