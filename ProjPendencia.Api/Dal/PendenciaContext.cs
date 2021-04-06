using Microsoft.EntityFrameworkCore;
using ProjPendencia.Api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjPendencia.Api.Dal
{
	public class PendenciaContext : DbContext
	{
		public PendenciaContext(DbContextOptions<PendenciaContext> options): base(options)
		{
		}

		public DbSet<Pendencia> Pendencia { get; set; }
	}
}
