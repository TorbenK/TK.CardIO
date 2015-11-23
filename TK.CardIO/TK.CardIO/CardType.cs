using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TK.CardIO
{
    /// <summary>
    /// Wrapper enum for the native <c>CreditCardType</c>
    /// </summary>
    public enum CardType
    {
        Ambiguous,
        Amex,
        Discover,
        JCB,
        Mastercard,
        Unrecognized,
        Visa,
        Dinersclub,
        InsufficientDigits,
        Maestro,
        Unknown
    }
}
