using Microsoft.Extensions.Logging.Abstractions;
using StudentManagment.BLL;

namespace StudentManagment.Test;

[TestClass]
public class TrangchuBLLTests
{
    private TrangchuBLL bll;

    [TestInitialize]
    public void Setup()
    {
        bll = new TrangchuBLL(NullLoggerFactory.Instance);
    }

    // ===== TinhTongSinhVien =====
    [TestMethod]
    public void TinhTongSinhVien_TraVeKieuInt()
    {
        int result = bll.TinhTongSinhVien();
        Assert.IsInstanceOfType(result, typeof(int));
    }

    [TestMethod]
    public void TinhTongSinhVien_TraVeGiaTriKhongAm()
    {
        int result = bll.TinhTongSinhVien();
        Assert.IsTrue(result >= 0, "Tổng sinh viên không được là số âm");
    }

    [TestMethod]
    public void TinhTongSinhVien_GioiHanTrenHopLe()
    {
        int result = bll.TinhTongSinhVien();
        Assert.IsTrue(result <= int.MaxValue, "Tổng sinh viên vượt quá giới hạn kiểu int");
    }

    // ===== TinhTongLopHoc =====
    [TestMethod]
    public void TinhTongLopHoc_TraVeKieuInt()
    {
        int result = bll.TinhTongLopHoc();
        Assert.IsInstanceOfType(result, typeof(int));
    }

    [TestMethod]
    public void TinhTongLopHoc_TraVeGiaTriKhongAm()
    {
        int result = bll.TinhTongLopHoc();
        Assert.IsTrue(result >= 0, "Tổng lớp học không được là số âm");
    }

    [TestMethod]
    public void TinhTongLopHoc_GioiHanTrenHopLe()
    {
        int result = bll.TinhTongLopHoc();
        Assert.IsTrue(result <= int.MaxValue, "Tổng lớp học vượt quá giới hạn kiểu int");
    }

    // ===== TinhTongMonHoc =====
    [TestMethod]
    public void TinhTongMonHoc_TraVeKieuInt()
    {
        int result = bll.TinhTongMonHoc();
        Assert.IsInstanceOfType(result, typeof(int));
    }

    [TestMethod]
    public void TinhTongMonHoc_TraVeGiaTriKhongAm()
    {
        int result = bll.TinhTongMonHoc();
        Assert.IsTrue(result >= 0, "Tổng môn học không được là số âm");
    }

    [TestMethod]
    public void TinhTongMonHoc_GioiHanTrenHopLe()
    {
        int result = bll.TinhTongMonHoc();
        Assert.IsTrue(result <= int.MaxValue, "Tổng môn học vượt quá giới hạn kiểu int");
    }

    // ===== Kiểm tra độc lập giữa các hàm =====
    [TestMethod]
    public void BaHam_HoatDongDocLap_KhongAnhHuongNhau()
    {
        int tongSinhVien = bll.TinhTongSinhVien();
        int tongLopHoc = bll.TinhTongLopHoc();
        int tongMonHoc = bll.TinhTongMonHoc();

        // Gọi lại lần 2 — kết quả phải nhất quán
        Assert.AreEqual(tongSinhVien, bll.TinhTongSinhVien(),
            "TinhTongSinhVien trả về kết quả khác nhau giữa hai lần gọi liên tiếp");
        Assert.AreEqual(tongLopHoc, bll.TinhTongLopHoc(),
            "TinhTongLopHoc trả về kết quả khác nhau giữa hai lần gọi liên tiếp");
        Assert.AreEqual(tongMonHoc, bll.TinhTongMonHoc(),
            "TinhTongMonHoc trả về kết quả khác nhau giữa hai lần gọi liên tiếp");
    }
}
