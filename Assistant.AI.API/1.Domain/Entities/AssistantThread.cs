using System;
using System.Collections.Generic;

namespace Assistant.Domain.Entities;

public partial class AssistantThread
{
    public string ThreadsId { get; set; } = null!;

    public string AssistantId { get; set; } = null!;
}
