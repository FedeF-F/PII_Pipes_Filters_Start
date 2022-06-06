using System;
using TwitterUCU;

namespace CompAndDel.Filters
{
    /// <summary>
    /// Un filtro que recibe una imagen y la publica en twitter.
    /// </remarks>
    public class PublicarTwitter : IFilter
    {
        /// Un filtro que publica una imagen en twitter.
        /// </summary>
        /// <param name="image">La imagen a publicar.</param>
        /// <returns>La imagen recibida.</returns>
        public IPicture Filter(IPicture image)
        {
            var twitter = new TwitterImage();

            PictureProvider provider = new PictureProvider();
            provider.SavePicture(image, @"imageToPublic.jpg");
            Console.WriteLine(twitter.PublishToTwitter("Test",@"imageToPublic.jpg"));
            return image;
        }
    }
}