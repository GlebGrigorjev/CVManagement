using LatvijasPastsCore.Models.Enum;

namespace LatvijasPasts.UseCases.Models
{
    public class LanguageViewModel
    {
        public string? Language { get; set; }

        public Categories? Speaking { get; set; }

        public Categories? Listening { get; set; }

        public Categories? Writing { get; set; }
    }
}
