namespace CleanMediator.Applicaiotn.Dtos; 

public record ResponseProductDto(int Id, string Name, decimal Price, List<string> Categories);