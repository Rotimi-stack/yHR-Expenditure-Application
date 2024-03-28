using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yHR.Common.Data;

namespace yHR.Desktop.Controller
{
    public interface ISetUpController
    {
        List<CodeTypeData> GetCodeTable(Utility.CodeTable codeTable);
    }
}
