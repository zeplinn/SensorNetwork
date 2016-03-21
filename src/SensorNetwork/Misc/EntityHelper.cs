using Microsoft.AspNet.Hosting.Internal;
using Microsoft.Data.Entity;
using System;
using System.Linq;
using System.Reflection;

namespace SensorNetwork.Misc
{
    public class EntityHelper
    {
        private static readonly EntityHelper _self = new EntityHelper();

        private EntityHelper()
        {
        }

        internal static void CreateEntities(ModelBuilder builder, string assemblyName, string nameSpace)
        {
            var assembly = Assembly.Load(new AssemblyName(assemblyName));
            
            var migEntity = typeof(EntityMigrator);
            foreach( var t in assembly.GetTypes()
                .Where(
                    n => String.Equals(n.Namespace, nameSpace)
                    && migEntity.IsAssignableFrom(n)
                    && !string.Equals(migEntity.Name, n.Name)
                 ))
            {
                Console.WriteLine(t);
            }
            var entities = assembly.GetTypes().Where(
                    n => String.Equals(n.Namespace, nameSpace)
                    && migEntity.IsAssignableFrom(n)
                    && !string.Equals(migEntity.Name, n.Name)
                 );
            if (entities.Count()<1)
            {
                throw new OperationCanceledException($"No such namespace exists: {nameSpace}");
            }
            foreach (var entity in entities)
            {
                if (Activator.CreateInstance(entity)==null)
                {
                    throw new ReflectionTypeLoadException(new Type[] { entity }
                    , new Exception[] { new InvalidOperationException() }
                    , $"Class do not have a genereic constructor: {entity}");
                }
            }
            foreach (Type e in entities)
            {

                var entity = Activator.CreateInstance(e) as EntityMigrator;
                entity.DefineEntityParameters(builder);
            }
        }
    }
}