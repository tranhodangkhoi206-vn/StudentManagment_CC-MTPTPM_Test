using StudentManagment.DAL.Util;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data;

[TestClass]
public class Test_DiemDAL
{
    private readonly DiemDAL dal = new DiemDAL(new NullLoggerFactory());

    [TestMethod]
    public void LayToanBoDiem_TraVeDataTable()
    {
        var result = dal.LayToanBoDiem();

        Assert.IsNotNull(result);
        Assert.IsInstanceOfType(result, typeof(DataTable));
    }
}