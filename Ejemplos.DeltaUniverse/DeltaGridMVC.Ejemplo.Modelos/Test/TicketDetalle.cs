using Delta_util.Estaticos;
using DeltaUniverse.Modelos.Base;
using Delta_entidad.Atributos;
using Delta_entidad.Atributos.MVC;

namespace DeltaGridMVC.Ejemplo.Modelos.Test
{
    [AttModelo("TicketDetalle", "DetalleId", false, 20, true, null, Enumerados.TIPO_OPERACION_GRID.INSERTAR, Enumerados.TIPO_OPERACION_GRID.ACTUALIZAR, Enumerados.TIPO_OPERACION_GRID.ELIMINAR)]
    public class TicketDetalle : TipoBase, ITipo
    {

        [AttrParametro(System.Data.SqlDbType.BigInt, 19, null, System.Data.ParameterDirection.Input, Enumerados.TIPO_QUERY.INSERTAR, Enumerados.TIPO_QUERY.OBTENER, Enumerados.TIPO_QUERY.ELIMINAR)]
        [AttProp(Titulo = "Clave", Editable = false, TipoEditor = Enumerados.TIPO_EDITOR.TEXBOX, Orden = 0)]
        [AttColumna("A")]
        public System.Int64 DetalleId
        {
            get;
            set;
        }

        //Se tiene que agregar la operacion Enumerados.TIPO_QUERY.OBTENER_TODOS, para que se pueda filtrar el detalle por ticketId
        [AttrParametro(System.Data.SqlDbType.BigInt, 19, null, System.Data.ParameterDirection.Input, Enumerados.TIPO_QUERY.INSERTAR, Enumerados.TIPO_QUERY.OBTENER_TODOS)]
        [AttProp(Titulo = "Ticket", TipoEditor = Enumerados.TIPO_EDITOR.TEXBOX, Orden = 10)]
        [AttColumna("B")]
        public System.Int64 TicketId
        {
            get;
            set;
        }

        [AttProp(Titulo = "Ticket", Editable = false, TipoEditor = Enumerados.TIPO_EDITOR.TEXBOX, Orden = 10)]
        [AttColumna("B")]
        public string Ticket { get; set; }

        [AttrParametro(System.Data.SqlDbType.VarChar, 100, null, System.Data.ParameterDirection.Input, Enumerados.TIPO_QUERY.INSERTAR)]
        [AttProp(Titulo = "Codigo", TipoEditor = Enumerados.TIPO_EDITOR.TEXBOX, Orden = 20)]
        [AttColumna("C")]
        public System.String Codigo
        {
            get;
            set;
        }

        [AttrParametro(System.Data.SqlDbType.VarChar, 500, null, System.Data.ParameterDirection.Input, Enumerados.TIPO_QUERY.INSERTAR)]
        [AttProp(Titulo = "Descripcion", TipoEditor = Enumerados.TIPO_EDITOR.TEXBOX, Orden = 30)]
        [AttColumna("D")]
        public System.String Descripcion
        {
            get;
            set;
        }

        [AttrParametro(System.Data.SqlDbType.Decimal, 18, null, System.Data.ParameterDirection.Input, Enumerados.TIPO_QUERY.INSERTAR)]
        [AttProp(Titulo = "Cantidad", TipoEditor = Enumerados.TIPO_EDITOR.TEXBOX, Orden = 40)]
        [AttColumna("E")]
        public System.Decimal Cantidad
        {
            get;
            set;
        }

        [AttrParametro(System.Data.SqlDbType.Decimal, 18, null, System.Data.ParameterDirection.Input, Enumerados.TIPO_QUERY.INSERTAR)]
        [AttProp(Titulo = "Iva", TipoEditor = Enumerados.TIPO_EDITOR.TEXBOX, Orden = 50)]
        [AttColumna("F")]
        public System.Decimal Iva
        {
            get;
            set;
        }

        [AttrParametro(System.Data.SqlDbType.Decimal, 18, null, System.Data.ParameterDirection.Input, Enumerados.TIPO_QUERY.INSERTAR)]
        [AttProp(Titulo = "Precio", TipoEditor = Enumerados.TIPO_EDITOR.TEXBOX, Orden = 70)]
        [AttColumna("H")]
        public System.Decimal Precio
        {
            get;
            set;
        }

        [AttrParametro(System.Data.SqlDbType.VarChar, 1000, null, System.Data.ParameterDirection.Input, Enumerados.TIPO_QUERY.INSERTAR)]
        [AttProp(Titulo = "Comentarios", TipoEditor = Enumerados.TIPO_EDITOR.TEXBOX, Orden = 80)]
        [AttColumna("I")]
        public System.String Comentarios
        {
            get;
            set;
        }


    }
}
