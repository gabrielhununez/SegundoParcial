namespace SegundoParcial.Data.Models;

public class Animal : BaseField
{
    public long AnimalId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int Age { get; set; }
}
