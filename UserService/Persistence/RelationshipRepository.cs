using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using UserService.Models;

namespace UserService.Persistence
{
    public class RelationshipRepository : IRelationshipRepository
    {
        private readonly UserServiceDbContext _dbContext;
        private readonly ILogger<RelationshipRepository> _logger;

        public RelationshipRepository(UserServiceDbContext dbContext, ILogger<RelationshipRepository> logger)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Relationship>> GetRelationships(Guid userId)
        {
            var relationships = new List<Relationship>();

            try
            {
                relationships = await _dbContext.Relationships.Where(r => r.Requestor == userId || r.Requestee == userId).ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting all relationships of user {id}", userId);
            }

            return relationships;
        }

        public async Task AddRelationship(Relationship relationship)
        {
            if (await _dbContext.Users.CountAsync(u => u.Id == relationship.Requestor) == 0)
                throw new Exception($"Requestor with Id {relationship.Requestor} does not exist");

            if (await _dbContext.Users.CountAsync(u => u.Id == relationship.Requestee) == 0)
                throw new Exception($"Requestee with Id {relationship.Requestee} does not exist");

            if (await _dbContext.Relationships.CountAsync(r => r.Requestor == relationship.Requestor && r.Requestee == relationship.Requestee && r.RelationshipType == relationship.RelationshipType) > 0)
                throw new Exception($"Relationship with Requestor {relationship.Requestor} and Requestee {relationship.Requestee} and Relationship Type {relationship.RelationshipType} already exists");

            await _dbContext.Relationships.AddAsync(relationship);
        }

        public async Task<Relationship> DeleteRelationship(Guid id)
        {
            var relationship = await _dbContext.Relationships.SingleOrDefaultAsync(r => r.Id == id);
            if (relationship == null)
                throw new Exception($"Relationship with Id {relationship.Id} is not found");

            _dbContext.Relationships.Remove(relationship);

            return relationship;
        }

        public async Task UpdateRelationship(Relationship relationship)
        {
            if (await _dbContext.Relationships.CountAsync(r => r.Id == relationship.Id) == 0)
                throw new Exception($"Relationship with Id {relationship.Id} is not found");

            _dbContext.Entry(relationship).State = EntityState.Modified;
        }
    }
}