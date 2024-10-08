using Lagrange.Core.Common;
using Lagrange.Core.Internal.Event;
using Lagrange.Core.Internal.Event.System;
using Lagrange.Core.Internal.Packets.Service.Oidb;
using Lagrange.Core.Internal.Packets.Service.Oidb.Request;
using Lagrange.Core.Utility.Extension;

namespace Lagrange.Core.Internal.Service.System;

[EventSubscribe(typeof(FetchFriendsAndFriendGroupsRequestsEvent))]
[Service("OidbSvcTrpcTcp.0x5cf_11")]
internal class FetchFriendsAndFriendGroupsRequestsService : BaseService<FetchFriendsAndFriendGroupsRequestsEvent>
{
    protected override bool Build(FetchFriendsAndFriendGroupsRequestsEvent input, BotKeystore keystore, BotAppInfo appInfo,
        BotDeviceInfo device, out Span<byte> output, out List<Memory<byte>>? extraPackets)
    {
        var packet = new OidbSvcTrpcTcpBase<OidbSvcTrpcTcp0x5CF_11>(new OidbSvcTrpcTcp0x5CF_11
        {
            Field1 = 1,
            Field3 = 6,
            SelfUid = keystore.Uid ?? "",
            Field5 = 0,
            Field6 = 80,
            Field8 = 2,
            Field9 = 0,
            Field12 = 1,
            Field22 = 1
        });

        output = packet.Serialize();
        extraPackets = null;
        return true;
    }

    protected override bool Parse(Span<byte> input, BotKeystore keystore, BotAppInfo appInfo, BotDeviceInfo device,
        out FetchFriendsAndFriendGroupsRequestsEvent output, out List<ProtocolEvent>? extraEvents)
    {
        return base.Parse(input, keystore, appInfo, device, out output, out extraEvents);
    }
}