﻿using System;
using System.Collections.Generic;
using System.Text;

namespace eBakery.UnitOfWork.ViewModels
{
    public class CategoryViewModel
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }
        public int ParentCategoryId { get; set; }
        public int StatusId { get; set; }
    }

    public class CategoryDisplayViewModel
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }
        public string ParentCategoryName { get; set; }
        public string StatusName { get; set; }
    }
}
