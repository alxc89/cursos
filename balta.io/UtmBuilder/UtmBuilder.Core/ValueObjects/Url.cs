using UtmBuilder.Core.ValueObjects.Exceptions;

namespace UtmBuilder.Core.ValueObjects
{
    public class Url : ValueObject
    {
        /// <summary>
        /// Create a new URL
        /// </summary>
        /// <param name="address">Address of URL (Website Link)</param>
        public Url(string address)
        {
            Address = address;
            InvalidUrlException.ThrowIfInvalid(address);
        }

        /// <summary>
        /// Address of URL (Website Link)
        /// </summary>
        public string Address { get; }
    }
}
