using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WDVA_ECommerce.Shared
{
	public class CartItem
	{
        public int ProductId { get; set; }
        public int Quantity { get; set; } = 1;
    }
}
