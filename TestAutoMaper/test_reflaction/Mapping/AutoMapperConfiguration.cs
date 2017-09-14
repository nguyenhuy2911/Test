using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_reflaction.Mapping
{
    public static class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(x =>
            {
                var profileTypes = typeof(ProfileBase).Assembly.GetTypes().Where(type => type.IsSubclassOf(typeof(ProfileBase)));
                foreach (var type in profileTypes)
                {
                    x.AddProfile((ProfileBase)Activator.CreateInstance(type));
                }
            });
        }
    }
}
