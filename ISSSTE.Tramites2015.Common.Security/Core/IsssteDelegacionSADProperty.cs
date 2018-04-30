using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISSSTE.Tramites2015.Common.Security.Core
{
    /// <summary>
    /// Delegaciones SAD y UPS asociadas
    /// </summary>
    /// 
    public class IsssteDelegacionSADProperty
    {
        public IsssteDelegacionSADProperty()
        {
            UPS = new List<IsssteUserProperty>();
        }
        public int IdDelegationSAD { get; set; }

        public string DelegationName { get; set; }

        public List<IsssteUserProperty> UPS { get; set; }

    }
}
