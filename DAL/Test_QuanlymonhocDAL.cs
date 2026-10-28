using StudentManagment.DAL;
using StudentManagment.DTO;
using Microsoft.Extensions.Logging.Abstractions;
using System.Data;

[TestClass]
public class Test_QuanlymonhocDAL
{
    private readonly QuanlymonhocDAL dal = new QuanlymonhocDAL(new NullLoggerFactory());

    [TestMethod]
    public void ThemMonHocMoi_VoiMonHocHopLe_TraVeDataTable()
    {
        var monHoc = new MonhocDTO
        {
            Mamon = "MH100",
            Tenmon = "Lap Trinh C#",
            Manganh = "CNTT",
            Sotietlythuyet = 30,
            Sotietthuchanh = 15,
            Giangvien = "Nguyen Van A",
            Tinhtrang = "Dang day"
        };

        var result = dal.ThemMonHocMoi(monHoc);

        Assert.IsNotNull(result);
        Assert.IsInstanceOfType(result, typeof(DataTable));
    }

    [TestMethod]
    public void SuaThongTinMonHocTheoMaMon_VoiMonHocHopLe_TraVeDataTable()
    {
        var monHoc = new MonhocDTO
        {
            Mamon = "MH100",
            Tenmon = "Lap Trinh C# Nang Cao",
            Manganh = "CNTT",
            Sotietlythuyet = 45,
            Sotietthuchanh = 15,
            Giangvien = "Nguyen Van B",
            Tinhtrang = "Dang day"
        };

        var result = dal.SuaThongTinMonHocTheoMaMon(monHoc);

        Assert.IsNotNull(result);
        Assert.IsInstanceOfType(result, typeof(DataTable));
    }

    [TestMethod]
    public void XoaThongTinMonHocTheoMaMon_VoiMaMonHopLe_TraVeDataTable()
    {
        var result = dal.XoaThongTinMonHocTheoMaMon("MH100");

        Assert.IsNotNull(result);
        Assert.IsInstanceOfType(result, typeof(DataTable));
    }
}