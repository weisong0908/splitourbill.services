using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserService.Models;

namespace UserService.Persistence
{
    public interface IRelationshipRepository
    {
        Task AddRelationship(Relationship relationship);
        Task<Relationship> DeleteRelationship(Guid id);
        Task<IEnumerable<Relationship>> GetRelationships(Guid userId);
        Task UpdateRelationship(Relationship relationship);
    }
}