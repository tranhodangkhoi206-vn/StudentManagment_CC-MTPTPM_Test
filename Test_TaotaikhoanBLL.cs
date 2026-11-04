using System;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudentManagment.DTO;
using StudentManagment.BLL;
[TestClass]
public class TaotaikhoanBLLTests
{
    private TaotaikhoanBLL bll;

    [TestInitialize]
    public void Setup()
    {
        bll = new TaotaikhoanBLL(NullLoggerFactory.Instance);
    }

    // ===== ThemTaiKhoanMoi =====
    [DataTestMethod]
    [DataRow(null, "user01", "123456")]
    [DataRow("", "user01", "123456")]
    [DataRow("Nguyễn Văn A", null, "123456")]
    [DataRow("Nguyễn Văn A", "", "123456")]
    [DataRow("Nguyễn Văn A", "user01", null)]
    [DataRow("Nguyễn Văn A", "user01", "")]
    public void ThemTaiKhoanMoi_ThieuThongTin_NemArgumentException(string hoVaTen, string username, string password)
    {
        var taiKhoan = new TaikhoanDTO
        {
            Hovaten = hoVaTen,
            Username = username,
            HashedPassword = password
        };

        var ex = Assert.ThrowsExactly<ArgumentException>(() => bll.ThemTaiKhoanMoi(taiKhoan));
        Assert.AreEqual("Bạn phải nhập đầy đủ thông tin trước khi thêm", ex.Message);
    }

    // ===== SuaTaiKhoan =====
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    public void SuaTaiKhoan_ThieuUsername_NemArgumentException(string username)
    {
        var taiKhoan = new TaikhoanDTO { Username = username, HashedPassword = "123456" };

        var ex = Assert.ThrowsExactly<ArgumentException>(() => bll.SuaTaiKhoan(taiKhoan));
        Assert.AreEqual("Bạn phải nhập username trước khi sửa", ex.Message);
    }

    // ===== XoaTaiKhoan =====
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    public void XoaTaiKhoan_ThieuUsername_NemArgumentException(string username)
    {
        var ex = Assert.ThrowsExactly<ArgumentException>(() => bll.XoaTaiKhoan(username));
        Assert.AreEqual("Bạn phải nhập username trước khi xóa", ex.Message);
    }

    // ===== LayDanhSachTaiKhoanTheoDieuKienUsername =====
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    public void LayDanhSachTaiKhoanTheoDieuKienUsername_ThieuUsername_NemArgumentException(string username)
    {
        var ex = Assert.ThrowsExactly<ArgumentException>(() => bll.LayDanhSachTaiKhoanTheoDieuKienUsername(username));
        Assert.AreEqual("Bạn phải nhập username trước khi tìm kiếm", ex.Message);
    }
}
