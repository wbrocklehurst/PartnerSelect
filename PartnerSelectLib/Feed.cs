using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace PartnerSelectLib
{
    [DataContract]
    public class Feed
    {
        #region Data Members

        [DataMember]
        public List<Feed> FeedContainer { get; set; }

        [DataMember]
        public string Title { get; set; }

        #endregion
    }

}
