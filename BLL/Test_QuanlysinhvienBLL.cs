using System.Windows.Forms;
using Microsoft.Extensions.Logging.Abstractions;
using StudentManagment.BLL;
using StudentManagment.DTO;

namespace StudentManagment.Test;

[TestClass]
public class Test_QuanlysinhvienBLL
{
    readonly QuanlysinhvienBLL _bll = new QuanlysinhvienBLL(NullLoggerFactory.Instance);
    [TestMethod]
    public void ThemTaiKhoanMoi_ArgumentException()
    {
        SinhvienDTO _dto = new SinhvienDTO()
        {
            MaSinhVien = "",
            HoVaTen = "",
            MaLop = "",
            GioiTinh = "",
            MaNganh = "",
            TinhTrang = ""
        };
        var ex = Assert.ThrowsExactly<ArgumentException>(() =>
        _bll.ThemsinhvienMoi(_dto));
        Assert.AreEqual("Bạn phải nhập đầy đủ thông tin trước khi thêm", ex.Message);
    }
    [TestMethod]
    public void SuaTaiKhoan_ArgumentException()
    {
        SinhvienDTO _dto = new SinhvienDTO()
        {
            MaSinhVien = "",
            HoVaTen = "",
            MaLop = "",
            GioiTinh = "",
            MaNganh = "",
            TinhTrang = ""
        };
        var ex = Assert.ThrowsExactly<ArgumentException>(() => _bll.SuaSinhVienTheoMaSinhVien(_dto));
        Assert.AreEqual("Bạn phải nhập mã sinh viên trước khi sửa", ex.Message);
    }
    [TestMethod]
    public void XoaTaiKhoan_ArgumentException()
    {
        string maSinhVien = "";
        var ex = Assert.ThrowsExactly<ArgumentException>(() => _bll.XoaSinhVienTheoMaSinhVien(maSinhVien));
        Assert.AreEqual("Bạn phải nhập mã sinh viên trước khi xóa", ex.Message);
    }
}
