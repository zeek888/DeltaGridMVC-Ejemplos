using Delta_entidad.Atributos.MVC;
using Delta_util.Estaticos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeltaGridMVC.Ejemplo.Modelos.Test
{
    [AttModelo("Ticket", "TicketId", false, 10, true, null, Enumerados.TIPO_OPERACION_GRID.INSERTAR, Enumerados.TIPO_OPERACION_GRID.ACTUALIZAR, Enumerados.TIPO_OPERACION_GRID.ELIMINAR)]
    public class TicketNumPaginas:Ticket
    {
    }
}
