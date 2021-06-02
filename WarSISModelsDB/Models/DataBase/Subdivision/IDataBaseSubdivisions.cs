using System;

namespace WarSISModelsDB.Models.DataBase.Subdivision
{
    public interface IDataBaseSubdivisions
    {
        String IdName { get; }
        String TitleName { get; }
        String CommanderName { get; }
        String SubdivisionTableName { get;}
        String SubdivisionIDName { get; }
    }
}
