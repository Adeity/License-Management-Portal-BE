namespace DP_BE_LicensePortal.Model.Entities;

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("ActivationStatusLogs", Schema = "Activation")]
public class ActivationStatusLog
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ID { get; set; }

    [ForeignKey("SerialNumberDetails")]
    public int SerialNumberDetailID { get; set; }

    [Required]
    public string Status { get; set; } = string.Empty;

    [Required]
    public string Reason { get; set; } = string.Empty;

    [Required]
    public string UserID { get; set; } = string.Empty;

    [Required]
    public DateTime UpdateDate { get; set; }

    // Navigation Property (Optional)
    public virtual SerialNumberDetail? SerialNumberDetail { get; set; }
}