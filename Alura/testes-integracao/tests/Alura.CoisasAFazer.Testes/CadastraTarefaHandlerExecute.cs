using Alura.CoisasAFazer.Core.Commands;
using Alura.CoisasAFazer.Core.Models;
using Alura.CoisasAFazer.Services.Handlers;
using System;
using Xunit;
using System.Linq;
using Alura.CoisasAFazer.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Alura.CoisasAFazer.Testes
{
    public class CadastraTarefaHandlerExecute
    {
        [Fact]
        public void DadaTarefaComInfoValidasDeveIncluirNoBD()
        {
            //Arrange
            var comando = new CadastraTarefa("Estudar XUnit", new Categoria("Estudo"), new DateTime(2020, 12, 31));

            var options = new DbContextOptionsBuilder<DbTarefasContext>()
                .UseInMemoryDatabase("DbTarefasContext")
                .Options;
            var contexto = new DbTarefasContext(options);
            var repo = new RepositorioTarefa(contexto);

            var handler = new CadastraTarefaHandler(repo);
            
            //Act
            handler.Execute(comando); //SUT >> CadastraTarefaHandlerExecute

            //Assert
            var tarefa = repo.ObtemTarefas(t => t.Titulo == "Estudar XUnit").FirstOrDefault();
            Assert.NotNull(tarefa);
        }
    }
}
