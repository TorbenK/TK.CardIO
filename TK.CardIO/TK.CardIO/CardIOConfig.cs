using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TK.CardIO
{
    /// <summary>
    /// Class holding configuration options for the Card.IO plugin
    /// </summary>
    public class CardIOConfig
    {
        /// <summary>
        /// Gets/Sets if expiry is required
        /// </summary>
        public bool RequireExpiry { get; set; }
        /// <summary>
        /// Gets/Sets if CVV is required
        /// </summary>
        public bool RequireCvv { get; set; }
        /// <summary>
        /// Gets/Sets if postal code is required
        /// </summary>
        public bool RequirePostalCode { get; set; }

        /// <summary>
        /// Gets/Sets if the PayPal Logo should be displayed
        /// </summary>
        public bool ShowPaypalLogo { get; set; }
        /// <summary>
        /// Gets/Sets the scan instructions displayed while scanning
        /// </summary>
        public string ScanInstructions { get; set; }
        /// <summary>
        /// Gets/Sets the localization
        /// Currently supported localizations: ar,da,de,en,en_AU,en_GB,es,es_MX,fr,he,is,it,ja,ko,ms,nb,nl,pl,pt,pt_BR,ru,sv,th,tr,zh-Hans,zh-Hant,zh-Hant_TW.
        /// </summary>
        public string Localization { get; set; }
        /// <summary>
        /// Creates a new instance of <c>CardIOConfig</c>
        /// </summary>
        public CardIOConfig()
        {
            this.ShowPaypalLogo = true;
            this.RequireExpiry = true;
            this.RequireCvv = false;
            this.RequirePostalCode = false;
        }
        
    }
}
