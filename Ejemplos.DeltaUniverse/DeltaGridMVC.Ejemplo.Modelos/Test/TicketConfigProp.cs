using Delta_util.Estaticos;
using DeltaUniverse.Modelos.Base;
using Delta_entidad.Atributos;
using Delta_entidad.Atributos.MVC;
using System;

namespace DeltaGridMVC.Ejemplo.Modelos.Test
{
    [AttModelo("Ticket", "TicketId", false, 100, true, null, Enumerados.TIPO_OPERACION_GRID.INSERTAR, Enumerados.TIPO_OPERACION_GRID.ACTUALIZAR, Enumerados.TIPO_OPERACION_GRID.ELIMINAR)]
    public class TicketConfigProp : Ticket
    {
        [AttrParametro(System.Data.SqlDbType.DateTime, 0, null, System.Data.ParameterDirection.Input, Enumerados.TIPO_QUERY.INSERTAR)]
        //La propiead TipoEditor, indica el tipo de editor que se usará para dibujar la columna en la tabla y el editor en el popup de edición
        [AttProp(Titulo = "Fecha (DD/MM/YYYY)", TipoEditor = Enumerados.TIPO_EDITOR.FECHAMX, Orden = 30)]
        [AttColumna("D")]
        public override DateTime Fecha
        {
            get; set;
        }
    }
}
