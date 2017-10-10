using Delta_util.Estaticos;
using DeltaUniverse.Modelos.Base;
using Delta_entidad.Atributos;
using Delta_entidad.Atributos.MVC;
using DeltaGridMVC.Ejemplo.Modelos.Test;

namespace DeltaGridMVC.Ejemplo.Modelos.Intermedio
{
    [AttModelo("Ticket", "TicketId", false, 100, true, null, Enumerados.TIPO_OPERACION_GRID.INSERTAR, Enumerados.TIPO_OPERACION_GRID.ACTUALIZAR, Enumerados.TIPO_OPERACION_GRID.ELIMINAR)]
    public class TicketConValidacionPersonal : Ticket
    {

        [AttrParametro(System.Data.SqlDbType.VarChar, 100, null, System.Data.ParameterDirection.Input, Enumerados.TIPO_QUERY.INSERTAR)]
        [AttProp(Titulo = "Folio", Requerido = true, TipoEditor = Enumerados.TIPO_EDITOR.TEXBOX, Orden = 20)]
        [AttColumna("C")]
        //Aqui se agrega una validación personalizada
        [AttValidacion("folioticket","FolioTicket","SUC-","El folio debe iniciar con SUC-")]
        public override System.String Folio
        {
            get;
            set;
        }

        [AttrParametro(System.Data.SqlDbType.VarChar, 10, null, System.Data.ParameterDirection.Input, Enumerados.TIPO_QUERY.INSERTAR)]
        [AttProp(Titulo = "CP",Requerido =true, TipoEditor = Enumerados.TIPO_EDITOR.TEXBOX, Orden = 100)]
        [AttColumna("K")]
        public override System.String CP
        {
            get;
            set;
        }
    }
}
