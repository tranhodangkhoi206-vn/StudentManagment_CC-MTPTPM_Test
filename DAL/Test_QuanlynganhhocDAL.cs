using StudentManagment.DAL;
using StudentManagment.DTO;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data;

[TestClass]
public class Test_QuanlynganhhocDAL
{
    private readonly QuanlynganhhocDAL dal = new QuanlynganhhocDAL(new NullLoggerFactory());

    [TestMethod]
    public void ThemNganhMoi_VoiNganhHopLe_TraVeDataTable()
    {
        var nganh = new NganhhocDTO
        {
            Manganh = "CK",
            Tennganh = "Cơ khí",
            Khoaquanly = "Công nghệ và Kỹ thuật"
        };

        var result = dal.ThemNganhMoi(nganh);

        Assert.IsNotNull(result);
        Assert.IsInstanceOfType(result, typeof(DataTable));
    }

    [TestMethod]
    public void SuaThongTinNganhTheoMaNganh_VoiNganhHopLe_TraVeDataTable()
    {
        var nganh = new NganhhocDTO
        {
            Manganh = "CK",
            Tennganh = "Cong Nghe Thong Tin Cap Cao",
            Khoaquanly = "Khoa Kinh tế biển"
        };

        var result = dal.SuaThongTinNganhTheoMaNganh(nganh);

        Assert.IsNotNull(result);
        Assert.IsInstanceOfType(result, typeof(DataTable));
    }

    [TestMethod]
    public void XoaThongTinNganhTheoMaNganh_VoiMaNganhHopLe_TraVeDataTable()
    {
        var result = dal.XoaThongTinNganhTheoMaNganh("CK");

        Assert.IsNotNull(result);
        Assert.IsInstanceOfType(result, typeof(DataTable));
    }
}