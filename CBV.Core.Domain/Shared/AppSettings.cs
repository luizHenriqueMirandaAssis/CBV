using System;
using System.Collections.Generic;
using System.Text;

namespace CBV.Core.Domain.Shared
{
    public class AppSettings
    {
        public string SecretKey { get; set; }
        public string Version { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
