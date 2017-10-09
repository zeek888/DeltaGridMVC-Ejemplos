using Delta_util.Estaticos;
using DeltaUniverse.Modelos.Base;
using Delta_entidad.Atributos;
using Delta_entidad.Atributos.MVC;

namespace DeltaGridMVC.Ejemplo.Modelos.Test
{
    [AttModelo("Ticket", "TicketId", false, 100, true, null, Enumerados.TIPO_OPERACION_GRID.INSERTAR, Enumerados.TIPO_OPERACION_GRID.ACTUALIZAR, Enumerados.TIPO_OPERACION_GRID.ELIMINAR)]
    public class TicketOcultandoColumnas:Ticket
    {
        [AttrParametro(System.Data.SqlDbType.BigInt, 19, null, System.Data.ParameterDirection.Input, Enumerados.TIPO_QUERY.INSERTAR, Enumerados.TIPO_QUERY.OBTENER, Enumerados.TIPO_QUERY.ELIMINAR)]
        //El atributo IncluirGrid indica si se debe o no mostrar la columna en la tabla
        [AttProp(Titulo = "TicketId", Editable = false,IncluirGrid =false, TipoEditor = Enumerados.TIPO_EDITOR.TEXBOX, Orden = 0)]
        [AttColumna("A")]
        public override System.Int64 TicketId
        {
            get;
            set;
        }


        [AttrParametro(System.Data.SqlDbType.VarChar, 10, null, System.Data.ParameterDirection.Input, Enumerados.TIPO_QUERY.INSERTAR)]
        //La propiedad Editable, indica si se debe o no editar esta propiedad en el popup de edición
        [AttProp(Titulo = "Clave",Editable =false,IncluirGrid =false, TipoEditor = Enumerados.TIPO_EDITOR.TEXBOX, Orden = 10)]
        [AttColumna("B")]
        public override System.String Clave
        {
            get;
            set;
        }
    }
}
