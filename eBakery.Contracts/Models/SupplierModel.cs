using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace eBakery.Contracts.Models
{
    public class SupplierModel
    {
        [Key]
       public int SupplierId {get;set;}
       public string CompanyName {get;set;}
        public string ContactName { get;set;}
        public string ContactTitle { get;set;}
        public string Address { get;set;}
        public string City { get;set;}            
        public int StateId { get;set;}
        public string ZipCode { get;set;}    
        public int RegionId { get;set;}
        public int CountryId { get;set;}
        public string Phone {get;set;}
        public string Email { get;set;}
        public string Notes { get;set;}
    }

    public class SupplierDisplayModel
    {
        public int SupplierId { get; set; }
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string ContactTitle { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string StateName { get; set; }
        public string ZipCode { get; set; }
        public string RegionName { get; set; }
        public string CountryName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Notes { get; set; }
    }

}
