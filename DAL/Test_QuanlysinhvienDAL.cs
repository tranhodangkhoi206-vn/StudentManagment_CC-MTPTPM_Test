using StudentManagment.DAL;
using StudentManagment.DTO;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data;

[TestClass]
public class Test_QuanlysinhvienDAL
{
    private readonly QuanlysinhvienDAL dal = new QuanlysinhvienDAL(new NullLoggerFactory());

    [TestMethod]
    public void ThemsinhVienMoi_VoiSinhVienHopLe_TraVeDataTable()
    {
        var sinhVien = new SinhvienDTO
        {
            MaSinhVien = "SV100",
            HoVaTen = "Nguyen Van A",
            MaLop = "CNTT01",
            NgaySinh = new DateTime(2000, 1, 1),
            GioiTinh = "Nam",
            MaNganh = "CNTT",
            TinhTrang = "Dang hoc"
        };

        var result = dal.ThemsinhVienMoi(sinhVien);

        Assert.IsNotNull(result);
        Assert.IsInstanceOfType(result, typeof(DataTable));
    }

    [TestMethod]
    public void SuaThongTinSinhVienTheoMaSinhVien_VoiSinhVienHopLe_TraVeDataTable()
    {
        var sinhVien = new SinhvienDTO
        {
            MaSinhVien = "SV100",
            HoVaTen = "Nguyen Van B",
            MaLop = "CNTT01",
            NgaySinh = new DateTime(2000, 1, 1),
            GioiTinh = "Nam",
            MaNganh = "CNTT",
            TinhTrang = "Đã tốt nghiệp"
        };

        var result = dal.SuaThongTinSinhVienTheoMaSinhVien(sinhVien);

        Assert.IsNotNull(result);
        Assert.IsInstanceOfType(result, typeof(DataTable));
    }

    [TestMethod]
    public void XoaThongTinSinhVienTheoMaSinhVien_VoiMaSinhVienHopLe_TraVeDataTable()
    {
        var result = dal.XoaThongTinSinhVienTheoMaSinhVien("SV100");

        Assert.IsNotNull(result);
        Assert.IsInstanceOfType(result, typeof(DataTable));
    }
}