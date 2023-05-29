using System;

namespace PLAutoMapperLib.PMapExport
{
    [Serializable]
    public enum ePMapExportCommands
    {
        Start,
        LoadSusceptor,
        LoadWafer,
        SetItem,
        SetFixedRange,
        SetAutoRange,
        SetAverageOffsetRange,
        Size,
        Save,
        Close,
        None,
        Error,
    }
}
