using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace SalesWebMvc.Models
{
    public class Seller
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="{0} requered")]
        [StringLength(60,MinimumLength = 3, ErrorMessage = "{0} size shouuld be between {2} and {1}")]
        public string Name { get; set; }

        [Required(ErrorMessage = "{0} requered")]
        [EmailAddress(ErrorMessage = "Enter a valid email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "{0} requered")]
        [Display(Name = "Birth Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "{0} requered")]
        [Range(100.0,50000.0,ErrorMessage = "{0} must be from {1} to {2}")]
        [Display(Name = "Base Salary")]
        [DisplayFormat(DataFormatString ="{0:F2}")]
        public double BaseSalary { get; set; }

        public Department Department { get; set; }
        public int DepartmentId { get; set; }
        public ICollection<SalesRecord> Sales { get; set; } = new List<SalesRecord>();

        public Seller ()
        {
        }
        public Seller (int id,string name,string email,DateTime BirthDate,double BaseSalary,Department department)
        {
            Id=id;
            Name=name;
            Email=email;
            this.BirthDate=BirthDate;
            this.BaseSalary=BaseSalary;
            Department=department;
        }

        public void AddSales (SalesRecord sr)
        {
            Sales.Add(sr);
        }
        public void RemoveSales (SalesRecord sr)
        {
            Sales.Remove(sr);
        }
        public double TotalSales (DateTime initial,DateTime final)
        {
            return Sales.Where(sr => sr.Date>=initial&&sr.Date<=final).Sum(sr => sr.Amount);
        }
    }
}
