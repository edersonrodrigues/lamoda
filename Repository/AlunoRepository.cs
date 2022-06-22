using Rgm.Domain.Entities.Entities;
using Rgm.Domain.Entities.Interfaces;
using Rgm.Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Rgm.BusinessEntities.Entities;

namespace Rgm.Repository
{
    public class AlunoRepository : IAluno
    {
        protected readonly DataContext _context;

        public AlunoRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Aluno_Entity>> GetAll()
        {
            try
            {
                return await _context.Set<Aluno_Entity>()
                .ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Aluno_Entity> GetById(int Id)
        {
            try
            {
                return await _context.Set<Aluno_Entity>()
                    .Where(x => x.Id == Id)
                    .SingleOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Aluno_Entity> Post(Aluno_Entity entity)
        {
            try
            {
                await _context.Set<Aluno_Entity>().AddAsync(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return entity;
        }

        public async Task<Aluno_Entity> Put(Aluno_Entity entity)
        {
            Aluno_Entity obj = await GetById(entity.Id);

            try
            {
                if (obj == null)
                {
                    return null;
                }

                obj.Nome = !String.IsNullOrWhiteSpace(entity.Nome) ? entity.Nome : obj.Nome;
                obj.Email = !String.IsNullOrWhiteSpace(entity.Email) ? entity.Email : obj.Email;
                obj.Rg = !String.IsNullOrWhiteSpace(entity.Rg) ? entity.Rg : obj.Rg;

                _context.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return obj;
        }

        public async Task<bool> Delete(int id)
        {
            Aluno_Entity obj = await GetById(id);

            if (obj == null)
            {
                return false;
            }

            try
            {
                _context.Set<Aluno_Entity>().Remove(obj);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return false;
        }



    }
}
