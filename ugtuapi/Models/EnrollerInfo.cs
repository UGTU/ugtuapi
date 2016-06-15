using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ugtuapi.Models
{
    /// <summary>
    /// Содержит основные данные по заявлению (DTO)
    /// </summary>
    public class EnrollerInfo
    {
        /// <summary>
        /// Получает или устанавливает фамилию 
        /// </summary>
        public string FamilyName { get; set; }
        /// <summary>
        /// Получает или устанавливает имя
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// Получает или устанавливает отчество
        /// </summary>
        public string MiddleName { get; set; }
        /// <summary>
        /// Получает или устанавливает строку текущего статуса заявления
        /// </summary>
        public string CurrentStatus { get; set; }
        /// <summary>
        /// Получает или устанавливает сумму баллов по экзаменам
        /// </summary>
        public int ScoreSum { get; set; }
        /// <summary>
        /// Получает или устанавливает дополнительные баллы
        /// </summary>
        public int ExtraScore { get; set; }
        /// <summary>
        /// Получает или устанавливает наличие оригиналов документов абитуриента
        /// </summary>
        public bool HasOriginalDocuments { get; set; }
        /// <summary>
        /// Получает или устанавливает строку категории зачисления
        /// </summary>
        public string Category { get; set; }
        /// <summary>
        /// Получает или устанавливает признак того, что заявление в текущий момент действительно
        /// </summary>
        public bool IsAlive { get; set; }
     

    }

    /// <summary>
    /// Информация о списках абитуриентов
    /// </summary>
    public class EnrollmentInfo
    {
        /// <summary>
        /// Получает или устанавливает год поступления
        /// </summary>
        public int Year { get; set; }
        /// <summary>
        /// Получает или устанавливает наименование института
        /// </summary>
        public string InstituteName { get; set; }
        /// <summary>
        /// Получает или устанавливает название направления подготовки
        /// </summary>
        public string Direction { get; set; }
        /// <summary>
        /// Получает или устанавливает шифр направления подготовки
        /// </summary>
        public string DirectionCode { get; set; }
        /// <summary>
        /// Получает или устанавливает строку формы обучения
        /// </summary>
        public string EducationForm { get; set; }
        /// <summary>
        /// Получает или устанавливает отметку времени о валидности данных
        /// </summary>
        public DateTime Timestamp { get; set; }
        /// <summary>
        /// Получает или устанавливает коллекцию с записями по заявлениям
        /// </summary>
        public EnrollerInfo[] Enrollers { get; set; }        
    }
}