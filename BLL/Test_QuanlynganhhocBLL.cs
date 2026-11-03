using Microsoft.Extensions.Logging.Abstractions;
using StudentManagment.BLL;
using StudentManagment.DTO;

namespace StudentManagment.Test;

[TestClass]
public class Test_QuanlynganhhocBLL
{
    readonly QuanlynganhhocBLL _bll = new QuanlynganhhocBLL(NullLoggerFactory.Instance);
    [TestMethod]
    public void ThemTaiKhoanMoi_ArgumentException()
    {
        NganhhocDTO _dto = new NganhhocDTO()
        {
            Manganh = "",
            Tennganh = "",
            Khoaquanly = ""
        };
        var ex = Assert.ThrowsExactly<ArgumentException>(() =>
        _bll.ThemNganhMoi(_dto));
        Assert.AreEqual("Bạn phải nhập đầy đủ thông tin trước khi thêm", ex.Message);
    }
    [TestMethod]
    public void SuaTaiKhoan_ArgumentException()
    {
        NganhhocDTO _dto = new NganhhocDTO()
        {
            Manganh = "",
            Tennganh = "",
            Khoaquanly = ""
        };
        var ex = Assert.ThrowsExactly<ArgumentException>(() => _bll.SuaThongTinNganhTheoMaNganh(_dto));
        Assert.AreEqual("Bạn phải nhập mã ngành trước khi sửa", ex.Message);
    }
    [TestMethod]
    public void XoaTaiKhoan_ArgumentException()
    {
        string maNganh = "";
        var ex = Assert.ThrowsExactly<ArgumentException>(() => _bll.XoaThongTinNganhTheoMaNganh(maNganh));
        Assert.AreEqual("Bạn phải nhập mã ngành trước khi xóa", ex.Message);
    }
}
