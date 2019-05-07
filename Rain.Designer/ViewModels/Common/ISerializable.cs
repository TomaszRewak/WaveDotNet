using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rain.Designer.ViewModels.Common
{
    internal interface ISerializable
    {
		dynamic Serialize();
		void Deserialize(dynamic value); 
    }
}
