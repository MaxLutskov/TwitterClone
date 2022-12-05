using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TwitterClone.Business.Abstraction
{
    public abstract class BaseModel
    {
        [Required, Column(TypeName = "varchar(50)")]
        public Guid Id { get; set; }

        [Required, Column(TypeName = "smalldatetime")]
        public DateTime CreatedAt { get; set; }

        [Required, Column(TypeName = "smalldatetime")]
        public DateTime UpdatedAt { get; set; }
    }
}
