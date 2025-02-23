using GraphQL.Types;
using GraphQLProject.Interfaces;
using GraphQLProject.Type;

namespace GraphQLProject.Query
{
	public class ReservationQuery : ObjectGraphType
	{
		public ReservationQuery(IReservationRepository reservation) 
		{
			Field<ListGraphType<ReservationType>>("Reservations").Resolve(context =>
				{
					return reservation.GetReservations();
				});
		}
	}
}
