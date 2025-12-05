using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.NET
{
    public class FormatFichierIncorrectException : Exception
    {
        public FormatFichierIncorrectException(string message)
            : base(message)
        {
        }
    }
}
