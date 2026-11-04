using System;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudentManagment.BLL;

using StudentManagment.DTO;
[TestClass]
public class DangnhapBLLTests
{
    private DangnhapBLL bll;

    [TestInitialize]
    public void Setup()
    {
        bll = new DangnhapBLL(NullLoggerFactory.Instance);
    }

    // ===== KiemTraDangNhap =====
    [DataTestMethod]
    [DataRow(null, "123456")]
    [DataRow("", "123456")]
    [DataRow("admin", null)]
    [DataRow("admin", "")]
    [DataRow(null, null)]
    [DataRow("", "")]
    public void KiemTraDangNhap_ThieuThongTin_NemArgumentException(string username, string password)
    {
        var ex = Assert.ThrowsExactly<ArgumentException>(() => bll.KiemTraDangNhap(username, password, false));
        Assert.AreEqual("Bạn phải nhập đầy đủ thông tin trước khi đăng nhập.", ex.Message);
    }
}