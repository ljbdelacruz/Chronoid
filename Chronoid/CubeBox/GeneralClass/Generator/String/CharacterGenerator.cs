using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralClass.Generator.String
{
    public static class CharacterGenerator
    {
        public static string NewGUID() {
            return Guid.NewGuid().ToString();
        }

    }
}
