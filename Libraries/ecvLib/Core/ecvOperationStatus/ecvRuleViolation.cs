namespace ecvLib.Core.ecvOperationStatus
{
    public partial class ecvRuleViolation
    {
        public string _propertyName { get; private set; }
        public object _propertyValue { get; private set; }
        public string _errorMessage { get; private set; }

        public ecvRuleViolation(string PropertyName, object PropertyValue, string ErrorMessage)
        {
            _propertyName = PropertyName;
            _propertyValue = PropertyValue;
            _errorMessage = ErrorMessage;
        }        
    }
}
