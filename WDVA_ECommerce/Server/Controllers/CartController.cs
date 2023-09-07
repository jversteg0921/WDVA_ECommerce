using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;
using System.Security.Claims;
using WDVA_ECommerce.Shared.DTOs;

namespace WDVA_ECommerce.Server.Controllers
{
	/// <summary>
	/// Cart and cart item management
	/// </summary>
	[Route("api/[controller]")]
	[ApiController]
	public class CartController : ControllerBase
	{
		private readonly ICartService _cartService;

		public CartController(ICartService cartService)
        {
			_cartService=cartService;
		}

		/// <summary>
		/// Gets a list of all items currently in cart
		/// </summary>
		/// <param name="cartItems"></param>
		/// <returns></returns>
		[HttpPost("products")]
		public async Task<ActionResult<ServiceResponse<List<CartProductDTO>>>> GetCartProducts(List<CartItem> cartItems)
		{
			var result = await _cartService.GetCartProducts(cartItems);
			return Ok(result);
		}

		/// <summary>
		/// Stores all local cart items in database
		/// </summary>
		/// <param name="cartItems"></param>
		/// <returns></returns>
		[HttpPost]
		public async Task<ActionResult<ServiceResponse<List<CartProductDTO>>>> StoreCartItems(List<CartItem> cartItems)
		{			
			var result = await _cartService.StoreCartItems(cartItems);
			return Ok(result);
		}

		/// <summary>
		/// Adds item to local cart
		/// </summary>
		/// <param name="cartItem"></param>
		/// <returns></returns>
		[HttpPost("add")]
		public async Task<ActionResult<ServiceResponse<bool>>> AddToCart(CartItem cartItem)
		{
			var result = await _cartService.AddToCart(cartItem);
			return Ok(result);
		}

		/// <summary>
		/// Updates the quantity of a cart item in cart
		/// </summary>
		/// <param name="cartItem"></param>
		/// <returns></returns>
		[HttpPut("update-quantity")]
		public async Task<ActionResult<ServiceResponse<bool>>> UpdateQuantity(CartItem cartItem)
		{
			var result = await _cartService.UpdateQuantity(cartItem);
			return Ok(result);
		}

		/// <summary>
		/// Removes a cart item from cart
		/// </summary>
		/// <param name="productId"></param>
		/// <returns></returns>
		[HttpDelete("{productId}")]
		public async Task<ActionResult<ServiceResponse<bool>>> RemoveItemFromCart(int productId)
		{
			var result = await _cartService.RemoveItemFromCart(productId);
			return Ok(result);
		}

		/// <summary>
		/// Gets total number of cart items in cart
		/// </summary>
		/// <returns></returns>
		[HttpGet("count")]
		public async Task<ActionResult<ServiceResponse<int>>> GetCartItemsCount()
		{
			return await _cartService.GetCartItemsCount();
		}

		/// <summary>
		/// Gets a list of all items currently in cart database
		/// </summary>
		/// <param"></param>
		/// <returns></returns>
		[HttpGet]
		public async Task<ActionResult<ServiceResponse<List<CartProductDTO>>>> GetDbCartProducts()
		{
			var result = await _cartService.GetDbCartProducts();
			return Ok(result);
		}


	}
}
