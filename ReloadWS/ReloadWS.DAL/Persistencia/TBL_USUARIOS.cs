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
    
    public partial class TBL_USUARIOS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBL_USUARIOS()
        {
            this.TBL_MENSAJES = new HashSet<TBL_MENSAJES>();
            this.TBL_MENSAJES1 = new HashSet<TBL_MENSAJES>();
            this.TBL_POST_COMENTARIO_RESPUESTAS = new HashSet<TBL_POST_COMENTARIO_RESPUESTAS>();
            this.TBL_POST_COMENTARIOS = new HashSet<TBL_POST_COMENTARIOS>();
            this.TBL_POSTS = new HashSet<TBL_POSTS>();
            this.TBL_POSTS_FAVORITOS = new HashSet<TBL_POSTS_FAVORITOS>();
            this.TBL_PUBLICACION_COMENTARIO_RESPUESTAS = new HashSet<TBL_PUBLICACION_COMENTARIO_RESPUESTAS>();
            this.TBL_PUBLICACION_COMENTARIOS = new HashSet<TBL_PUBLICACION_COMENTARIOS>();
            this.TBL_PUBLICACIONES = new HashSet<TBL_PUBLICACIONES>();
            this.TBL_USUARIOS_POSTS = new HashSet<TBL_USUARIOS_POSTS>();
        }
    
        public int USUARIO_ID { get; set; }
        public string USUARIO_CODIGO { get; set; }
        public string USUARIO_PASSWORD { get; set; }
        public string USUARIO_MAIL { get; set; }
        public int USUARIO_PUNTOS { get; set; }
        public int USUARIO_MEDALLAS { get; set; }
        public int USUARIO_PUBLICACIONES { get; set; }
        public int USUARIO_SEGUIDORES { get; set; }
        public int USUARIO_SIGUIENDO { get; set; }
        public int USUARIO_MENSAJES { get; set; }
        public bool USUARIO_BAN { get; set; }
        public string USUARIO_RAZON_BAN { get; set; }
        public bool USUARIO_DEBAJA { get; set; }
        public int USUARIO_RANGO { get; set; }
        public bool USUARIO_ACTIVO { get; set; }
        public string USUARIO_NOMBRE { get; set; }
        public string USUARIO_APELLIDO { get; set; }
        public Nullable<System.DateTime> USUARIO_FECHANAC { get; set; }
        public string USUARIO_HABITOS { get; set; }
        public string USUARIO_IDIOMAS { get; set; }
        public string USUARIO_IMAGEN { get; set; }
        public string USUARIO_SEXO { get; set; }
        public string USUARIO_DATOS_PROF { get; set; }
        public Nullable<int> USUARIO_PAIS_ID { get; set; }
        public System.DateTime USUARIO_FECALT { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_MENSAJES> TBL_MENSAJES { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_MENSAJES> TBL_MENSAJES1 { get; set; }
        public virtual TBL_PAISES TBL_PAISES { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_POST_COMENTARIO_RESPUESTAS> TBL_POST_COMENTARIO_RESPUESTAS { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_POST_COMENTARIOS> TBL_POST_COMENTARIOS { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_POSTS> TBL_POSTS { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_POSTS_FAVORITOS> TBL_POSTS_FAVORITOS { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_PUBLICACION_COMENTARIO_RESPUESTAS> TBL_PUBLICACION_COMENTARIO_RESPUESTAS { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_PUBLICACION_COMENTARIOS> TBL_PUBLICACION_COMENTARIOS { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_PUBLICACIONES> TBL_PUBLICACIONES { get; set; }
        public virtual TBL_RANGOS TBL_RANGOS { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_USUARIOS_POSTS> TBL_USUARIOS_POSTS { get; set; }
    }
}
