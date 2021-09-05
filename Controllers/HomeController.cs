using EntitiesForRabbitMq;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using testRabbitMq.Models;

namespace testRabbitMq.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        /// <summary>
        ///     Конечная точка публикации.
        /// </summary>
        /// <remarks>
        ///     Конечная точка публикации позволяет базовому транспорту определять
        ///     фактическую конечную точку, в которую отправляется сообщение.
        /// </remarks>
        private readonly IPublishEndpoint _publishEndpoint;

        public HomeController(IPublishEndpoint publishEndpoint, 
            ILogger<HomeController> logger)
        {
            _publishEndpoint = publishEndpoint;
            _logger = logger;
        }

        /// <summary>
        ///     Открыть документ.
        /// </summary>
        /// <param name="fileId"> Id документа. </param>
        /// <returns> Объект со ссылкой на документ. </returns>
        [HttpGet("open/{fileId}")]
        public async Task OpenDocumentAsync(string fileId)
        {
            await _publishEndpoint.Publish(new ConsumerRequest { TestMessage = fileId });
        }
    }
}
