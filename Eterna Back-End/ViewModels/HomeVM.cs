using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eterna_Back_End.Models;

namespace Eterna_Back_End.ViewModels
{
    public class HomeVM
    {
        public List<Slider> Sliders { get; set; }
        public List<MiniCard> MiniCards { get; set; }
        public List<AboutDescript> AboutDescripts { get; set; }
        public List<AboutImage> AboutImages { get; set; }
        public List<AboutMain> AboutMains { get; set; }
        public List<AboutToDoList> AboutToDoLists { get; set; }
        public List<HomeCard> HomeCards { get; set; }
        public List<Carousel> Carousels { get; set; }
    }
}
