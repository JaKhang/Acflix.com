﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Image
{
    public record VarientResponse
        (
        string Url,
        int Width,
        int Height
        )
    {
    }
}