using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace KalkulatorKaloriiXamarin.Models
{
    public class UserHistory
    {
        [PrimaryKey, AutoIncrement]
        public int HistoryID { get; set; }
        [MaxLength(30)]
        public int UserID { get; set; }
        [MaxLength(30)]
        public string MealType { get; set; }
        [MaxLength(30)]
        public string MealName { get; set; }
        [MaxLength(30)]
        public string MealWeight { get; set; }
        [MaxLength(30)]
        public string MealKcal { get; set; }
        [MaxLength(30)]
        public string WaterQty { get; set; }
        [MaxLength(30)]
        public string Activity { get; set; }
        [MaxLength(30)]
        public string ActivityTime { get; set; }
        [MaxLength(30)]
        public string Date { get; set; }
    }
}
