using SharedTrip.Models;
using SharedTrip.ViewModel.Trips;
using System;
using System.Collections.Generic;
using System.Text;

namespace SharedTrip.Services
{
    public interface ITripService
    {
        public IEnumerable<T> All<T>(Func<Trip, T> selectFunc);

        public void Add(TripsInfoModel infoViewModel);

        TripsInfoModel GetDetails(string id);
    }
}
