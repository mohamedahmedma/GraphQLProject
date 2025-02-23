using GraphQLProject.Data;
using GraphQLProject.Interfaces;
using GraphQLProject.Models;

namespace GraphQLProject.Service
{
	public class ReservationRepository : IReservationRepository
	{
		private GraphQLDbContext _dbContext;
		public ReservationRepository(GraphQLDbContext dbContext)
		{
			_dbContext = dbContext;
		}
		public Reservation AddReservation(Reservation reservation)
		{
			_dbContext.Reservations.Add(reservation);
			_dbContext.SaveChanges();
			return reservation;
		}

		public List<Reservation> GetReservations()
		{
			return _dbContext.Reservations.ToList();
		}
	}
}
