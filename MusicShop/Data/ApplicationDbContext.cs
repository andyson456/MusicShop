using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MusicShop.Models;

namespace MusicShop.Data
{
	public class ApplicationDbContext : IdentityDbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
		}

		public DbSet<Guitar> Guitar { get; set; }
		public DbSet<Drum> Drum { get; set; }
		public DbSet<Recording> Recording { get; set; }
		public DbSet<Product> Product { get; set; }
	}
}
