using letscode_trabalho_ferroviaria.domain.Entities;
using letscode_trabalho_ferroviaria.infrastructure.Repositories;

namespace letscode_trabalho_ferroviaria.insfrastructure.Repositories
{
    public class FuncionarioRepository : RepositoryBase<FuncionarioEntity>
    {
        public FuncionarioRepository() : base("Funcionario")
        { }
    }
}
