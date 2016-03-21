using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace SensorNetwork.Misc
{
    public abstract class EntityMigrator
    {
        internal abstract void DefineEntityParameters(ModelBuilder builder);
    }
}
