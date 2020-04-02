using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IdentityMVC.Models
{
    public class TodoListItems
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool isCompleted { get; set; }
        public string user_todolist_id { get; set; }



        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}