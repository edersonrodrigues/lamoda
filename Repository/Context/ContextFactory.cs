using Rgm.Repository.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Rgm.Repository.Context
{
    //ContextFactory para acessar o oracle
    public class ContextFactory : IDesignTimeDbContextFactory<DataContext>
    {
        public DataContext CreateDbContext(string[] args)
        {
            //Usado para Criar as Migrações
            //Oracle
            //var connectionString = "User Id=system;Password=sql2008;Data Source=(DESCRIPTION =(ADDRESS_LIST =(ADDRESS = (PROTOCOL = TCP)(HOST = NOTE_EDERSON)(PORT = 1521)))(CONNECT_DATA =(SERVICE_NAME = XE)))";
            //SqlServer
            var connectionString = "Data Source=note_ederson\\sql2008;Initial Catalog=Volks;User ID=sa;Password=sql2008";
            var optionsBuilder = new DbContextOptionsBuilder<DataContext>();
            optionsBuilder.UseOracle(connectionString);
            return new DataContext(optionsBuilder.Options);
        }
    }
}
