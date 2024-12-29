using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DP_BE_LicensePortal.Model.Entities;

[Table("SerialNumberRequestLog", Schema = "Activation")]
public partial class SerialNumberRequestLog
{
    [Key]
    public int ID { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime OrderdDate { get; set; }

    public int RequestedSN { get; set; }

    [StringLength(256)]
    public string UserID { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime UpdateDate { get; set; }

    [InverseProperty("SerialNumberRequestLog")]
    public virtual ICollection<SerialNumberDetail> SerialNumberDetails { get; set; } = new List<SerialNumberDetail>();
}
