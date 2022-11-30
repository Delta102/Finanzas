using Finanzas_APP.Controllers;
using Finanzas_APP.Data;
using Finanzas_APP.Models;
using Finanzas_APP.Repositorio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace FinanzasAPPTESTING
{
    public class CuentaTESTING
    {
        HomeController controller;
        CuentaRepositorio repositorio;

        IQueryable lista;

        [SetUp]
        public void Setup() {
            lista = new List<Cuenta>() {
                new Cuenta(){
                    IdCuenta = 1,
                    Nombre = "Test1",
                    SaldoInicial = 5000
                },

                new Cuenta(){
                    IdCuenta = 2,
                    Nombre = "Test2",
                    SaldoInicial = 1000
                },

                new Cuenta(){
                    IdCuenta = 3,
                    Nombre = "Test1",
                    SaldoInicial = 5000
                },

                new Cuenta(){
                    IdCuenta = 40,
                    Nombre = "Test2",
                    SaldoInicial = 1000
                },
            }.AsQueryable();

            var mockCuenta = new Mock<DbSet<Cuenta>>();
            mockCuenta.As<IQueryable<Cuenta>>().Setup(o => o.Provider).Returns(lista.Provider);

            mockCuenta.As<IQueryable<Cuenta>>().Setup(o => o.Expression).Returns(lista.Expression);

            mockCuenta.As<IQueryable<Cuenta>>().Setup(o => o.ElementType).Returns(lista.ElementType);

            mockCuenta.As<IQueryable<Cuenta>>().Setup(o => o.GetEnumerator()).Returns((IEnumerator<Cuenta>)lista.GetEnumerator());

            var mock = new Mock<ContextoDb>();
            mock.Setup(x => x.Cuenta).Returns(mockCuenta.Object);

            repositorio = new CuentaRepositorio(mock.Object);

            controller = new HomeController(repositorio);
        }

        [Test]
        public void IndexTest() {

            var controller = new HomeController(repositorio);

            Assert.IsNotNull(controller.Index());
        }

        [Test]
        public void CrearCuentaTest()
        {
            var cuenta = new Cuenta
            {
                IdCuenta = 1,
                Nombre = "TestNombreCuenta",
                SaldoInicial = 5000
            };

            var result = controller.CrearCuenta(cuenta);

            Assert.IsInstanceOf<RedirectToActionResult>(result);
        }

        [Test]
        public void ConteoTest() {

            int result = repositorio.CantidadCuenta();

            Assert.AreEqual(4, result);
        }
    }
}