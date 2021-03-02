using System;

namespace Module2_Task5.Services
{
    public class BusinessException : Exception
    {
        public BusinessException()
        {
        }

        public BusinessException(string name)
            : base(string.Format("Action failed by reason:", name))
        {
        }
    }
}
