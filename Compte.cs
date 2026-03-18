using System.ComponentModel.DataAnnotations;

class Compte
{
    private int numero;
    private string nom;
    private double solde;
    
    public void SetNumero(int numero)
    {
        this.numero = numero;
    }
    public void SetNom(string nom)
    {
        this.nom = nom;
    }
    public void SetSolde(double solde)
    {
        this.solde = solde;
    }

    public int GetNumero()
    {
        return this.numero;
    }
    public string GetNom()
    {
        return this.nom;
    }
    public double GetSolde()
    {
        return this.solde;
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