using System;
using System.Runtime.Serialization;

namespace Novus.Payer1060.BusinessObjects.Utilities
{
    [Serializable]
    public class HighErrorRateException : Exception
    {
        public HighErrorRateException()
        {
        }
        public HighErrorRateException(string message) : base(message)
        {
        }
        public HighErrorRateException(string message, Exception inner) : base(message, inner)
        {
        }
        protected HighErrorRateException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }

    [Serializable]
    public class PayerException : Exception
    {
        public PayerException()
        {
        }
        public PayerException(string message) : base(message)
        {
        }
        public PayerException(string message, Exception inner) : base(message, inner)
        {
        }
        protected PayerException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }

    public static class ExceptionUtilities
    {
        public static void CountChecker(string parentName, int masterCount, int successCount, int exceptionCount, int intCheckNumRows = 1000)
        {
            if (masterCount > 0 && (masterCount % intCheckNumRows == 0) && (exceptionCount > successCount))
            {
                throw new HighErrorRateException("Hold up... " + parentName +
                    " has an unexpected high volume of exceptions being written. Total Count: " + masterCount +
                    ", Successful Count: " + successCount + ", Exception Count: " + exceptionCount);
            }
        }
    }
}
