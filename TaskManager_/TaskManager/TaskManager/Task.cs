using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManager
{
    public class Task
    {
        public int TaskID { get; set; }

        [ForeignKey("UserID")]
        public User User { get; set; }
        public int UserID { get; set; }

        public string Naslov { get; set; }
        public string Opis { get; set; }
        public DateTime DatumKreiranja { get; set; }

    }
}
