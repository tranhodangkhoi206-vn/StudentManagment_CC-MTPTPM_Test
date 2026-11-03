using Microsoft.Extensions.Logging.Abstractions;
using StudentManagment.BLL;
using StudentManagment.DTO;

namespace StudentManagment.Test;

[TestClass]
public class Test_QuanlymonhocBLL
{
    private readonly QuanlymonhocBLL _bll = new QuanlymonhocBLL(NullLoggerFactory.Instance);
    [TestMethod]
    public void ThemTaiKhoanMoi_ArgumentException()
    {
        MonhocDTO _dto = new MonhocDTO()
        {
            Mamon = "",
            Manganh = "",
            Giangvien = "",
            Tenmon = "",
            Tinhtrang = ""
        };
        var ex = Assert.ThrowsExactly<ArgumentException>(() =>
        _bll.ThemmonhocMoi(_dto));
        Assert.AreEqual("Bạn phải nhập đầy đủ thông tin trước khi thêm", ex.Message);
    }
    [TestMethod]
    public void SuaTaiKhoan_ArgumentException()
    {
        MonhocDTO _dto = new MonhocDTO()
        {
            Mamon = "",
            Manganh = "",
            Giangvien = "",
            Tenmon = "",
            Tinhtrang = ""
        };
        var ex = Assert.ThrowsExactly<ArgumentException>(() => _bll.SuaMonHocTheoMaMonHoc(_dto));
        Assert.AreEqual("Bạn phải nhập mã môn học trước khi sửa", ex.Message);
    }
    [TestMethod]
    public void XoaTaiKhoan_ArgumentException()
    {
        string maMon = "";
        var ex = Assert.ThrowsExactly<ArgumentException>(() => _bll.XoaMonHocTheoMaMonHoc(maMon));
        Assert.AreEqual("Bạn phải nhập mã môn học trước khi xóa", ex.Message);
    }

}
