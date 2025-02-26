using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReceitasPerfeitas.Exceptions.ExceptionsBase
{

    public class ErroOnValidationException: ReceitasPerfeitasException
    {
        public IList<String> ErroMessages { get; set; }

        public ErroOnValidationException(IList<String> erroMessages)
        {
            ErroMessages = erroMessages;
        }
    }
}
