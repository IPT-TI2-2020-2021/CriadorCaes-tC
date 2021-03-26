using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CriadorCaes.Models {

   /// <summary>
   /// dados dos Criadores dos cães
   /// </summary>
   public class Criadores {

      /// <summary>
      /// Nome do cão
      /// </summary>
      public string Nome { get; set; }

      /// <summary>
      /// sufixo associado ao cão criado pelo criador
      /// </summary>
      public string NomeComercial { get; set; }

      /// <summary>
      /// Morada
      /// </summary>
      public string Morada { get; set; }

      /// <summary>
      /// código postal
      /// </summary>
      public string CodPostal { get; set; }

      /// <summary>
      /// email do criador
      /// </summary>
      public string Email { get; set; }

      /// <summary>
      /// telemóvel do Criador
      /// </summary>
      public string Telemovel { get; set; }

   }
}
