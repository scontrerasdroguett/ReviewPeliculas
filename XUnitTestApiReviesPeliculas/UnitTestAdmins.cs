using ReviewPeliculas.Azure;
using ReviewPeliculas.Models;
using System;
using System.Linq;
using Xunit;

namespace XUnitTestApiReviesPeliculas
{ 
    public class UnitTestAdmins
    {
        [Fact]
        public void TestObtenerAdmin()
        {
            //Arrange
            bool vieneConDatos = false;

            //Act
            var resultado = AdministradorAzure.ObtenerAdmins();
            vieneConDatos = resultado.Any();

            //Assert 
            Assert.True(vieneConDatos);
        }

        [Fact]
        public void TestObtenerAdminPorId()
        {
            //Arrange
            int idProbar = 1;
            Administrador adminRetornado;

            //Act
            adminRetornado = AdministradorAzure.ObtenerAdministradorPorId(idProbar);

            //Assert 
            Assert.NotNull(adminRetornado);
        }

        [Fact]
        public void TestObtenerAdminPorNombres()
        {
            //Arrange
            string nombres = "Cesar Roberto";
            Administrador adminRetornado;

            //Act
            adminRetornado = AdministradorAzure.obtenerAdministradorPorNombres(nombres);

            //Assert 
            Assert.NotNull(adminRetornado);
        }

    }
}
