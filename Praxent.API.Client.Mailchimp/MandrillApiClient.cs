using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Mandrill;
using Mandrill.Model;

namespace Praxent.API.Client.Mailchimp
{
    public class MandrillApiClient : IMandrillApiClient
    {
        private readonly IMandrillMessagesApi _mandrillMessagesApi;

        public MandrillApiClient(IMandrillMessagesApi mandrillMessagesApi)
        {
            _mandrillMessagesApi = mandrillMessagesApi;
        }

        public async Task<IList<MandrillSendMessageResponse>> SendAsync(MandrillMessage message, bool async = false, string ipPool = null, DateTime? sendAtUtc = null)
        {
            return await _mandrillMessagesApi.SendAsync(message, async, ipPool, sendAtUtc);
        }

        public async Task<IList<MandrillSendMessageResponse>> SendTemplateAsync(MandrillMessage message, string templateName, IList<MandrillTemplateContent> templateContent = null, bool async = false,
            string ipPool = null, DateTime? sendAtUtc = null)
        {
            return await _mandrillMessagesApi.SendTemplateAsync(message, templateName, templateContent, async, ipPool, sendAtUtc);
        }

        public async Task<IList<MandrillSendMessageResponse>> SendRawAsync(string rawMessage, string fromEmail = null, string fromName = null, IList<string> to = null,
            bool? async = null, string ipPool = null, DateTime? sendAtUtc = null, string returnPathDomain = null)
        {
            return await _mandrillMessagesApi.SendRawAsync(rawMessage, fromEmail, fromName, to, async, ipPool, sendAtUtc, returnPathDomain);
        }

        public async Task<IList<MandrillMessageInfo>> SearchAsync(string query, DateTime? dateFrom = null, DateTime? dateTo = null, IList<string> tags = null,
            IList<string> senders = null, IList<string> apiKeys = null, int? limit = null)
        {
            return await _mandrillMessagesApi.SearchAsync(query, dateFrom, dateTo, tags, senders, apiKeys, limit);
        }

        public async Task<IList<MandrillMessageTimeSeries>> SearchTimeSeriesAsync(string query, DateTime? dateFrom = null, DateTime? dateTo = null, IList<string> tags = null,
            IList<string> senders = null)
        {
            return await _mandrillMessagesApi.SearchTimeSeriesAsync(query, dateFrom, dateTo, tags, senders);
        }

        public async Task<MandrillMessageInfo> InfoAsync(string id)
        {
            return await _mandrillMessagesApi.InfoAsync(id);
        }

        public async Task<MandrillMessageContent> ContentAsync(string id)
        {
            return await _mandrillMessagesApi.ContentAsync(id);
        }

        public async Task<MandrillMessage> ParseAsync(string rawMessage)
        {
            return await _mandrillMessagesApi.ParseAsync(rawMessage);
        }

        public async Task<IList<MandrillMessageScheduleInfo>> ListScheduledAsync(string to = null)
        {
            return await _mandrillMessagesApi.ListScheduledAsync(to);
        }

        public async Task<MandrillMessageScheduleInfo> RescheduleAsync(string id, DateTime sendAtUtc)
        {
            return await _mandrillMessagesApi.RescheduleAsync(id, sendAtUtc);
        }

        public async Task<MandrillMessageScheduleInfo> CancelScheduledAsync(string id)
        {
            return await _mandrillMessagesApi.CancelScheduledAsync(id);
        }
    }
}