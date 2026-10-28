using StudentManagment.DAL.Util;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data;

[TestClass]
public class Test_LopDAL
{
    private readonly LopDAL dal = new LopDAL(new NullLoggerFactory());

    [TestMethod]
    public void LayToanBoLopChoComboBox_TraVeDataTable()
    {
        var result = dal.LayToanBoLopChoComboBox();

        Assert.IsNotNull(result);
        Assert.IsInstanceOfType(result, typeof(DataTable));
    }
}