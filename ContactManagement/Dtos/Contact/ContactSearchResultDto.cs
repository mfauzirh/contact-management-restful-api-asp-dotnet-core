namespace ContactManagement.Dtos;

public class ContactSearchResultDto
{
    public List<ContactResponseDto> Contacts { get; set; } = new List<ContactResponseDto>();
    public int Page { get; set; }
    public int TotalItems { get; set; }
    public int TotalPages { get; set; }
}