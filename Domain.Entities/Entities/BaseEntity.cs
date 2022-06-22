using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rgm.Domain.Entities.Entities
{
    public abstract class BaseEntity
    {
        [Key]
        public abstract int Id { get; set; }
    }
}
