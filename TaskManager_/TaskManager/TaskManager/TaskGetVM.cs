namespace TaskManager
{
    public class TaskGetVM 
    {
       // public int TaskID { get; set; }
        public int UserID { get; set; }
        public User User { get; set; }


        public string Naslov { get; set; }
        public string Opis { get; set; }
        public DateTime DatumKreiranja { get; set; }

    }
}
