﻿using IMS.CoreBusiness.Entities;

namespace IMS.UseCases.Products.Interfaces
{
    public interface IViewProductByIdUseCase
    {
        Task<Product> ExecuteAsync(int productId);
    }
}