using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class NoSearhResultException : Exception
    {
        public NoSearhResultException(string msg)
        : base(msg)
        {
            
        }
        public override string Message { get { return $"NoSearhResultException : {base.Message}"; } }

    }
}
