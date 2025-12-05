
using System;

namespace Exam.NET
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Bibliotheque biblio = new Bibliotheque();
            bool quitter = false;

            while (!quitter)
            {
                Console.WriteLine("\n=== MENU ===");
                Console.WriteLine("1. Ajouter un document");
                Console.WriteLine("2. Afficher tous les documents");
                Console.WriteLine("3. Rechercher");
                Console.WriteLine("4. Supprimer");
                Console.WriteLine("5. Sauvegarder");
                Console.WriteLine("6. Charger");
                Console.WriteLine("7. Quitter");
                Console.Write("Choix : ");

                string choix = Console.ReadLine();

                try
                {
                    switch (choix)
                    {
                        case "1":
                            Ajouter(biblio);
                            break;

                        case "2":
                            biblio.AfficherTous();
                            break;

                        case "3":
                            Rechercher(biblio);
                            break;

                        case "4":
                            Supprimer(biblio);
                            break;

                        case "5":
                            Sauvegarder(biblio);
                            break;

                        case "6":
                            Charger(biblio);
                            break;

                        case "7":
                            quitter = true;
                            break;

                        default:
                            Console.WriteLine("Choix invalide.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erreur : {ex.Message}");
                }
            }

            Console.WriteLine("Au revoir !");
        }

        static void Ajouter(Bibliotheque b)
        {
            Console.Write("Type (Livre, Magazine, PDF) : ");
            string type = Console.ReadLine();

            Console.Write("Titre : ");
            string titre = Console.ReadLine();

            Console.Write("Auteur : ");
            string auteur = Console.ReadLine();

            Console.Write("Année : ");
            int annee = int.Parse(Console.ReadLine());

            Guid id = Guid.NewGuid();

            switch (type.ToLower())
            {
                case "livre":
                    Console.Write("Nombre de pages : ");
                    int pages = int.Parse(Console.ReadLine());
                    b.AjouterDocument(new Livre(id, titre, auteur, annee, pages));
                    break;

                case "magazine":
                    Console.Write("Numéro : ");
                    int numero = int.Parse(Console.ReadLine());
                    b.AjouterDocument(new Magazine(id, titre, auteur, annee, numero));
                    break;

                case "pdf":
                    Console.Write("Taille en Mo : ");
                    double taille = double.Parse(Console.ReadLine());
                    b.AjouterDocument(new DocumentPDF(id, titre, auteur, annee, taille));
                    break;

                default:
                    Console.WriteLine("Type invalide.");
                    return;
            }

            Console.WriteLine("Document ajouté !");
        }

        static void Rechercher(Bibliotheque b)
        {
            Console.Write("Mot clé : ");
            string mot = Console.ReadLine();

            var results = b.Rechercher(mot);

            foreach (var doc in results)
                doc.AfficherDetails();
        }

        static void Supprimer(Bibliotheque b)
        {
            Console.Write("ID du document : ");
            Guid id = Guid.Parse(Console.ReadLine());
            b.SupprimerDocument(id);
            Console.WriteLine("Document supprimé !");
        }

        static void Sauvegarder(Bibliotheque b)
        {
            Console.Write("Nom du fichier à créer : ");
            string fichier = Console.ReadLine();

            b.Sauvegarder(fichier);

            Console.WriteLine("Sauvegarde OK !");
        }

        static void Charger(Bibliotheque b)
        {
            Console.Write("Nom du fichier à charger : ");
            string fichier = Console.ReadLine();

            b.Charger(fichier);

            Console.WriteLine("Chargement OK !");
        }
    }
}
