using WDVA_ECommerce.Shared.DTOs;

namespace WDVA_ECommerce.Client.Services.CartService
{
	public interface ICartService
	{
		event Action OnChange;
		Task AddToCart(CartItem cartItem);
		Task<List<CartProductDTO>> GetCartProducts();
		Task RemoveProductFromCart(int productId);
		Task UpdateQuantity(CartProductDTO product);
		Task StoreCartItems(bool emptyLocalCart);
		Task GetCartItemsCount();		
	}
}
