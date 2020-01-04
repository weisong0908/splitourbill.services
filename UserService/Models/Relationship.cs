using System;

namespace UserService.Models
{
    public class Relationship
    {
        public Guid Id { get; set; }
        public Guid Requestor { get; set; }
        public Guid Requestee { get; set; }
        public string RelationshipType { get; set; }
        public string Status { get; set; }
    }
}