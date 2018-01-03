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
    public class TablaConBotones:TablaBootstrap
    {
        public TablaConBotones()
        {

            //Si se quiere agregar botones a la celda de opciones de cada fila, se usa esta función
            this.extenderOpcionesFila = BotonesExtrasFila;

            //Si se quiere agregar botones a la barra de herramientas, se usa este metodo
            this.extenderBarraBotones = AgregarBotonesBarra;
            
        }

        private string BotonesExtrasFila()
        {
            //En el texto, el {0} se reemplaza por el id de la instancia de la tabla
            //Es necesario indicarlo, ya que el scope, se aisla en un objeto con el nombre de la instancia
            return "<span ng-click='{0}.saludar(el_{0});' class='btn btn-default btn-sm'>Saludar</span>";
        }


        
        private void AgregarBotonesBarra(Panel panel)
        {
            var btnNuevoPersonalizado= new HtmlGenericControl("button") { InnerText = "Agregar X" };
            btnNuevoPersonalizado.Attributes.Add("ng-click", $"{this.id}.agregarRegistro();");
            panel.Controls.Add(btnNuevoPersonalizado);
    }


    }
}