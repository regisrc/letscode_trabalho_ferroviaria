namespace letscode_trabalho_ferroviaria.domain.Entities
{
    public class FuncionarioEntity : EntityBase
    {
        public string Name { get; set; }

        public FuncionarioEntity(string name)
        {
            Name = name;
        }
    }
}
