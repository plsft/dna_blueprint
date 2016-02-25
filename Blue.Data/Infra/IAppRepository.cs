using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Helix.Data;

namespace Blue.Data.Infra
{
    public interface IAppRepository : IHelixPetaRepository
    {
         void Dispose();
    }
}
