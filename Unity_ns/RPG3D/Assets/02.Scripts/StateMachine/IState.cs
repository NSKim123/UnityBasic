using System.Collections.Generic;
using System;

public interface IState
{
    int id { get; set; }
    int current { get; set; }
    bool canExecute { get; }
    List<KeyValuePair<Func<bool>, int>> transitions { get; set; }
    void Execute();
    void Stop();
    int Update();
    void MoveNext();
}
