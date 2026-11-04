using System;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using StudentManagment.DTO;
using StudentManagment.BLL;
[TestClass]
public class QuanlysinhvienBLLTests
{
    private QuanlysinhvienBLL bll;

    [TestInitialize]
    public void Setup()
    {
        bll = new QuanlysinhvienBLL(NullLoggerFactory.Instance);
    }

    // ===== ThemsinhvienMoi =====
    [DataTestMethod]
    [DataRow(null, "SV01", "L01", "N01", "Nam", "Đang học")]
    [DataRow("", "SV01", "L01", "N01", "Nam", "Đang học")]
    [DataRow("Nguyễn Văn A", null, "L01", "N01", "Nam", "Đang học")]
    [DataRow("Nguyễn Văn A", "", "L01", "N01", "Nam", "Đang học")]
    [DataRow("Nguyễn Văn A", "SV01", null, "N01", "Nam", "Đang học")]
    [DataRow("Nguyễn Văn A", "SV01", "", "N01", "Nam", "Đang học")]
    [DataRow("Nguyễn Văn A", "SV01", "L01", null, "Nam", "Đang học")]
    [DataRow("Nguyễn Văn A", "SV01", "L01", "", "Nam", "Đang học")]
    [DataRow("Nguyễn Văn A", "SV01", "L01", "N01", null, "Đang học")]
    [DataRow("Nguyễn Văn A", "SV01", "L01", "N01", "", "Đang học")]
    [DataRow("Nguyễn Văn A", "SV01", "L01", "N01", "Nam", null)]
    [DataRow("Nguyễn Văn A", "SV01", "L01", "N01", "Nam", "")]
    public void ThemsinhvienMoi_ThieuThongTin_NemArgumentException(string hoVaTen, string maSv, string maLop, string maNganh, string gioiTinh, string tinhTrang)
    {
        var sinhVien = new SinhvienDTO
        {
            HoVaTen = hoVaTen,
            MaSinhVien = maSv,
            MaLop = maLop,
            MaNganh = maNganh,
            GioiTinh = gioiTinh,
            TinhTrang = tinhTrang
        };

        var ex = Assert.ThrowsExactly<ArgumentException>(() => bll.ThemsinhvienMoi(sinhVien));
        Assert.AreEqual("Bạn phải nhập đầy đủ thông tin trước khi thêm", ex.Message);
    }

    // ===== SuaSinhVienTheoMaSinhVien =====
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    public void SuaSinhVienTheoMaSinhVien_ThieuMaSinhVien_NemArgumentException(string maSv)
    {
        var sinhVien = new SinhvienDTO { MaSinhVien = maSv };

        var ex = Assert.ThrowsExactly<ArgumentException>(() => bll.SuaSinhVienTheoMaSinhVien(sinhVien));
        Assert.AreEqual("Bạn phải nhập mã sinh viên trước khi sửa", ex.Message);
    }

    // ===== XoaSinhVienTheoMaSinhVien =====
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    public void XoaSinhVienTheoMaSinhVien_ThieuMaSinhVien_NemArgumentException(string maSv)
    {
        var ex = Assert.ThrowsExactly<ArgumentException>(() => bll.XoaSinhVienTheoMaSinhVien(maSv));
        Assert.AreEqual("Bạn phải nhập mã sinh viên trước khi xóa", ex.Message);
    }

    // ===== TimKiemSinhVien =====
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    public void TimKiemSinhVien_ThieuMaSinhVien_NemArgumentException(string maSv)
    {
        var ex = Assert.ThrowsExactly<ArgumentException>(() => bll.TimKiemSinhVien(maSv));
        Assert.AreEqual("Bạn phải nhập mã sinh viên trước khi tìm kiếm", ex.Message);
    }
}