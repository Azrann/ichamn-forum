using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ichamn.Models
{
    public interface IJobable:IComparable
    {
        int Secuence
        {
            get;
            set;
        }
        Guid Id
        {
            get;
            set;
        }

        string Type();
        Guid OfficeId();
       // string ToJson();
    }
}
