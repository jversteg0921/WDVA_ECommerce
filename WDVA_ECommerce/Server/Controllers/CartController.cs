﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;
using System.Security.Claims;
using WDVA_ECommerce.Shared.DTOs;

namespace WDVA_ECommerce.Server.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CartController : ControllerBase
	{
		private readonly ICartService _cartService;

		public CartController(ICartService cartService)
        {
			_cartService=cartService;
		}

		[HttpPost("products")]
		public async Task<ActionResult<ServiceResponse<List<CartProductDTO>>>> GetCartProducts(List<CartItem> cartItems)
		{
			var result = await _cartService.GetCartProducts(cartItems);
			return Ok(result);
		}

		[HttpPost]
		public async Task<ActionResult<ServiceResponse<List<CartProductDTO>>>> StoreCartItems(List<CartItem> cartItems)
		{			
			var result = await _cartService.StoreCartItems(cartItems);
			return Ok(result);
		}

		[HttpPost("add")]
		public async Task<ActionResult<ServiceResponse<bool>>> AddToCart(CartItem cartItem)
		{
			var result = await _cartService.AddToCart(cartItem);
			return Ok(result);
		}

		[HttpPut("update-quantity")]
		public async Task<ActionResult<ServiceResponse<bool>>> UpdateQuantity(CartItem cartItem)
		{
			var result = await _cartService.UpdateQuantity(cartItem);
			return Ok(result);
		}

		[HttpDelete("{productId}")]
		public async Task<ActionResult<ServiceResponse<bool>>> RemoveItemFromCart(int productId)
		{
			var result = await _cartService.RemoveItemFromCart(productId);
			return Ok(result);
		}

		[HttpGet("count")]
		public async Task<ActionResult<ServiceResponse<int>>> GetCartItemsCount()
		{
			return await _cartService.GetCartItemsCount();
		}

		[HttpGet]
		public async Task<ActionResult<ServiceResponse<List<CartProductDTO>>>> GetDbCartProducts()
		{
			var result = await _cartService.GetDbCartProducts();
			return Ok(result);
		}


	}
}
