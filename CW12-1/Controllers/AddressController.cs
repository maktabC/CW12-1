using CW12_1.Models;
using CW12_1.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CW12_1.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AddressController : ControllerBase
{
    Serilization serialize = new Serilization();
    DataAccsess dataAccess = new DataAccsess("C:\\Users\\Navid\\Documents\\My Files\\MaktabC#\\CW12-1\\new\\CW12-1_2\\address.txt");

    [HttpPost("SaveAddress")]
    public IActionResult SaveAddress([FromForm] string address)
    {
        var addressJson = serialize.SerilizeToJson(new Address { AddressName = address });
        dataAccess.SaveToFile(addressJson);
        return Ok();
    }

    [HttpGet("GetAddress")]
    public IActionResult GetAddress( [FromQuery]string id)
    {
        var addressArr = dataAccess.ReadFile();

        foreach (var address in addressArr)
        {
            var currentAdderss = serialize.DeserilizeJson(address);
            if (currentAdderss.AddressID == id)
            {
                return Ok(currentAdderss);
            }
        }
        
        return NotFound();
    }
}