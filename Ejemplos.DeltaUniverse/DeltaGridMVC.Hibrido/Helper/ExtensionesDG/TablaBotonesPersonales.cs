using DeltaWebControlMVC.Control;
using DeltaWebControlMVC.Render;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace DeltaGridMVC.Hibrido.Helper.ExtensionesDG
{
    public class TablaBotonesPersonales : TablaBootstrap
    {
        public TablaBotonesPersonales()
        {

        
        }

        //Si se quiere personalizar por completo la barra de botones, se reemplaza el siguiente método
        //La configuracion en extenderBarraBotones no tendrá efecto
        public override void PintarBarraBotones(Panel panel)
        {
            var btnNuevoPersonalizado = new HtmlGenericControl("button") { InnerText = "Agregar X" };
            btnNuevoPersonalizado.Attributes.Add("ng-click", $"{this.id}.agregarRegistro();");
            panel.Controls.Add(btnNuevoPersonalizado);
        }
     

        //Si se quiere personaalizar por completo la celda de opciones, se debe reemplazar el siguiente metodo
        //La configuracion en extenderOpcionesFila no tendrá efecto
        public override void PintarColumnaOpciones(HtmlGenericControl filah, HtmlGenericControl filab)
        {
            var thopciones = new HtmlTableCellClonable("th") { InnerText = "Opciones" };            
            var tdopciones = new HtmlTableCell("td");
            thopciones.Attributes.Add("class", "thopciones");
            tdopciones.Attributes.Add("class", "tdopciones");

            tdopciones.InnerHtml = string.Format("<span ng-click='{0}.saludar(el_{0});' class='btn btn-default btn-sm'>Saludar</span>", this.id);

            //filah, representa la fila encabezado de la tabla
            filah.Controls.AddAt(0, thopciones);

            //filab, representa la fila cuerpo de la tabla
            filab.Controls.AddAt(0, tdopciones);
        }
     


    }
}