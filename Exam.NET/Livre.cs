using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.NET
{
    public class Livre : Document
    {
        public int NombrePages { get; set; }

        public Livre(Guid id, string titre, string auteur, int annee, int pages)
            : base(id, titre, auteur, annee)
        {
            NombrePages = pages;
        }

        public override void AfficherDetails()
        {
            Console.WriteLine($"[Livre] {Titre} — {Auteur} — {Annee} — Pages : {NombrePages} — Id : {Id}");
        }

        public override string ToCsv()
        {
            return base.ToCsv() + $";{NombrePages}";
        }
    }
}