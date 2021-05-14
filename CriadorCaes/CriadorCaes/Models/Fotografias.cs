using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CriadorCaes.Models {

   /// <summary>
   /// Fotografias associadas a cada cão
   /// </summary>
   public class Fotografias {

      /// <summary>
      /// PK para as Fotografias
      /// </summary>
      [Key]
      public int Id { get; set; }

      /// <summary>
      /// nome do ficheiro que contém a fotografia
      /// </summary>
      public string Fotografia { get; set; }

      /// <summary>
      /// data em que a fotografia foi tirada
      /// </summary>
      [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
      public DateTime DataFoto { get; set; }

      /// <summary>
      /// local onde foi tirada a fotografia
      /// </summary>
      public string Local { get; set; }

      //**************************************************************
      // FK para o Cão
      //**************************************************************
      [ForeignKey(nameof(Cao))]
      public int CaoFK { get; set; } // FK para o Cao (SQL)
      public Caes Cao { get; set; }  // FK para o Cao (C#)

      //**************************************************************
   }
}
