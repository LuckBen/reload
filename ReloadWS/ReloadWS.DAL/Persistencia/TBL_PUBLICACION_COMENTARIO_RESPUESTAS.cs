//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ReloadWS.DAL.Persistencia
{
    using System;
    using System.Collections.Generic;
    
    public partial class TBL_PUBLICACION_COMENTARIO_RESPUESTAS
    {
        public int PUBLICACION_COMENTARIO_RESPUESTASid { get; set; }
        public int PUBLICACION_COMENTARIO_RESPUESTA_COMENTARIOid { get; set; }
        public int PUBLICACION_COMENTARIO_RESPUESTA_USUARIOid { get; set; }
        public string PUBLICACION_COMENTARIO_RESPUESTA_CONTENIDO { get; set; }
        public System.DateTime PUBLICACION_COMENTARIO_RESPUESTA_FECALT { get; set; }
        public bool PUBLICACION_COMENTARIO_RESPUESTA_DEBAJA { get; set; }
    
        public virtual TBL_PUBLICACION_COMENTARIOS TBL_PUBLICACION_COMENTARIOS { get; set; }
        public virtual TBL_USUARIOS TBL_USUARIOS { get; set; }
    }
}
