using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CriadorCaes.Models {

   /// <summary>
   /// Relaciona os objetos da classe Criadores com os objetos da classe Caes
   /// </summary>
   public class CriadoresCaes {

      [Key]
      public int Id { get; set; }

      /// <summary>
      /// data de compra
      /// </summary>
      public DateTime DataCompra { get; set; }


      //************************************************************************
      // FK para o Criador
      //************************************************************************
      //     [Key, Column(Order =1)]  // PK com dois atributos
      [ForeignKey(nameof(Criador))]
      public int CriadorFK { get; set; }
      public Criadores Criador { get; set; }
      //************************************************************************


      //************************************************************************
      // FK para o Cao
      //************************************************************************
      //     [Key,Column(Order =2)]  // PK com dois atributos
      [ForeignKey(nameof(Cao))]
      public int CaoFK { get; set; }
      public Caes Cao { get; set; }
      //************************************************************************

   }
}
