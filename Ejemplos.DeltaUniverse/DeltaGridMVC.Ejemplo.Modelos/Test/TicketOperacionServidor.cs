using Delta_util.Estaticos;
using DeltaUniverse.Modelos.Base;
using Delta_entidad.Atributos;
using Delta_entidad.Atributos.MVC;

namespace DeltaGridMVC.Ejemplo.Modelos.Test
{
    [AttModelo("Ticket", "TicketId", false, 10, true, null, Enumerados.TIPO_OPERACION_GRID.INSERTAR, Enumerados.TIPO_OPERACION_GRID.ACTUALIZAR, Enumerados.TIPO_OPERACION_GRID.ELIMINAR,PaginarServidor =true)]
    public class TicketOperacionServidor:Ticket
    {
        [AttrParametro(System.Data.SqlDbType.VarChar, 100, null, System.Data.ParameterDirection.Input, Enumerados.TIPO_QUERY.INSERTAR)]
        [AttProp(Titulo = "Folio", TipoEditor = Enumerados.TIPO_EDITOR.TEXBOX, Orden = 20)]
        [AttColumna("C")]
        [AttFiltro(Nombre = "FiltroTexto")]
        public override string Folio
        {
            get; set;
        }


        [AttrParametro(System.Data.SqlDbType.VarChar, 500, null, System.Data.ParameterDirection.Input, Enumerados.TIPO_QUERY.INSERTAR)]
        [AttProp(Titulo = "NombreCliente", TipoEditor = Enumerados.TIPO_EDITOR.TEXBOX, Orden = 40)]
        [AttColumna("E")]
        [AttFiltro(Nombre = "FiltroLista", TomarValoresGrid = true)]
        public override string NombreCliente
        {
            get; set;
        }
        
    }
}
