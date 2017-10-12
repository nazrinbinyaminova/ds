using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VoguishTemplate.Models;

namespace VoguishTemplate.View_Models
{
    public class ViewModel
    {
        public IEnumerable<Author> Authors { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<Filess> Filesses { get; set; }
        public IEnumerable<Link> Links { get; set; }
        public IEnumerable<Menu> Menus { get; set; }
        public IEnumerable<News> Newses { get; set; }
    }
}