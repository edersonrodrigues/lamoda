using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Rgm.Domain.Entities.Entities;

namespace Rgm.Domain.Entities.Entities
{
    public class Aluno_Entity
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Rg { get; set; }
    }
}
