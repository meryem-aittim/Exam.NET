using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.NET
{
    public class DocumentPDF : Document
    {
        public double TailleEnMo { get; set; }

        public DocumentPDF(Guid id, string titre, string auteur, int annee, double tailleMo)
            : base(id, titre, auteur, annee)
        {
            TailleEnMo = tailleMo;
        }

        public override void AfficherDetails()
        {
            Console.WriteLine($"[PDF] {Titre} — {Auteur} — {Annee} — Taille : {TailleEnMo} Mo — Id : {Id}");
        }

        public override string ToCsv()
        {
            return base.ToCsv() + $";{TailleEnMo}";
        }
    }
}
