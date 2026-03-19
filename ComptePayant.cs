using System.ComponentModel.DataAnnotations;

class ComptePayant : Compte
{

    private double commission;
    private int nombreOperation;
    
    public void SetCommission(double commission)
    {
        this.commission = commission;
    }
    public void SetNombreCommission(int nombreOperation)
    {
        this.nombreOperation = nombreOperation;
    }

    public double GetCommission()
    {
        return this.commission;
    }
    public int GetNombreOperation()
    {
        return this.nombreOperation;
    }

    public ComptePayant(int numero, string nom, double solde, double commission, int nombreOperation) : base(numero, nom, solde)
    {
        this.numero = numero;
        this.nom = nom;
        this.solde = solde;
        this.commission = commission;
        this.nombreOperation = nombreOperation;
    }

    public ComptePayant()
    {
        this.numero = 0;
        this.nom = "Inconnu";
        this.solde = 0;
        this.commission = 0;
        this.nombreOperation = 0;
    }

    private void AddOperation()
    {
        this.nombreOperation = this.nombreOperation + 1;
    }

    public void Display()
    {
        Console.WriteLine("------ Informations du compte payant : ------");
        Console.WriteLine($"Numéro de compte : {numero}");
        Console.WriteLine($"Nom du titulaire : {nom}");
        Console.WriteLine($"Solde : {solde}");
        Console.WriteLine($"commission : {commission}");
        Console.WriteLine($"nombre d'opération : {nombreOperation}");
        Console.WriteLine("---------------------------------------------");
    }

    public void Crediter(double montant)
    {
        if (montant > 0)
        {           
             solde += montant;
             AddOperation();
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
                AddOperation();
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

    static public void Transferer(ComptePayant compteSource, ComptePayant compteDestinataire, double montant)
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
                    compteSource.AddOperation();
                    compteDestinataire.AddOperation();
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