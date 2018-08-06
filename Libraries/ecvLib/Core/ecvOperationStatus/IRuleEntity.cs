using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecvLib.Core.ecvOperationStatus
{
    public interface IRuleEntity
    {
        List<ecvRuleViolation> ecvGetRuleViolations();
    }
}
