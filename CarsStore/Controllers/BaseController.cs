using CarsStore.ViewModel.BaseViewModel;
using CarStoreDbEF.Entities;
using CarStoreDbEF.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace CarsStore.Controllers
{
    public abstract class BaseController<Entity, Repository_T, DeleteViewModel_T, EditViewModel_T, ListViewModel_T> : Controller
                            where Entity : BaseEntity, new()
                            where Repository_T : BaseRepository<Entity>, new()
                            where DeleteViewModel_T : BaseDeleteViewModel, new()
                            where EditViewModel_T : BaseEditViewModel, new()
                            where ListViewModel_T : BaseListViewModel<Entity>, new()

    {

        public abstract EditViewModel_T GetMapperEdit(Entity entity);//?
        public abstract Entity PostMapperEdit(EditViewModel_T EVM_T);//?
        public abstract DeleteViewModel_T GetMapperDelete(Entity entity);

        public virtual ActionResult Index(int page = 1)
        {          
            #region WastedCode
           // User user = new User();
           // user = (User)Session["LoggedUser"];

           // if (user == null)
           //     return RedirectToAction("Login", "Home");
           // Repository_T repository = new Repository_T();
           // ListViewModel_T listviewmodel = new ListViewModel_T();

           // listviewmodel.items = repository.GetAll();
           // listviewmodel.IsAdmin = user.IsAdmin;



           //// int pageSize = 4;// количество объектов на страницу
           // IEnumerable<Entity> objectsPerPage = listviewmodel.items.Skip((page - 1) * pageSize).Take(pageSize);
           // PageInfo pageInfo = new PageInfo { PageNumber = page, PageSize = pageSize, TotalItems = listviewmodel.items.Count };
           // ListViewModel_T ivm = new ListViewModel_T { PageInfo = pageInfo, items = objectsPerPage.ToList<Entity>() };
           // ivm.IsAdmin = user.IsAdmin;
           // return View(ivm);
          //  return View(listviewmodel);
            #endregion
            return View();
        }


        [HttpGet]
        public ActionResult Edit(int? id)
        {
            User user = new User();
            user = (User)Session["LoggedUser"];


            Repository_T repository = new Repository_T();

            EditViewModel_T model = new EditViewModel_T();

            if (id.HasValue)
            {
                Entity entity = repository.GetById(id.Value);
                model = GetMapperEdit(entity);
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(EditViewModel_T editviewmodel)
        {

            Repository_T repository = new Repository_T();
            Entity entity = new Entity();
            if (editviewmodel != null)
            {
                entity = PostMapperEdit(editviewmodel);

                repository.Save(entity);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            Repository_T repository = new Repository_T();
            Entity entity = repository.GetById(id);

            DeleteViewModel_T deleteviewmodel = new DeleteViewModel_T();
            deleteviewmodel = GetMapperDelete(entity);

            return View(deleteviewmodel);
        }
        [HttpPost]
        public ActionResult Delete(DeleteViewModel_T deleteviewmodel)
        {
            Repository_T repository = new Repository_T();
            repository.Delete(deleteviewmodel.Id);

            return RedirectToAction("Index");
        }



    }
}