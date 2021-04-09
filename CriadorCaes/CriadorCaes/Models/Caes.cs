using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CriadorCaes.Models {

   /// <summary>
   /// dados dos Cães
   /// </summary>
   public class Caes {

      // construtor
      public Caes() {
         // inicialização das 'listas'
         ListaDeFotografias = new HashSet<Fotografias>();
         ListaDeCriadores = new HashSet<CriadoresCaes>();
      }

      /// <summary>
      /// PK para identificar um cão
      /// </summary>
      [Key]
      public int Id { get; set; }

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



      //************************************************************
      // FK para a Raça
      //************************************************************
      [ForeignKey(nameof(Raca))]  // [ForeignKey("Raca")]
      public int RacaFK { get; set; }  // FK para Raca no SGBD (SQL)
      public Racas Raca { get; set; }  // FK para Raca no C#

      /* em SQL, a criação desta tabela seria...
       * Create Table Caes(
       *    ??????? Primary Key,
       *    nome Varchar(30) not null,
       *    sexo char(1),
       *    ....
       *    LOP Varchar(20),
       *    racaFK int not null,
       *    Foreign Key (racaFK) References Racas(Id)
       * )
       *
       */

      //************************************************************
      // Lista de Fotografias do cão
      //************************************************************
      public ICollection<Fotografias> ListaDeFotografias { get; set; }
      //************************************************************


      //************************************************************************
      // Lista de Criadores associados ao cão
      //************************************************************************
      public ICollection<CriadoresCaes > ListaDeCriadores { get; set; }
      //************************************************************************
   }
}
