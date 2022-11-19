using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapInterfaces.Entities
{
    class Vehicle
    {
        public string  Model { get; set; }
        public Vehicle(string model)        // Implementar o construtor para forçar a instanciação do jeito que vc precisar
        {
            Model = model;
        }
    }
}
