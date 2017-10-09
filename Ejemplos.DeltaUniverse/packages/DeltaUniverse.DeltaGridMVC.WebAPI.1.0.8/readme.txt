Durante la instalación se configura la clase Global (Global.asax) para desactivar la seguridad en la Web API, el código que se agrega en el método Application_Start es:


            DeltaGridWebAPI.Servicios.DeltaGridAPIConfig.Configurar(o =>
            {
                o.SeguridadAPI = (contexto, tipoValidacion) => true;            
            });
            
            
Si la configuración no es agregada, entonces agregue el código anterior de forma manual.
