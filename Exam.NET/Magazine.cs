using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.NET
{
    public class Magazine : Document
    {
        public int Numero { get; set; }

        public Magazine(Guid id, string titre, string auteur, int annee, int numero)
            : base(id, titre, auteur, annee)
        {
            Numero = numero;
        }

        public override void AfficherDetails()
        {
            Console.WriteLine($"[Magazine] {Titre} — {Auteur} — {Annee} — Numéro : {Numero} — Id : {Id}");
        }

        public override string ToCsv()
        {
            return base.ToCsv() + $";{Numero}";
        }
    }
}
