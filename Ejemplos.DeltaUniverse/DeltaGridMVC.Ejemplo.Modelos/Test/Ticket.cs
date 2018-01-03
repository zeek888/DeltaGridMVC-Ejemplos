using Delta_util.Estaticos;
using DeltaUniverse.Modelos.Base;
using Delta_entidad.Atributos;
using Delta_entidad.Atributos.MVC;

namespace DeltaGridMVC.Ejemplo.Modelos.Test
{
    [AttModelo("Ticket", "TicketId", false, 100, true, null, Enumerados.TIPO_OPERACION_GRID.INSERTAR, Enumerados.TIPO_OPERACION_GRID.ACTUALIZAR, Enumerados.TIPO_OPERACION_GRID.ELIMINAR)]
    public class Ticket : TipoBase, ITipo
    {

        [AttrParametro(System.Data.SqlDbType.BigInt, 19, null, System.Data.ParameterDirection.Input, Enumerados.TIPO_QUERY.INSERTAR, Enumerados.TIPO_QUERY.OBTENER, Enumerados.TIPO_QUERY.ELIMINAR)]
        [AttProp(Titulo = "TicketId", Editable = false, TipoEditor = Enumerados.TIPO_EDITOR.TEXBOX, Orden = 0)]
        [AttColumna("A")]
        public virtual System.Int64 TicketId
        {
            get;
            set;
        }

        [AttrParametro(System.Data.SqlDbType.VarChar, 10, null, System.Data.ParameterDirection.Input, Enumerados.TIPO_QUERY.INSERTAR)]
        [AttProp(Titulo = "Clave", TipoEditor = Enumerados.TIPO_EDITOR.TEXBOX, Orden = 10)]
        [AttColumna("B")]
        public virtual System.String Clave
        {
            get;
            set;
        }

        [AttrParametro(System.Data.SqlDbType.VarChar, 100, null, System.Data.ParameterDirection.Input, Enumerados.TIPO_QUERY.INSERTAR)]
        [AttProp(Titulo = "Folio", TipoEditor = Enumerados.TIPO_EDITOR.TEXBOX, Orden = 20)]
        [AttColumna("C")]
        public virtual System.String Folio
        {
            get;
            set;
        }

        [AttProp(Titulo = "Fecha", TipoEditor = Enumerados.TIPO_EDITOR.TEXBOX, Orden = 30)]
        [AttColumna("D")]
        public virtual System.DateTime Fecha
        {
            get;
            set;
        }

        [AttrParametro(System.Data.SqlDbType.VarChar, 500, null, System.Data.ParameterDirection.Input, Enumerados.TIPO_QUERY.INSERTAR)]
        [AttProp(Titulo = "NombreCliente", TipoEditor = Enumerados.TIPO_EDITOR.TEXBOX, Orden = 40)]
        [AttColumna("E")]
        public virtual System.String NombreCliente
        {
            get;
            set;
        }

        [AttrParametro(System.Data.SqlDbType.VarChar, 500, null, System.Data.ParameterDirection.Input, Enumerados.TIPO_QUERY.INSERTAR)]
        [AttProp(Titulo = "ApellidosCliente", TipoEditor = Enumerados.TIPO_EDITOR.TEXBOX, Orden = 50)]
        [AttColumna("F")]
        public virtual System.String ApellidosCliente
        {
            get;
            set;
        }

        [AttrParametro(System.Data.SqlDbType.VarChar, 50, null, System.Data.ParameterDirection.Input, Enumerados.TIPO_QUERY.INSERTAR)]
        [AttProp(Titulo = "RFCEmisor", TipoEditor = Enumerados.TIPO_EDITOR.TEXBOX, Orden = 60)]
        [AttColumna("G")]
        public virtual System.String RFCEmisor
        {
            get;
            set;
        }

        [AttrParametro(System.Data.SqlDbType.VarChar, 50, null, System.Data.ParameterDirection.Input, Enumerados.TIPO_QUERY.INSERTAR)]
        [AttProp(Titulo = "RFCReceptor", TipoEditor = Enumerados.TIPO_EDITOR.TEXBOX, Orden = 70)]
        [AttColumna("H")]
        public virtual System.String RFCReceptor
        {
            get;
            set;
        }

        [AttrParametro(System.Data.SqlDbType.VarChar, 1000, null, System.Data.ParameterDirection.Input, Enumerados.TIPO_QUERY.INSERTAR)]
        [AttProp(Titulo = "Direccion", TipoEditor = Enumerados.TIPO_EDITOR.TEXBOX, Orden = 80)]
        [AttColumna("I")]
        public virtual System.String Direccion
        {
            get;
            set;
        }

        [AttrParametro(System.Data.SqlDbType.VarChar, 10, null, System.Data.ParameterDirection.Input, Enumerados.TIPO_QUERY.INSERTAR)]
        [AttProp(Titulo = "CP", TipoEditor = Enumerados.TIPO_EDITOR.TEXBOX, Orden = 100)]
        [AttColumna("K")]
        public virtual System.String CP
        {
            get;
            set;
        }


    }
}
