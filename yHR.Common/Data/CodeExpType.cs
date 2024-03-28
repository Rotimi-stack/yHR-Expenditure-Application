using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yHR.Common.Data
{
    public class CodeExpType
    {
        public string Code { get; set; }
        public string Descrip { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now.Date;
    }
}
