namespace letscode_trabalho_ferroviaria.domain.Entities
{
    public class GerenciamentoTremEntity : EntityBase
    {
        public DateTime Chegada { get; set; }

        public DateTime Saida { get; set; }

        public TremEntity Trem { get; set; }

        public FuncionarioEntity FuncionarioAtendimento { get; set; }

        public GerenciamentoTremEntity(DateTime chegada, DateTime saida, TremEntity trem, FuncionarioEntity funcionarioAtendimento)
        {
            Chegada = chegada;
            Saida = saida;
            Trem = trem;
            FuncionarioAtendimento = funcionarioAtendimento;
        }
    }
}
