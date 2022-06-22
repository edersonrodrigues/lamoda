using Rgm.Domain.Entities.Entities;
using Rgm.Domain.Entities.Interfaces;
using Rgm.Repository.Context;
using Rgm.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Rgm.BusinessEntities.Entities;
using Rgm.Domain.Service.Security;
using Microsoft.Extensions.Configuration;

namespace Rgm.Domain.Service
{
    public class AlunoService : IAluno
    {
        private AlunoRepository _repositorySystem;
        private SigningConfigurations _signingConfigurations;
        private TokenConfigurations _tokenConfigurations;
        public IConfiguration _configuration;

        public AlunoService(DataContext context, SigningConfigurations signingConfigurations, TokenConfigurations tokenConfigurations, IConfiguration configuration)
        {
            _repositorySystem = new AlunoRepository(context);
            _signingConfigurations = signingConfigurations;
            _tokenConfigurations = tokenConfigurations;
            _configuration = configuration;
        }

        public async Task<IEnumerable<Aluno_Entity>> GetAll()
        {
            return await _repositorySystem.GetAll();
        }

        public async Task<Aluno_Entity> GetById(int Id)
        {
            return await _repositorySystem.GetById(Id);
        }

        public async Task<Aluno_Entity> Post(Aluno_Entity entity)
        {
            return await _repositorySystem.Post(entity);
        }

        public async Task<Aluno_Entity> Put(Aluno_Entity entity)
        {
            return await _repositorySystem.Put(entity);
        }

        public async Task<bool> Delete(int id)
        {
            return await _repositorySystem.Delete(id);
        }


    }
}

