using System.Net;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using TELE2Test.BLL.DTO_s;
using TELE2Test.BLL.Interfaces;
using TELE2Test.DAL.Tools;

namespace TELE2Test.Server.Controllers;

[ApiController]
[Route("/citizens")]
public class CitizenController : ControllerBase
{
    private readonly ICitizenService _service;

    public CitizenController(ICitizenService service)
    {
        _service = service;
    }

    [HttpGet("get-all")]
    public async Task<ActionResult<List<CitizenDTO>>> GetAllCitizensAsync(SexType? sex = null)
    {
        var response = sex is null 
            ? await _service.GetAllAsync()
            : await _service.GetAllBySex(sex);

        return Ok(response);
    }

    [HttpGet("get-by-id/{id}")]
    public async Task<ActionResult<CitizenDTO>> GetCitizenById(string id)
    {
        var response = await _service.GetCitizenAsync(id);
        return Ok(response);
    }

    [HttpPost("add-citizen")]
    public async Task<ActionResult> AddCitizen([FromQuery] CitizenDTO citizenDto)
    {
        await _service.CreateCitizenAsync(citizenDto);
        return Ok();
    }

    [HttpPost("update-citizen")]
    public async Task<ActionResult> UpdateCitizen([FromQuery] CitizenDTO citizenDto)
    {
        await _service.UpdateCitizenAsync(citizenDto);
        return Ok();
    }

    [HttpPost("add-many-from-url")]
    public async Task<ActionResult> AddCitizens(string url = "http://testlodtask20172.azurewebsites.net/task")
    {
        var json = new WebClient().DownloadString(url);
        await _service.AddManyCitizens(json);
        return Ok();
    }

    [HttpPost("update-citizen-from-url")]
    public async Task<ActionResult> UpdateCitizen(string url)
    {
        var json = new WebClient().DownloadString(url);
        var jsonCitizenDto = JsonConvert.DeserializeObject<JsonCitizenDto>(json);
        jsonCitizenDto.Id =  url.Split('/').LastOrDefault();
        await _service.UpdateCitizenAsync(jsonCitizenDto);
        return Ok();
    }
}