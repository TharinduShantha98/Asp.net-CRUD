

namespace MysqlConnectProject.Model
{

    [Index(nameof(Email), IsUnique = true)]
    public class Employee
    {

        public int Id { get; set; }


        [Required(ErrorMessage = "Name filed is required. ")]
        [StringLength(maximumLength: 100, MinimumLength = 1)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Name filed is required. ")]
        [StringLength(maximumLength: 100, MinimumLength = 1)]
        [EmailAddress]
        public string Email { get; set; }


        [Required(ErrorMessage = "Name filed is required. ")]
        public string Phone { get; set; }


        [StringLength(maximumLength: 250)]
        public string Address { get; set; }






    }
}
