using CarStoreDbEF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarsStore.ViewModel.BaseViewModel
{
    public class BaseListViewModel<Entity> where Entity : BaseEntity
    {
        public List<Entity> items { get; set; }
        public bool IsAdmin { get; set; }
        public PageInfo PageInfo { get; set; }

    }
    public class PageInfo
    {
        public int PageNumber { get; set; } // номер текущей страницы
        public int PageSize { get; set; } // кол-во объектов на странице
        public int TotalItems { get; set; } // всего объектов
        public int TotalPages  // всего страниц
        {
            get { return (int)Math.Ceiling((decimal)TotalItems / PageSize); }
        }
    }
}