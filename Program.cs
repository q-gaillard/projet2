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
    }
}
