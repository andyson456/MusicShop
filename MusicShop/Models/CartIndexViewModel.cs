using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicShop.Models
{
	public class CartIndexViewModel
	{
		public CustomerCart Cart { get; set; }
		public string ReturnUrl { get; set; }
	}
}
