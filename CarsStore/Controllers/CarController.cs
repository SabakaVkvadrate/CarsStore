using CarsStore.ViewModel.BaseViewModel;
using CarsStore.ViewModel.CarViewModel;
using CarStoreDbEF.Entities;
using CarStoreDbEF.Repository;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace CarsStore.Controllers
{
    public class CarController : BaseController<Car,
                                               CarRepository,
                                               CarDeleteViewModel,
                                               CarEditViewModel,
                                               CarListViewModel>
    {
        public override CarDeleteViewModel GetMapperDelete(Car entity)
        {
            CarDeleteViewModel model = new CarDeleteViewModel();

            model.Id = entity.Id;
            model.Brand = entity.Brand;
            model.Model = entity.Model;
            model.ManafDate = entity.ManafDate;
            model.Price = entity.Price;
            model.ImgLink = entity.ImgLink;

            return model;
        }

        public override CarEditViewModel GetMapperEdit(Car entity)
        {

            CarEditViewModel model = new CarEditViewModel();

            model.Id = entity.Id;
            model.Brand = entity.Brand;
            model.Model = entity.Model;
            model.ManafDate = entity.ManafDate;
            model.Price = entity.Price;
            model.ImgLink = entity.ImgLink;

            return model;
        }


        public override Car PostMapperEdit(CarEditViewModel model)
        {
            Car entity = new Car();

            entity.Id = model.Id;
            entity.Brand = model.Brand;
            entity.Model = model.Model;
            entity.ManafDate = model.ManafDate;
            entity.Price = model.Price;
            entity.ImgLink = model.ImgLink;

            return entity;
        }

        public override ActionResult Index(int page = 1)
        {
            User user = new User();
            user = (User)Session["LoggedUser"];

            if (user == null)
                return RedirectToAction("Login", "Home");

            CarRepository repository = new CarRepository();
            CarListViewModel listviewmodel = new CarListViewModel();

            listviewmodel.items = repository.GetAll();
            listviewmodel.IsAdmin = user.IsAdmin;

            int pageSize = 3;// количество объектов на страницу
            IEnumerable<Car> objectsPerPage = listviewmodel.items.Skip((page - 1) * pageSize).Take(pageSize);
            PageInfo pageInfo = new PageInfo { PageNumber = page, PageSize = pageSize, TotalItems = listviewmodel.items.Count };

            CarListViewModel ivm = new CarListViewModel { PageInfo = pageInfo, items = objectsPerPage.ToList<Car>() };
            ivm.IsAdmin = user.IsAdmin;

            return View(ivm);


            //return View(listviewmodel);
        }
        


        public ActionResult StartPage()

        {
            CarRepository repository = new CarRepository();
            CarListViewModel model = new CarListViewModel();

            User user = (User)Session["LoggedUser"];

            if (user == null)
                return RedirectToAction("Login", "Home");

            string connectionString = ConfigurationManager.ConnectionStrings["CarStoreDb"].ToString();


            model.items = repository.GetTopCars(connectionString);        
            model.IsAdmin = user.IsAdmin;

            return View(model);
        }

    }
}