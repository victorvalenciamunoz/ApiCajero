namespace ApiCajero.Models;

public class Account
{
    public int Id { get; set; }
    
    public string AccountNumber { get; set; }
    
    public decimal Balance { get; set; }    

    public int BankId { get; set; }

    public int PersonId { get; set; }
}
