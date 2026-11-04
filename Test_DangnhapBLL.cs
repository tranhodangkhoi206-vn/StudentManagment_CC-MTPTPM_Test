using Microsoft.Extensions.Logging.Abstractions;
using StudentManagment.BLL;

namespace StudentManagment.Test;

[TestClass]
public class Test_DangnhapBLL
{
    private readonly DangnhapBLL _bll = new DangnhapBLL(NullLoggerFactory.Instance);
    [TestMethod]
    [DataRow(null, "pass")]
    [DataRow("", "pass")]
    [DataRow("user", null)]
    [DataRow("user", "")]
    public void KiemTraDangNhap_ThrowArgumentException(string username, string password)
    {
        var ex = Assert.ThrowsExactly<ArgumentException>(() =>
                _bll.KiemTraDangNhap(username, password, false)
        );
        Assert.AreEqual("Bạn phải nhập đầy đủ thông tin trước khi đăng nhập.", ex.Message);
    }
    [TestMethod]
    public void KiemTraDangNhap_UnauthorizedAccessException()
    {
        var ex = Assert.ThrowsExactly<UnauthorizedAccessException>(() =>
        _bll.KiemTraDangNhap("tranhodangkhoi", "1", false));
        Assert.AreEqual("Bạn nhập mật khẩu chưa chính xác.",ex.Message);
    }
    [TestMethod]
    public void KiemTraDangNhap_KeyNotFoundException()
    {
        var ex = Assert.ThrowsExactly<KeyNotFoundException>(() => _bll.KiemTraDangNhap("khongtontai", "123", false));
        Assert.AreEqual("Tên tài khoản hoặc mật khẩu chưa chính xác.", ex.Message);
    }
    [TestMethod]
    public void KiemTraDangNhap_DangNhapThanhCong()
    {
        Assert.IsNotNull(_bll.KiemTraDangNhap("tranhodangkhoi", "123", false));
    }
}
