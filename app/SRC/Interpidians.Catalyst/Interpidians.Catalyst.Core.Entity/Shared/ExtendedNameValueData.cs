using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Interpidians.Catalyst.Core.Entity
{
    [Serializable]
    [DataContract]
    public class ExtendedNameValueData
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Value { get; set; }

        [DataMember]
        public string Parameter { get; set; }
    }
}
