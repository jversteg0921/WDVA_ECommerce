﻿using WDVA_ECommerce.Shared.DTOs;

namespace WDVA_ECommerce.Client.Services.ProductService
{
	public class ProductService : IProductService
	{
		private readonly HttpClient _http;

		public ProductService(HttpClient http)
		{
			_http=http;
		}
        public List<Product> Products { get; set; } = new List<Product>();
		public string Message { get; set; } = "Loading Products...";
		public int CurrentPage { get; set; } = 1;
		public int PageCount { get; set; } = 0;
		public string LastSearchText { get; set; } = string.Empty;

		//Event allows any subscribed component to know something has been updated
		public event Action ProductsChanged;

		//Gets a single product from database, based on productId
		public async Task<ServiceResponse<Product>> GetProduct(int productId)
		{
			var result = await _http.GetFromJsonAsync<ServiceResponse<Product>>($"api/product/{productId}");
			return result;
		}

		//Gets all products from database if categoryUrl argument is empty.
		//Otherwise, get products with matching category
		public async Task GetProducts(string? categoryUrl = null)
		{
			var result = categoryUrl == null ?
				await _http.GetFromJsonAsync<ServiceResponse<List<Product>>>("api/product/featured") :
				await _http.GetFromJsonAsync<ServiceResponse<List<Product>>>($"api/product/category/{categoryUrl}");
			
			if(result != null && result.Data != null)
				Products = result.Data;

			CurrentPage = 1;
			PageCount = 0;

			if(Products.Count == 0)
			{
				Message = "No products found";
			}

			ProductsChanged.Invoke();
		}

		public async Task<List<string>> GetProductSearchSuggestions(string searchText)
		{
			var result = await _http.GetFromJsonAsync<ServiceResponse<List<string>>>($"api/product/searchsuggestions/{searchText}");
			return result.Data;

		}

		public async Task SearchProducts(string searchText, int page)
		{
			LastSearchText = searchText;
			var result = await _http.GetFromJsonAsync<ServiceResponse<ProductSearchResultDTO>>($"api/product/search/{searchText}/{page}");
			if (result !=null && result.Data != null)
			{
				Products = result.Data.Products;
				CurrentPage = result.Data.CurrentPage;
				PageCount = result.Data.Pages;
			}
			
			if (Products.Count == 0)
				Message = "No products found.";

			ProductsChanged?.Invoke();
		}
	}
}
