using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicShop.ViewModels
{
	public class DrumCreateViewModel
	{
		public string Brand { get; set; }
		public string PercussionModel { get; set; }
		public string Description { get; set; }
		public decimal Price { get; set; }
		public IFormFile Image { get; set; }
	}
}
