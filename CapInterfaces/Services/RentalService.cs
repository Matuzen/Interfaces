using System;
using CapInterfaces.Entities;

namespace CapInterfaces.Services
{
    class RentalService     // Serviço de aluguel que tem uma dependência de outra classe serviço BrazilTaxService 
    {
        public double PricePerHour { get; private set; }    // Não pode modificá-los de outra classe
        public double PricePerDay { get; private set; }

        // Dependência inapropriada 
        private BrazilTaxService _brazilTaxService = new BrazilTaxService();

        public RentalService(double pricePerHour, double pricePerDay)
        {
            PricePerHour = pricePerHour;
            PricePerDay = pricePerDay;
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

            double tax = _brazilTaxService.Tax(basicPayment);

            // Instanciarr o Invoice e associar com o carRental
            carRental.Invoice = new Invoice(basicPayment, tax);
        }
    }
}
