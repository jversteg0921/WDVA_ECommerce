using WDVA_ECommerce.Shared.DTOs;

namespace WDVA_ECommerce.Server.Services.OrderService
{
	public interface IOrderService
	{
		Task<ServiceResponse<bool>> PlaceOrder();
		Task<ServiceResponse<List<OrderOverviewDTO>>> GetOrders();
		Task<ServiceResponse<OrderDetailsDTO>> GetOrdersDetails(int orderId);
	}
}
