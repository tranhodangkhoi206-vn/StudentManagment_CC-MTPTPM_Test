using Microsoft.Extensions.Logging.Abstractions;
using StudentManagment.BLL;

namespace StudentManagment.Test;

[TestClass]
public class Test_TrangchuBLL
{
    private TrangchuBLL _bll = new TrangchuBLL(NullLoggerFactory.Instance);
    [TestMethod]
    public void TinhTongSinhVien()
    {
        Assert.AreEqual(8, _bll.TinhTongSinhVien());
    }
    public void TinhTongLopHoc()
    {
        Assert.AreEqual(6, _bll.TinhTongLopHoc());
    }
    public void TinhTongMonHoc()
    {
        Assert.AreEqual(9, _bll.TinhTongMonHoc());
    }
}
