using System;

namespace WarSISModelsDB.Models.Data
{
    /// <summary>
    /// Интерфейс для всех сущностей типа "Звания" (Генералы, Рядовые и т.д.)
    /// Так как человек может иметь любое звание, 
    /// то в его поле мы будем хранить IRanks, в который будем
    /// помещать различные сущности данных типа "Звания"
    /// </summary>
    public interface IRank
    {
        Int32 People { get; set; }
        String Date { get; set; }
    }
}
