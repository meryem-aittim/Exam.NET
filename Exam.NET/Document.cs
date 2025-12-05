using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.NET
{
    public abstract class Document
    {
        public Guid Id { get; set; }
        public string Titre { get; set; }
        public string Auteur { get; set; }
        public int Annee { get; set; }

        public Document(Guid id, string titre, string auteur, int annee)
        {
            Id = id;
            Titre = titre;
            Auteur = auteur;
            Annee = annee;
        }

        public abstract void AfficherDetails();

        public virtual string ToCsv()
        {
            return $"{GetType().Name};{Id};{Titre};{Auteur};{Annee}";
        }
    }
}
