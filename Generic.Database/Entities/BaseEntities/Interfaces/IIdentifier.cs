using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic.Database.Entities.BaseEntities.Interfaces
{
    public interface IIdentifier
    {
        Guid Identifier { get; set; }
    }
}
