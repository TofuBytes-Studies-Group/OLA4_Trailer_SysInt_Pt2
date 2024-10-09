using Microsoft.AspNetCore.Mvc;

namespace PaymentService.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class PriceController
{
    [HttpGet(Name = "GetInsurancePrice")]
    public int GetInsurancePrice(bool isInsured)
    {
        if (isInsured)
        {
            return 50;
        }
        return 0;
    }

    [HttpGet(Name = "GetOverduePrice")]
    public int GetOverduePrice(DateTime endDate)
    {
        if (DateTime.Now > endDate)
        {
            return 75;
        }
        return 0;
    }
}