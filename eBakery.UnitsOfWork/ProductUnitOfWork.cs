using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using eBakery.Contracts.Services;
using eBakery.Contracts.Models;
using eBakery.UnitOfWork.ViewModels;
using System.Threading.Tasks;

namespace eBakery.UnitOfWork
{
    public class ProductUnitOfWork: IProductUnitOfWork
    {
        private readonly IProductService _productService;

        public ProductUnitOfWork(IProductService productService)
        {
            _productService = productService;

        }
        public async Task<List<ProductDisplayViewModel>> ProductDisplayList()
        {
            var product = await _productService.ProductDisplayList();

            if (product != null)
            {
                var productItems = product.Select(x => new ProductDisplayViewModel
                {
                    ProductId = x.ProductId,
                    ProductName = x.ProductName,
                    ProductCode = x.ProductCode,
                    CategoryName = x.CategoryName,
                    SupplierName = x.SupplierName,
                    UnitPrice = x.UnitPrice,
                    UnitSalePrice = x.UnitSalePrice,
                    UnitsInStock = x.UnitsInStock,
                    UnitsOnOrder = x.UnitsOnOrder,
                    QuantityPerUnit = x.QuantityPerUnit,
                    StatusName = x.StatusName
                }).ToArray();
                return productItems.ToList();
            }
            return null;
        }

        public async Task<ProductViewModel> ProductById(int ProductId)
        {
            var p = await _productService.ProductById(ProductId);

            ProductViewModel pVM = new ProductViewModel();
            pVM.ProductId = p.ProductId;
            pVM.ProductName = p.ProductName;
            pVM.ProductCode = p.ProductCode;
            pVM.CategoryId = p.CategoryId;
            pVM.SupplierId = p.SupplierId;
            pVM.UnitPrice = p.UnitPrice;
            pVM.UnitSalePrice = p.UnitSalePrice;
            pVM.UnitsInStock = p.UnitsInStock;
            pVM.UnitsOnOrder = p.UnitsOnOrder;
            pVM.QuantityPerUnit = p.QuantityPerUnit;
            pVM.StatusId = p.StatusId;

            return pVM;
        }

    }
}
