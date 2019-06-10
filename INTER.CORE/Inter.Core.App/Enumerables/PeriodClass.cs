using System.ComponentModel.DataAnnotations;

namespace Inter.Core.App.Enumerables
{
    public enum PeriodClass
    {
        [Display(Name = "Morning")]
        Morning,
        [Display(Name = "Afternoon")]
        Afternoon,
        [Display(Name = "Night")]
        Night
    }
}
