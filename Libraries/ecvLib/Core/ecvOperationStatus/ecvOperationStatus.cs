using System.Collections.Generic;

namespace ecvLib.Core.ecvOperationStatus
{
    public partial class ecvOperationStatus
    {

        public OperationType? operationType { get; set; }
        public OperationStatus? operationStatus { get; set; }
        public string OperationMessage { get; set; }
        public List<ecvRuleViolation> ecvRuleViolation { get; set; }

        //public ecvOperationStatus(OperationType? operationType, OperationStatus? operationStatus, string OperationMessage, List<ecvRuleViolation> ecvRuleViolation)
        //{
        //    _operationType = operationType;
        //    _operationStatus = operationStatus;
        //    _OperationMessage = OperationMessage;
        //    _ecvRuleViolation = ecvRuleViolation;
        //}

        public enum OperationType
        {
            New
            , Edit
            , Detail
            , Delete
        }

        public enum OperationStatus
        {
            Success
           , Error
        }


    }// End of -- public partial class ecvErrorEntity
}
