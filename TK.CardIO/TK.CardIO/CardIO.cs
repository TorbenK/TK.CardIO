using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TK.CardIO
{
    /// <summary>
    /// Class holding an Instance to the dependeny service of <c>ICardIO</c>
    /// </summary>
    public sealed class CardIO
    {
        private static ICardIO _instance;
        /// <summary>
        /// Gets instance of the dependency service of <c>ICardIO</c>
        /// </summary>
        public static ICardIO Instance
        {
            get
            {
                return _instance ?? (_instance = DependencyService.Get<ICardIO>());
            }
        }
    }
}
