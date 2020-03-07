using SharedTrip.Services;
using SharedTrip.ViewModel.Trips;
using SIS.HTTP;
using SIS.MvcFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace SharedTrip.Controllers
{
    public class TripsController : Controller
    {
        private readonly ITripService itripService;

        public TripsController(ITripService itripService)
        {
            this.itripService = itripService;
        }

        public HttpResponse All()
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var viewModel = new AllTripsModel
            {
                Trips = this.itripService.All(x => new TripsInfoModel
                {
                    Id = x.Id,
                    StartPoint = x.StartPoint,
                    EndPoint = x.EndPoint,
                    DepartureTime = x.DepartureTime,
                    Seats = x.Seats,
                    Description = x.Description,
                }),
            };
            return this.View(viewModel);
        }
        public HttpResponse Add()
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Add (TripsInfoModel input)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            if (input.Seats < 2 || input.Seats > 6)
            {
                return this.View();
            }

            if (input.Description.Length > 80)
            {
                return this.View();
            }

            this.itripService.Add(input);
            return this.Redirect("/Trips/All");
        }


        public HttpResponse Details(string tripId)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var detailsViewModel = this.itripService.GetDetails(tripId);
            return this.View(detailsViewModel, "Details");
        }

    }
}
