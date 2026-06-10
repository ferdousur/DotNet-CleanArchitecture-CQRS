namespace CleanMediator.Applicaiotn.Dtos; 

public record ResponseCategoryDto(string Name, int? ParentCategoryId, List<CategoryDto>? SubCategories=null);