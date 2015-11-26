using System;
using System.Threading.Tasks;
using Card.IO;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(TK.CardIO.iOSUnified.CardIO))]

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

        /// <inheritdoc/>
        public async Task<CardIOResult> Scan(CardIOConfig config = null)
        {
            if(this._paymentViewController == null)
                this._paymentViewController = new CardIOPaymentViewController();
            
            if (config == null) config = new CardIOConfig();

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

            if(!string.IsNullOrEmpty(config.ScanInstructions))
                this._paymentViewController.ScanInstructions = config.ScanInstructions;

            Device.BeginInvokeOnMainThread(() => 
            {
                var window= UIApplication.SharedApplication.KeyWindow;
                var vc = window.RootViewController;
                while (vc.PresentedViewController != null)
                {
                    vc = vc.PresentedViewController;
                }

                vc.PresentViewController(
                    this._paymentViewController,
                    true,
                    null);
            });

            while (!this._finished) await Task.Delay(100);

            return this._result;
        }
        /// <summary>
        /// Just to prevent the linker from removing the assembly on iOS
        /// </summary>
        public static void Init()
        { }
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
            get { return this._paymentViewController == null ? IntPtr.Zero : this._paymentViewController.Handle; }
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
