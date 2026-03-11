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

class Compte
{
    private int numero;
    public int Numero
    {
        get { return numero; }
        set { numero = value; }
    }

    private string nom;
    public string Nom
    {
        get { return nom; }
        set { nom = value; }
    }

    private double solde;
    public double Solde
    {
        get { return solde; }
        set { solde = value; }
    }

    public Compte(int numero, string nom, double solde)
    {
        this.numero = numero;
        this.nom = nom;
        this.solde = solde;
    }

    public Compte(int numero, string nom)
    {
        this.numero = numero;
        this.nom = nom;
        this.solde = 0;
    }

    public Compte(int numéro)
    {
        this.numero = numero;
        this.nom = "Inconnu";
        this.solde = 0;
    }

    public void Display()
    {
        Console.WriteLine("------ Informations du compte : ------");
        Console.WriteLine($"Numéro de compte : {numero}");
        Console.WriteLine($"Nom du titulaire : {nom}");
        Console.WriteLine($"Solde : {solde}");
        Console.WriteLine("---------------------------------------");
    }

    public void Crediter(double montant)
    {
        if (montant > 0)
        {           
             solde += montant;
        }
        else
        {
            Console.WriteLine("|!| Le montant doit être positif. |!|");
        }
    }

    public void Debiter(double montant)
    {
        if (montant <= solde)
        {
            if (montant > 0)
            {
                solde -= montant;
            }
            else
            {
                Console.WriteLine("|!| Le montant doit être positif. |!|");
            }
        }
        else
        {
            Console.WriteLine("|!| Fonds insuffisants pour débiter le compte. |!|");
        }
    }

    static public void Transferer(Compte compteSource, Compte compteDestinataire, double montant)
    {
        if (montant <= compteSource.solde)
        {
            if (montant > 199)
            {
                if (compteSource.numero == compteDestinataire.numero)
                {
                    Console.WriteLine("|!| Impossible de transférer vers le même compte. |!|");
                    
                }
                else
                {
                    compteSource.solde -= montant;
                    compteDestinataire.solde += montant;
                }
            }
            else
            {
                if (montant <= 0)
                {
                    Console.WriteLine("|!| Le montant doit être positif. |!|");
                }
                else
                {
                    Console.WriteLine("|!| Le montant dois être égal ou plus grand que 200. |!|");
                }
            }
        }
        else
        {
            Console.WriteLine("|!| Fonds insuffisants pour transférer. |!|");
        }
    }
}
class Program
{
    static void Main(string[] args)
    {
        // Créer des comptes
        Compte compte1 = new Compte(1, "Alex", 0);
        Compte compte2 = new Compte(2, "Tim", 10000);
        Compte compte3 = new Compte(3, "Quentin", 122);

        // Afficher les informations des comptes
        compte1.Display();
        compte2.Display();
        compte3.Display();
        Console.WriteLine();

        // Référence et copie
        Compte compte4 = compte1;

        compte4.Crediter(500);
        Console.WriteLine("première affichage du compte 1 et 4:");
        compte1.Display();
        compte4.Display();

        compte4.Debiter(100);
        Console.WriteLine("deuxième affichage du compte 1 et 4:");
        compte1.Display();
        compte4.Display();
        Console.WriteLine();

        // ------ réponse à le question : ------
        // lors de la création du compte 4, nous avons crée une référence  qui mène vers le compte 1 et non une copie, donc, d'es que je modifie le compte 4, je modifie aussi le compte 1.
        // -------------------------------------

        // Transférer des fonds
        Console.WriteLine("avant le transfert de 200 du compte 2 vers le compte 1:");
        compte1.Display();
        compte2.Display();
        Compte.Transferer(compte2, compte1, 200);
        Console.WriteLine("après le transfert de 200 du compte 2 vers le compte 1:");
        compte1.Display();
        compte2.Display();
    }
}
