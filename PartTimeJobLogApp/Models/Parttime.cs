using System.ComponentModel.DataAnnotations;

namespace PartTimeJobLogApp.Models
{
    public class Parttime
    {
        public int Id { get; set; }

        public String Name { get; set; }    // 名前

        public string Tel { get; set; }     // 電話番号

        public DateTime Interview { get; set; } // 面接日
    }
}
