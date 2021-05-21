using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

      /// <summary>
      /// variável auxiliar para permitir a recolha dos dados 
      /// do honorário do veterinário
      /// </summary>

      [NotMapped] // ignora este atributo nas migrações
                  // nunca surgirá na Base de Dados
      [Required(ErrorMessage = "Os {0} são de preenchimento obrigatório")]
      [Display(Name = "Honorários")]
      [RegularExpression("[0-9]+([.,][0-9]{1,2})?", ErrorMessage = "Deve escrever apenas números, com, no máximo, 2 casas decimais.")]
      [StringLength(10, ErrorMessage = "Não pode escrever mais do que {1} caracteres nos {0}")]
      public string HonorarioAux { get; set; }


      //*****************************************************************************
      // relacionar o veterinários com os cães que ele tratou
      /// <summary>
      /// Lista os caes tratados pelo Veterinário
      /// </summary>
      public ICollection<Caes> ListaDeCaesTratados { get; set; }
      //*****************************************************************************

   }
}
