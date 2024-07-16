using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBoard
{
    internal class OnSiteJobOffer : JobOffer
    {
        private string city;

        public string City
        {
            get { return city; }
            set {
                if (value.Length < 3 || value.Length > 30)
                {
                    throw new ArgumentException("City should be between 3 and 30 characters!");
                }
                city = value; }
        }
        public OnSiteJobOffer(string jobtitle, string company, double salary, string city) : base(jobtitle, company, salary)
        {
            City = city;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Job Title: {JobTitle}");
            sb.AppendLine($"Company: {Company}");
            sb.AppendLine($"Salary: {Salary:f2} BGN");
            sb.AppendLine($"City: {City}");
            return sb.ToString();
        }
    }
}
