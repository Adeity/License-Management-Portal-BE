namespace LicenseManagementPortal.Model.Entities;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("ActivationDetails", Schema = "Activation")]
public class ActivationDetail
{
    [Key]
    public int ID { get; set; }

    [ForeignKey("SerialNumberDetails")]
    public int SerialNumberDetailsID { get; set; }

    [Required]
    public int ReferenceId { get; set; }

    [MaxLength(50)]
    public string? CustomerName { get; set; }

    [MaxLength(50)]
    public string? Organization { get; set; }

    [MaxLength(50)]
    public string? SystemName { get; set; }

    [Required]
    [MaxLength(256)]
    public string ProfileHash { get; set; } = string.Empty;

    [Required]
    public DateTime DateActivated { get; set; }

    [Required]
    public bool AllowNewMachine { get; set; }

    [Required]
    [MaxLength(256)]
    public string UserID { get; set; } = string.Empty;

    [Required]
    public DateTime UpdateDate { get; set; } = DateTime.UtcNow;

    // Navigation Property (Optional)
    public virtual SerialNumberDetail? SerialNumberDetails { get; set; }
}

