using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicShop.Models
{
	public class Product
	{
		public int Id { get; set; }

		public virtual Guitar Guitar { get; set; }
		public virtual Drum Drum { get; set; }
		public virtual Recording Recording { get; set; }
	}
}
