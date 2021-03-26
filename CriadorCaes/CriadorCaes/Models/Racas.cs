using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CriadorCaes.Models {

   /// <summary>
   /// Identifica as Raças de um cão
   /// </summary>
   public class Racas {

      /// <summary>
      /// construtor da classe Racas
      /// </summary>
      public Racas() {
         // aceder à BD, e selecionar todos os cães da raça
         ListaDeCaes = new HashSet<Caes>();
      }

      /// <summary>
      /// nome da Raça
      /// </summary>
      public string Designacao { get; set; }

      //**************************************************************
      // criar a lista de Cães a que uma Raça está associada
      //**************************************************************
      public ICollection<Caes> ListaDeCaes { get; set; }
      
      //**************************************************************


   }
}
