using AzureDevOpsServices.interfaces;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.TeamFoundation.SourceControl.WebApi;
using Microsoft.TeamFoundation.WorkItemTracking.WebApi;
using Microsoft.TeamFoundation.WorkItemTracking.WebApi.Models;
using Microsoft.VisualStudio.Services.Common;
using Microsoft.VisualStudio.Services.Identity;
using Microsoft.VisualStudio.Services.Identity.Client;
using Microsoft.VisualStudio.Services.Users.Client;
using Microsoft.VisualStudio.Services.WebApi;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using efort = Effort.Models.Dto.TimeExtension;

namespace AzureDevOpsServices
{
    public class AzureDevOpsService : IAzureDevOpsService
    {
        private readonly VssConnection _connection;
        private readonly ILogger<AzureDevOpsService> _logger;
        private readonly DevOpsServerConfiguration _config;

        public AzureDevOpsService(IOptions<DevOpsServerConfiguration> config, ILogger<AzureDevOpsService> logger)
        {
            _logger = logger;
            _config = config?.Value;

            if (_config == null)
                throw new ArgumentNullException("Config is null");
            if (string.IsNullOrWhiteSpace(_config.URL))
                throw new ArgumentNullException("DevOpsServerConfiguration.URL is null");
            if (string.IsNullOrWhiteSpace(_config.Collection))
                throw new ArgumentNullException("DevOpsServerConfiguration.Collection is null");
            if (string.IsNullOrWhiteSpace(_config.AccessToken))
                throw new ArgumentNullException("DevOpsServerConfiguration.AccessToken is null");

            VssCredentials creds = new VssBasicCredential(string.Empty, _config.AccessToken);
            _connection = new VssConnection(new Uri($"{_config.URL}/{_config.Collection}"), creds);
            _logger.LogInformation($"[{nameof(AzureDevOpsService)}] CREATED.");

        }
        public async Task<List<WorkItem>> GetChildWorkItems(string projectId, int selfId, bool isRecursive = false)
        {
            try
            {
                _logger.LogInformation($"[{nameof(GetChildWorkItems)}] BEGIN {{selfId:{selfId}}}");

                if (isRecursive) throw new NotImplementedException("Рекурсивный вызов не реализован");

                GitHttpClient gitClient = _connection.GetClient<GitHttpClient>();
                WorkItemTrackingHttpClient wiClient = _connection.GetClient<WorkItemTrackingHttpClient>();

                var childIds = await GetChildRelations(projectId, selfId);

                return await wiClient.GetWorkItemsAsync(
                    projectId, 
                    childIds, 
                    new List<String> { "id", "System.Title", "System.WorkItemType"}, 
                    null, 
                    null, 
                    null);
            }
            catch (Exception e)
            {
                _logger.LogError($" {nameof(GetChildWorkItems)} FAILED: {e}");
                return null;
            }
            finally
            {
                _logger.LogInformation($"[{nameof(GetChildWorkItems)}] COMPLETED");
            }
        }

        public async Task<IdentitiesCollection> GetUser(string UniqueName)
        {
            using (IdentityHttpClient Client = _connection.GetClient<IdentityHttpClient>())
            {

                //IdentityImageHttpClient 
                //IdentityRef   ivan.varnavskiy@shtormtech.ru  spartanec_kop@mail.ru
                //var user = await Client.ReadIdentitiesAsync(IdentitySearchFilter.TeamGroupName, "ShtormDemoProject(Agile) Team", QueryMembership.ExpandedDown); //GetUserIdentityIdsByDomainIdAsync()
                return await Client.ReadIdentitiesAsync(IdentitySearchFilter.General, UniqueName, QueryMembership.ExpandedDown); //GetUserIdentityIdsByDomainIdAsync()
            }
        }

        public async Task<IdentitiesCollection> GetIdentitiesByIds(List<Guid> ids)
        {
            using (IdentityHttpClient Client = _connection.GetClient<IdentityHttpClient>())
            {
                return await Client.ReadIdentitiesAsync(ids);
            }
        }

        public async Task<List<efort.User>> GetUserByIds(List<Guid> ids)
        {
            using (IdentityHttpClient Client = _connection.GetClient<IdentityHttpClient>())
            {
                List<efort.User> res = new List<efort.User>();
                var identities = await Client.ReadIdentitiesAsync(ids);
                identities.ForEach(x => res.Add(new efort.User($"{_config.URL}/{_config.Collection}") { Id = x.Id, DisplayName = x.DisplayName }));
                return res;
            }
        }

        private async Task<List<int>> GetChildRelations(string projectId, int selfId) 
        {
            string query = $"Select [System.Id] FROM workitemLinks WHERE ([Source].[System.Id] = {selfId}) AND ([System.Links.LinkType] = 'Child') MODE (MustContain)";
            List<int> ids = new List<int>();
            try
            {
                _logger.LogInformation($"[{nameof(GetChildWorkItems)}] BEGIN {{selfId:{selfId}}}");
                
                WorkItemTrackingHttpClient wiClient = _connection.GetClient<WorkItemTrackingHttpClient>();
                var childsLnk = await wiClient.QueryByWiqlAsync(new Wiql() {Query = query}, projectId);

                childsLnk.WorkItemRelations.ForEach(x => ids.Add(x.Target.Id));
            }
            catch (Exception e)
            {
                _logger.LogError($"{nameof(GetChildWorkItems)}  FAILED: {e}");
            }
            finally
            {                
                _logger.LogInformation($"[{nameof(GetChildWorkItems)}] COMPLETED");
            }
            return ids;
        }
    }
}
