using System;
using CapInterfaces.Entities;

namespace CapInterfaces.Services
{
    class RentalService     // Serviço de aluguel que tem uma dependência de outra classe serviço BrazilTaxService 
    {
        public double PricePerHour { get; private set; }    // Não pode modificá-los de outra classe
        public double PricePerDay { get; private set; }

        // Alterar a dependencia por meio da interface
        private ITaxService _taxService;

        public RentalService(double pricePerHour, double pricePerDay, ITaxService taxService)
        {
            PricePerHour = pricePerHour;
            PricePerDay = pricePerDay;
            _taxService = taxService;  // inversão de controle por meio de injeção de dependência
        }

        public void ProcessInvoice(CarRental carRental)         // Essa operação vai gerar o Invoice
        {
            TimeSpan duration = carRental.Finish.Subtract(carRental.Start);
            double basicPayment = 0.0;
            if (duration.TotalHours <= 12.0)
            {
                basicPayment = PricePerHour * Math.Ceiling(duration.TotalHours);
            }
            else
            {
                basicPayment = PricePerDay * Math.Ceiling(duration.TotalDays);
            }

            double tax = _taxService.Tax(basicPayment);

            // Instanciarr o Invoice e associar com o carRental
            carRental.Invoice = new Invoice(basicPayment, tax);
        }
    }
}
