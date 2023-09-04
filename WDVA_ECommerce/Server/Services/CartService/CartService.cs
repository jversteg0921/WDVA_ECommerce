using WDVA_ECommerce.Shared.DTOs;

namespace WDVA_ECommerce.Server.Services.CartService
{
	public class CartService : ICartService
	{
		private readonly DataContext _context;

		public CartService(DataContext context)
        {
			_context=context;
		}
        public async Task<ServiceResponse<List<CartProductDTO>>> GetCartProducts(List<CartItem> cartItems)
		{
			var result = new ServiceResponse<List<CartProductDTO>>()
			{
				Data = new List<CartProductDTO>()
			};

			foreach(var item in cartItems) {
				var product = await _context.Products
					.Where(p => p.Id == item.ProductId)
					.FirstOrDefaultAsync();

				if(product == null)
				{
					continue;
				}

				var cartProduct = new CartProductDTO
				{
					ProductId = product.Id,
					Title = product.Title,
					ImgUrl = product.ImgUrl,
					Price = product.Price,
					Quantity = item.Quantity
				};

				result.Data.Add(cartProduct);
				
			}

			return result;
		}
	}
}
