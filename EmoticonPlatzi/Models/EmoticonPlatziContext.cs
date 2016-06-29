using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EmoticonPlatzi.Models
{
    public class EmoticonPlatziContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    

            /// <summary>
            /// Crea y elimina la base de datos cada vez que se cambia el modelo.
            /// </summary>
        public EmoticonPlatziContext() : base("name=EmoticonPlatziContext")
        {
            Database.SetInitializer<EmoticonPlatziContext>( new DropCreateDatabaseIfModelChanges<EmoticonPlatziContext>());
        }

        public DbSet<EmoPicture> EmoPictures { get; set; }
        public DbSet<EmoFace> EmoFaces { get; set; }
        public DbSet<EmoEmotion> EmoEmotions { get; set; }

        public System.Data.Entity.DbSet<EmoticonPlatzi.Models.Home> Homes { get; set; }
    }
}
