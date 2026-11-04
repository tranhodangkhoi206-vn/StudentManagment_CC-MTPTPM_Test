using System;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using StudentManagment.DTO;
using StudentManagment.BLL;
[TestClass]
public class QuanlymonhocBLLTests
{
    private QuanlymonhocBLL bll;

    [TestInitialize]
    public void Setup()
    {
        bll = new QuanlymonhocBLL(NullLoggerFactory.Instance);
    }

    // ===== ThemmonhocMoi =====
    [DataTestMethod]
    [DataRow(null, "N01", "Toán", "Đang mở", "GV01")]
    [DataRow("", "N01", "Toán", "Đang mở", "GV01")]
    [DataRow("MH01", null, "Toán", "Đang mở", "GV01")]
    [DataRow("MH01", "", "Toán", "Đang mở", "GV01")]
    [DataRow("MH01", "N01", null, "Đang mở", "GV01")]
    [DataRow("MH01", "N01", "", "Đang mở", "GV01")]
    [DataRow("MH01", "N01", "Toán", null, "GV01")]
    [DataRow("MH01", "N01", "Toán", "", "GV01")]
    [DataRow("MH01", "N01", "Toán", "Đang mở", null)]
    [DataRow("MH01", "N01", "Toán", "Đang mở", "")]
    public void ThemmonhocMoi_ThieuThongTin_NemArgumentException(string maMon, string maNganh, string tenMon, string tinhTrang, string giangVien)
    {
        var monHoc = new MonhocDTO
        {
            Mamon = maMon,
            Manganh = maNganh,
            Tenmon = tenMon,
            Tinhtrang = tinhTrang,
            Giangvien = giangVien
        };

        var ex = Assert.ThrowsExactly<ArgumentException>(() => bll.ThemmonhocMoi(monHoc));
        Assert.AreEqual("Bạn phải nhập đầy đủ thông tin trước khi thêm", ex.Message);
    }

    // ===== SuaMonHocTheoMaMonHoc =====
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    public void SuaMonHocTheoMaMonHoc_ThieuMaMon_NemArgumentException(string maMon)
    {
        var monHoc = new MonhocDTO { Mamon = maMon };

        var ex = Assert.ThrowsExactly<ArgumentException>(() => bll.SuaMonHocTheoMaMonHoc(monHoc));
        Assert.AreEqual("Bạn phải nhập mã môn học trước khi sửa", ex.Message);
    }

    // ===== XoaMonHocTheoMaMonHoc =====
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    public void XoaMonHocTheoMaMonHoc_ThieuMaMon_NemArgumentException(string maMon)
    {
        var ex = Assert.ThrowsExactly<ArgumentException>(() => bll.XoaMonHocTheoMaMonHoc(maMon));
        Assert.AreEqual("Bạn phải nhập mã môn học trước khi xóa", ex.Message);
    }

    // ===== TimKiemMonHocTheoMaMon =====
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    public void TimKiemMonHocTheoMaMon_ThieuMaMon_NemArgumentException(string maMon)
    {
        var ex = Assert.ThrowsExactly<ArgumentException>(() => bll.TimKiemMonHocTheoMaMon(maMon));
        Assert.AreEqual("Bạn phải nhập mã môn học trước khi tìm kiếm", ex.Message);
    }
}