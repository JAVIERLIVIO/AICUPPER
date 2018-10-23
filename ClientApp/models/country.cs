using System.ComponentModel.DataAnnotations;
namespace aicupper.models
{
    /// <summary>
    /// Country Object
    /// </summary>
    public class country
    {
        [Key]
        public string CountryCode { get; set; }

        public string CountryName { get; set; }
    }
}
