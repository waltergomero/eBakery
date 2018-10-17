using System;
using System.Collections.Generic;
using System.Text;

namespace eBakery.UnitOfWork.ViewModels
{
    public class ProductViewModel
    {
            public int ProductId { get; set; }
            public string ProductName { get; set; }
            public string ProductCode { get; set; }
            public int SupplierId { get; set; }
            public int CategoryId { get; set; }
            public int QuantityPerUnit { get; set; }
            public decimal UnitPrice { get; set; }
            public decimal UnitSalePrice { get; set; }
            public int UnitsInStock { get; set; }
            public int UnitsOnOrder { get; set; }
            public int ReorderLevel { get; set; }
            public bool Discontinued { get; set; }
            public int StatusId { get; set; }
            public string CreatedDate { get; set; }
            public string UpdatedDate { get; set; }
            public string CreatedBy { get; set; }
            public string UpdatedBy { get; set; }
        }
        public class ProductDisplayViewModel
        {
            public int ProductId { get; set; }
            public string ProductName { get; set; }
            public string ProductCode { get; set; }
            public string SupplierName { get; set; }
            public string CategoryName { get; set; }
            public int QuantityPerUnit { get; set; }
            public decimal UnitPrice { get; set; }
            public decimal UnitSalePrice { get; set; }
            public int UnitsInStock { get; set; }
            public int UnitsOnOrder { get; set; }
            public int ReorderLevel { get; set; }
            public bool Discontinued { get; set; }
            public string StatusName { get; set; }
            public string CreatedDate { get; set; }
            public string UpdatedDate { get; set; }
            public string CreatedBy { get; set; }
            public string UpdatedBy { get; set; }
        }
    }
