﻿using AutoMapper;
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
        protected ProfileBase(string profileName)
        {
            _profileName = profileName;
        }

        public override string ProfileName
        {
            get { return _profileName; }
        }

        //protected override void Configure()
        //{           
        //    CreateMaps();
        //}

        //protected abstract void CreateMaps();
    }
}