using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBoard
{
    internal class RemoteJobOffer : JobOffer
    {
        private bool fullyremote;
        public bool FullyRemote { get { return fullyremote; } set { fullyremote = value; } }
        public RemoteJobOffer(string jobtitle, string company, double salary, bool fullyremote) : base(jobtitle, company, salary)
        {
            FullyRemote = fullyremote;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Job Title: {JobTitle}");
            sb.AppendLine($"Company: {Company}");
            sb.AppendLine($"Salary: {Salary:f33} BGN");
            if (FullyRemote == true)
            {
                sb.AppendLine($"yes");
            }
            else
            {
                sb.AppendLine($"no");
            }
            return sb.ToString();
        }
    }
}
