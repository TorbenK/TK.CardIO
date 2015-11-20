using TK.CardIO;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using TK.CardIO.Android;
using Card.IO;

[assembly: Dependency(typeof(TK.CardIO.Android.CardIO))]

namespace TK.CardIO.Android
{
    /// <summary>
    /// Android implementation of the PayPal CardIO plugin
    /// </summary>
    public class CardIO : ICardIO
    {
        private const int ScanActivityResultCode = 362814;

        private static CardIO _currentScan;

        private CardIOResult _result;
        private bool _finished;

        /// <summary>
        /// Forwards <c>OnActivityResult</c> to the <c>CardIO</c> plugin. This is a must!
        /// </summary>
        /// <param name="requestCode">Request code</param>
        /// <param name="resultCode">Result code</param>
        /// <param name="data">Intent data</param>
        public static void ForwardActivityResult(int requestCode, Result resultCode, Intent data)
        {
            if (requestCode == ScanActivityResultCode)
            {
                if (data != null && data.HasExtra(CardIOActivity.ExtraScanResult))
                {
                    CreditCard scanResult = (CreditCard)data.GetParcelableExtra(CardIOActivity.ExtraScanResult);

                    _currentScan._result = new CardIOResult
                    {
                        CardNumber = scanResult.CardNumber,
                        Cvv = scanResult.Cvv,
                        Expiry = new DateTime(scanResult.ExpiryYear, scanResult.ExpiryMonth, 1),
                        PostalCode = scanResult.PostalCode,
                        Success = true
                    };
                }
                else
                    _currentScan._result = new CardIOResult { Success = false };

                _currentScan._finished = true;
            }
        }
        /// <inheritdoc/>
        public async Task<CardIOResult> Scan(CardIOConfig config = null)
        {
            if (config == null) config = new CardIOConfig();

            _currentScan = this;

            var formsActivity = (Activity)Forms.Context;
            if (formsActivity == null) throw new InvalidOperationException("No Activity found!");

            Intent scanIntent = new Intent(formsActivity, typeof(CardIOActivity));

            scanIntent.PutExtra(CardIOActivity.ExtraRequireExpiry, config.RequireExpiry);
            scanIntent.PutExtra(CardIOActivity.ExtraRequireCvv, config.RequireCvv);
            scanIntent.PutExtra(CardIOActivity.ExtraRequirePostalCode, config.RequirePostalCode);
            scanIntent.PutExtra(CardIOActivity.ExtraUsePaypalActionbarIcon, config.ShowPaypalLogo);

            if (!string.IsNullOrEmpty(config.ScanInstructions))
                scanIntent.PutExtra(CardIOActivity.ExtraScanInstructions, config.ScanInstructions);
            if (!string.IsNullOrEmpty(config.Localization))
                scanIntent.PutExtra(CardIOActivity.ExtraLanguageOrLocale, config.Localization);

            Device.BeginInvokeOnMainThread(() =>
            {
                formsActivity.StartActivityForResult(scanIntent, ScanActivityResultCode);
            });

            while (!this._finished) await Task.Delay(100);

            return this._result;
        }
    }
}