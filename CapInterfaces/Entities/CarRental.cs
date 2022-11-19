using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapInterfaces.Entities
{
    class CarRental     // Aluguel de carro que está associado ao Vehicle (veículo) e ao Invoice (nota de pagamento)
    {
        public DateTime Start { get; set; }
        public DateTime Finish { get; set; }
        public Vehicle Vehicle { get; set; }    // Associação
        public Invoice Invoice { get; set; }    // Associação

        public CarRental(DateTime start, DateTime finish, Vehicle vehicle)
        {
            Start = start;
            Finish = finish;
            Vehicle = vehicle;
            Invoice = null;     // Nota de pagamento vai ser iniciada como nulo, pois só será gerada quando for processado o alugel do carro
        }
    }
}
