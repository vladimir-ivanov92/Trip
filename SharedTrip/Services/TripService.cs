using SharedTrip.Models;
using SharedTrip.ViewModel.Trips;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharedTrip.Services
{
    public class TripService : ITripService
    {
        private readonly ApplicationDbContext db;

        public TripService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<T> All<T>(Func<Trip, T> selectFunc)
        {
            var allTrips = this.db.Trips.Select(selectFunc).ToList();
            return allTrips;
        }
        public void Add(TripsInfoModel tripInfoViewModel)
        {
            var trip = new Trip
            {
                StartPoint = tripInfoViewModel.StartPoint,
                EndPoint = tripInfoViewModel.EndPoint,
                DepartureTime = tripInfoViewModel.DepartureTime,
                Seats = tripInfoViewModel.Seats,
                Description = tripInfoViewModel.Description,
            };
            this.db.Trips.Add(trip);
            this.db.SaveChanges();
        }


        public TripsInfoModel GetDetails(string tripId)
        {
            var trip = this.db.Trips.Where(x => x.Id == tripId)
                .Select(x => new TripsInfoModel
                {
                    Id = x.Id,
                    StartPoint = x.StartPoint,
                    EndPoint = x.EndPoint,
                    DepartureTime = x.DepartureTime,
                    Seats = x.Seats,
                    Description = x.Description,
                }).FirstOrDefault();
            return trip;
        }
    }
}
