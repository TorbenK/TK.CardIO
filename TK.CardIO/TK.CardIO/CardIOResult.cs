using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TK.CardIO
{
    /// <summary>
    /// Resultset of the Card.IO scanning process
    /// </summary>
    public class CardIOResult
    {
        /// <summary>
        /// Gets/Sets if the scan was successfull
        /// </summary>
        public bool Success { get; set; }
        /// <summary>
        /// Gets/Sets the credit card number
        /// </summary>
        public string CardNumber { get; set; }
        /// <summary>
        /// Gets/Sets the expiration date
        /// </summary>
        public DateTime Expiry { get; set; }
        /// <summary>
        /// Gets/Sets the CVV
        /// </summary>
        public string Cvv { get; set; }
        /// <summary>
        /// Gets/Sets the postal code
        /// </summary>
        public string PostalCode { get; set; }
    }
}
