using ToolStore.Domain.Interfaces;
using ToolStore.Domain.Models;
using ToolStore.WebApi.Dtos.Tool;
using Microsoft.AspNetCore.Mvc;
using ToolStore.WebApi.Dtos.Book;
using AutoMapper;

namespace ToolStore.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class toolsController(IMapper mapper,
        IToolService toolService) : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var tools = await toolService.GetAll();
            return Ok(mapper.Map<IEnumerable<ToolResultDto>>(tools));
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var tool = await toolService.GetById(id);

            if (tool == null) return NotFound();

            return Ok(mapper.Map<ToolResultDto>(tool));
        }

        [HttpGet]
        [Route("get-tools-by-category/{categoryId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GettoolsByCategory(int categoryId)
        {
            var tools = await toolService.GetToolsByCategory(categoryId);
            if (!tools.Any()) return NotFound();

            return Ok(mapper.Map<IEnumerable<ToolResultDto>>(tools));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Add([FromBody] ToolAddDto toolDto)
        {
            if (!ModelState.IsValid) return BadRequest();

            var tool = mapper.Map<Tool>(toolDto);
            var toolResult = await toolService.Add(tool);

            if (toolResult == null) return BadRequest();

            return Ok(mapper.Map<ToolResultDto>(toolResult));
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update([FromBody] ToolEditDto toolDto)
        {
            if (!ModelState.IsValid) return BadRequest();

            var toolResult = await toolService.Update(mapper.Map<Tool>(toolDto));
            if (toolResult == null) return BadRequest();

            return Ok(toolDto);
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Remove(int id)
        {
            var tool = await toolService.GetById(id);
            if (tool == null) return NotFound();

            await toolService.Remove(tool);

            return Ok();
        }

        [HttpGet]
        [Route("search/{toolName}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<Tool>>> Search(string toolName)
        {
            var tools = mapper.Map<List<Tool>>(await toolService.Search(toolName));

            if (tools == null || tools.Count == 0) return NotFound("None tool was founded");

            return Ok(tools);
        }

        [HttpGet]
        [Route("search-tool-with-category/{searchedValue}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<Tool>>> SearchtoolWithCategory(string searchedValue)
        {
            var tools = mapper.Map<List<Tool>>(await toolService.SearchToolWithCategory(searchedValue));
            if (tools.Count == 0) return NotFound("None tool was founded");

            return Ok(mapper.Map<IEnumerable<ToolResultDto>>(tools));
        }
    }
}