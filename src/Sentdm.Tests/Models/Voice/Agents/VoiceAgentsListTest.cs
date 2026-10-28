using System;
using System.Collections.Generic;
using System.Text.Json;
using Sentdm.Core;
using Sentdm.Models.Voice.Agents;
using Sentdm.Models.Webhooks;

namespace Sentdm.Tests.Models.Voice.Agents;

public class VoiceAgentsListTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new VoiceAgentsList
        {
            Agents =
            [
                new()
                {
                    ID = "id",
                    Audio = new() { SampleRate = 0 },
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Fallback = new() { Kind = "kind", Value = "value" },
                    Greeting = "greeting",
                    Limits = new()
                    {
                        AllowedCountries = ["string"],
                        MaxCallSeconds = 0,
                        MaxConcurrentCalls = 0,
                    },
                    Name = "name",
                    SessionType = "session_type",
                    SigningSecret = "signing_secret",
                    Speech = new()
                    {
                        Language = "language",
                        Setting = "setting",
                        Voice = "voice",
                    },
                    Tools = ["string"],
                    Transcripts = new() { RetentionDays = 0, Store = true },
                    TransferTargets = [new() { Kind = "kind", Value = "value" }],
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    WebsocketUrl = "websocket_url",
                },
            ],
            Pagination = new()
            {
                Cursors = new() { After = "after", Before = "before" },
                HasMore = true,
                Page = 0,
                PageSize = 0,
                TotalCount = 0,
                TotalPages = 0,
            },
        };

        List<VoiceAgent> expectedAgents =
        [
            new()
            {
                ID = "id",
                Audio = new() { SampleRate = 0 },
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Fallback = new() { Kind = "kind", Value = "value" },
                Greeting = "greeting",
                Limits = new()
                {
                    AllowedCountries = ["string"],
                    MaxCallSeconds = 0,
                    MaxConcurrentCalls = 0,
                },
                Name = "name",
                SessionType = "session_type",
                SigningSecret = "signing_secret",
                Speech = new()
                {
                    Language = "language",
                    Setting = "setting",
                    Voice = "voice",
                },
                Tools = ["string"],
                Transcripts = new() { RetentionDays = 0, Store = true },
                TransferTargets = [new() { Kind = "kind", Value = "value" }],
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                WebsocketUrl = "websocket_url",
            },
        ];
        PaginationMeta expectedPagination = new()
        {
            Cursors = new() { After = "after", Before = "before" },
            HasMore = true,
            Page = 0,
            PageSize = 0,
            TotalCount = 0,
            TotalPages = 0,
        };

        Assert.NotNull(model.Agents);
        Assert.Equal(expectedAgents.Count, model.Agents.Count);
        for (int i = 0; i < expectedAgents.Count; i++)
        {
            Assert.Equal(expectedAgents[i], model.Agents[i]);
        }
        Assert.Equal(expectedPagination, model.Pagination);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new VoiceAgentsList
        {
            Agents =
            [
                new()
                {
                    ID = "id",
                    Audio = new() { SampleRate = 0 },
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Fallback = new() { Kind = "kind", Value = "value" },
                    Greeting = "greeting",
                    Limits = new()
                    {
                        AllowedCountries = ["string"],
                        MaxCallSeconds = 0,
                        MaxConcurrentCalls = 0,
                    },
                    Name = "name",
                    SessionType = "session_type",
                    SigningSecret = "signing_secret",
                    Speech = new()
                    {
                        Language = "language",
                        Setting = "setting",
                        Voice = "voice",
                    },
                    Tools = ["string"],
                    Transcripts = new() { RetentionDays = 0, Store = true },
                    TransferTargets = [new() { Kind = "kind", Value = "value" }],
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    WebsocketUrl = "websocket_url",
                },
            ],
            Pagination = new()
            {
                Cursors = new() { After = "after", Before = "before" },
                HasMore = true,
                Page = 0,
                PageSize = 0,
                TotalCount = 0,
                TotalPages = 0,
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<VoiceAgentsList>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new VoiceAgentsList
        {
            Agents =
            [
                new()
                {
                    ID = "id",
                    Audio = new() { SampleRate = 0 },
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Fallback = new() { Kind = "kind", Value = "value" },
                    Greeting = "greeting",
                    Limits = new()
                    {
                        AllowedCountries = ["string"],
                        MaxCallSeconds = 0,
                        MaxConcurrentCalls = 0,
                    },
                    Name = "name",
                    SessionType = "session_type",
                    SigningSecret = "signing_secret",
                    Speech = new()
                    {
                        Language = "language",
                        Setting = "setting",
                        Voice = "voice",
                    },
                    Tools = ["string"],
                    Transcripts = new() { RetentionDays = 0, Store = true },
                    TransferTargets = [new() { Kind = "kind", Value = "value" }],
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    WebsocketUrl = "websocket_url",
                },
            ],
            Pagination = new()
            {
                Cursors = new() { After = "after", Before = "before" },
                HasMore = true,
                Page = 0,
                PageSize = 0,
                TotalCount = 0,
                TotalPages = 0,
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<VoiceAgentsList>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<VoiceAgent> expectedAgents =
        [
            new()
            {
                ID = "id",
                Audio = new() { SampleRate = 0 },
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Fallback = new() { Kind = "kind", Value = "value" },
                Greeting = "greeting",
                Limits = new()
                {
                    AllowedCountries = ["string"],
                    MaxCallSeconds = 0,
                    MaxConcurrentCalls = 0,
                },
                Name = "name",
                SessionType = "session_type",
                SigningSecret = "signing_secret",
                Speech = new()
                {
                    Language = "language",
                    Setting = "setting",
                    Voice = "voice",
                },
                Tools = ["string"],
                Transcripts = new() { RetentionDays = 0, Store = true },
                TransferTargets = [new() { Kind = "kind", Value = "value" }],
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                WebsocketUrl = "websocket_url",
            },
        ];
        PaginationMeta expectedPagination = new()
        {
            Cursors = new() { After = "after", Before = "before" },
            HasMore = true,
            Page = 0,
            PageSize = 0,
            TotalCount = 0,
            TotalPages = 0,
        };

        Assert.NotNull(deserialized.Agents);
        Assert.Equal(expectedAgents.Count, deserialized.Agents.Count);
        for (int i = 0; i < expectedAgents.Count; i++)
        {
            Assert.Equal(expectedAgents[i], deserialized.Agents[i]);
        }
        Assert.Equal(expectedPagination, deserialized.Pagination);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new VoiceAgentsList
        {
            Agents =
            [
                new()
                {
                    ID = "id",
                    Audio = new() { SampleRate = 0 },
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Fallback = new() { Kind = "kind", Value = "value" },
                    Greeting = "greeting",
                    Limits = new()
                    {
                        AllowedCountries = ["string"],
                        MaxCallSeconds = 0,
                        MaxConcurrentCalls = 0,
                    },
                    Name = "name",
                    SessionType = "session_type",
                    SigningSecret = "signing_secret",
                    Speech = new()
                    {
                        Language = "language",
                        Setting = "setting",
                        Voice = "voice",
                    },
                    Tools = ["string"],
                    Transcripts = new() { RetentionDays = 0, Store = true },
                    TransferTargets = [new() { Kind = "kind", Value = "value" }],
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    WebsocketUrl = "websocket_url",
                },
            ],
            Pagination = new()
            {
                Cursors = new() { After = "after", Before = "before" },
                HasMore = true,
                Page = 0,
                PageSize = 0,
                TotalCount = 0,
                TotalPages = 0,
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new VoiceAgentsList { };

        Assert.Null(model.Agents);
        Assert.False(model.RawData.ContainsKey("agents"));
        Assert.Null(model.Pagination);
        Assert.False(model.RawData.ContainsKey("pagination"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new VoiceAgentsList { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new VoiceAgentsList
        {
            // Null should be interpreted as omitted for these properties
            Agents = null,
            Pagination = null,
        };

        Assert.Null(model.Agents);
        Assert.False(model.RawData.ContainsKey("agents"));
        Assert.Null(model.Pagination);
        Assert.False(model.RawData.ContainsKey("pagination"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new VoiceAgentsList
        {
            // Null should be interpreted as omitted for these properties
            Agents = null,
            Pagination = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new VoiceAgentsList
        {
            Agents =
            [
                new()
                {
                    ID = "id",
                    Audio = new() { SampleRate = 0 },
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Fallback = new() { Kind = "kind", Value = "value" },
                    Greeting = "greeting",
                    Limits = new()
                    {
                        AllowedCountries = ["string"],
                        MaxCallSeconds = 0,
                        MaxConcurrentCalls = 0,
                    },
                    Name = "name",
                    SessionType = "session_type",
                    SigningSecret = "signing_secret",
                    Speech = new()
                    {
                        Language = "language",
                        Setting = "setting",
                        Voice = "voice",
                    },
                    Tools = ["string"],
                    Transcripts = new() { RetentionDays = 0, Store = true },
                    TransferTargets = [new() { Kind = "kind", Value = "value" }],
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    WebsocketUrl = "websocket_url",
                },
            ],
            Pagination = new()
            {
                Cursors = new() { After = "after", Before = "before" },
                HasMore = true,
                Page = 0,
                PageSize = 0,
                TotalCount = 0,
                TotalPages = 0,
            },
        };

        VoiceAgentsList copied = new(model);

        Assert.Equal(model, copied);
    }
}
