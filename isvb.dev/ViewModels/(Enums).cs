using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isvb.dev.ViewModels
{
    namespace Enums
    {
        public enum Role
        {
            Administrator=100,
            Owner=50,
            Customer=2,
            Guest=1
        }
        public enum FileType
        {
            Cover=1,
            Slide=2
        }
    }
}
