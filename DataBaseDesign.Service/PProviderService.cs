using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBaseDesign.Model;

namespace DataBaseDesign.Service
{
    public partial class ProviderService
    {
        public bool CreatAccount(Provider provider)
        {
            return this.Add(provider);
        }
    }
}
