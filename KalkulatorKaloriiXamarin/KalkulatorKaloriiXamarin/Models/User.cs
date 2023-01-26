using SQLite;

namespace KalkulatorKaloriiXamarin.Models
{
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        [MaxLength(30)]
        public string Username { get; set; }
        [MaxLength(30)]
        public string Sex { get; set; }
        [MaxLength(30)]
        public string Height { get; set; }
        [MaxLength(30)]
        public string Weight { get; set; }
        [MaxLength(30)]
        public string TargetWeight { get; set; }
        [MaxLength(30)]
        public string Age { get; set; }
        [MaxLength(30)]
        public string KcalPerDay { get; set; }
        [MaxLength(30)]
        public string WaterPerDay { get; set; }
    }
}
