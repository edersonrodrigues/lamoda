using Rgm.Domain.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rgm.BusinessEntities.Entities;

namespace Rgm.Repository.Map
{
    internal sealed class AlunoMap : IEntityTypeConfiguration<Aluno_Entity>
    {
        public void Configure(EntityTypeBuilder<Aluno_Entity> builder)
        {
            builder.ToTable("Aluno");
        }
    }
}