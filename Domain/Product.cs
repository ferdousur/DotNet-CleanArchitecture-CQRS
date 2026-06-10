namespace CleanMediator.Domain;

public class Product
{
    public int Id {get;set;}
    public string ProductName {get;set;}
    public decimal ProductPrice {get;set;}
    public bool IsActive {get;set;}
    public ICollection<Category> Categories {get;set;}
}