using CarsStore.ViewModel.BaseViewModel;
using CarsStore.ViewModel.OrderViewModel;
using CarStoreDbEF.Entities;
using CarStoreDbEF.Repository;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace CarsStore.Controllers
{
    public class OrderController : Controller
    {
        public ActionResult Index(int page= 1)
        {
            User user = new User();
            user = (User)Session["LoggedUser"];

            if (user == null)
                return RedirectToAction("Login", "Home");

            string connectionString = ConfigurationManager.ConnectionStrings["CarStoreDb"].ToString();

            OrderRepository orderRepository = new OrderRepository();
            OrderListViewModel orderListViewModel = new OrderListViewModel();

            orderListViewModel.items = orderRepository.getOrderData(connectionString);

            int pageSize = 10; // количество объектов на страницу
            IEnumerable<OrderData> objectsPerPage = orderListViewModel.items.Skip((page - 1) * pageSize).Take(pageSize);
            PageInfo pageInfo = new PageInfo { PageNumber = page, PageSize = pageSize, TotalItems = orderListViewModel.items.Count };
            OrderListViewModel ivm = new OrderListViewModel { PageInfo = pageInfo, items = objectsPerPage.ToList<OrderData>() };
            ivm.IsAdmin = user.IsAdmin;

            return View(ivm);
        }

        [HttpGet]
        public ActionResult Purchase(int id)
        {
            PurchaseViewModel model = new PurchaseViewModel();
            User user = (User)Session["LoggedUser"];

            CarRepository carRepository = new CarRepository();

            Car car = carRepository.GetById(id);


            model.UserId = user.Id;
            model.CarId = car.Id;
            model.Brand = car.Brand;
            model.Model = car.Model;
            model.Price = car.Price;


            return View(model);
        }
        [HttpPost]
        public ActionResult Purchase(PurchaseViewModel model)
        {
            Order order = new Order();
            OrderRepository orderRepository = new OrderRepository();

            order.CarId = model.CarId;
            order.UserId = model.UserId;
            order.OrderDate = DateTime.Now;
            order.Warranty = model.Warranty;


            orderRepository.Save(order);

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            OrderRepository repository = new OrderRepository();
            Order order = repository.GetById(id);
            OrderDeleteViewModel model = new OrderDeleteViewModel();

            model.Id = order.Id;

            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(OrderDeleteViewModel model)
        {
            OrderRepository repository = new OrderRepository();

            repository.Delete(model.Id);

            return RedirectToAction("Index");
        }






    }
}