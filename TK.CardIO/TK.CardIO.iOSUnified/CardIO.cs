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
        private CardIOPaymentViewController _paymentViewController;

        private bool _disposed;
        private CardIOResult _result;
        private bool _finished;

        /// <summary>
        /// Creates a new instance of <c>CardIO</c>
        /// </summary>
        public CardIO()
        {
            this._paymentViewController = new CardIOPaymentViewController(this);
        }
        /// <inheritdoc/>
        public async Task<CardIOResult> Scan(CardIOConfig config = null)
        {
            this._result = null;
            this._finished = false;

            this._paymentViewController.CollectExpiry = config.RequireExpiry;
            this._paymentViewController.CollectCVV = config.RequireCvv;
            this._paymentViewController.CollectPostalCode = config.RequirePostalCode;
            this._paymentViewController.UseCardIOLogo = config.ShowPaypalLogo;

            if (!string.IsNullOrEmpty(config.ScanInstructions))
                this._paymentViewController.ScanInstructions = config.ScanInstructions;
            if (!string.IsNullOrEmpty(config.Localization))
                this._paymentViewController.LanguageOrLocale = config.Localization;

            this._paymentViewController.ScanInstructions = config.ScanInstructions;

            Device.BeginInvokeOnMainThread(() => 
            {
                UIApplication.SharedApplication.KeyWindow.RootViewController.PresentViewController(
                    this._paymentViewController,
                    true,
                    null);
            });

            while (!this._finished) await Task.Delay(100);

            return this._result;
        }
        /// <inheritdoc/>
        public void UserDidCancelPaymentViewController(CardIOPaymentViewController paymentViewController)
        {
            this._result = new CardIOResult() { Success = false };
            this._finished = true;
        }
        /// <inheritdoc/>
        public void UserDidProvideCreditCardInfo(CreditCardInfo cardInfo, CardIOPaymentViewController paymentViewController)
        {
            this._result = new CardIOResult 
            {
                CreditCardType = cardInfo.CardType.ToPclCardType(),
                CardNumber = cardInfo.CardNumber,
                Cvv = cardInfo.Cvv,
                Expiry = new DateTime((int)cardInfo.ExpiryYear, (int)cardInfo.ExpiryMonth, 1),
                PostalCode = cardInfo.PostalCode,
                Success = true
            };
            this._finished = true;
        }
        /// <inheritdoc/>
        public IntPtr Handle
        {
            get { return this._paymentViewController.Handle; }
        }
        /// <inheritdoc/>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }
        /// <summary>
        /// Diposes the <c>CardIOPaymentViewController</c>
        /// </summary>
        /// <param name="disposing">Should be disposed</param>
        protected virtual void Dispose(bool disposing)
        {
            if (this._disposed) return;

            if (disposing)
                this._paymentViewController.Dispose();

            this._disposed = true;
        }
    }
}
