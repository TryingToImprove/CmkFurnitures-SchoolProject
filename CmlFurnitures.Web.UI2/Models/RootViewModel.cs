using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace CmkFurnitures.Web.UI.Models
{
    public abstract class RootViewModel
    {
        public string CurrentPageHeader { get; set; }

        public IEnumerable<MenuItem> MenuItems { get; set; }

        public RootViewModel(string currentPageHeader, string menuKey)
        {
            this.MenuItems = GenerateMenuItems(menuKey);
            this.CurrentPageHeader = currentPageHeader;
        }

        private static IEnumerable<MenuItem> GenerateMenuItems(string menuKey)
        {
            IEnumerable<MenuItem> menuItems = new MenuItem[]{
                new MenuItem{
                    Key = "home",
                    Name = "Forside",
                    Action = "Index",
                    Controller = "Home"
                },
                new MenuItem{
                    Key = "articles",
                    Name = "Nyheds arkiv",
                    Action = "Index",
                    Controller = "Articles"
                },
                new MenuItem{
                    Key = "furnitures",
                    Name = "Møbler",
                    Action = "Search",
                    Controller = "Furniture"
                },
                new MenuItem{
                    Key = "contact",
                    Name = "Kontakt",
                    Action = "Index",
                    Controller = "Contact"
                    //,Parameters = new RouteValueDictionary{ { "hey", "test"} }
                }
            };

            MenuItem selectedMenuItem = menuItems.FirstOrDefault(x => x.Key.Equals(menuKey, StringComparison.OrdinalIgnoreCase));
            if (selectedMenuItem != null)
            {
                selectedMenuItem.Selected = true;
            }

            return menuItems;
        }

        public class MenuItem
        {
            public string Key { get; set; }
            public string Name { get; set; }

            public bool Selected { get; set; }

            public string Action { get; set; }
            public string Controller { get; set; }
            public RouteValueDictionary Parameters { get; set; }

            public MenuItem()
            {
                this.Parameters = null;
            }
        }
    }
}