using System;
using CompAndDel.Pipes;
using CompAndDel.Filters;

namespace CompAndDel
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            /// Parte 1.


            PictureProvider provider = new PictureProvider();
            IPicture picture = provider.GetPicture(@"C:\Users\fede2\OneDrive\Escritorio\Proyectos\PII_Pipes_Filters_Start\src\Program\LaveOlave.jpg");

            IFilter filterBlurConvolution = new FilterBlurConvolution();
            IFilter filterGreyscale = new FilterGreyscale();
            IFilter filterNegative = new FilterNegative();
            PipeNull pipeNull = new PipeNull();
            PipeSerial pipeSerialNegative = new PipeSerial(filterNegative, pipeNull);
            PipeSerial pipeSerialGreyScale = new PipeSerial(filterGreyscale, pipeSerialNegative);

            IPicture pmodificada = pipeSerialGreyScale.Send(picture);

            provider.SavePicture(pmodificada, @"ImagenEditada.jpg");
            */


            PictureProvider provider = new PictureProvider();
            IPicture picture = provider.GetPicture(@"C:\Users\fede2\OneDrive\Escritorio\Proyectos\PII_Pipes_Filters_Start\src\Program\beer.jpg");

            IFilter filterBlurConvolution = new FilterBlurConvolution();
            IFilter filterGreyscale = new FilterGreyscale();
            IFilter filterNegative = new FilterNegative();
            IFilterBoolean faceFinder = new DetectarCara();
            IFilter guardar = new Guardar();
            IFilter publicar = new PublicarTwitter();
            PipeNull pipeNull = new PipeNull();


            PipeSerial pipeTwitterFace = new PipeSerial(publicar, pipeNull);
            PipeSerial stepTwoFace = new PipeSerial(guardar, pipeTwitterFace);
            PipeSerial pipeSerialNegativeFace = new PipeSerial(filterNegative, stepTwoFace);
            PipeSerial stepOneFace = new PipeSerial(guardar, pipeSerialNegativeFace);
            PipeSerial pipeSerialGreyScaleFace = new PipeSerial(filterGreyscale, stepOneFace);

            PipeSerial pipeTwitterNoFace = new PipeSerial(publicar, pipeNull);
            PipeSerial stepOneNoFace = new PipeSerial(guardar, pipeTwitterNoFace);
            PipeSerial pipeSerialGreyScaleNoFace = new PipeSerial(filterGreyscale, stepOneNoFace);

            PipeConditional checkFace = new PipeConditional(faceFinder, pipeSerialGreyScaleFace, pipeSerialGreyScaleNoFace);

            IPicture pmodificada = checkFace.Send(picture);

        }
    }
}
