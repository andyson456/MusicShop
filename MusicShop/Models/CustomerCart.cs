using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicShop.Models
{
	public class CustomerCart
	{
		private List<CartLine> lineCollection = new List<CartLine>();

		public virtual void AddGuitar(Guitar guitar)
		{
			CartLine line = lineCollection
				.Where(g => g.Guitar.Id == guitar.Id)
				.FirstOrDefault();

			if (line == null)
			{
				lineCollection.Add(new CartLine
				{
					Guitar = guitar
					
				});
			}
		}

		public virtual void AddDrum(Drum drum)
		{
			CartLine line = lineCollection
				.Where(d => d.Drum.Id == drum.Id)
				.FirstOrDefault();

			if (line == null)
			{
				lineCollection.Add(new CartLine
				{
					Drum = drum
				});
			}
		}

		public virtual void AddRecording(Recording recording)
		{
			CartLine line = lineCollection
				.Where(r => r.Recording.Id == recording.Id)
				.FirstOrDefault();

			if (line == null)
			{
				lineCollection.Add(new CartLine
				{
					Recording = recording
				});
			}
		}

		public virtual IEnumerable<CartLine> Lines => lineCollection;
	}

	public class CartLine
	{
		public int CartLineID { get; set; }
		public Guitar Guitar { get; set; }
		public Drum Drum { get; set; }
		public Recording Recording { get; set; }
		public int Quantity { get; set; }
	}
}
