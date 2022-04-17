using letscode_trabalho_ferroviaria.application.Services;
using letscode_trabalho_ferroviaria.domain.Entities;
using letscode_trabalho_ferroviaria.insfrastructure.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xunit;

namespace letscode_trabalho_ferroviaria.tests.Application
{
    public class FuncionarioServiceTest
    {
        private readonly Mock<FuncionarioRepository> _funcionarioRepository;
        private readonly FuncionarioService _funcionarioService;

        public FuncionarioServiceTest()
        {
            _funcionarioRepository = new Mock<FuncionarioRepository>();
            _funcionarioService = new FuncionarioService(_funcionarioRepository.Object);
        }

        [Fact]
        public void GetByName_should_get_data()
        {
            var data = new List<FuncionarioEntity>
            {
                new FuncionarioEntity("Funcionario1"),
                new FuncionarioEntity("Funcionario2"),
                new FuncionarioEntity("Funcionario3")
            };

            var first = data.First();

            _funcionarioRepository.Setup(x => x.GetAll()).Returns(data);

            var result = _funcionarioService.GetByName(first.Name);

            Assert.Equal(first.Id, result.Id);
            Assert.Equal(first.Name, result.Name);

            _funcionarioRepository.Verify(x => x.GetAll(), Times.Once);
        }

        [Fact]
        public void GetAll_should_get_data()
        {
            var data = new List<FuncionarioEntity>
            {
                new FuncionarioEntity("Funcionario1"),
                new FuncionarioEntity("Funcionario2"),
                new FuncionarioEntity("Funcionario3")
            };

            _funcionarioRepository.Setup(x => x.GetAll()).Returns(data);

            var result = _funcionarioService.GetAll();

            Assert.NotEmpty(result);
            Assert.Equal(data.Count, result.Count);

            foreach (var item in result)
            {
                var value = data.Find(x => x.Id == item.Id);

                Assert.Equal(value.Id, item.Id);
                Assert.Equal(value.Name, item.Name);
            }

            _funcionarioRepository.Verify(x => x.GetAll(), Times.Once);
        }

        [Fact]
        public void Add_should_has_a_non_valid_name()
        {
            var data = new List<FuncionarioEntity>
            {
                new FuncionarioEntity("Funcionario1"),
                new FuncionarioEntity("Funcionario2"),
                new FuncionarioEntity("Funcionario3")
            };

            var input = new StringReader("");
            Console.SetIn(input);

            _funcionarioRepository.Setup(x => x.GetAll()).Returns(data);

            _funcionarioService.Add();

            _funcionarioRepository.Verify(x => x.GetAll(), Times.Once);

            _funcionarioRepository.Verify(x => x.Add(It.IsAny<List<FuncionarioEntity>>()), Times.Never);
        }

        [Fact]
        public void Add_should_already_has_a_data_inserted()
        {
            var data = new List<FuncionarioEntity>
            {
                new FuncionarioEntity("Funcionario1"),
                new FuncionarioEntity("Funcionario2"),
                new FuncionarioEntity("Funcionario3")
            };

            var input = new StringReader("Funcionario1");
            Console.SetIn(input);

            _funcionarioRepository.Setup(x => x.GetAll()).Returns(data);

            _funcionarioService.Add();

            _funcionarioRepository.Verify(x => x.GetAll(), Times.Once);

            _funcionarioRepository.Verify(x => x.Add(It.IsAny<List<FuncionarioEntity>>()), Times.Never);
        }

        [Fact]
        public void Add_should_insert_data()
        {
            var name = "Funcionario4";

            var data = new List<FuncionarioEntity>
            {
                new FuncionarioEntity("Funcionario1"),
                new FuncionarioEntity("Funcionario2"),
                new FuncionarioEntity("Funcionario3")
            };

            var input = new StringReader(name);
            Console.SetIn(input);

            _funcionarioRepository.Setup(x => x.GetAll()).Returns(data);

            _funcionarioService.Add();

            _funcionarioRepository.Verify(x => x.GetAll(), Times.Once);

            _funcionarioRepository.Verify(x => x.Add(It.IsAny<List<FuncionarioEntity>>()), Times.Once);

            _funcionarioRepository.Verify(x => x.Add(It.Is<List<FuncionarioEntity>>(x => x.Any(x => x.Name == name) && x.Count == 4)), Times.Once);
        }

        [Fact]
        public void Update_should_not_find()
        {
            var name = "Funcionario4";

            var data = new List<FuncionarioEntity>
            {
                new FuncionarioEntity("Funcionario1"),
                new FuncionarioEntity("Funcionario2"),
                new FuncionarioEntity("Funcionario3")
            };

            var input = new StringReader(name);
            Console.SetIn(input);

            _funcionarioRepository.Setup(x => x.GetAll()).Returns(data);

            _funcionarioService.Update();

            _funcionarioRepository.Verify(x => x.GetAll(), Times.Once);

            _funcionarioRepository.Verify(x => x.Add(It.IsAny<List<FuncionarioEntity>>()), Times.Never);
        }

        [Fact]
        public void Update_should_has_a_non_valid_name()
        {
            var name = "";

            var data = new List<FuncionarioEntity>
            {
                new FuncionarioEntity("Funcionario1"),
                new FuncionarioEntity("Funcionario2"),
                new FuncionarioEntity("Funcionario3")
            };

            var input = new StringReader(name);
            Console.SetIn(input);

            _funcionarioRepository.Setup(x => x.GetAll()).Returns(data);

            _funcionarioService.Update();

            _funcionarioRepository.Verify(x => x.GetAll(), Times.Once);

            _funcionarioRepository.Verify(x => x.Add(It.IsAny<List<FuncionarioEntity>>()), Times.Never);
        }

        [Fact]
        public void Update_should_has_duplicated_value()
        {
            var name = @"Funcionario1
Funcionario1";

            var data = new List<FuncionarioEntity>
            {
                new FuncionarioEntity("Funcionario1"),
                new FuncionarioEntity("Funcionario2"),
                new FuncionarioEntity("Funcionario3")
            };

            var input = new StringReader(name);
            Console.SetIn(input);

            _funcionarioRepository.Setup(x => x.GetAll()).Returns(data);

            _funcionarioService.Update();

            _funcionarioRepository.Verify(x => x.GetAll(), Times.Once);

            _funcionarioRepository.Verify(x => x.Add(It.IsAny<List<FuncionarioEntity>>()), Times.Never);
        }

        [Fact]
        public void Update_should_updated()
        {
            var name = "Funcionario4";

            var stringReader = $@"Funcionario1
{name}";

            var data = new List<FuncionarioEntity>
            {
                new FuncionarioEntity("Funcionario1"),
                new FuncionarioEntity("Funcionario2"),
                new FuncionarioEntity("Funcionario3")
            };

            var input = new StringReader(stringReader);
            Console.SetIn(input);

            _funcionarioRepository.Setup(x => x.GetAll()).Returns(data);

            _funcionarioService.Update();

            _funcionarioRepository.Verify(x => x.GetAll(), Times.Once);

            _funcionarioRepository.Verify(x => x.Add(It.IsAny<List<FuncionarioEntity>>()), Times.Once);

            _funcionarioRepository.Verify(x => x.Add(It.Is<List<FuncionarioEntity>>(x => x.Any(x => x.Name == name) && x.Count == 3)), Times.Once);
        }
    }
}
