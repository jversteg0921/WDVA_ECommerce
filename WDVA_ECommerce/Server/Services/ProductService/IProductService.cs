﻿namespace WDVA_ECommerce.Server.Services.ProductService
{
	public interface IProductService
	{
		Task<ServiceResponse<List<Product>>> GetProductsAsync();
	}
}
