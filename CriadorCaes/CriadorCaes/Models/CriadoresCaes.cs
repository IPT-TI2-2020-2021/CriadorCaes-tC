using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CriadorCaes.Models {

   /// <summary>
   /// Relaciona os objetos da classe Criadores com os objetos da classe Caes
   /// </summary>
   public class CriadoresCaes {

      //************************************************************************
      // FK para o Criador
      //************************************************************************
      [ForeignKey(nameof(Criador))]
      public int CriadorFK { get; set; }
      public Criadores Criador { get; set; }
      //************************************************************************


      //************************************************************************
      // FK para o Cao
      //************************************************************************
      [ForeignKey(nameof(Cao))]
      public int CaoFK { get; set; }
      public Caes Cao { get; set; }
      //************************************************************************

   }
}
