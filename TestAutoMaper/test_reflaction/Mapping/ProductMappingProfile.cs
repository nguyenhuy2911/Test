﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using test_reflaction.modal;

namespace test_reflaction.Mapping
{
    public class ProductMappingProfile : ProfileBase
    {
        public ProductMappingProfile()
        {
            CreateMap<Product, Product_DTO>();
        }
    }
}
