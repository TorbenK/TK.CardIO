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
        Task<CardIOResult> Scan(CardIOConfig config = null);
    }
}
