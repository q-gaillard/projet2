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
