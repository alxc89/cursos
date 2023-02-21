using UtmBuilder.Core.ValueObjects.Exceptions;

namespace UtmBuilder.Core.ValueObjects
{
    public class Campaign : ValueObject
    {
        /// <summary>
        /// Generate a new campaing for a URL
        /// </summary>
        /// <param name="source">The referrer (e.g. google, newsletter</param>
        /// <param name="medium">Marketin medium (e.g. cpc, banner, email)</param>
        /// <param name="name">Product, promo code, or slogan(e.g. spring_sale)</param>
        /// <param name="id">The ads campaing id.</param>
        /// <param name="term">Identify the paid keyword</param>
        /// <param name="content">Use to differentiate adds</param>
        public Campaign(string source, string medium, string name, string? id = null, string? term = null, string? content = null)
        {
            Source = source;
            Medium = medium;
            Name = name;
            Id = id;
            Term = term;
            Content = content;

            InvalidCampaignException.ThrowIfNull(source, "Source is invalid");
            InvalidCampaignException.ThrowIfNull(medium, "Medium is invalid");
            InvalidCampaignException.ThrowIfNull(name, "Name is invalid");
        }
        /// <summary>
        /// The adds campaign id.
        /// </summary>
        public string? Id { get; set; }
        /// <summary>
        /// The referre (e.g. google, newsletter)
        /// </summary>
        public string Source { get; }
        /// <summary>
        /// Marketing medium (e.g. cpc, banner, email)
        /// </summary>
        public string Medium { get; }
        /// <summary>
        /// Promo code, or slogan (e.g. spring_sale)
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// Identify the paid keywords
        /// </summary>
        public string? Term { get; set; }
        /// <summary>
        /// Use to differentiate adds
        /// </summary>
        public string? Content { get; set; }
    }
}
