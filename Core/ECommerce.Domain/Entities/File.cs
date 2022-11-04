using ECommerce.Domain.Entities.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Domain.Entities
{
    public class File : BaseEntity
    {
        //file entitiysi için updateddate kullanmayacağız bu yüzden onu ezerek not map attribitu ile maplenmesini engelliyoruz.
        [NotMapped]
        public override DateTime UpdatedDate { get => base.UpdatedDate; set => base.UpdatedDate = value; }
        public string FileName { get; set; }
        public string Path { get; set; }
        public string Storage { get; set; }
    }
}
