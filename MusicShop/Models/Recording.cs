using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicShop.Models
{
	public class Recording
	{
		public int Id { get; set; }
		public string Brand { get; set; }
		public string Model { get; set; }
		public string Description { get; set; }
		public decimal Price { get; set; }
	}
}
