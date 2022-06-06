using System.Drawing;
using System;

namespace CompAndDel.Filters
{
    /// <summary>
    /// Un filtro que recibe una imagen y la guarda.
    /// </remarks>
    public class Guardar : IFilter
    {
        static int num = 1;
        /// <summary>
        /// Un filtro que retorna la imagen recibida sin modificarla, pero la guarda.
        /// </summary>
        /// <param name="image">La imagen a guardar.</param>
        /// <returns>La imagen recibida.</returns>
        public IPicture Filter(IPicture image)
        {
            PictureProvider provider = new PictureProvider();
            provider.SavePicture(image, @$"paso{num}.jpg");
            num ++;
            return image;
        }
    }
}