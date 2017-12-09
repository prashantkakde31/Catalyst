using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Interpidians.Catalyst.Core.Entity
{
    [DataContract]
    [Serializable]
    public class IdentifiableData
    {

        private int? _Id;
        private long? _LId;
        private string _DTOType = string.Empty;

        /// <summary>
        /// Get and set Id
        /// </summary>
        [DataMember]
        public int? Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

        /// <summary>
        /// Get and set Long Id
        /// </summary>
        [DataMember]
        public long? LId
        {
            get { return _LId; }
            set { _LId = value; }
        }


        /// <summary>
        /// Get and set DTOType
        /// </summary>
        [DataMember]
        public string DTOType
        {
            get { return _DTOType; }
            set { _DTOType = value; }
        }

    }
}
