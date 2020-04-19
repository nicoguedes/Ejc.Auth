using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ejc.Common
{
    public class IsoDateConverter : IsoDateTimeConverter
    {
        public IsoDateConverter() =>
            this.DateTimeFormat = Culture.DateTimeFormat.ShortDatePattern;
    }
}
