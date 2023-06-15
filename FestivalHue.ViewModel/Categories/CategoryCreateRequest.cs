using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestivalHue.ViewModel.Categories
{
    public class CategoryCreateRequest
    {
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public Status status { get; set; }
    }
}
