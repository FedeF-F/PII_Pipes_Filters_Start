using System;
using CompAndDel;

namespace CompAndDel.Pipes
{
    public class PipeConditional : IPipe
    {
        protected IFilterBoolean filtro;
        protected IPipe nextPipeTrue;
        protected IPipe nextPipeFalse;
        protected IPipe nextPipe;
        
        /// <summary>
        /// La cañería recibe una imagen, y la envia a distintas cañerias dependiendo del resultado de un filtro booleano.
        /// </summary>
        /// <param name="filtro">Filtro booleano usado.</param>
        /// <param name="nextPipe">Siguiente cañería</param>
        public PipeConditional(IFilterBoolean filtro, IPipe nextPipeTrue, IPipe nextPipeFalse)
        {
            this.nextPipeTrue = nextPipeTrue;
            this.nextPipeFalse = nextPipeFalse;
            this.filtro = filtro;
        }
        /// <summary>
        /// Devuelve el proximo IPipe
        /// </summary>
        public IPipe Next
        {
            get { 
                if ( filtro.filterConditionResult ){
                    this.nextPipe = this.nextPipeTrue;
                    
                }else{
                    this.nextPipe = this.nextPipeFalse;
                }
                return this.nextPipe; 
            }
        }
        /// <summary>
        /// Devuelve el IFilterBoolean que aplica este pipe
        /// </summary>
        public IFilterBoolean Filter
        {
            get { return this.filtro; }
        }
        /// <summary>
        /// Recibe una imagen, le aplica un filtro y la envía al siguiente Pipe
        /// </summary>
        /// <param name="picture">Imagen a la cual se debe aplicar el filtro</param>
        public IPicture Send(IPicture picture)
        {
            picture = this.filtro.Filter(picture);
            return this.Next.Send(picture);
        }
    }
}
