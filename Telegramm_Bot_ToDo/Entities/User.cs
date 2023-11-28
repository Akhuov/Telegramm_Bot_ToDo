using System.ComponentModel.DataAnnotations;

namespace Telegramm_Bot_ToDo.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public long UserId { get; set; }
        public string firstName { get; set; }
    }
}
