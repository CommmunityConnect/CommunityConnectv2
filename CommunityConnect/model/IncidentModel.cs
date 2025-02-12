using CommunityConnect.model;
using CommunityConnect.model.Enums;

public class IncidentModel : ObservableObject
{
    private string _id;
    private string _title;
    private string _description;
    private DateTime _dateReported;
    private IncidentType _type;
    private IncidentSeverity _severity;
    private Location _location;
    private string _reporterId;
    private bool _isAnonymous;
    private List<MediaItem> _mediaItems;
    private IncidentStatus _status;

    public string Id
    {
        get => _id;
        set => SetProperty(ref _id, value);
    }

    public string Title
    {
        get => _title;
        set => SetProperty(ref _title, value);
    }

    public string Description
    {
        get => _description;
        set => SetProperty(ref _description, value);
    }

    public DateTime DateReported
    {
        get => _dateReported;
        set => SetProperty(ref _dateReported, value);
    }

    public IncidentType Type
    {
        get => _type;
        set => SetProperty(ref _type, value);
    }

    public IncidentSeverity Severity
    {
        get => _severity;
        set => SetProperty(ref _severity, value);
    }

    public Location Location
    {
        get => _location;
        set => SetProperty(ref _location, value);
    }

    public string ReporterId
    {
        get => _reporterId;
        set => SetProperty(ref _reporterId, value);
    }

    public bool IsAnonymous
    {
        get => _isAnonymous;
        set => SetProperty(ref _isAnonymous, value);
    }

    public List<MediaItem> MediaItems
    {
        get => _mediaItems;
        set => SetProperty(ref _mediaItems, value);
    }

    public IncidentStatus Status
    {
        get => _status;
        set => SetProperty(ref _status, value);
    }
}