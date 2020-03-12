using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicShop.Models
{
	public class Guitar
	{
		public int Id { get; set; }
		public string Brand { get; set; }
		public string ModelName { get; set; }
		public int NumOfStrings { get; set; }
		public string Description { get; set; }
		public decimal Price { get; set; }
		public string ImagePath { get; set; }
	}
}
