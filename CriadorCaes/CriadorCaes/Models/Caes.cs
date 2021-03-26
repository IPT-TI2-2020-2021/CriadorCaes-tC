using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CriadorCaes.Models {

   /// <summary>
   /// dados dos Cães
   /// </summary>
   public class Caes {

      /// <summary>
      /// nome do cão
      /// </summary>
      public string Nome { get; set; }

      /// <summary>
      /// sexo do cão
      /// </summary>
      public string Sexo { get; set; }

      /// <summary>
      /// data de nascimento
      /// </summary>
      public DateTime DataNasc { get; set; }

      /// <summary>
      /// data de compra
      /// </summary>
      public DateTime DataCompra { get; set; }

      /// <summary>
      /// referência ao código LOP do cão - 
      /// LOP - Livro de Origens Português 
      /// </summary>
      public string LOP { get; set; }

   }
}
