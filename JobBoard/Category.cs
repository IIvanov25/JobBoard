using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBoard
{
    internal class Category
    {
        private string name;
        private List<JobOffer> jobOffers;

        public string Name
        {
            get { return name; }
            set
            {
                if (value.Length < 2 || value.Length > 40)
                {
                    throw new ArgumentException("Name should be between 2 and 40 characters!");
                }
                name = value;
            }
        }
        public Category(string name)
        {
            Name = name;
            jobOffers = new List<JobOffer>();
        }
        public void AddJobOffer(JobOffer offer)
        {
            jobOffers.Add(offer);
        }
        public double AverageSalary()
        {
            double averageSalary = 0;
            foreach (var offer in jobOffers)
            {
                averageSalary += offer.Salary;
            }
            return averageSalary / jobOffers.Count;
        }
        public List<JobOffer> GetOffersAboveSalary(double salary)
        {
            List<JobOffer> jobOffersAboveSalaryLevel = new List<JobOffer>();
            foreach (var offer in jobOffers)
            {
                if (offer.Salary >= salary)
                {
                    jobOffersAboveSalaryLevel.Add(offer);
                }
            }
            jobOffersAboveSalaryLevel.OrderByDescending(x => x.Salary);
            return jobOffersAboveSalaryLevel;
        }
        public List<JobOffer> GetOffersWithoutSalary()
        {
            List<JobOffer> jobOffersWithZeroSalary = new List<JobOffer>();
            foreach (var offer in jobOffers)
            {
                if (offer.Salary == 0)
                {
                    jobOffersWithZeroSalary.Add(offer);
                }
            }
            jobOffersWithZeroSalary.OrderBy(x => x.Company);
            return jobOffersWithZeroSalary;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Category {Name}");
            sb.AppendLine($"Total offers: {jobOffers.Count}");
            return sb.ToString();
        }
    }
}
