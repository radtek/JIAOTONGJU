using DYApp.Domain;
using DYApp.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DYApp.Domain.Model
{
    public class CaseHandling:AggregateRoot
    {
        public virtual Filing Filing { get; set; }
        public string Conclusion { get; set; }
        public string ConclusionSign1 { get; set; }
        public string ConclusionSign2 { get; set; }
        public DateTime ConclusionTime { get; set; }
        //法制工作机构意见
        public string WorkSuggestion { get; set; }
        public string WorkSuggestionSign { get; set; }
        public DateTime WorkSuggestionTime { get; set; }
        public string ExecuteSuggestion { get; set; }
        public string ExecuteSuggestionSign { get; set; }
        public DateTime ExecuteSuggestionTime { get; set; }
        public virtual WorkFlow WorkFlow { get; set; }
    }
}
