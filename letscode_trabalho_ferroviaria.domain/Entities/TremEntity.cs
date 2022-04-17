namespace letscode_trabalho_ferroviaria.domain.Entities
{
    public class TremEntity : EntityBase
    {
        public string Name { get; set; }

        public TremEntity Previous { get; set; }
    }
}
