using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicShop.ViewModels
{
	public class GuitarCreateViewModel
	{
		public string Brand { get; set; }
		public string ModelName { get; set; }
		public int NumOfStrings { get; set; }
		public string Description { get; set; }
		public decimal Price { get; set; }
		public IFormFile Image { get; set; }
	}
}
