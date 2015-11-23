using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace TK.CardIO.Android
{
    /// <summary>
    /// Extension methods
    /// </summary>
    internal static class Extensions
    {
        /// <summary>
        /// Converts the native Android <c>CardType</c> to the PCL <c>CardType</c>
        /// </summary>
        /// <param name="self">Native Android <c>CardType</c> instance</param>
        /// <returns>PCL <c>CardType</c></returns>
        public static CardType ToPclCardType(this Card.IO.CardType self)
        {
            switch (self.Name)
            {
                case "AMEX":
                    return CardType.Amex;
                case "DINERSCLUB":
                    return CardType.Dinersclub;
                case "DISCOVER":
                    return CardType.Discover;
                case "INSUFFICIENT_DIGITS":
                    return CardType.InsufficientDigits;
                case "JCB":
                    return CardType.JCB;
                case "MAESTRO":
                    return CardType.Maestro;
                case "MASTERCARD":
                    return CardType.Mastercard;
                case "UNKNOWN":
                    return CardType.Unknown;
                case "VISA":
                    return CardType.Visa;
                default:
                    return CardType.Unknown;
            }
        }
    }
}