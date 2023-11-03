using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CourierManagementSystem.Entity
{
    public class UserLogHistory : Bases
    {

        [MaxLength(250)]
        public string? userId { get; set; }
        [MaxLength(250)]
        public DateTime logTime { get; set; }
        public int? status { get; set; }
        [MaxLength(250)]
        public string? ipAddress { get; set; }
        [MaxLength(250)]
        public string? browserName { get; set; }
        [MaxLength(250)]
        public string? pcName { get; set; }
        [NotMapped]
        public string? statusName { get; set; }
    }
}
