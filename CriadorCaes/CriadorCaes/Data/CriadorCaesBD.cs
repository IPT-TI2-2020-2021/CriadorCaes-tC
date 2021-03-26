using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CriadorCaes.Models;

namespace CriadorCaes.Data {

   /// <summary>
   /// representa a DB dos criadores de caes
   /// </summary>
   public class CriadorCaesBD : DbContext {

      // e onde está a BD armazenada?


      //************************************************************************
      // especificar as tabelas na BD
      //************************************************************************
      public DbSet<Criadores> Criadores { get; set; }
      public DbSet<Caes> Caes { get; set; }
      public DbSet<Fotografias> Fotografias { get; set; }
      public DbSet<Racas> Racas { get; set; }
      public DbSet<CriadoresCaes> CriadoresCaes { get; set; }
      //************************************************************************

   }
}
