using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DotNetDesign.WebSecurity
{
    public partial class UserData
    {
        /// <summary>
        /// Gets or sets the password salt.
        /// </summary>
        /// <value>The password salt.</value>
        [JsonIgnore]
        [XmlIgnore]
        protected internal byte[] PasswordSalt { get; set; }

        /// <summary>
        /// Gets or sets the password hash.
        /// </summary>
        /// <value>The password hash.</value>
        [JsonIgnore]
        [XmlIgnore]
        protected internal byte[] PasswordHash { get; set; }
    }
}
