using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Delta_control.Base;
using DeltaGridMVC.Ejemplo.Modelos.Test;
using Delta_util.Clases;

namespace PruebasDG
{
    [TestClass]
    public class DeltaControl
    {

        public DeltaControl()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion



        [TestMethod]
        public void ObtenerDatosTicketGral()
        {
            var ticketId = 13;

            //Existe un controlador generico que realiza las operaciones CRUD sin necesidad de generar transacción o compartir
            //conexion a la base de datos
            var datosTicket = ExecGral<Ticket>.GetDataGral(new Ticket() { TicketId = ticketId });
            var detalle = ExecGral<TicketDetalle>.GetListGral(new TicketDetalle() { TicketId = ticketId });

            Assert.IsNotNull(datosTicket, "Los datos del ticket no fueron encontrados");
            Assert.IsNotNull(detalle, "El detalle del ticket no fue encontrado");
        }


        [TestMethod]
        public void ObtenerDatosConControl()
        {
            var ticketId = 16065;

            using (var ctrl = new ControlBase<Ticket>())
            using (var conexion = ctrl.ObtenerConexion())
            using (var ctrlDetalle = ctrl.GenerarSubControl<TicketDetalle>())
            {
                ctrl.CrearConexion(conexion, null, true, true);

                //Al ejecutar el método de obtener, el resultado se guarda en la propiedad Dato
                ctrl.Obtener(new Ticket() { TicketId = ticketId });

                //Al ejecutar el método de obtener listado, el resultado se guarda en la propiedad Lista
                ctrlDetalle.ObtenerListado(new TicketDetalle() { TicketId = ticketId });

                Assert.IsNotNull(ctrl.Dato, "Los datos del ticket no fueron encontrados");
                Assert.IsTrue(ctrlDetalle.Lista.Count>0, "El detalle del ticket no fue encontrado");

            }
            
        }



        [TestMethod]
        public void InsertarTicket()
        {
            var datosTicket = new Ticket();
            datosTicket.Clave = Utilerias.ObtenerIdUnico(5);
            datosTicket.Folio = Utilerias.ObtenerIdUnico(5);
            datosTicket.Fecha = DateTime.Now;
            datosTicket.NombreCliente = "test";
            datosTicket.ApellidosCliente = "test";
            datosTicket.RFCEmisor = Utilerias.ObtenerIdUnico(8);
            datosTicket.RFCReceptor = Utilerias.ObtenerIdUnico(8);
            datosTicket.Direccion = "";

            //Cuando se requiere usar transacción se debe usar el controlador generico para cada entidad
            using (var ctrlTicket = new ControlBase<Ticket>())
            using (var tran = ctrlTicket.ObtenerConexion(true)) //Se obtiene una conexión unica para compartirla con los controladores,enviando true indicamos que vamos a usar transacción
            using (var ctrlDetalle = ctrlTicket.GenerarSubControl<TicketDetalle>(tran)) //Aqui se 
            {

                //Aqui indicamos que al insertar/actualizar un registro, se obtienen los datos de ese registro para 
                //actualizar la entidad que enviamos a guardar
                ctrlTicket.ActualizarDatosUpdateInsert = true;
                ctrlDetalle.ActualizarDatosUpdateInsert = true;


                //Esta linea es necesaria para cada controlador, aqui se crea la conexión, se recomienda realizar esto antes de
                //llamar cualquier otra operacion del controlador

                ctrlTicket.CrearConexion(null, tran, true, true);


                //Aqui se inserta los datos del ticket, se debe especificar el parametro finalizar=false, para poder
                //finalizar la transacción de forma manual, en caso contrario, se finaliza la transacción antes de insertar
                //el detalle
                ctrlTicket.Insertar(datosTicket, false);

                //ctrlDetalle.EjecutarComandoSqlClient("sp_name",parametros, false)


                var detalle = new TicketDetalle();

                detalle.TicketId = datosTicket.TicketId;
                detalle.Codigo = Utilerias.ObtenerIdUnico(8);
                detalle.Descripcion = Utilerias.ObtenerIdUnico(8);
                detalle.Comentarios = Utilerias.ObtenerIdUnico(8);
                detalle.Precio = 100;
                detalle.Cantidad = 1;
                detalle.Iva = 0;

                ctrlDetalle.Insertar(detalle, false);

                tran.Confirmar();



                Assert.IsTrue(datosTicket.TicketId > 0, "Los datos del ticket no fueron insertado");
                Assert.IsTrue(detalle.DetalleId > 0, "El detalle del ticket no fue insertado");



            }
        }




        [TestMethod]
        public void EliminarTicket()
        {
            var ticketId = 10;
            var ticketEliminado = false;
            var detalleEliminado = false;

            using (var ctrlTicket = new ControlBase<Ticket>())
            using (var tran = ctrlTicket.ObtenerConexion(true))
            using (var ctrlDetalle = ctrlTicket.GenerarSubControl<TicketDetalle>(tran))
            {
                //Generamos la conexion usando la transacción que anteriormente creamos
                ctrlTicket.CrearConexion(null, tran, true, true);

                //Como ticket tiene relacion con la tabla ticketDetalle, primero hay que eliminar el detalle
                //Para eso hay dos opciones:
                //1.- Eliminar el detalle en el SP de Ticket_Eliminar
                //2.-Obtener el detalle del tiket y eliminar uno por uno, es lo que vamos a hacer

                //Aqui se obtiene el listado del detalle del ticket, el resultado se guarda en la propiedad Lista del control
                ctrlDetalle.ObtenerListado(new TicketDetalle() { TicketId = ticketId });
                if (ctrlDetalle.Lista?.Count > 0)
                {
                    foreach (var detalle in ctrlDetalle.Lista)
                    {
                        detalleEliminado = ctrlDetalle.Eliminar(detalle, false);
                    }
                }


                //Enviamos a eliminar el ticket, notese que no es necesario obtener toda la entidad, solo enviar el valor de los
                //parametros de acuerdo a la operacion, en este caso, ELIMINAR
                ticketEliminado = ctrlTicket.Eliminar(new Ticket() { TicketId = ticketId }, false);

                tran.Confirmar();



                Assert.IsTrue(ticketEliminado, "Los datos del ticket no fueron eliminados");
                Assert.IsTrue(detalleEliminado, "El detalle del ticket no fue eliminado");



            }
        }
    }
}
