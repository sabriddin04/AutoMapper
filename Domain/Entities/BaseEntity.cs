using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class BaseEntity
{
    [Key]
    public int Id { get; set; }
    public DateTime CreateAt { get; set; }
    public DateTime UpdateAt { get; set; }
}