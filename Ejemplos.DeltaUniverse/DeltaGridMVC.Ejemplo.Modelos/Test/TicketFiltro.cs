using Delta_util.Estaticos;
using DeltaUniverse.Modelos.Base;
using Delta_entidad.Atributos;
using Delta_entidad.Atributos.MVC;
using System;

namespace DeltaGridMVC.Ejemplo.Modelos.Test
{
    [AttModelo("Ticket", "TicketId", false, 100, true, null, Enumerados.TIPO_OPERACION_GRID.INSERTAR, Enumerados.TIPO_OPERACION_GRID.ACTUALIZAR, Enumerados.TIPO_OPERACION_GRID.ELIMINAR)]
    public class TicketFiltro:Ticket
    {

        [AttrParametro(System.Data.SqlDbType.VarChar, 100, null, System.Data.ParameterDirection.Input, Enumerados.TIPO_QUERY.INSERTAR)]
        [AttProp(Titulo = "Folio", TipoEditor = Enumerados.TIPO_EDITOR.TEXBOX, Orden = 20)]
        [AttColumna("C")]
        //Este atributo indica que se debe mostrar el filtro para esta propiedad
        [AttFiltro(Nombre ="FiltroTexto")]
        public override string Folio
        {
            get;set;
        }


        [AttrParametro(System.Data.SqlDbType.VarChar, 500, null, System.Data.ParameterDirection.Input, Enumerados.TIPO_QUERY.INSERTAR)]
        [AttProp(Titulo = "NombreCliente", TipoEditor = Enumerados.TIPO_EDITOR.TEXBOX, Orden = 40)]
        [AttColumna("E")]
        //Este atributo contiene la propiedad TomarValoresGrid, que indica que se debe crear una lista con los valores únicos de esta propiedad en toda la tabla
        [AttFiltro(Nombre = "FiltroLista",TomarValoresGrid =true)]
        public override string NombreCliente
        {
            get;set;
        }

        [AttrParametro(System.Data.SqlDbType.VarChar, 500, null, System.Data.ParameterDirection.Input, Enumerados.TIPO_QUERY.INSERTAR)]
        [AttProp(Titulo = "ApellidosCliente", TipoEditor = Enumerados.TIPO_EDITOR.TEXBOX, Orden = 50)]
        [AttColumna("F")]
        [AttFiltro(Nombre = "FiltroTexto")]
        public override string ApellidosCliente
        {
            get;set;
        }
    }
}
