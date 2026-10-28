using StudentManagment.DAL;
using StudentManagment.DTO;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data;
using Microsoft.Extensions.Logging;
using Microsoft.Data.SqlClient;

[TestClass]
public class Test_QuanlydiemDAL
{
    private QuanlydiemDAL dal = new QuanlydiemDAL(new NullLoggerFactory());
    [TestMethod]
    public void ThemDiemMoi_VoiDiemHopLe_TraVeDataTable()
    {
        var diem = new DiemDTO
        {
            Masinhvien = "SV010",
            Mamon = "MH010",
            Diemchuyencan = 8,
            Diemgiuaky = 7,
            Diemcuoiky = 9,
            Diemtong = 8.5
        };

        var result = dal.ThemDiemMoi(diem);

        Assert.IsNotNull(result);
        Assert.IsInstanceOfType(result, typeof(DataTable));
    }

    [TestMethod]
    public void SuaThongTinDiemTheoMaSinhVienVaMaMon_VoiDiemHopLe_TraVeDataTable()
    {
        var diem = new DiemDTO
        {
            Masinhvien = "SV010",
            Mamon = "MH010",
            Diemchuyencan = 9.0,
            Diemgiuaky = 9.0,
            Diemcuoiky = 9.0,
            Diemtong =9.0 
        };

        var result = dal.SuaThongTinDiemTheoMaSinhVienVaMaMon(diem);

        Assert.IsNotNull(result);
        Assert.IsInstanceOfType(result, typeof(DataTable));
    }

    [TestMethod]
    public void XoaThongTinDiemTheoMaSinhVienVaMaMon_VoiMaHopLe_TraVeDataTable()
    {
        var result = dal.XoaThongTinDiemTheoMaSinhVienVaMaMon("SV010", "MH010");

        Assert.IsNotNull(result);
        Assert.IsInstanceOfType(result, typeof(DataTable));
    }
}