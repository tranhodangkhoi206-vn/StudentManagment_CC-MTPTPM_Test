using StudentManagment.DAL;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class Test_DangnhapDAL
{
    private readonly DangnhapDAL dal = new DangnhapDAL(new NullLoggerFactory());

    [TestMethod]
    public void LayTaiKhoanCoDieuKien_DungUsernameVaPassword_TraVeThongTinTaiKhoan()
    {
        var result = dal.LayTaiKhoanCoDieuKien("tranhodankhoi", "123");

        Assert.AreEqual("Trần Hồ Đăng Khôi", result.Hovaten);
    }

    [TestMethod]
    public void LayTaiKhoanCoDieuKien_SaiPassword_TraVeDoiTuongRong()
    {
        var result = dal.LayTaiKhoanCoDieuKien("tranhodankhoi", "SaiMatKhau");

        Assert.AreEqual("", result.Hovaten);
    }

    [TestMethod]
    public void LayTaiKhoanCoDieuKien_SaiUsername_TraVeDoiTuongRong()
    {
        var result = dal.LayTaiKhoanCoDieuKien("khong_ton_tai", "123");

        Assert.AreEqual("", result.Hovaten);
    }
}