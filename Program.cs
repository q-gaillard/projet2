using System.Collections.Specialized;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Data.Common;
using System.Diagnostics.Contracts;
using System.Diagnostics.Tracing;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace projet_C_;

class Program
{
    static void Main(string[] args)
    {
        // Créer des comptes
        Console.WriteLine("afficher des comptes normaux :\n");
        Compte compteAlice = new Compte(1, "Alice", 100);
        Compte compteBob = new Compte(2, "Bob", 500);
        Compte compteCharlie = new Compte(3, "Charlie", 200);

        // action avec les comptes
        compteAlice.Crediter(300);
        compteBob.Debiter(100);
        Compte.Transferer(compteCharlie, compteAlice, 200); // normalement dans l'exercice c'est 150, mais il faut que la valeur sois plus grande ou égal à 200

        compteAlice.Display();
        compteBob.Display();
        compteCharlie.Display();

        // Crée des comptes spéciaux
        Console.WriteLine("\nafficher des comptes spéciaux\n");
        CompteEpargne compteDiane = new CompteEpargne(10, "Diane", 800, 0.04, "01/09/2024");
        ComptePayant compteEmma = new ComptePayant(11, "Emma", 600, 2, 0);

        //action avec les comptes spéciaux
        compteDiane.Crediter(100);
        compteDiane.Debiter(200);
        compteDiane.Debiter(800);
        compteDiane.Display();

        compteEmma.Crediter(50);
        compteEmma.Debiter(100);
        compteEmma.Debiter(50);
        Console.WriteLine($"nombre d'opération d'Emma : {compteEmma.GetNombreOperation()}");

        //création de comptes spéciaux après modification en héritage
        Console.WriteLine("\nafficher des comptes après héritage\n");
        Compte compteFarid = new Compte(20, "Farid", 1500);
        CompteEpargne compteGina = new CompteEpargne(21, "Gina", 1000, 0.3, "15/01/2024");
        ComptePayant compteHugo = new ComptePayant(22, "Hugo", 700, 3, 0);

        //action
        compteFarid.Display();
        compteGina.Display();
        compteHugo.Display();

        Console.WriteLine();
        compteFarid.Crediter(200);
        compteFarid.Debiter(400);
        compteFarid.Display();

        compteGina.Crediter(150);
        compteGina.Debiter(300);
        compteGina.Debiter(1000);
        compteGina.Display();

        compteHugo.Crediter(100);
        compteHugo.Debiter(200);
        compteHugo.Debiter(50);
        compteHugo.Display();

        Compte.Transferer(compteFarid, compteGina, 100);
        Compte.Transferer(compteGina, compteHugo, 50);
        Compte.Transferer(compteHugo, compteFarid, 2000);

        Console.WriteLine();
        compteFarid.Display();
        compteGina.Display();
        compteHugo.Display();
    }
}
