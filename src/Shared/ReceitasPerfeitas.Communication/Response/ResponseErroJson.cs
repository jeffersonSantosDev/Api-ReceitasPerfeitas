using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReceitasPerfeitas.Communication.Response
{
    public class ResponseErroJson
    {
        public IList<string> Errors { get; set; }

        public ResponseErroJson(IList<string> errors) => Errors = errors;

        public ResponseErroJson(string error)
        {
            Errors = new List<string>
            {
                error
            };
        }

    }
}
