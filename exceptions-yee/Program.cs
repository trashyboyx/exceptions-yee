using exceptions_yee.Entities;
using exceptions_yee.Entities.Exceptions;
using System;

namespace exceptions_yee
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Room number: ");
                int numeroQuarto = int.Parse(Console.ReadLine());
                Console.Write("Check-in date (dd/MM/yyyy): ");
                DateTime checkin = DateTime.Parse(Console.ReadLine());
                Console.Write("Check-out date (dd/MM/yyyy): ");
                DateTime checkout = DateTime.Parse(Console.ReadLine());
                Reservation reservation = new Reservation(numeroQuarto, checkin, checkout);
                Console.WriteLine(reservation.ToString());
                Console.WriteLine();
                Console.WriteLine("Enter data to update the reservation: ");
                Console.Write("Check-in date (dd/MM/yyyy): ");
                checkin = DateTime.Parse(Console.ReadLine());
                Console.Write("Check-out date (dd/MM/yyyy): ");
                checkout = DateTime.Parse(Console.ReadLine());

                reservation.updateData(checkin, checkout);
                Console.WriteLine("Reservation: " + reservation);
            }
            catch (DomainException ex)
            {
                Console.WriteLine("Error in reservation: " + ex.Message);
            }
            catch(FormatException ex)
            {
                Console.WriteLine("Format error: " + ex.Message);
            }
            catch(Exception ex)
            {
                Console.WriteLine("Unexpected error: " + ex.Message);
            }
        }
    }
}
