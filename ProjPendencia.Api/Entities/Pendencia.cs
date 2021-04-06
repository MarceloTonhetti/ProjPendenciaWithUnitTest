using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjPendencia.Api.Entities
{
    public class Pendencia
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime Data { get; set; }
    }
}