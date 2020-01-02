using System;

namespace UserService.Models
{
    public class Relationship
    {
        public Guid Id { get; set; }
        public Guid User1 { get; set; }
        public Guid User2 { get; set; }
        public string RelationshipType { get; set; }
    }
}