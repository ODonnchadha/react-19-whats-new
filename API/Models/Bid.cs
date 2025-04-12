namespace API.Models;
public class Bid
{
    public int Id { get; set; }
    public int HouseId { get; set; }
    public string? Bidder { get; set; }
    public int Amount { get; set; }
}
