namespace SharedTrip.App.Controllers
{
    using SIS.HTTP;
    using SIS.MvcFramework;

    public class HomeController : Controller
    {
        //TODO: add user service if needed
        public HomeController()
        {
                
        }

        [HttpGet("/")]
        public HttpResponse IndexSlash()
        {
            if (this.IsUserLoggedIn())
            {
                //var viewModel = new IndexViewModel();
                //viewModel.Username = this.usersService.GetUsername(this.User);
                //return this.View(viewModel, "Home");
            }

            return this.Index();
        }
        public HttpResponse Index()
        {
            return this.View();
        }
    }
}