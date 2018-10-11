﻿using InstagramApiSharp.Classes.Models;
using InstagramApiSharp.Classes.ResponseWrappers;
using System;
using System.Linq;

namespace InstagramApiSharp.Converters.Users
{
    internal class InstaFriendshipShortStatusListConverter :
        IObjectConverter<InstaFriendshipShortStatusList, InstaFriendshipShortStatusListResponse>
    {
        public InstaFriendshipShortStatusListResponse SourceObject { get; set; }

        public InstaFriendshipShortStatusList Convert()
        {
            if (SourceObject == null) throw new ArgumentNullException($"Source object");
            var friendships = new InstaFriendshipShortStatusList();
            if (SourceObject != null && SourceObject.Any())
            {
                foreach (var item in SourceObject)
                {
                    try
                    {
                        var friend = new InstaFriendshipShortStatus
                        {
                            Following = item.Following,
                            IncomingRequest = item.IncomingRequest,
                            IsBestie = item.IsBestie,
                            IsPrivate = item.IsPrivate,
                            OutgoingRequest = item.OutgoingRequest,
                            Pk = item.Pk
                        };
                        friendships.Add(friend);
                    }
                    catch { }
                }
            }
            return friendships;
        }
    }
}