using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecvLib.Core.ecvFunctions
{
    public static class ecvFunctionsCommon
    {

        public static bool isNumber(object ecvExpression)
        {
            bool _isNumber = false;
            Int64 n;
            try
            {
                _isNumber = Int64.TryParse(ecvExpression.ToString(), out n);
            }
            catch
            {
                _isNumber = false;
            }
            return _isNumber;
        }

        public static bool stringHasOnlyNumber(object ecvExpression, char delimiter=' ')
        {
            bool _stringHasOnlyNumber = false;

            try
            {
                if (string.IsNullOrEmpty(delimiter.ToString()) || string.IsNullOrWhiteSpace(delimiter.ToString()))
                {
                    _stringHasOnlyNumber = isNumber(ecvExpression);                    
                }
                else //check all elements
                {
                    Int64[] _int64Array = Array.ConvertAll<string, Int64>(ecvExpression.ToString().Split(delimiter), Int64.Parse);
                    _stringHasOnlyNumber = true;
                }
            }
            catch
            {
                _stringHasOnlyNumber = false;
            }
            return _stringHasOnlyNumber;
        }

    }// End of -- public class ecvFunctionsCommon
}
