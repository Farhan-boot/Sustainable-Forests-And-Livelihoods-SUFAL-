using PTSL.GENERIC.Common.Model.BaseModels;

namespace PTSL.GENERIC.Common.Model.EntityViewModels.Beneficiary;

public class CipFileVM : BaseModel
{
    public long CipId { get; set; }
    public CipVM? Cip { get; set; }

    public string? FileName { get; set; }
    public string? FileNameUrl { get; set; }
    public FileType FileType { get; set; }
}

