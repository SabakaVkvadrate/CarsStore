using CarsStore.ViewModel.BaseViewModel;
using CarsStore.ViewModel.CarViewModel;
using CarsStore.ViewModel.UserViewModel;
using CarStoreDbEF.Entities;
using CarStoreDbEF.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;


namespace CarsStore.Controllers
{
    public class UserController : BaseController<User,
                                                 UserRepository,
                                                 UserDeleteViewModel,
                                                 UserEditViewModel,
                                                 UserListViewModel>
    {
      
        public override UserDeleteViewModel GetMapperDelete(User entity)
        {
            UserDeleteViewModel model = new UserDeleteViewModel();
          
            model.Id = entity.Id;
            model.Username = entity.Username;
            model.Password = entity.Password;
            model.Firstname = entity.Firstname;
            model.Lastname = entity.Lastname;
            model.Email = entity.Email;
            model.IsAdmin = entity.IsAdmin;

            return model;
        }

        public override UserEditViewModel GetMapperEdit(User entity)
        {
            UserEditViewModel model = new UserEditViewModel();

            model.Id = entity.Id;
            model.Username = entity.Username;
            model.Password = entity.Password;
            model.Firstname = entity.Firstname;
            model.Lastname = entity.Lastname;
            model.Email = entity.Email;
            model.IsAdmin = entity.IsAdmin;

            return model;
        }

        public override User PostMapperEdit(UserEditViewModel EVM)
        {
            User entity = new User();

            entity.Id = EVM.Id;
            entity.Username = EVM.Username;
            entity.Password = EVM.Password;
            entity.Firstname = EVM.Firstname;
            entity.Lastname = EVM.Lastname;
            entity.Email = EVM.Email;
            entity.IsAdmin = EVM.IsAdmin;

            return entity;
        }


        public override ActionResult Index(int page = 1)
        {
            User user = new User();
            user = (User)Session["LoggedUser"];

            if (user == null)
                return RedirectToAction("Login", "Home");
             
            UserRepository repository = new UserRepository();
            UserListViewModel listviewmodel = new UserListViewModel();

            listviewmodel.items = repository.GetAll();
            listviewmodel.IsAdmin = user.IsAdmin;

            int pageSize = 10;// количество объектов на страницу
            IEnumerable<User> objectsPerPage = listviewmodel.items.Skip((page - 1) * pageSize).Take(pageSize);
            PageInfo pageInfo = new PageInfo { PageNumber = page, PageSize = pageSize, TotalItems = listviewmodel.items.Count };

            UserListViewModel ivm = new UserListViewModel { PageInfo = pageInfo, items = objectsPerPage.ToList<User>() };
            ivm.IsAdmin = user.IsAdmin;

            return View(ivm);
            //return View(listviewmodel);
        }
    }
}