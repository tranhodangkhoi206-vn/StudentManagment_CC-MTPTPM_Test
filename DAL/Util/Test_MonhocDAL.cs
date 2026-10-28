using StudentManagment.DAL.Util;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data;

[TestClass]
public class Test_MonhocDAL
{
    private readonly MonhocDAL dal = new MonhocDAL(new NullLoggerFactory());

    [TestMethod]
    public void LayToanBoMonHoc_TraVeDataTable()
    {
        var result = dal.LayToanBoMonHoc();

        Assert.IsNotNull(result);
        Assert.IsInstanceOfType(result, typeof(DataTable));
    }
}