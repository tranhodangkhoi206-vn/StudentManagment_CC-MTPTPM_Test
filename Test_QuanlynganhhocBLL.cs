using System;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using StudentManagment.DTO;
using StudentManagment.BLL;
[TestClass]
public class QuanlynganhhocBLLTests
{
    private QuanlynganhhocBLL bll;

    [TestInitialize]
    public void Setup()
    {
        bll = new QuanlynganhhocBLL(NullLoggerFactory.Instance);
    }

    // ===== ThemNganhMoi =====
    [DataTestMethod]
    [DataRow(null, "CNTT", "Khoa CNTT")]
    [DataRow("", "CNTT", "Khoa CNTT")]
    [DataRow("N01", null, "Khoa CNTT")]
    [DataRow("N01", "", "Khoa CNTT")]
    [DataRow("N01", "CNTT", null)]
    [DataRow("N01", "CNTT", "")]
    public void ThemNganhMoi_ThieuThongTin_NemArgumentException(string maNganh, string tenNganh, string khoaQuanLy)
    {
        var nganh = new NganhhocDTO
        {
            Manganh = maNganh,
            Tennganh = tenNganh,
            Khoaquanly = khoaQuanLy
        };

        var ex = Assert.ThrowsExactly<ArgumentException>(() => bll.ThemNganhMoi(nganh));
        Assert.AreEqual("Bạn phải nhập đầy đủ thông tin trước khi thêm", ex.Message);
    }

    // ===== SuaThongTinNganhTheoMaNganh =====
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    public void SuaThongTinNganhTheoMaNganh_ThieuMaNganh_NemArgumentException(string maNganh)
    {
        var nganh = new NganhhocDTO { Manganh = maNganh };

        var ex = Assert.ThrowsExactly<ArgumentException>(() => bll.SuaThongTinNganhTheoMaNganh(nganh));
        Assert.AreEqual("Bạn phải nhập mã ngành trước khi sửa", ex.Message);
    }

    // ===== XoaThongTinNganhTheoMaNganh =====
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    public void XoaThongTinNganhTheoMaNganh_ThieuMaNganh_NemArgumentException(string maNganh)
    {
        var ex = Assert.ThrowsExactly<ArgumentException>(() => bll.XoaThongTinNganhTheoMaNganh(maNganh));
        Assert.AreEqual("Bạn phải nhập mã ngành trước khi xóa", ex.Message);
    }

    // ===== TimKiemNganhHoc =====
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    public void TimKiemNganhHoc_ThieuMaNganh_NemArgumentException(string maNganh)
    {
        var ex = Assert.ThrowsExactly<ArgumentException>(() => bll.TimKiemNganhHoc(maNganh));
        Assert.AreEqual("Bạn phải nhập mã ngành trước khi tìm kiếm", ex.Message);
    }
}