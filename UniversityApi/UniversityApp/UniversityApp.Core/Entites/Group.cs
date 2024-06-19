using System.ComponentModel.DataAnnotations.Schema;

namespace UniversityApp.Core.Entites
{
    public class Group:AuditEntity
    {
        public string? No { get; set; }
        public byte Limit { get; set; }
        public List<Student> Students { get; set; } 
    }
}
