using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UserService.Models;
using UserService.Persistence;

namespace UserService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RelationshipsController : ControllerBase
    {
        private readonly IRelationshipRepository _relationshipRepository;
        private readonly IUnitOfWork _unitOfWork;

        public RelationshipsController(IRelationshipRepository relationshipRepository, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _relationshipRepository = relationshipRepository;
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetRelationships(Guid userId)
        {
            var relationships = await _relationshipRepository.GetRelationships(userId);

            return Ok(relationships);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRelationship(Guid id)
        {
            var relationship = await _relationshipRepository.GetRelationship(id);

            return Ok(relationship);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRelationship([FromBody]Relationship relationship)
        {
            await _relationshipRepository.AddRelationship(relationship);
            await _unitOfWork.CompleteAsync();

            return CreatedAtAction(nameof(GetRelationship), new { id = relationship.Id }, relationship);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRelationship(Guid id)
        {
            var deletedRelationship = await _relationshipRepository.DeleteRelationship(id);
            await _unitOfWork.CompleteAsync();

            return Ok(deletedRelationship);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRelationship(Guid id, [FromBody]Relationship relationship)
        {
            if (id != relationship.Id)
                return BadRequest();

            await _relationshipRepository.UpdateRelationship(relationship);
            await _unitOfWork.CompleteAsync();

            return Ok();
        }
    }
}