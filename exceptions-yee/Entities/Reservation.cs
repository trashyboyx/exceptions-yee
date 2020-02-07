using System;
using exceptions_yee.Entities.Exceptions;

namespace exceptions_yee.Entities
{
    class Reservation
    {
        public int NumeroQuarto  { get; set; }
        public DateTime Checkin { get; set; }
        public DateTime Checkout { get; set; }

        public Reservation()
        {
        }

        public Reservation(int numeroQuarto, DateTime checkin, DateTime checkout)
        {
            DateTime now = DateTime.Now;
            if (checkin < now || checkout < now)
            {
                throw new DomainException("Reservation dates for update must be future dates");
            }
            if (checkout <= checkin)
            {
                throw new DomainException("Check-out date must be after check-in date");
            }

            NumeroQuarto = numeroQuarto;
            Checkin = checkin;
            Checkout = checkout;
        }

        public int Duracao()
        {
            TimeSpan duracao = Checkout.Subtract(Checkin);
            return (int)duracao.TotalDays;
        }
        public void updateData(DateTime checkin, DateTime checkout)
        {
            DateTime now = DateTime.Now;
            if (checkin < now || checkout < now)
            {
                throw new DomainException("Reservation dates for update must be future dates");
            }
            if (checkout <= checkin)
            {
                throw new DomainException("Check-out date must be after check-in date");
            }
            Checkin = checkin;
            Checkout = checkout;
        }

        public override string ToString()
        {
            return "Quarto " 
                + NumeroQuarto 
                + ", chek-in: " 
                + Checkin.ToString("dd/MM/yyyy") 
                + ", check-out: " 
                + Checkout.ToString("dd/MM/yyyy") 
                + ", " 
                + Duracao() 
                + " noites";
        }
    }
}
