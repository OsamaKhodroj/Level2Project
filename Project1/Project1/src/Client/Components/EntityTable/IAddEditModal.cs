﻿namespace Project1.Client.Components.EntityTable;

public interface IAddEditModal<TRequest>
{
    TRequest RequestModel { get; }
    bool IsCreate { get; }
    void ForceRender();
    bool Validate(object request);
}