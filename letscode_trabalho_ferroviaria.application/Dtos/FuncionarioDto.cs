using letscode_trabalho_ferroviaria.domain.Entities;

namespace letscode_trabalho_ferroviaria.application.Dtos
{
    public class FuncionarioDto
    {
        public string Name { get; set; }

        public FuncionarioDto(string name)
        {
            Name = name;
        }

        public FuncionarioEntity FromDtoToEntity(FuncionarioDto dto) => new FuncionarioEntity(dto.Name);
    }
}
