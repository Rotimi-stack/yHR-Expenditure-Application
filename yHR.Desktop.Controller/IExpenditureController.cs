using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yHR.Common.Data;

namespace yHR.Desktop.Controller
{
    public interface IExpenditureController
    {
        bool Save(Expenditures data);
        bool SaveExpType(CodeExpType data);
        bool SaveExpSubType(CodeExpSubType data);
        bool UpdateExpType(CodeExpType data);
        bool UpdateExpSubType(CodeExpSubType data);
    }
}
