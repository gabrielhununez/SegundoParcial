namespace SegundoParcial.Data.Models;

public class BaseField
{
    public bool IsDelete { get; set; }
    public DateTime CreatedOn { get; set; }
    public string CreatedBy { get; set; }
    public DateTime? UpdateOn { get; set; }
    public string? UpdateBy { get; set; }
}