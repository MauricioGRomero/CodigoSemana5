using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosLayer
{
    // Clase que representa un cliente en el sistema.
    public class Customers
    {
        // Propiedad para el ID del cliente. Es el identificador único del cliente.
        public string CustomerID { get; set; }

        // Propiedad para el nombre de la empresa del cliente.
        public string CompanyName { get; set; }

        // Propiedad para el nombre del contacto principal del cliente.
        public string ContactName { get; set; }

        // Propiedad para el título del contacto principal del cliente.
        public string ContactTitle { get; set; }

        // Propiedad para la dirección del cliente.

        public string Address { get; set; }

        // Propiedad para la ciudad donde se encuentra el cliente.
        public string City { get; set; }

        // Propiedad opcional para la región del cliente. Puede ser nula o vacía.
        public string Region { get; set; }

        // Propiedad opcional para el código postal del cliente.
        public string PostalCode { get; set; }

        // Propiedad opcional para el país del cliente.
        public string Country { get; set; }

        // Propiedad opcional para el número de teléfono del cliente.
        public string Phone { get; set; }

        // Propiedad opcional para el número de fax del cliente.
        public string Fax { get; set; }
    }
}
