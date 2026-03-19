class CompteEpargne : Compte
{

    private double tauxInteret;
    private string dateOuverture;
    
    public void SetTauxInteret(double tauxInteret)
    {
        this.tauxInteret = tauxInteret;
    }
    public void SetDateOuverture(string dateOuverture)
    {
        this.dateOuverture = dateOuverture;
    }

    public double GetTauxInteret()
    {
        return this.tauxInteret;
    }
    public string GetDateOuverture()
    {
        return this.dateOuverture;
    }

    public CompteEpargne(int numero, string nom, double solde, double tauxInteret ,string dateOuverture) : base(numero, nom, solde)
    {
        this.numero = numero;
        this.nom = nom;
        this.solde = solde;
        this.tauxInteret = tauxInteret;
        this.dateOuverture = dateOuverture;
    }

    public CompteEpargne()
    {
        this.numero = 0;
        this.nom = "Inconnu";
        this.solde = 0;
        this.tauxInteret = 0;
        this.dateOuverture = "00/00/0000";
    }

    public void Display()
    {
        Console.WriteLine("------ Informations du compte épargne : ------");
        Console.WriteLine($"Numéro de compte : {numero}");
        Console.WriteLine($"Nom du titulaire : {nom}");
        Console.WriteLine($"Date d'ouverture : {dateOuverture}");
        Console.WriteLine($"Solde : {solde}");
        Console.WriteLine($"taux d'intérêt : {tauxInteret}");
        Console.WriteLine("----------------------------------------------");
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

    static public void Transferer(CompteEpargne compteSource, CompteEpargne compteDestinataire, double montant)
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