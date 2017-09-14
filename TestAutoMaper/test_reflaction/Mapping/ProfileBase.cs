using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using test_reflaction.modal;

namespace test_reflaction.Mapping
{
    public abstract class ProfileBase : Profile
    {
        private readonly string _profileName;
        protected ProfileBase()
        {
            _profileName = "ProfileBase";
        }

        public override string ProfileName
        {
            get { return _profileName; }
        }
    }
}
