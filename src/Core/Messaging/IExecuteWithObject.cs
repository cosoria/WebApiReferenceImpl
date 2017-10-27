﻿namespace WebApiReferenceImpl.Core.Messaging
{

    public interface IExecuteWithObject
    {
        object Target { get; }

        void ExecuteWithObject(object parameter);
        void MarkForDeletion();
    }
}