using Effort.Models.Enums;
using Microsoft.VisualStudio.Services.Common;
using System;
using System.Collections.Generic;
using System.Text;
using azure = Microsoft.TeamFoundation.WorkItemTracking.WebApi.Models;

namespace Effort.Models.Dto.TimeExtension
{
    public class WorkItem
    {
        public WorkItem()
        {
        }
        
        public WorkItem(azure.WorkItem azureWI, int duration = 0)
        {
            Id = azureWI.Id ?? -1;
            azureWI.Fields.TryGetValue<string>("System.WorkItemType", out var tmpWiType);
            WiType = tmpWiType;
            azureWI.Fields.TryGetValue<string>("System.Title", out var tmpTitle);
            Title = tmpTitle;
            Duration = duration;

        }

        /// <summary>
        /// ID рабочего элемента
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Тип рабочего элемента
        /// </summary>
        public string WiType { get; set; }
        /// <summary>
        /// Заголовок рабочего элемента
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Врем в минутах
        /// </summary>
        public int Duration { get; set; }
    }
}
