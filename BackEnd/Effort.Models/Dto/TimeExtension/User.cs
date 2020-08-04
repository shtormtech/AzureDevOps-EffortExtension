using System;
using System.Collections.Generic;

using Microsoft.VisualStudio.Services.Identity;

namespace Effort.Models.Dto.TimeExtension
{
    public class User
    {
        private readonly string _server;
        public User(string server)
        {
            _server = server;
        }
        public User(string server, Identity identity, List<Activities> activities)
        {
            _server = server;
            Id = identity.Id;
            DisplayName = identity.DisplayName;
            UserUniqueName = identity.Properties.GetValue<string>("Mail","");
            //UserUniqueName = azureWI.Fields


            Activities = activities;
        }
        public Guid Id { get; set; }
        public string UserUniqueName { get; set; }
        public string DisplayName { get; set; }
        public string Url 
        { 
            get => $"{_server.TrimEnd('/')}/_apis/Identities/{Id}"; 
        }
        public string ImageUrl 
        { 
            get => $"{_server.TrimEnd('/')}/_api/_common/identityImage?id={Id}";
        }
        public List<Activities> Activities { get; set; }
    }
}
