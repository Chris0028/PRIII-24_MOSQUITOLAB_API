﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MosquitoLaboratorio.Entities;

/// <summary>
/// caseType es &quot;Confirmado&quot; o &quot;Sospechoso&quot;, method es &quot;Por Laboratorio&quot; o &quot;Por Nexo Epidemiológico&quot;
/// </summary>
[Table("case")]
public class Case
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("caseType")]
    [StringLength(10)]
    public string CaseType { get; set; }

    [Column("method")]
    [StringLength(30)]
    public string? Method { get; set; }

    [Column("diseaseId")]
    public int DiseaseId { get; set; }

    [Column("fileId")]
    public long FileId { get; set; }

    [ForeignKey("DiseaseId")]
    [InverseProperty("Cases")]
    [NotMapped]
    public Disease? Disease { get; set; }

    [ForeignKey("FileId")]
    [InverseProperty("Cases")]
    [NotMapped]
    public File? File { get; set; }
}
