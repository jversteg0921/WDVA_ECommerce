using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WDVA_ECommerce.Shared.DTOs;

namespace WDVA_ECommerce.Server.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class OrderController : ControllerBase
	{
		private readonly IOrderService _orderService;

		public OrderController(IOrderService orderService)
        {
			_orderService=orderService;
		}

		[HttpPost]
		public async Task<ActionResult<ServiceResponse<bool>>> PlaceOrder()
		{
			var results = await _orderService.PlaceOrder();
			return Ok(results);
		}

		[HttpGet]
		public async Task<ActionResult<ServiceResponse<OrderOverviewDTO>>> GetOrders()
		{
			var results = await _orderService.GetOrders();
			return Ok(results);
		}

		[HttpGet("{orderId}")]
		public async Task<ActionResult<ServiceResponse<OrderDetailsDTO>>> GetOrderDetails(int orderId)
		{
			var results = await _orderService.GetOrdersDetails(orderId);
			return Ok(results);
		}
	}
}
