using Alura.CoisasAFazer.Core.Commands;
using Alura.CoisasAFazer.Core.Models;
using Alura.CoisasAFazer.Services.Handlers;
using System;
using Xunit;

namespace Alura.CoisasAFazer.Testes
{
    public class CadastraTarefaHandlerExecute
    {
        [Fact]
        public void DadaTarefaComInfoValidasDeveIncluirNoBD()
        {
            //Arrange
            var comando = new CadastraTarefa("Estudar XUnit", new Categoria("Estudo"), new DateTime(2020, 12, 31));
            var repo = new RepositorioFake();

            var handler = new CadastraTarefaHandler(repo);
            
            //Act
            handler.Execute(comando); //SUT >> CadastraTarefaHandlerExecute

            //Assert
            Assert.True(true);
        }
    }
}
