using Delta_util.Estaticos;
using DeltaUniverse.Modelos.Base;
using Delta_entidad.Atributos;
using Delta_entidad.Atributos.MVC;
using DeltaGridMVC.Ejemplo.Modelos.Test;

namespace DeltaGridMVC.Ejemplo.Modelos.Intermedio
{
    [AttModelo("Ticket", "TicketId", false, 100, true, null, Enumerados.TIPO_OPERACION_GRID.INSERTAR, Enumerados.TIPO_OPERACION_GRID.ACTUALIZAR, Enumerados.TIPO_OPERACION_GRID.ELIMINAR)]
    public class TicketConValidacion : Ticket
    {

        [AttrParametro(System.Data.SqlDbType.VarChar, 100, null, System.Data.ParameterDirection.Input, Enumerados.TIPO_QUERY.INSERTAR)]
        [AttProp(Titulo = "Folio", Requerido = true, TipoEditor = Enumerados.TIPO_EDITOR.TEXBOX, Orden = 20)]
        //Aqui se configuran las validaciones para esta propiedad en el formulario de edición
        //Para saber los tipos de validadores que soporta parsleyjs, consulte la página http://parsleyjs.org/doc/index.html#validators
        //Parametros:
        //tipo=Indica el nombre de la validación de parsley
        //nombre=Identificador para la validación
        //valor=Parametro que recibe la validación, en este caso, indica el número(2) de caracteres minimo para que cumpla la validación
        //mensaje=Es el mensaje que se mostrará cuando el valor no cumpla con la validación
        [AttValidacion("minlength", "TamanioMinimo2", "2", "Debe escribir al menos 2 caracteres")]
        [AttColumna("C")]
        public override System.String Folio
        {
            get;
            set;
        }

        [AttrParametro(System.Data.SqlDbType.VarChar, 10, null, System.Data.ParameterDirection.Input, Enumerados.TIPO_QUERY.INSERTAR)]
        //Al asignar true a la propiedad Requerido, se configura automáticamente la validación parsley Required
        [AttProp(Titulo = "CP",Requerido =true, TipoEditor = Enumerados.TIPO_EDITOR.TEXBOX, Orden = 100)]
        //Se puede usar una o mas validaciones
        [AttValidacion("length", "Tamanio5", "[5,5]", "El CP debe ser de 5 digitos")]
        [AttValidacion("type", "TipoEntero", "integer", "El CP debe ser un digito")]
        [AttColumna("K")]
        public override System.String CP
        {
            get;
            set;
        }
    }
}
