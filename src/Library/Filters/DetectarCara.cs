using System;
using CognitiveCoreUCU;

namespace CompAndDel.Filters
{
    /// <summary>
    /// Un filtro que recibe una imagen y detecta si tiene una cara.
    /// </remarks>
    public class DetectarCara : IFilterBoolean
    {
        bool FilterConditionResult = false;
        public bool filterConditionResult{ get{return this.FilterConditionResult;} set{this.FilterConditionResult = value;}}
        /// Un filtro que detecta si hay una cara en la imagen.
        /// </summary>
        /// <param name="image">La imagen a en cual se va a buscar la cara.</param>
        /// <returns>La imagen recibida.</returns>
        public IPicture Filter(IPicture image)
        {
            CognitiveFace cog = new CognitiveFace(false);
            PictureProvider provider = new PictureProvider();
            provider.SavePicture(image, @"cog.jpg");
            cog.Recognize(@"cog.jpg");
            if (cog.FaceFound){
                filterConditionResult = true;
            }
            return image;
        }

    }
}