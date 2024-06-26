using System.ComponentModel.DataAnnotations;

namespace NamePicker.Entities
{
    public class User
    {
        [Key]
        public required int Id { get; set; }
        public required int UserId {  get; set; }
        public required string FullName { get; set; }
        public required string JiraDashboardUrl { get; set; }
    }
}
