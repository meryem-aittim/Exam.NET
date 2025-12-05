
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Exam.NET
{
    public class Bibliotheque
    {
        private List<Document> documents = new List<Document>();

        public void AjouterDocument(Document d)
        {
            documents.Add(d);
        }

        public void SupprimerDocument(Guid id)
        {
            var doc = documents.FirstOrDefault(d => d.Id == id);
            if (doc == null)
                throw new DocumentNonTrouveException("Document non trouvé !");
            documents.Remove(doc);
        }

        public List<Document> Rechercher(string motCle)
        {
            var result = documents.Where(d =>
                d.Titre.Contains(motCle, StringComparison.OrdinalIgnoreCase)
                || d.Auteur.Contains(motCle, StringComparison.OrdinalIgnoreCase)
            ).ToList();

            if (!result.Any())
                throw new DocumentNonTrouveException("Aucun document trouvé.");

            return result;
        }

        public void AfficherTous()
        {
            if (!documents.Any())
            {
                Console.WriteLine("La bibliothèque est vide.");
                return;
            }

            foreach (var d in documents)
                d.AfficherDetails();
        }

        public void Sauvegarder(string chemin)
        {
            using (var fs = new FileStream(chemin, FileMode.Create))
            using (var sw = new StreamWriter(fs))
            {
                foreach (var d in documents)
                    sw.WriteLine(d.ToCsv());
            }
        }

        public void Charger(string chemin)
        {
            if (!File.Exists(chemin))
                throw new FileNotFoundException("Fichier introuvable.");

            documents.Clear();

            using (var fs = new FileStream(chemin, FileMode.Open))
            using (var sr = new StreamReader(fs))
            {
                string? line;
                int lineNumber = 0;

                while ((line = sr.ReadLine()) != null)
                {
                    lineNumber++;
                    var cols = line.Split(';');

                    if (cols.Length < 6)
                        throw new FormatFichierIncorrectException($"Format incorrect ligne {lineNumber}");

                    string type = cols[0];
                    Guid id = Guid.Parse(cols[1]);
                    string titre = cols[2];
                    string auteur = cols[3];
                    int annee = int.Parse(cols[4]);

                    switch (type.ToLower())
                    {
                        case "livre":
                            int pages = int.Parse(cols[5]);
                            documents.Add(new Livre(id, titre, auteur, annee, pages));
                            break;

                        case "magazine":
                            int numero = int.Parse(cols[5]);
                            documents.Add(new Magazine(id, titre, auteur, annee, numero));
                            break;

                        case "pdf":
                            double taille = double.Parse(cols[5]);
                            documents.Add(new DocumentPDF(id, titre, auteur, annee, taille));
                            break;

                        default:
                            throw new FormatFichierIncorrectException($"Type inconnu ligne {lineNumber}");
                    }
                }
            }
        }
    }
}