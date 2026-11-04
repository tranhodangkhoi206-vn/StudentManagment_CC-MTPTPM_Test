using System;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using StudentManagment.DTO;
using StudentManagment.BLL;
[TestClass]
public class QuanlylopBLLTests
{
    private QuanlylopBLL bll;

    [TestInitialize]
    public void Setup()
    {
        bll = new QuanlylopBLL(NullLoggerFactory.Instance);
    }

    // ===== TimKiemLopHoc =====
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void TimKiemLopHoc_ThieuMaLop_NemArgumentException(string maLop)
    {
        var ex = Assert.ThrowsExactly<ArgumentException>(() => bll.TimKiemLopHoc(maLop));
        Assert.AreEqual("Bạn phải nhập mã lớptrước khi tìm kiếm", ex.Message);
    }

    // ===== ThemLopHocMoi =====
    [DataTestMethod]
    [DataRow(null, "N01", "Lớp A", "GV01")]
    [DataRow("", "N01", "Lớp A", "GV01")]
    [DataRow("L01", null, "Lớp A", "GV01")]
    [DataRow("L01", "", "Lớp A", "GV01")]
    [DataRow("L01", "N01", null, "GV01")]
    [DataRow("L01", "N01", "", "GV01")]
    [DataRow("L01", "N01", "Lớp A", null)]
    [DataRow("L01", "N01", "Lớp A", "")]
    public void ThemLopHocMoi_ThieuThongTin_NemArgumentException(string maLop, string maNganh, string tenLop, string giangVien)
    {
        var lop = new LopDTO
        {
            Malop = maLop,
            Manganh = maNganh,
            Tenlop = tenLop,
            Giangvienphutrach = giangVien
        };

        var ex = Assert.ThrowsExactly<ArgumentException>(() => bll.ThemLopHocMoi(lop));
        Assert.AreEqual("Bạn phải nhập đầy đủ thông tin trước khi thêm", ex.Message);
    }

    // ===== SuaThongTinLop =====
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    public void SuaThongTinLop_ThieuMaLop_NemArgumentException(string maLop)
    {
        var lop = new LopDTO { Malop = maLop };

        var ex = Assert.ThrowsExactly<ArgumentException>(() => bll.SuaThongTinLop(lop));
        Assert.AreEqual("Bạn phải nhập mã lớptrước khi sửa", ex.Message);
    }

    // ===== XoaThongTinLop =====
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    public void XoaThongTinLop_ThieuMaLop_NemArgumentException(string maLop)
    {
        var ex = Assert.ThrowsExactly<ArgumentException>(() => bll.XoaThongTinLop(maLop));
        Assert.AreEqual("Bạn phải nhập mã lớptrước khi xóa", ex.Message);
    }
}