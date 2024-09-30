namespace Shared.RequestFeatures;

public class CourseParameters : RequestParameters
{
    public decimal MaxPrice { get; set; } = 999999999999999.99m;
    public decimal MinPrice { get; set; }
    public bool ValidPriceRange => MaxPrice >= MinPrice;

    public string SearchTerm { get; set; }

}