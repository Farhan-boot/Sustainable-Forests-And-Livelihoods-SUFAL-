namespace PTSL.GENERIC.Common.Model.EntityViewModels.Labour;

public class LabourWorkFilterVM
{
    public long? LabourDatabaseId { get; set; }

    public bool HasLabourDatabaseId => LabourDatabaseId is not null && LabourDatabaseId != default;
}

