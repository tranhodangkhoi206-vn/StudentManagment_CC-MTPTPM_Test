using Microsoft.Extensions.Logging.Abstractions;
using StudentManagment.DTO;
using StudentManagment.BLL;

namespace StudentManagment.Test;

[TestClass]
public class Test_QuanlydiemBLL
{
    private readonly QuanlydiemBLL _bll = new QuanlydiemBLL(NullLoggerFactory.Instance);
    [TestMethod]
    public void ThemTaiKhoanMoi_ArgumentException()
    {
        DiemDTO _dto = new DiemDTO()
        {
            Masinhvien = "",
            Mamon = "",
            Diemchuyencan = -1,
            Diemgiuaky = -1,
            Diemcuoiky = -1
        };
        var ex = Assert.ThrowsExactly<ArgumentException>(() =>
        _bll.ThemDiemMoi(_dto));
        Assert.AreEqual("Bạn phải nhập đầy đủ thông tin trước khi thêm", ex.Message);
    }
    [TestMethod]
    public void SuaTaiKhoan_ArgumentException()
    {
        DiemDTO _dto = new DiemDTO()
        {
            Masinhvien = "",
            Mamon = "",
            Diemchuyencan = -1,
            Diemgiuaky = -1,
            Diemcuoiky = -1
        };
        var ex = Assert.ThrowsExactly<ArgumentException>(() => _bll.SuaThongTinDiemTheoMaSinhVienVaMaMon(_dto));
        Assert.AreEqual("Bạn phải nhập mã sinh viên và mã môn trước khi sửa", ex.Message);
    }
    [TestMethod]
    public void XoaTaiKhoan_ArgumentException()
    {
        string maSinhVien = "";
        string maMon = "";
        var ex = Assert.ThrowsExactly<ArgumentException>(() => _bll.XoaThongTinDiemTheoMaSinhVienVaMaMon(maSinhVien, maMon));
        Assert.AreEqual("Bạn phải nhập mã sinh viên và mã môn trước khi xóa", ex.Message);
    }
}
