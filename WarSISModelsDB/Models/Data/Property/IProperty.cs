using System;

namespace WarSISModelsDB.Models.Data
{
    /// <summary>
    /// Интерфейс для всех сущностей типа "Имущество" (Автоматы, Автомобили и т.д.)
    /// Так как человек может иметь любое звание, 
    /// то в его поле мы будем хранить IProperty, в который будем
    /// помещать различные сущности данных типа "Имущество"
    /// </summary>
    public interface IProperty
    {
        Int32 ID { get; set; }
        String Title { get; set; }
        Int32 Inventary { get; set; }
    }
}
