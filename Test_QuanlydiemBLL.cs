using System;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudentManagment.BLL;

using StudentManagment.DTO;
[TestClass]
public class QuanlydiemBLLTests
{
    private QuanlydiemBLL bll;

    [TestInitialize]
    public void Setup()
    {
        bll = new QuanlydiemBLL(NullLoggerFactory.Instance);
    }

    // ===== ThemDiemMoi =====
    [DataTestMethod]
    [DataRow(null, "SV01", 8.0, 7.0, 9.0)]
    [DataRow("", "SV01", 8.0, 7.0, 9.0)]
    [DataRow("MH01", null, 8.0, 7.0, 9.0)]
    [DataRow("MH01", "", 8.0, 7.0, 9.0)]
    [DataRow("MH01", "SV01", -1.0, 7.0, 9.0)]
    [DataRow("MH01", "SV01", 8.0, -1.0, 9.0)]
    [DataRow("MH01", "SV01", 8.0, 7.0, -1.0)]
    public void ThemDiemMoi_ThieuThongTin_NemArgumentException(string maMon, string maSv, double cc, double gk, double ck)
    {
        var diem = new DiemDTO
        {
            Mamon = maMon,
            Masinhvien = maSv,
            Diemchuyencan = cc,
            Diemgiuaky = gk,
            Diemcuoiky = ck
        };

        var ex = Assert.ThrowsExactly<ArgumentException>(() => bll.ThemDiemMoi(diem));
        Assert.AreEqual("Bạn phải nhập đầy đủ thông tin trước khi thêm", ex.Message);
    }

    // ===== SuaThongTinDiemTheoMaSinhVienVaMaMon =====
    [DataTestMethod]
    [DataRow(null, "SV01")]
    [DataRow("", "SV01")]
    [DataRow("MH01", null)]
    [DataRow("MH01", "")]
    public void SuaThongTinDiem_ThieuMaMonHoacMaSinhVien_NemArgumentException(string maMon, string maSv)
    {
        var diem = new DiemDTO { Mamon = maMon, Masinhvien = maSv };

        var ex = Assert.ThrowsExactly<ArgumentException>(() => bll.SuaThongTinDiemTheoMaSinhVienVaMaMon(diem));
        Assert.AreEqual("Bạn phải nhập mã sinh viên và mã môn trước khi sửa", ex.Message);
    }

    // ===== XoaThongTinDiemTheoMaSinhVienVaMaMon =====
    [DataTestMethod]
    [DataRow(null, "MH01")]
    [DataRow("", "MH01")]
    [DataRow("SV01", null)]
    [DataRow("SV01", "")]
    public void XoaThongTinDiem_ThieuMaSinhVienHoacMaMon_NemArgumentException(string maSv, string maMon)
    {
        var ex = Assert.ThrowsExactly<ArgumentException>(() => bll.XoaThongTinDiemTheoMaSinhVienVaMaMon(maSv, maMon));
        Assert.AreEqual("Bạn phải nhập mã sinh viên và mã môn trước khi xóa", ex.Message);
    }

    // ===== TimKiemDiemTheoMaSinhVienVaMaMon =====
    [DataTestMethod]
    [DataRow(null, "MH01")]
    [DataRow("", "MH01")]
    [DataRow("SV01", null)]
    [DataRow("SV01", "")]
    public void TimKiemDiem_ThieuMaSinhVienHoacMaMon_NemArgumentException(string maSv, string maMon)
    {
        var ex = Assert.ThrowsExactly<ArgumentException>(() => bll.TimKiemDiemTheoMaSinhVienVaMaMon(maSv, maMon));
        Assert.AreEqual("Bạn phải nhập mã sinh viên và mã môn trước khi tìm kiếm", ex.Message);
    }

    // ===== TinhDiemTongVaHienThi =====
    [DataTestMethod]
    [DataRow("9", "9", "9", 9.0)]
    [DataRow("8", "7", "8", 7.7)]
    [DataRow("10", "0", "5", 5.0)]
    public void TinhDiemTong_DuLieuHopLe_TraVeDiemTrungBinhLamTronMotChuSo(string cc, string gk, string ck, double expected)
    {
        Assert.AreEqual(expected, bll.TinhDiemTongVaHienThi(cc, gk, ck), 0.0001);
    }

    [DataTestMethod]
    [DataRow(null, "8", "9")]
    [DataRow("8", null, "9")]
    [DataRow("8", "9", null)]
    [DataRow("", "8", "9")]
    [DataRow("8", "", "9")]
    [DataRow("8", "9", "")]
    public void TinhDiemTong_ThieuDiem_TraVeKhong(string cc, string gk, string ck)
    {
        Assert.AreEqual(0, bll.TinhDiemTongVaHienThi(cc, gk, ck), 0.0001);
    }
}