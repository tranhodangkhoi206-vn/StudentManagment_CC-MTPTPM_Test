using StudentManagment.DAL.Util;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data;

[TestClass]
public class Test_NganhhocDAL
{
    private readonly NganhhocDAL dal = new NganhhocDAL(new NullLoggerFactory());

    [TestMethod]
    public void LayToanBoNganhHocChoComboBox_TraVeDataTable()
    {
        var result = dal.LayToanBoNganhHocChoComboBox();

        Assert.IsNotNull(result);
        Assert.IsInstanceOfType(result, typeof(DataTable));
    }

    [TestMethod]
    public void LayToanBoNganhHoc_TraVeDataTable()
    {
        var result = dal.LayToanBoNganhHoc();

        Assert.IsNotNull(result);
        Assert.IsInstanceOfType(result, typeof(DataTable));
    }
}