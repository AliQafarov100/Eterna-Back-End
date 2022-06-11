using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eterna_Back_End.Models;

namespace Eterna_Back_End.ViewModels
{
    public class ServiceVM
    {
        public List<Card> Cards { get; set; }
        public List<Progress> Progresses { get; set; }
        public List<AnotherDescription> AnotherDescriptions { get; set; }
        public List<Information> informations { get; set; }
        public List<Skill> Skills { get; set; }
    }
}
