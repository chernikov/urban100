using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using urban100.Model;


namespace urban100.Web.Models.ViewModels
{
    public class OwnerView
    {
        private readonly IRepository _repository = DependencyResolver.Current.GetService<IRepository>();

        public int ID { get; set; }

        public string Name { get; set; }

        public string SubTitle { get; set; }

        public string Image { get; set; }

        public string FullImage
        {
            get
            {
                return (string.IsNullOrWhiteSpace(Image) ? "/Content/images/hover_effect.png" : Image) + "?w=120&h=120&mode=crop";
            }
        }

        public string Twitter { get; set; }

        public string Facebook { get; set; }

        public string Google { get; set; }

        public string Instagram { get; set; }

        public string Tumblr { get; set; }

        public int Cell { get; set; }

        private List<int> BusyCells 
        {
            get
            {
                return _repository.Owners.Where(p => p.ID != ID).Select(p => p.Cell).ToList();
            }
        }

        public IEnumerable<SelectListItem> SelectListCell
        {
            get
            {
                for (var i = 0; i < 100; i++)
                    {
                        if (BusyCells.Contains(i))
                        {
                            continue;
                        }
                        yield return new SelectListItem()
                        {
                            Value = i.ToString(),
                            Text = (i+1).ToString(),
                            Selected = Cell == i
                        };
                    }
            }
        }
    }
}