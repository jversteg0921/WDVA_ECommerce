using WDVA_ECommerce.Shared.DTOs;

namespace WDVA_ECommerce.Server.Services.CartService
{
	public interface ICartService
	{
		Task<ServiceResponse<List<CartProductDTO>>> GetCartProducts(List<CartItem> cartItems);
	}
}
