using StudentManagment.DAL.Util;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data;

[TestClass]
public class Test_SinhvienDAL
{
    private readonly SinhvienDAL dal = new SinhvienDAL(new NullLoggerFactory());

    [TestMethod]
    public void LayToanBoSinhVien_TraVeDataTable()
    {
        var result = dal.LayToanBoSinhVien();

        Assert.IsNotNull(result);
        Assert.IsInstanceOfType(result, typeof(DataTable));
    }
}