using CourseCreator.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseCreator.UI.Services
{
    public static class Utility
    {
        public static List<IContentDisplayable> GetAllContentTypes()
        {
            var types = AppDomain.CurrentDomain.GetAssemblies().SelectMany(x => x.GetTypes())
                .Where(x => typeof(IContentDisplayable).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract).ToList();

            var instances = new List<IContentDisplayable>();

            types.ForEach(x => instances.Add((IContentDisplayable)Activator.CreateInstance(x)));

            return instances;
        }
    }
}
