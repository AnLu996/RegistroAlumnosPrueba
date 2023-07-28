using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Web.Services;

namespace ProyectServices
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        IList<String> getCiudades();

        [OperationContract]
        void Information(string nombre, string apellido, string sexo, string email, string direccion, int ciudad, string requerimiento);

        [OperationContract]
        bool Verificar(string nombre, string apellido);
    }
}
