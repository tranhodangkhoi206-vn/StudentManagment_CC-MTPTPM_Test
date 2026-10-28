using StudentManagment.DAL;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data;

[TestClass]
public class Test_TracuusinhvienDAL
{
    private readonly TracuusinhvienDAL _dal = new TracuusinhvienDAL(new NullLoggerFactory());

    [TestMethod]
    public void LaySinhVienTheoDieuKienTen_VoiTenHopLe_TraVeDataTable()
    {
        var result = _dal.LaySinhVienTheoDieuKienTen("Nguyen");

        Assert.IsNotNull(result);
        Assert.IsInstanceOfType(result, typeof(DataTable));
    }

    [TestMethod]
    public void LaySinhVienTheoDieuKienLop_VoiMaLopHopLe_TraVeDataTable()
    {
        var result = _dal.LaySinhVienTheoDieuKienLop("LOP01");

        Assert.IsNotNull(result);
        Assert.IsInstanceOfType(result, typeof(DataTable));
    }

    [TestMethod]
    public void LaySinhVienTheoDieuKienNganhHoc_VoiMaNganhHopLe_TraVeDataTable()
    {
        var result = _dal.LaySinhVienTheoDieuKienNganhHoc("CNTT");

        Assert.IsNotNull(result);
        Assert.IsInstanceOfType(result, typeof(DataTable));
    }
}