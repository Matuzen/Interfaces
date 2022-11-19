using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapInterfaces.Services
{
    // Aqui temos uma composição de serviços onde um depende do outro (RentalService - BrazilTaxService)
    class BrazilTaxService      // Imposto
    {
        public double Tax(double amount)    // operação
        {
            if (amount <= 100)
            {
                return amount * 0.2;
            }

            else
            {
                return amount * 0.15;
            }
        }
    }
}
