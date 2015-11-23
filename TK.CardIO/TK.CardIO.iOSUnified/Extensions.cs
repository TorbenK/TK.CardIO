using System;
using System.Collections.Generic;
using System.Text;

namespace TK.CardIO.iOSUnified
{
    /// <summary>
    /// Extension methods
    /// </summary>
    internal static class Extensions
    {
        /// <summary>
        /// Converts the native iOS <c>CreditCardType</c> to the PCL <c>CardType</c>
        /// </summary>
        /// <param name="self">Native iOS <c>CreditCardType</c> enum</param>
        /// <returns>PCL <c>CardType</c></returns>
        public static CardType ToPclCardType(this Card.IO.CreditCardType self)
        {
            switch (self)
            {
                case Card.IO.CreditCardType.Ambiguous:
                    return CardType.Ambiguous;
                case Card.IO.CreditCardType.Amex:
                    return CardType.Amex;
                case Card.IO.CreditCardType.Discover:
                    return CardType.Discover;
                case Card.IO.CreditCardType.JCB:
                    return CardType.JCB;
                case Card.IO.CreditCardType.Mastercard:
                    return CardType.Mastercard;
                case Card.IO.CreditCardType.Unrecognized:
                    return CardType.Unrecognized;
                case Card.IO.CreditCardType.Visa:
                    return CardType.Visa;
                default:
                    return CardType.Unknown;
            }
        }
    }
}
