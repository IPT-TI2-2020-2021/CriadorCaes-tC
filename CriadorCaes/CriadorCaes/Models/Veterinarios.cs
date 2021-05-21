using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CriadorCaes.Models {

   /// <summary>
   /// recolhe os dados dos Veterinários que interagem com os Cães
   /// </summary>
   public class Veterinarios {

      public Veterinarios() {
         ListaDeCaesTratados = new HashSet<Caes>();
      }

      /// <summary>
      /// identificador do veterinário
      /// </summary>
      public int Id { get; set; }

      /// <summary>
      /// Nome do veterinário
      /// </summary>
      public string Nome { get; set; }

      /// <summary>
      /// preço cobrado pelo veterinário numa consulta
      /// </summary>
      public decimal Honorario { get; set; }




      //*****************************************************************************
      // relacionar o veterinários com os cães que ele tratou
      /// <summary>
      /// Lista os caes tratados pelo Veterinário
      /// </summary>
      public ICollection<Caes> ListaDeCaesTratados { get; set; }
      //*****************************************************************************

   }
}
