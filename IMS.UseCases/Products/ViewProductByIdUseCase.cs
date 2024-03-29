﻿using IMS.CoreBusiness.Entities;
using IMS.UseCases.PluginIRepositories;
using IMS.UseCases.Products.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.UseCases.Products
{
    public class ViewProductByIdUseCase : IViewProductByIdUseCase
    {
        private readonly IProductRepository _productRepository;

        public ViewProductByIdUseCase(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Product> ExecuteAsync(int productId)
        {
            return await _productRepository.GetProductByIdAsync(productId);
        }
    }
}
