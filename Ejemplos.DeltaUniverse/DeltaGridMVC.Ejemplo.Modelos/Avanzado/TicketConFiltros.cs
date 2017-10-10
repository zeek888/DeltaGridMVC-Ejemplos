using Delta_entidad.Atributos;
using Delta_entidad.Atributos.MVC;
using Delta_util.Estaticos;
using DeltaGridMVC.Ejemplo.Modelos.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeltaGridMVC.Ejemplo.Modelos.Avanzado
{
    [AttModelo("Ticket", "TicketId", false, 100, true, null, Enumerados.TIPO_OPERACION_GRID.INSERTAR, Enumerados.TIPO_OPERACION_GRID.ACTUALIZAR, Enumerados.TIPO_OPERACION_GRID.ELIMINAR)]
    public class TicketConFiltros:Ticket
    {

        //Agregamos esta propiedad para usarla como parametro en el sp, para filtrar por rango de fecha
        [AttrParametro(System.Data.SqlDbType.Date, 4, null, System.Data.ParameterDirection.Input, Enumerados.TIPO_QUERY.OBTENER_TODOS)]
        public DateTime? FechaInicio
        {
            get;
            set;
        }

        //Agregamos esta propiedad para usarla como parametro en el sp, para filtrar por rango de fecha
        [AttrParametro(System.Data.SqlDbType.Date, 4, null, System.Data.ParameterDirection.Input, Enumerados.TIPO_QUERY.OBTENER_TODOS)]
        public DateTime? FechaFin
        {
            get;
            set;
        }
    }
}
