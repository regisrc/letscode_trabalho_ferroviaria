using letscode_trabalho_ferroviaria.domain.Entities;
using letscode_trabalho_ferroviaria.infrastructure.Repositories;

namespace letscode_trabalho_ferroviaria.insfrastructure.Repositories
{
    public class TremRepository : RepositoryBase<TremEntity>
    {
        public TremRepository() : base("Trem")
        { }
    }
}
