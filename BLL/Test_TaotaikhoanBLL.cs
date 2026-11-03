using Microsoft.DiaSymReader;
using Microsoft.Extensions.Logging.Abstractions;
using StudentManagment.BLL;
using StudentManagment.DTO;

namespace StudentManagment.Test;

[TestClass]
public class Test_TaotaikhoanBLL
{
    private readonly TaotaikhoanBLL _bll = new TaotaikhoanBLL(NullLoggerFactory.Instance);
    [TestMethod]
    public void ThemTaiKhoanMoi_ArgumentException()
    {
        TaikhoanDTO _dto = new TaikhoanDTO()
        {
            Hovaten = "",
            Username = "",
            HashedPassword = "",
            Admin = false
        };
        var ex = Assert.ThrowsExactly<ArgumentException>(() =>
        _bll.ThemTaiKhoanMoi(_dto));
        Assert.AreEqual("Bạn phải nhập đầy đủ thông tin trước khi thêm", ex.Message);
    }
    [TestMethod]
   public void SuaTaiKhoan_ArgumentException()
    {
        TaikhoanDTO _dto = new TaikhoanDTO()
        {
            Hovaten = "",
            Username = "",
            HashedPassword = "",
            Admin = false
        };
        var ex = Assert.ThrowsExactly<ArgumentException>(() => _bll.SuaTaiKhoan(_dto));
        Assert.AreEqual("Bạn phải nhập username trước khi sửa",ex.Message);
    }
    [TestMethod]
    public void XoaTaiKhoan_ArgumentException()
    {
        string username = "";
        var ex = Assert.ThrowsExactly<ArgumentException>(() => _bll.XoaTaiKhoan(username));
        Assert.AreEqual("Bạn phải nhập username trước khi xóa", ex.Message);
    }
}
