﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCFileUpload.Models
{
    public class FileUploadResult
    {
        public string Name { get; set; }
        public int Length { get; set; }
        public string Type { get; set; }
    }
}