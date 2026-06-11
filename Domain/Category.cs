namespace CleanMediator.Domain;

public class Category
{
    public int Id {get;set;}
    public string CategoryName {get;set;}
    //amar parent k
    public int? ParentCategoryId {get;set;}
    // amr Parent Category
    public Category? Parent  {get;set;}
    //amr kotogulo children ache
    public ICollection<Category> Children {get;set;} =[];
    public bool IsActive {get;set;}
    public ICollection<Product> Products {get;set;}
}