using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Rgm.Domain.Entities.Entities;

namespace Rgm.BusinessEntities.Entities
{
    public class TokenEntity : BaseEntity
    {
        [Key]
        public override int Id { get; set; }
        
        public string key { get; set; }
    }
}
