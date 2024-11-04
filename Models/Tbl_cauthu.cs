namespace CRUD.Models
{
    public class Tbl_cauthu
    {
        public int Ma_ct { get; set; }  // Mã cầu thủ
        public string? Ten_ct { get; set; }  // Tên cầu thủ
        public DateTime NgaySinh { get; set; }  // Ngày sinh
        public string? Que_quan { get; set; }  // Quê quán
        public int Ma_clb { get; set; }  // Mã câu lạc bộ để liên kết
    }
}
