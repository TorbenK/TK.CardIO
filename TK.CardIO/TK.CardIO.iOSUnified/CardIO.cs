using TK.CardIO;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using System.Threading.Tasks;
using Card.IO;
using UIKit;

namespace TK.CardIO.iOSUnified
{
    /// <summary>
    /// iOS implementation of the <c>CardIO</c> plugin
    /// </summary>
    public class CardIO : ICardIO, ICardIOPaymentViewControllerDelegate
    {
        /// <inheritdoc/>
        public async Task<CardIOResult> Scan(CardIOConfig config = null)
        {
            // TODO
            var paymentViewController = new CardIOPaymentViewController();
            UIApplication.SharedApplication.KeyWindow.RootViewController.PresentViewController(
                paymentViewController,
                true,
                null);

            return null;
            
        }

        public void UserDidCancelPaymentViewController(CardIOPaymentViewController paymentViewController)
        {
            throw new NotImplementedException();
        }

        public void UserDidProvideCreditCardInfo(CreditCardInfo cardInfo, CardIOPaymentViewController paymentViewController)
        {
            throw new NotImplementedException();
        }

        public IntPtr Handle
        {
            get { throw new NotImplementedException(); }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
