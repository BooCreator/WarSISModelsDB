using System;

namespace WarSISModelsDB.Models.Data
{
    /// <summary>
    /// Интерфейс для всех сущностей типа "Подразделения" (Роты, Взводы и т.д.)
    /// Так как человек может иметь любое звание, 
    /// то в его поле мы будем хранить IDivision, в который будем
    /// помещать различные сущности данных типа "Подразделения"
    /// </summary>
    public interface ISubdivision
    {
        Int32 ID { get; set; }
        String Title { get; set; }
        Int32 Commander { get; set; }
        Int32 Subdivision { get; set; }
        Int32 SubdivisionID { get; set; }
    }
}
