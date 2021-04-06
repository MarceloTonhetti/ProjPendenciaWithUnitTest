using Microsoft.EntityFrameworkCore;
using System;
using Xunit;
using ProjPendencia.Api.Dal;
using ProjPendencia.Api.Controllers;
using System.Collections.Generic;
using ProjPendencia.Api.Entities;
using System.Linq;

namespace ProjPendencia.Tests
{
    public class PendenciaUnitTest
    {
        private DbContextOptions<PendenciaContext> options;

        private void InitializeDataBase()
        {
            // Criando um Database temporario
            options = new DbContextOptionsBuilder<PendenciaContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            // Inserindo dados no Database in memory
            using (var context = new PendenciaContext(options))
            {
                context.Pendencia.Add(new Api.Entities.Pendencia { Id = 1, Description = "Criar projeto teste", Data = DateTime.Now});
                context.Pendencia.Add(new Api.Entities.Pendencia { Id = 2, Description = "Validar testes", Data = DateTime.Now });
                context.Pendencia.Add(new Api.Entities.Pendencia { Id = 3, Description = "Concluir projeto", Data = DateTime.Now });
                context.SaveChanges();
            }
        }

        [Fact]
        public void GetAll()
        {
            InitializeDataBase();

            // Use uma instancia limpa (nova) de context para rodar o teste
            using (var context = new PendenciaContext(options))
            {
                PendenciaController pendenciaController = new PendenciaController(context);
                IEnumerable<Pendencia> pendencias = pendenciaController.GetPendencia().Result.Value;

                Assert.Equal(3, pendencias.Count());
            }
        }

        [Fact]
        public void GetById()
        {
            InitializeDataBase();

            using (var context = new PendenciaContext(options))
            {
                int pendenciaId = 2;
                PendenciaController pendenciaController = new PendenciaController(context);
                Pendencia pendencia = pendenciaController.GetPendencia(pendenciaId).Result.Value;

                Assert.Equal(pendenciaId, pendencia.Id);
            }
        }

        [Fact]
        public void Create()
        {
            InitializeDataBase();

            Pendencia pendencia = new Pendencia()
            {
                Id = 4,
                Description = "Testar o create",
                Data = DateTime.Now
            };

            using (var context = new PendenciaContext(options))
            {
                PendenciaController pendenciaController = new PendenciaController(context);
                Pendencia newPendencia = pendenciaController.PostPendencia(pendencia).Result.Value;

                Assert.Equal(pendencia.Id, newPendencia.Id);
            }
        }

        [Fact]
        public void Update()
        {
            InitializeDataBase();

            Pendencia pendencia = new Pendencia()
            {
                Id = 3,
                Description = "Testar o update",
                Data = DateTime.Now
            };

            using (var context = new PendenciaContext(options))
            {
                PendenciaController pendenciaController = new PendenciaController(context);
				Pendencia updatedPendencia = pendenciaController.PutPendencia(pendencia.Id, pendencia).Result.Value;
                Assert.Equal("Testar o update", updatedPendencia.Description);
            }
        }

        [Fact]
        public void Delete()
        {
            InitializeDataBase();

            // Use a clean instance of the context to run the test
            using (var context = new PendenciaContext(options))
            {
                int pendenciaId = 3;
                PendenciaController pendenciaController = new PendenciaController(context);
                Pendencia deletedPendencia = pendenciaController.DeletePendencia(pendenciaId).Result.Value;
                Assert.Null(deletedPendencia);
            }
        }

    }
}
