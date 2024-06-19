using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UniversityApi.Data;
using UniversityApp.Core.Entites;
using UniversityApp.Service.Dtos.GroupDtos;
using UniversityApp.Service.Interfaces;

namespace UniversityApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupsController : ControllerBase
    {
        private readonly IGroupService _groupService;

        public GroupsController(IGroupService groupService)
        {
            _groupService = groupService;
        }

        [HttpGet("")]
        public ActionResult<List<GroupGetDto>> GetAll()
        {
            return StatusCode(200, _groupService.GetAll());
        }

        [HttpGet("{id}")]

        public ActionResult<GroupGetDto> GetById(int id)
        {
            return StatusCode(200, _groupService.GetById(id));
        }

        [HttpPost("")]
        public ActionResult Create(GroupCreateDto createDto)
        {
            return StatusCode(201, new {Id=_groupService.Create(createDto)});
        }

        [HttpPut("{id}")]
        public ActionResult Update([FromRoute]int id, [FromBody]GroupUpdateDto updateDto)
        {
            _groupService.Update(id, updateDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _groupService.Delete(id);
            return NoContent();
        }
    }
}
