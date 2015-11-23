using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TK.CardIO
{
    /// <summary>
    /// Interface for the implementation of the PayPal Card.IO plugin
    /// </summary>
    public interface ICardIO
    {
        /// <summary>
        /// Starts a credit card scan
        /// </summary>
        /// <param name="config">Optional configurations</param>
        /// <returns>Result of the scan process</returns>
        Task<CardIOResult> Scan(CardIOConfig config = null);
    }
}
