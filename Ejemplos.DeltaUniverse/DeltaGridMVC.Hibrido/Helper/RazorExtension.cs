using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Xml;

namespace DeltaGridMVC.Hibrido.Helper
{
    public class RazorExtension
    {
        public static XmlNode NodoActivo { get; set; }
        public static string ValorAtributo(XmlNode nodo, string atributo, string def = null)
        {
            return nodo?.Attributes[atributo]?.Value ?? def;
        }
        public static string Url(UrlHelper helper, string ruta)
        {
            return helper.Content(ruta);
        }

        public static XmlNodeList ObtenerBotones()
        {
            var ctrlXML = new Delta_util.Clases.ControlConfigXML("rutaConfigMenu");
            return ctrlXML.ObtenerNodoLista("/config/grupos/grupo");
        }

        public static List<XmlNode> ObtenerItems(string grupo)
        {
            var ctrlXML = new Delta_util.Clases.ControlConfigXML("rutaConfigMenu");
            return ctrlXML.ObtenerNodoLista("/config/dato[@Grupo='" + grupo + "']").Cast<XmlNode>().ToList();
        }

        public static bool RellenarEstatus(List<XmlNode> items, RequestContext req, UrlHelper hl)
        {
            var activo = false;
            foreach (XmlNode item in items)
            {

                var esUrl = ValorAtributo(item, "EsUrl", "false") == "true";
                var ac = esUrl ? hl.Content(ValorAtributo(item, "Tipo")) : hl.Action("Ver", "Vista", new { id = item.Attributes["Id"].Value });
                var itemActivo = ac == req.HttpContext.Request.Path;
                item.Attributes.Append(item.OwnerDocument.CreateAttribute("url"));
                item.Attributes.Append(item.OwnerDocument.CreateAttribute("activo"));
                item.Attributes["url"].Value = ac;
                item.Attributes["activo"].Value = itemActivo ? "active" : string.Empty;
                activo = activo || itemActivo;
                if (itemActivo)
                    NodoActivo = item;

            }


            return activo;
        }

        public static XmlNode ObtenerActivo(List<XmlNode> items)
        {
            return items.FirstOrDefault(o => o.Attributes["activo"].Value == "active");
        }
    }
}