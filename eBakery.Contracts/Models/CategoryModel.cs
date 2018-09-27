using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace eBakery.Contracts.Models
{
    public class CategoryModel
    {
        [Key]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }
        public int ParentCategoryId { get; set; }
        public int StatusId { get; set; }
    }

    public class CategoryDisplayModel
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }
        public string ParentCategoryName { get; set; }
        public string StatusName { get; set; }
    }
}
