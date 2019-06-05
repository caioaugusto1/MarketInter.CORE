using System.ComponentModel.DataAnnotations;

namespace Inter.Core.App.Enumerables
{
    public enum PeriodClass
    {
        [Display(Name = "Morning")]
        Morning = 'M',
        [Display(Name = "Afternoon")]
        Afternoon = 'A',
        [Display(Name = "Night")]
        Night = 'N'
    }
}
