﻿namespace EventCase.Common.Entities
{
    public interface IEntity<T>
    {
        public T Id { get; set; }
    }
}
